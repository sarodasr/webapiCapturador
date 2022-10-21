using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApplication1.Data;
using GestorRRHH_BackEnd_Api.Models;
using GestorRRHH_BackEnd_Api.Models.DTO;
using WebApplication1.Models;

namespace GestorRRHH_BackEnd_Api.Data
{
    public class DbEmpleados
    {
        GestorRRHHContext _context;
        public DbEmpleados()
        {
            _context = new GestorRRHHContext();
        }

        /// <summary>
        /// Buscar un empleado por código
        /// </summary>
        /// <param name="CompanyID"></param>
        /// <param name="EmployeeCode"></param>
        /// <returns></returns>
        public BaseRetorno BuscaEmpleadoPorCodigo(long CompanyID, string EmployeeCode) {
            BaseRetorno r = new BaseRetorno() { Codigo = 1500, Mensaje = "No es posible realizar la búsqueda solicitada." };

            try
            {
                var empleado = _context.Employee.Where(x => x.companyID == CompanyID && x.employeeCode == EmployeeCode).FirstOrDefault();

                if (empleado != null)
                {
                    r.Codigo = 0;
                    r.Mensaje = string.Format("{0} {1}, {2}", empleado.employeeLastName, empleado.employeeLastName2, empleado.employeeName);
                }
                else {
                    r.Codigo = 2500;
                    r.Mensaje = "El empleado solicitado no existe";
                }
            }
            catch (Exception e)
            {
            }

            return r;
        }

        /// <summary>
        /// Agregar empleado
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public BaseRetorno AgregarEmpleado(EmployeeDTO employee) {
            BaseRetorno res = new BaseRetorno() { Codigo = 500, Mensaje = "No es posible realizar la operación solicitada" };

            try
            {
                var existe = _context.Employee.Any(x => x.companyID == employee.companyID && x.employeeCode == employee.employeeCode);

                if (!existe)
                {
                    Employee emp = new Employee {
                        companyID = employee.companyID,
                        employeeCode = employee.employeeCode,
                        employeeName = employee.employeeName,
                        employeeLastName = employee.employeeLastName,
                        employeeLastName2 = employee.employeeLastName2,
                        employeeDOB = DateTime.Parse(employee.employeeDOB),
                        employeeBT = employee.employeeBT,
                        employeeGender = employee.employeeGender,
                        employeeLanguage = employee.employeeLanguage,
                        employeeLocalLanguage = employee.employeeLocalLanguage,
                        employeeCollegeDegree = employee.employeeCollegeDegree,
                        employeeFN = employee.employeeFN,
                        employeeMN = employee.employeeMN,
                        employeeSN = employee.employeeSN,
                        employeeUG = employee.employeeUG,
                        employeeBACAcct = employee.employeeBACAcct,
                        employeeIDT = employee.employeeIDT,
                        employeeIDNo = employee.employeeIDNo,
                        employeeSSN = employee.employeeSSN,
                        employeeNIT = employee.employeeNIT,
                        employeePRO = employee.employeePRO,
                        employeeCT = employee.employeeCT,
                        employeeCY = employee.employeeCY,
                        employeeTW = employee.employeeTW,
                        employeeET = employee.employeeET,
                        employeeMS = employee.employeeMS,
                        employeeADDR = employee.employeeADDR,
                        employeeHS = employee.employeeHS,
                        employeeHT = employee.employeeHT,
                        employeeCP = employee.employeeCP,
                        employeeEM = employee.employeeEM,
                        employeeJOBTi = employee.employeeJOBTi,
                        employeeJOBSB = employee.employeeJOBSB,
                        employeeJOBVT = employee.employeeJOBVT,
                        employeeJOBDS = employee.employeeJOBDS,
                        employeeJOBBB = employee.employeeJOBBB,
                        employeeJOBJJY = employee.employeeJOBJJY,
                        employeeJOBHS = TimeSpan.Parse(employee.employeeJOBHS),
                        employeeJOBHT = TimeSpan.Parse(employee.employeeJOBHT),
                        employeeJOBSJY = employee.employeeJOBSJY == "**" ? false : true,
                        employeeJOBSHS = string.IsNullOrEmpty(employee.employeeJOBSHS) ? new TimeSpan?() : TimeSpan.Parse(employee.employeeJOBSHS),
                        employeeJOBSHT = string.IsNullOrEmpty(employee.employeeJOBSHT) ? new TimeSpan?() : TimeSpan.Parse(employee.employeeJOBSHT),
                        employeeDATE = employee.employeeDATE == 1,
                        employeeDAMX = employee.employeeDAMX,
                        employeeDACT = employee.employeeDACT,
                        employeeDANOP = employee.employeeDANOP,
                        employeeDAMSG = employee.employeeDAMSG,
                        employeeSOSName = employee.employeeSOSName,
                        employeeSOSPhone = employee.employeeSOSPhone,
                        employeeSOSWho = employee.employeeSOSWho,
                        employeeSOSHospital = employee.employeeSOSHospital,
                        employeeSOSPMD = employee.employeeSOSPMD,
                        record_created = DateTime.Now,
                        record_created_who = employee.UserID
                    };
                    _context.Employee.Add(emp);
                    _context.SaveChanges();

                    res.Codigo = 0;
                    res.Mensaje = "El usuario fue agregado correctamente";
                }
                else {
                    res.Codigo = 403;
                    res.Mensaje = "El usuario enviado ya existe";
                }
            }
            catch (Exception)
            {

                throw;
            }

            return res;
        }

        /// <summary>
        /// Solicitar reinicio de clave
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        public BaseRetorno SolicitarReinicioDeClave(string correo) {
            BaseRetorno res = new BaseRetorno() { Codigo = 500, Mensaje = "No es posible realizar la operación indicada" };

            return res;
        }
    }
}
