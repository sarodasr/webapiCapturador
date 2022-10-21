﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class CertificateRequest
    {
        [Key]
        public long ID { get; set; }
        public long companyID { get; set; }
        [Required]
        [StringLength(50)]
        public string employeeCode { get; set; }
        public short type { get; set; }
        [Column(TypeName = "date")]
        public DateTime dateR { get; set; }
        public short state { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime create_date { get; set; }
        [Required]
        [StringLength(50)]
        public string create_who { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? update_date { get; set; }
        [StringLength(50)]
        public string update_who { get; set; }

        [ForeignKey("companyID,employeeCode")]
        [InverseProperty("CertificateRequest")]
        public virtual Employee Employee { get; set; }
    }
}