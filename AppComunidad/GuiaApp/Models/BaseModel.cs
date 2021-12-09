using System;
using System.Collections.Generic;

namespace GuiaApp.Models
{
    public class BaseModel
    {
        public DateTime FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime FechaModifica { get; set; }
        public string UsuarioModifica { get; set; }

    }
    public class BasePagination
    {
        public int Start { get; set; }
        public int Draw { get; set; } 
        public int Length { get; set; }
    }
    public class Pagination<T> where T : new()
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int Draw { get; set; }
        //cantidad de la pagina - ref BasePagination.Rows
        public int RecordsTotal { get; set; }
        // cantidad de registros en base
        public int RecordsFiltered { get { return RecordsTotal; } } 
    }

    public class BaseJson
    {
        public string Message { get; set; }
        public bool Estado { get; set; }
    }
}
