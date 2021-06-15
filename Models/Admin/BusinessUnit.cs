using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLMS.v2.Models.Admin
{
    public class BusinessUnit
    {
        [Key]
        public int UnitID { get; set; }

        public int DivID { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Business Division Name")]
        public string DivName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Business Unit Name")]
        [Required(ErrorMessage = "Please Fill Business Unit Name")]
        public string UnitName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Head of Company Name")]
        [Required(ErrorMessage = "Please Fill Head of Company Name")]
        public string HoCName { get; set; }

        //check duplicate
        public int ExistData { get; set; }
    }
}
