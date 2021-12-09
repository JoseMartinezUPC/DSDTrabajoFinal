using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class ModificarAsociadoModel
    {
        public UsuarioModel Usuario { get; set; }

        public ImagenModel Imagen { get; set; }

        public RedModel Red { get; set; }

        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Display(Name = "Sub Categoria")]
        public int SubCategoriaId { get; set; }

        [Display(Name = "Descripcion del Negocio")]
        public string Descripcion { get; set; }
    }
}
