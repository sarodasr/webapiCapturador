using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestorRRHH_BackEnd_Api.Models;

namespace WebApplication1.Models
{
    /// <summary>
    /// Response for 200 status code
    /// </summary>
    public class AuthenticateResponse : BaseRetorno
    {
        /// <summary>
        /// Name for the user
        /// </summary>
        public string Nombre { get; set; }
        /// <summary>
        /// JWT for the session
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Allowed companies
        /// </summary>
        public List<CompanyAssoc> Companies { get; set; }
        /// <summary>
        /// List of allowed options
        /// </summary>
        public List<NavNodo> Elementos { get; set; }
    }

    /// <summary>
    /// Company associated
    /// </summary>
    public class CompanyAssoc {
        /// <summary>
        /// CompanyID
        /// </summary>
        public long CompanyID { get; set; }
        /// <summary>
        /// Company name
        /// </summary>
        public string CompanyName { get; set; }
    }
}
