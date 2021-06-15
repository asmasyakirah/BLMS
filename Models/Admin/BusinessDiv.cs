using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLMS.v2.Models.Admin
{
    public class BusinessDiv
    {
        [Key]
        public int DivID { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Business Division Name")]
        [Required(ErrorMessage = "Please Fill Business Division Name")]
        public string DivName { get; set; }

        //check duplicate
        public int ExistData { get; set; }

        //check linked data
        public int LinkedData { get; set; }
    }
}
