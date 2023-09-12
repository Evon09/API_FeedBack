using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula04.RazorPages.Models {
    public class CursoModel {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? IdCurso { get; set; }
        [Required(ErrorMessage ="Nome do curso é obrigatório")]
        public string? NomeCurso { get; set; }
        [Required(ErrorMessage ="Descrição é obrigatória")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage ="Data de inicio é obrigatória")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? DataInicio { get; set; }
        [Required(ErrorMessage ="Data de termino é obrigatória")]
        [DisplayFormat(DataFormatString ="{0:dd MMM yyyy}")]
        public DateTime? DataTérmino { get; set; }
        public List<AlunoModel>? Alunos { get; set; } 
    }
}