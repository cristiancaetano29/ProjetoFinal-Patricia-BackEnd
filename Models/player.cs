using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalPatricia.Models
{
    public class player
    {
        public int id { get; set; }
        public String username { get; set; } = string.Empty;
        public String senha { get; set; } = string.Empty;
        public String role { get; set; } = string.Empty;
    }
}