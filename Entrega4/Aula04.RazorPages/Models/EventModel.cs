using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula04.RazorPages.Models {
    public class EventModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? EventID { get; set; }
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Descrição é obrigatória")]
        public string? Description { get; set; }
        [Required(ErrorMessage ="Data é obrigatória")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? Date { get; set; }
        public List<PlayerModel>? Players { get; set; } 
    }
}