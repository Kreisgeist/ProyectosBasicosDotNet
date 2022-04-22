using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PublicisExercise.Models
{
    public partial class Page
    {
        public int Id { get; set; }
        public string Medio { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int IdCategory { get; set; }
        public int Spots { get; set; }
        public string? SrcLink { get; set; }
        public bool Processing { get; set; }
    }
}
