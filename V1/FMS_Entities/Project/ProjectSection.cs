using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS_Entities
{
   public class ProjectSection
    {

       [Key]
       public int ProjectSectionId { get; set; }

       [Required]
       public int PostId { get; set; }

       [ForeignKey("PostId")]
       public PostAProject PostAProject;

       [Required]
       public string SectionName { get; set; }

       [Required]
       public int Percentage { get; set; }

       [NotMapped]
       public double Price { get; set; }
    }
}
