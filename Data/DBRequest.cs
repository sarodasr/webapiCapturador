using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorRRHH_BackEnd_Api.Models;
using GestorRRHH_BackEnd_Api.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using WebApplication1.Data;
using WebApplication1.Models;

namespace GestorRRHH_BackEnd_Api.Data
{
    public class DBRequest
    {
        GestorRRHHContext _context;

        public DBRequest()
        {
            _context = new GestorRRHHContext();
        }

        #region "Vacations region"
        public RetornoAdd addVacation(VacationDTO x) {
            RetornoAdd ret = new RetornoAdd() { Codigo = 500, Mensaje = "Error inesperado", ID = 0 };

            try
            {
                Vacation vacation = new Vacation
                {
                    companyID = x.CompanyID,
                    employeeCode = x.EmployeeCode,
                    dateStart = DateTime.Parse(x.dateStart),
                    dateEnd = DateTime.Parse(x.dateEnd),
                    comments = x.comments,
                    state = 1,
                    create_date = DateTime.Now,
                    create_who = x.UserID
                };
                _context.Vacation.Add(vacation);
                _context.SaveChanges();
                ret.Codigo = 0;
                ret.Mensaje = "New vacation request was added.";
                ret.ID = vacation.ID;
            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }

        public Vacation getVacation(long ID) {
            try
            {
                return _context.Vacation.Where(x => x.ID == ID).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Salary Advance region"
        public BaseRetorno addSalaryAdvance(SalaryAdvanceDTO salaryAdvance) {
            BaseRetorno ret = new BaseRetorno() { Codigo = 500, Mensaje = "No es posible realizar la operación solicitada" };

            try
            {
                SalaryAdvance advance = new SalaryAdvance { 
                    companyID = salaryAdvance.CompanyID,
                    employeeCode = salaryAdvance.EmployeeCode,
                    typeRequest = salaryAdvance.typeRequest,
                    ammount = salaryAdvance.ammount,
                    dateTBD = DateTime.Parse(salaryAdvance.dateTBD),
                    dateTSP = salaryAdvance.typeRequest == 3 ? DateTime.Parse(salaryAdvance.dateTSP) : DateTime.Now,
                    numerOP = salaryAdvance.typeRequest == 3 ? salaryAdvance.numberOP : (short)0,
                    state = 1,
                    create_date = DateTime.Now,
                    create_who = salaryAdvance.userID
                };

                _context.SalaryAdvance.Add(advance);
                _context.SaveChanges();
                ret.Codigo = 0;
                ret.Mensaje = "Your salary advance request was processed.";
            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }
        #endregion

        #region "Certificate request"
        public BaseRetorno addCertificateRequest(CertificateRequestDTO x) {
            BaseRetorno ret = new BaseRetorno() { Codigo = 500, Mensaje = "La operación solicitada no pudo ser realizada" };

            try
            {
                CertificateRequest certificate = new CertificateRequest {
                    companyID = x.CompanyID,
                    employeeCode = x.EmployeeCode,
                    dateR = DateTime.Parse(x.DateNeeded),
                    type = (short)x.TypeRequest,
                    state = 1,
                    create_who = x.UserID,
                    create_date = DateTime.Now
                };

                _context.CertificateRequest.Add(certificate);
                _context.SaveChanges();

                ret.Codigo = 0;
                ret.Mensaje = "Your certificate request was procesed";
            }
            catch (Exception)
            {

                throw;
            }

            return ret;
        }
        #endregion
    }
}
