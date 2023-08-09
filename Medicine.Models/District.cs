using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicine.Models
{
    public class District // Участик
    {
        [Key]
        public int Dis_ID { get; set; }
        [Required]
        [StringLength(128)]
        [DisplayName("Введите номер участка")]
        public string Dis_Number { get; set; } = string.Empty;
    }
}