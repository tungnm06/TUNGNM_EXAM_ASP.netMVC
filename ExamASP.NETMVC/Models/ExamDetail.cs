﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExamASP.NETMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class ExamDetail
    {
        public int ExamId { get; set; }
        [Required(ErrorMessage = " Không được để trống !")]
        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm}")]
        public Nullable<System.DateTime> StartTime { get; set; }
        [Required(ErrorMessage = " Không được để trống !")]
        [DisplayName("Exam Date")]

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string ExamDate { get; set; }
        [Required(ErrorMessage = " Không được để trống !")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "Thi lau vay ban oi! ")]
        [DisplayName("Exam Duration")]

        public string ExamDuration { get; set; }
        [DisplayName("Exam Subject")]

        public string ExamSubject { get; set; }
        [DisplayName("Class Room")]

        public string ClassRoom { get; set; }

        public string FacultyName { get; set; }
        public string Status { get; set; }
    
        public virtual ClassRoom ClassRoom1 { get; set; }
        public virtual ExamSubject ExamSubject1 { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
