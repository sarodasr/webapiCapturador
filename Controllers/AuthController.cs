using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GestorRRHH_BackEnd_Api.Models;
using GestorRRHH_BackEnd_Api.Utils;
using GestorRRHH_BackEnd_Api.Models.DTO;

namespace GestorRRHH_BackEnd_Api.Controllers
{
    /// <summary>
    /// Para autenticación
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(AuthenticateResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            GestorRRHHContextProcedures context = new GestorRRHHContextProcedures(new GestorRRHHContext());
            OutputParameter<string> nombre = new OutputParameter<string>();
            OutputParameter<long?> codigo = new OutputParameter<long?>();
            OutputParameter<string> mensaje = new OutputParameter<string>();

            nombre.SetValue("");
            codigo.SetValue((long?)1000);
            mensaje.SetValue("");
            using (GestorRRHHContext db = new GestorRRHHContext())
            {
                var procedures = new GestorRRHHContextProcedures(db);
                var result = await procedures.sp_loginAsync(user.UserName, user.UserPassword, nombre, codigo, mensaje);

                if (codigo.Value == 0)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Pz8/Pz8/I2R/Pz8PPwh6Hj8qPz8/Pz9ZPz4kP0M/VCwNCg=="));
                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:44369",
                        audience: "https://localhost:44369",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(25),
                        signingCredentials: signingCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

                    var companies = (from x in db.UserCompany.Where(x => x.userName == user.UserName)
                        select new CompanyAssoc { 
                            CompanyID = x.company.companyID,
                            CompanyName = x.company.companyName
                        }).ToList();

                    return Ok(new AuthenticateResponse
                    {
                        Codigo = 0,
                        Mensaje = mensaje.Value,
                        Nombre = nombre.Value,
                        Token = tokenString,
                        Companies = companies,
                        Elementos = (from x in result
                                     select new NavNodo
                                     {
                                         Codigo = x.codigo,
                                         Nombre = x.nombre,
                                         Ruta = x.ruta
                                     }).ToList()
                    }); ;
                }
            }

            BaseRetorno b = new BaseRetorno();
            b.Codigo = (int)codigo.Value;
            b.Mensaje = mensaje.Value;

            return Unauthorized(b);
        }

        /// <summary>
        /// Solicita reinicio de clave
        /// </summary>
        /// <param name="request">Datos para reinicio</param>
        /// <returns></returns>
        [HttpPost]
        [Route("ResetPassword")]
        public BaseRetorno SolicitaReinicioClave(ResetPwdDTO request) {
            BaseRetorno res = new BaseRetorno() { Codigo = 500, Mensaje = "No es posible realizar la operación solicitada" };

            try
            {
                using (GestorRRHHContext db = new GestorRRHHContext()) {
                    string RandomPassword = Utils.Utils.RandomPassword();
                    var Usuario = (from x in db.User.Where(x => x.email == request.email) select x).FirstOrDefault();
                    if (Usuario != null)
                    {
                        string bodyMail = @"Estimado <b>" + Usuario.firstName + " " + Usuario.lastName + "</b><br/><br/>" +
                            "Hemos recibido una solicitud para reinicio de clave de su usuario. En este correo encontrará PIN de un único uso que deberá ingresar en la pantalla de reinicio de clave.<br/><br/>" +
                            "La clave es:<h3>" + RandomPassword + "</h3>" + 
                            "Si usted no ha solicitado este reinicio de clave por favor hacer caso omiso de este correo o póngase en contacto con el administrador.<br/><br/>" + 
                            "Atentamente,<br/><br/><b>El equipo del capturador</>.";

                        var respuesta = Utils.Utils.Send_Email(Usuario.email, "Solicitud de reinicio de clave", bodyMail).Result;

                        if (respuesta == "OK")
                        {
                            UserPwdReset req = new UserPwdReset
                            {
                                userName = Usuario.userName,
                                emailSended = Usuario.email,
                                OTP = RandomPassword,
                                dateRequested = DateTime.Now,
                                validUntil = DateTime.Now.AddMinutes(10)
                            };
                            db.UserPwdReset.Add(req);
                            db.SaveChanges();

                            res.Codigo = 0;
                            res.Mensaje = Usuario.userName;
                        }
                    }
                    else {
                        res.Codigo = 50;
                        res.Mensaje = "El correo enviado no existe";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }

        /// <summary>
        /// Reset password for a user
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ActionResetPassword")]
        [ProducesResponseType(typeof(BaseRetorno), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType(typeof(BaseRetorno))]
        public async Task<IActionResult> CambioDeClave(ActionResetPasswordDTO payload) {
            BaseRetorno retorno = new BaseRetorno() { Codigo=500, Mensaje= "No es posible realizar la operación solicitada" };

            using (GestorRRHHContext db = new GestorRRHHContext()) {
                var procedures = db.GetProcedures();
                OutputParameter<long?> codigo = new OutputParameter<long?>();
                OutputParameter<string> mensaje = new OutputParameter<string>();

                codigo.SetValue((long?)1000);
                mensaje.SetValue("");

                var r = await procedures.sp_nueva_claveAsync(payload.userID, payload.OTP, payload.new_password_1, payload.new_password_2, codigo, mensaje);

                retorno.Codigo = (int)codigo.Value;
                retorno.Mensaje = mensaje.Value;
            }

            return Ok(retorno);
        }
    }
}
