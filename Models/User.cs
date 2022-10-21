﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class User
    {
        public User()
        {
            UserCompany = new HashSet<UserCompany>();
        }

        [Key]
        [StringLength(50)]
        public string userName { get; set; }
        [Required]
        [MaxLength(20)]
        public byte[] userPassword { get; set; }
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50)]
        public string middleName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        [Required]
        [StringLength(50)]
        public string lastName2 { get; set; }
        public long userRole { get; set; }
        [Required]
        [StringLength(75)]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string cellPhone { get; set; }
        /// <summary>
        /// Numero de intentos
        /// </summary>
        public short? NoT { get; set; }
        public short state { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? lastLogin { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? passwordExpiracy { get; set; }
        public short? daysPasswordExpiracy { get; set; }

        [ForeignKey(nameof(userRole))]
        [InverseProperty(nameof(Role.User))]
        public virtual Role userRoleNavigation { get; set; }
        [InverseProperty("userNameNavigation")]
        public virtual ICollection<UserCompany> UserCompany { get; set; }
    }
}