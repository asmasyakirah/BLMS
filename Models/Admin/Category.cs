using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLMS.v2.Models.Admin
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Type of License / Category")]
        [Required(ErrorMessage = "Please Fill Type of License / Category")]
        public string CategoryName { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [DisplayName("Description")]
        [Required(ErrorMessage = "Please Fill Description")]
        public string Description { get; set; }

        //check duplicate
        public int ExistData { get; set; }
    }
}
