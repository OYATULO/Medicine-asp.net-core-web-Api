using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medicine.Models
{
    public class Patients // Пациенты
    {
        [Key]
        public int Pat_ID { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Фамилия")]
        public string Pat_Surname { get; set;} = string.Empty;
        [Required]
        [StringLength(50)]
        [DisplayName("Имя")]
        public string Pat_Name { get; set; } = string.Empty;
        [StringLength(50)]
        [DisplayName("Отчество")]
        public string Pat_Middlename { get; set; } = string.Empty;
        [Required]
        [StringLength(128)]
        [DisplayName("Адрес")]
        public string Pat_Address { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayName("Дата рождения")]
        public DateTime? Pat_Bday { get; set; } = null;
        
        [DisplayName("Пол")]
        public Dengers? Pat_Denger { get; set; }

        [ForeignKey("District_data")]
        public int Pat_Dis_ID { get; set; }
        public District? District_data { get; set; } 

    }

    public enum Dengers // ПОЛ
    {
        мужской,
        женской
    }



}
