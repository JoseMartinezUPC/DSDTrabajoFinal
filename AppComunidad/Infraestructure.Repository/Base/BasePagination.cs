using System.Collections.Generic;

namespace Infraestructure.Repository.Base
{
    public class BasePagination
    {
        public int Start { get; set; }
        public int Rows { get; set; }
    }
    public class Pagination<T> where T : new()
    {
        public IEnumerable<T> Data { get; set; }
        //cantidad de la pagina - ref BasePagination.Rows
        public int RecordsFiltered { get; set; }
        // cantidad de registros en base
        public int RecordsTotal { get; set; }
    }
}
