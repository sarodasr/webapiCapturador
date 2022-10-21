using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models.DTO
{
    /// <summary>
    /// DTO for vacation request
    /// </summary>
    public class VacationDTO
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
        /// Starting date
        /// </summary>
        [Required]
        public string dateStart { get; set; }
        /// <summary>
        /// Ending date, the next labor day will be back
        /// </summary>
        [Required]
        public string dateEnd { get; set; }
        /// <summary>
        /// Comments for this request
        /// </summary>
        [Required]
        public string comments { get; set; }
        /// <summary>
        /// User name associated to the request
        /// </summary>
        [Required]
        public string UserID { get; set; }
    }
}
