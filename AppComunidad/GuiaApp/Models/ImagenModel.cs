using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class ImagenModel : AuditoriaModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre (ejemplo:BannerPrincipal)")]
        public string Nombre { get; set; }

        [Display(Name = "Ruta")]
        public string Ruta { get; set; }

        [Display(Name = "Tipo de Imagen")]
        public int TipoImagenId { get; set; }

        [Display(Name = "Tipo Imagen")]
        public string TipoImagen { get; set; }

        [Display(Name = "Extension")]
        public string Extension { get; set; }


        public int UsuarioId { get; set; }
    }
    public class ImagenFilter : BasePagination
    {
        public int Id { get; set; }
    }

    public class ImagenPagination : Pagination<ImagenModel>
    {
    }

    public class ImagenJson : BaseJson
    { 
    }
}
