using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class Doctors // Врачи
    {
        [Key]
      
        public int Doc_ID { get; set; }
        [Required]
        [StringLength(128)]
        [DisplayName("ФИО")]
        public string Doc_fullname { get; set; } = string.Empty;

        [ForeignKey("Cabinet_data")]
        public int Doc_Cab_ID { get; set; }
        public Cabinet? Cabinet_data { get; set; } = null;
      
        public int Doc_Spec_ID { get; set; }
        [ForeignKey("Doc_Spec_ID")]
        public Specialization? Spec_data { get; set; } = null; 
        [Required]
        [DisplayName("Учасковой врач ?")]
        public bool IfDistrict_doctor { get; set; } = false;
      
        public int Doc_Dis_ID { get; set; }
        [ForeignKey("Doc_Dis_ID")]
        public District? District_data { get; set; } = null;


    }
}
