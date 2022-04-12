using System;
using System.Collections.Generic;

#nullable disable

namespace InyeccionDependenciasMVC.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string User1 { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Gender { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Status { get; set; }

        public virtual Gender GenderNavigation { get; set; }
    }
}
