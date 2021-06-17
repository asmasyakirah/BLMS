using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BLMS.v2.Models
{
    [Table("tblCompetentPersonnel")]
    public partial class CompetentPersonnel
    {
        [Required]
        [StringLength(150)]
        [Display(Name = "Business Unit")]
        public string BusinessUnit { get; set; }

        [Key]
        [Column("PersonnelID")]
        public int PersonnelId { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Name")]
        public string PersonnelName { get; set; }

        [Column("AppointedDT")]
        [Display(Name = "Appointment Date")]
        public DateTime? AppointedDt { get; set; }

        [Column("ICNo")]
        [StringLength(15)]
        public string Icno { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Certificate Body")]
        public string CertFrom { get; set; }

        [StringLength(100)]
        [Display(Name = "Certificate Type")]
        public string CertType { get; set; }

        [StringLength(100)]
        [Display(Name = "Certificate No")]
        public string CertNo { get; set; }

        [Column("ExpiredDT")]
        [Display(Name = "Expired Date")]
        public DateTime? ExpiredDt { get; set; }

        public int? YearAwarded { get; set; }

        [StringLength(200)]
        [Display(Name = "File")]
        public string CertFileName { get; set; }

        [StringLength(200)]
        public string RegNo { get; set; }

        [StringLength(200)]
        public string Branch { get; set; }

        [Column("CreatedDT")]
        public DateTime CreatedDt { get; set; }

        [Column("CreatedBY")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column("UpdatedDT")]
        public DateTime UpdatedDt { get; set; }

        [Column("UpdatedBY")]
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        [Required]
        [StringLength(150)]
        public string BusinessDiv { get; set; }
    }
}
