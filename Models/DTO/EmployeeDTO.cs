using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models.DTO
{
    /// <summary>
    /// Employee DTO
    /// </summary>
    public class EmployeeDTO
    {
        /// <summary>
        /// Company ID
        /// </summary>
        [Required]
        public long companyID { get; set; }
        /// <summary>
        /// Employee code
        /// </summary>
        [Required]
        [StringLength(50)]
        public string employeeCode { get; set; }
        /// <summary>
        /// Employee names
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Longitud inválida")]
        public string employeeName { get; set; }
        /// <summary>
        /// employee last name (father)
        /// </summary>
        [Required]
        [StringLength(50,ErrorMessage = "Longitud inválida")]
        public string employeeLastName { get; set; }
        /// <summary>
        /// Employee last name (mother)
        /// </summary>
        [StringLength(50)]
        public string employeeLastName2 { get; set; }
        /// <summary>
        /// Employee date of birth
        /// </summary>
        public string employeeDOB { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeBT { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeGender { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeLanguage { get; set; }
        [StringLength(50)]
        public string employeeLocalLanguage { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeCollegeDegree { get; set; }
        [StringLength(128)]
        public string employeeFN { get; set; }
        [StringLength(128)]
        public string employeeMN { get; set; }
        public short employeeSN { get; set; }
        public bool employeeUG { get; set; }
        [StringLength(75)]
        public string employeeBACAcct { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeIDT { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeIDNo { get; set; }
        [StringLength(50)]
        public string employeeSSN { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeNIT { get; set; }
        [Required]
        [StringLength(50)]
        public string employeePRO { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeCT { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeCY { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeTW { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeET { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeMS { get; set; }
        [Required]
        [StringLength(256)]
        public string employeeADDR { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeHS { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeHT { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeCP { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeEM { get; set; }
        [Required]
        [StringLength(128)]
        public string employeeJOBTi { get; set; }
        public decimal employeeJOBSB { get; set; }
        public decimal employeeJOBVT { get; set; }
        public DateTime employeeJOBDS { get; set; }
        public decimal employeeJOBBB { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeJOBJJY { get; set; }
        public string employeeJOBHS { get; set; }
        public string employeeJOBHT { get; set; }
        public string employeeJOBSJY { get; set; }
        public string employeeJOBSHS { get; set; }
        public string employeeJOBSHT { get; set; }
        public short employeeDATE { get; set; }
        [StringLength(256)]
        public string employeeDAMX { get; set; }
        [StringLength(50)]
        public string employeeDACT { get; set; }
        [StringLength(50)]
        public string employeeDANOP { get; set; }
        [StringLength(256)]
        public string employeeDAMSG { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeSOSName { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeSOSPhone { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeSOSWho { get; set; }
        [StringLength(50)]
        public string employeeSOSHospital { get; set; }
        [StringLength(50)]
        public string employeeSOSPMD { get; set; }
        /// <summary>
        /// user associated
        /// </summary>
        public string UserID { get; set; }
    }
}
