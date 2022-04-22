using System;
using System.Collections.Generic;

namespace PublicisExercise.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public int RefId { get; set; }
        public string Name { get; set; } = null!;
        public string Alias { get; set; } = null!;
    }
}
