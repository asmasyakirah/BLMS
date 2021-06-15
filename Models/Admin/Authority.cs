using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BLMS.v2.Models.Admin
{
    public class Authority
    {
        [Key]
        public int AuthorityID { get; set; }

        [DisplayName("Authority Link")]
        [Required(ErrorMessage = "Please Fill Authority Link")]
        public string AuthorityLink { get; set; }

        [DisplayName("Authority Name")]
        [Required(ErrorMessage = "Please Fill Authority Name")]
        public string AuthorityName { get; set; }

        public DateTime CreatedDT { get; set; }

        public DateTime UpdatedDT { get; set; }


        public int ExistData { get; set; }
    }
}
