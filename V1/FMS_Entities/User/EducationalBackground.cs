using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS_Entities
{
  public  class EducationalBackground
    {
        [Key]
        public int UserId{ get; set; }
        [ForeignKey("UserId")]
        public UserInfo UserInfo;
        [Required]
        public string School{ get; set; }
        [Required]
        public string Collage{ get; set; }
        [Required]
        public string UniversityPost { get; set; }
        [Required]
        public string UniversityUnder { get; set; }
       
        public string Others { get; set; }






    }


}
