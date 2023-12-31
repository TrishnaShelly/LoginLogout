//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginLogout.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class user
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "User Name: ")]
        public string usrName { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ")]
        public string UsrEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "User Password: ")]
        public string UsrPass { get; set; }

        [Required]
        [Compare("UsrPass")]
        [Display(Name = "Re-Enter Password: ")]
        [DataType(DataType.Password)]
        public String Pass { get; set; }
    }
}
