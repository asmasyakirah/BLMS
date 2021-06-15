using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BLMS.v2.Models.Admin
{
    public class PIC
    {
        [Key]
        public int PICID { get; set; }

        [DisplayName("Person-In-Charge Staff No.")]
        public string PICStaffNo { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Person-In-Charge Name")]
        public string PICName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [DisplayName("Person-In-Charge Email")]
        public string PICEmail { get; set; }

        public int DivID { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Business Division Name")]
        public string DivName { get; set; }

        public int UnitID { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Business Unit Name")]
        public string UnitName { get; set; }

        public int UserTypeID { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Type of User")]
        public string UserType { get; set; }
    }
}
