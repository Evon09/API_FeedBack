using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula04.RazorPages.Models {
    public class PlayerModel {
        public int? PlayerID { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
    }
}