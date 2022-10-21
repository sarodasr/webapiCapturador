﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public partial class RoleOption
    {
        [Key]
        public long idRole { get; set; }
        [Key]
        public long idOption { get; set; }

        [ForeignKey(nameof(idOption))]
        [InverseProperty(nameof(Option.RoleOption))]
        public virtual Option idOptionNavigation { get; set; }
        [ForeignKey(nameof(idRole))]
        [InverseProperty(nameof(Role.RoleOption))]
        public virtual Role idRoleNavigation { get; set; }
    }
}