using GestorRRHH_BackEnd_Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using GestorRRHH_BackEnd_Api.Models;
using GestorRRHH_BackEnd_Api.Models.DTO;

namespace GestorRRHH_BackEnd_Api.Controllers
{
    /// <summary>
    /// API para obtener administrar empleados
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        DbEmpleados dbEmpleado = null;

        /// <summary>
        /// 
        /// </summary>
        public EmployeeController()
        {
            dbEmpleado = new DbEmpleados();
        }

        /// <summary>
        /// Obtener el nombre de un empleado con base a la empresa y su código de empleado
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <param name="EmployeeCode"></param>
        /// <returns></returns>
        [HttpGet()]
        [Route("GetEmployeeNameByID")]
        [ProducesResponseType(typeof(BaseRetorno),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public BaseRetorno GetEmployeeName(long CompanyID, string EmployeeCode) {
            return dbEmpleado.BuscaEmpleadoPorCodigo(CompanyID, EmployeeCode);
        }

        /// <summary>
        /// Create new employee entity
        /// </summary>
        /// <param name="emp">Payload</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddEmployee")]
        [ProducesResponseType(typeof(BaseRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
        public BaseRetorno Post(EmployeeDTO emp) {
            return dbEmpleado.AgregarEmpleado(emp);
        }
    }
}
