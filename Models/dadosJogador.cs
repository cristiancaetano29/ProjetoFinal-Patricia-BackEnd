using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalPatricia.Models
{
    public class dadosJogador
    {
        public int id { get; set; }
        public string namePlayer { get; set; }
        public string namePersonagem { get; set; }
        public int agilidade { get; set; }
        public int vigor { get; set; }
        public int presenca { get; set; }
        public int forca { get; set; }
        public string origem { get; set; }
        public string classe { get; set; }
        //revisar o limite
        /*
        public int nex { get; set; }
        public int pv { get; set; }
        public int sam { get; set; }
        */

    }
}