using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuiaApp.Models
{
    public class RedModel : AuditoriaModel
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Red")]
        public int TipoRedId { get; set; }

        [Display(Name = "Tipo de Red")]
        public string TipoRed { get; set; }

        [Display(Name = "Recurso")]
        public string Recurso { get; set; }


        public int UsuarioId { get; set; }
    }
    public class RedFilter : BasePagination
    {
        public int Id { get; set; }
    }

    public class RedPagination : Pagination<RedModel>
    {
    }

    public class RedJson : BaseJson
    {
    }
}
