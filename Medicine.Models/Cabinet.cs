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
    public class Cabinet // Кабинеты
    {
        [Key]
   
        public int Cab_ID { get; set;  }
        [Required]
        [StringLength(128)]
        [DisplayName("Введите номер кабинета")]
        public string Cab_Name { get; set; } = string.Empty;
    }
}
