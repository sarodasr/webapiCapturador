﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class Employee
    {
        public Employee()
        {
            CertificateRequest = new HashSet<CertificateRequest>();
            SalaryAdvance = new HashSet<SalaryAdvance>();
            Vacation = new HashSet<Vacation>();
        }

        [Key]
        public long companyID { get; set; }
        [Key]
        [StringLength(50)]
        public string employeeCode { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeName { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeLastName { get; set; }
        [StringLength(50)]
        public string employeeLastName2 { get; set; }
        [Column(TypeName = "date")]
        public DateTime employeeDOB { get; set; }
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
        [Required]
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
        [Column(TypeName = "money")]
        public decimal employeeJOBSB { get; set; }
        [Column(TypeName = "money")]
        public decimal employeeJOBVT { get; set; }
        [Column(TypeName = "date")]
        public DateTime employeeJOBDS { get; set; }
        [Column(TypeName = "money")]
        public decimal employeeJOBBB { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeJOBJJY { get; set; }
        public TimeSpan employeeJOBHS { get; set; }
        public TimeSpan employeeJOBHT { get; set; }
        public bool? employeeJOBSJY { get; set; }
        public TimeSpan? employeeJOBSHS { get; set; }
        public TimeSpan? employeeJOBSHT { get; set; }
        public bool employeeDATE { get; set; }
        [Required]
        [StringLength(256)]
        public string employeeDAMX { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeDACT { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeDANOP { get; set; }
        [Required]
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
        [Required]
        [StringLength(50)]
        public string employeeSOSHospital { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeSOSPMD { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime record_created { get; set; }
        [Required]
        [StringLength(50)]
        public string record_created_who { get; set; }
        [Column(TypeName = "date")]
        public DateTime? record_affected { get; set; }
        [StringLength(50)]
        public string record_affected_who { get; set; }

        [ForeignKey(nameof(companyID))]
        [InverseProperty(nameof(Company.Employee))]
        public virtual Company company { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<CertificateRequest> CertificateRequest { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<SalaryAdvance> SalaryAdvance { get; set; }
        [InverseProperty("Employee")]
        public virtual ICollection<Vacation> Vacation { get; set; }
    }
}