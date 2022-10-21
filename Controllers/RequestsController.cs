using GestorRRHH_BackEnd_Api.Data;
using GestorRRHH_BackEnd_Api.Models;
using GestorRRHH_BackEnd_Api.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class RequestsController : ControllerBase
    {
        DBRequest dbRequest = null;

        public RequestsController()
        {
            dbRequest = new DBRequest();
        }

        /// <summary>
        /// Request for vacation
        /// </summary>
        /// <param name="x">Entity for vacation</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Vacation")]
        [ProducesResponseType(typeof(BaseRetorno), StatusCodes.Status200OK)]
        public BaseRetorno Vacation([FromBody] VacationDTO x)
        {
            return dbRequest.addVacation(x);
        }

        /// <summary>
        /// Resquest for salary advance
        /// </summary>
        /// <param name="x">Payload request</param>
        /// <returns></returns>
        [HttpPost]
        [Route("SalaryAdvance")]
        [ProducesResponseType(typeof(BaseRetorno), StatusCodes.Status200OK)]
        public BaseRetorno SalaryAdvance([FromBody] SalaryAdvanceDTO x){
            return dbRequest.addSalaryAdvance(x);
        }

        /// <summary>
        /// Certificate request
        /// </summary>
        /// <param name="x">Payload</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Certificate")]
        [ProducesResponseType(typeof(BaseRetorno), StatusCodes.Status200OK)]
        public BaseRetorno CertificateRequest([FromBody] CertificateRequestDTO x) {
            return dbRequest.addCertificateRequest(x);
        }
    }
}
