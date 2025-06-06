using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeresztrejtvenyCMD
{
    internal class VizszintStatisztika
    {
        public int hossz {  get; set; }
        public int darab { get; set; }

        public VizszintStatisztika (int hossz, int darab)
        {
            this.hossz = hossz;
            this.darab = darab;
        }
    }
}
