using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models.DTO
{
    /// <summary>
    /// DTO for Certificate
    /// </summary>
    public class CertificateRequestDTO
    {
        /// <summary>
        /// Company ID
        /// </summary>
        [Required]
        public int CompanyID { get; set; }
        /// <summary>
        /// Employee code
        /// </summary>
        [Required]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Type of certificate
        /// </summary>
        /// <remarks>1 - IGSS, 2 - Otro</remarks>
        /// <example>1</example>
        [Required]
        [RegularExpression(pattern: @"^(1|2|3)$", ErrorMessage = "El valor enviado no es válido")]
        public int TypeRequest { get; set; }
        /// <summary>
        /// Dated needed
        /// </summary>
        /// <example>2022-01-01</example>
        [Required]
        public string DateNeeded { get; set; }
        /// <summary>
        /// User
        /// </summary>
        public string UserID { get; set; }
    }
}
