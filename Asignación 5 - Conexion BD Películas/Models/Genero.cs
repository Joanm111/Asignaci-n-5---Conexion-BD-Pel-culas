using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Asignación_5___Conexion_BD_Películas.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Pelicula = new HashSet<Pelicula>();
        }

        public int Id { get; set; }
        public string Genero1 { get; set; }

        public virtual ICollection<Pelicula> Pelicula { get; set; }
    }
}
