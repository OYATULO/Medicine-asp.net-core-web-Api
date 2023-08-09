using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class Specialization //Cпелизации
    {
        [Key]
      
        public int Spec_ID { get; set; }

        [Required]
        [StringLength(128)]
        [DisplayName("Введите название")]
        public string Spec_Name { get; set; } = string.Empty;
    }
}
