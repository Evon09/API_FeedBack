using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula04.RazorPages.Models {
    public class AlunoModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? AlunoID { get; set; }
        [Required(ErrorMessage ="Nome é obrigatório")]
        public string? NomeAluno { get; set; }
        [Required(ErrorMessage ="Email é obrigatório")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Data é obrigatória")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? DataInscricao { get; set; }
        public List<CursoModel>? Cursos { get; set; } 
    }
}