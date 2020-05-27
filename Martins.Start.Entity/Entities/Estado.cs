using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Martins.Start.Entity.Entities
{
    public class Estado : IEstado
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sigla { get; set; }
        public int PaisId { get; set; }
        public IPais Pais { get; set; }
    }
}
