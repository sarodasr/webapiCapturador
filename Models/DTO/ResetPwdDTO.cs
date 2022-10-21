using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models.DTO
{
    /// <summary>
    /// For password reset request
    /// </summary>
    public class ResetPwdDTO
    {
        /// <summary>
        /// Associated email for the account
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "El dato no es válido")]
        public string email { get; set; }
    }
}
