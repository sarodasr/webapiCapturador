using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models
{
    /// <summary>
    /// Default response
    /// </summary>
    public class BaseRetorno
    {
        /// <summary>
        /// Error code
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        public string Mensaje { get; set; }
    }
}
