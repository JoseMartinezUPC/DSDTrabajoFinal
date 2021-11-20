using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementMicroService.Model
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuNombre { get; set; }
        public string MenuIcon { get; set; }
        public string MenuAction { get; set; }
        public string MenuController { get; set; }
        public int MenuPadre { get; set; }
        public bool MenuActivo { get; set; }
    }
}
