using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    //public class MenuModel
    //{
    //    public string Nombre { get; set; }
    //    public string Icon { get; set; }
    //    public string Action { get; set; }
    //    public string Controller { get; set; }
    //    public int Padre { get; set; }
    //}

    public class MenuModel : AuditoriaModel
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Debe ingresar el nombre.")]
        [StringLength(20, ErrorMessage = "Longitud entre 1 y 20 caracteres.", MinimumLength = 1)]
        [RegularExpression(@"^[A-Za-z0-9ñÑáéíóúü\s]*$", ErrorMessage = "No debe ingresar caracteres especiales")]
        public string Nombre { get; set; }

        [Display(Name = "Icono")]
        public string Icon { get; set; }

        [Display(Name = "Menu")]
        public string Action { get; set; }

        [Display(Name = "SubMenu")]
        public string Controller { get; set; }

        [Display(Name = "Menu Padre")]
        public int Padre { get; set; }


    }
    public class MenuFilter : BasePagination
    {
    }

    public class MenuPagination : Pagination<MenuModel>
    {
    }
}
