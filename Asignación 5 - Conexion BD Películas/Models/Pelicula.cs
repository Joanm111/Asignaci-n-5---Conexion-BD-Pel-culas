using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Asignación_5___Conexion_BD_Películas.Models
{
    public partial class Pelicula
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Generoid { get; set; }

        public virtual Genero Genero { get; set; }
    }
}
