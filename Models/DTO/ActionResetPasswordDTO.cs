using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorRRHH_BackEnd_Api.Models.DTO
{
    /// <summary>
    /// Action for reset password
    /// </summary>
    public class ActionResetPasswordDTO
    {
        /// <summary>
        /// User ID
        /// </summary>
        public string userID { get; set; }
        /// <summary>
        /// OTP
        /// </summary>
        public string OTP { get; set; }
        /// <summary>
        /// New password
        /// </summary>
        public string new_password_1 { get; set; }
        /// <summary>
        /// repeat new password
        /// </summary>
        public string new_password_2 { get; set; }
    }
}
