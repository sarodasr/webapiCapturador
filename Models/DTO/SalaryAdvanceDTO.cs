using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models.DTO
{
    /// <summary>
    /// DTO por Salary Advance request
    /// </summary>
    public class SalaryAdvanceDTO
    {
        /// <summary>
        /// Company ID
        /// </summary>
        [Required]
        public long CompanyID { get; set; }
        /// <summary>
        /// Employee code
        /// </summary>
        [Required]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Type of request;
        /// 1 - Bono14
        /// 2 - Aguinaldo
        /// 3 - Salario
        /// </summary>
        /// <example>1</example>
        [Required]
        public short typeRequest { get; set; }
        /// <summary>
        /// Ammount of salary advance
        /// </summary>
        [Required]
        [Range(minimum:500,maximum:25000,ErrorMessage = "El rango permitido es de entre 500 y 25000")]
        public decimal ammount { get; set; }
        /// <summary>
        /// Date to be disbursed. Format YYYY/MM/DD
        /// </summary>
        /// <example>2022-01-01</example>
        [Required]
        [RegularExpression(pattern: @"^(19|20)[0-9]{2}-(0[1-9]|1[012])-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "El formato de la fecha no es correcto")]
        public string dateTBD { get; set; }
        /// <summary>
        /// Date to start payment. In case type is "Salario"
        /// </summary>
        public string dateTSP { get; set; }
        /// <summary>
        /// Number of payments. In case type is "Salario"
        /// </summary>
        public short numberOP { get; set; }
        /// <summary>
        /// User ID
        /// </summary>
        [Required]
        public string userID { get; set; }
    }
}
