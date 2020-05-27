using System.ComponentModel.DataAnnotations;

namespace Martins.Start.Entity.Entities
{
    public class Pais : IPais
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}