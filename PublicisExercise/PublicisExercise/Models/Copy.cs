using System;
using System.Collections.Generic;

namespace PublicisExercise.Models
{
    public partial class Copy
    {
        public int Id { get; set; }
        public string Medio { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string Marca { get; set; } = null!;
        public string Producto { get; set; } = null!;
        public string Version { get; set; } = null!;
        public string Programa { get; set; } = null!;
        public TimeSpan? Hora { get; set; }
        public string Vehiculo { get; set; } = null!;
        public string Anunciante { get; set; } = null!;
        public string? Tema { get; set; }
        public int IdCategory { get; set; }
        public bool Processing { get; set; }
        public string File { get; set; } = null!;
    }
}
