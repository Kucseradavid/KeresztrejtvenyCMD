using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeresztrejtvenyCMD
{
    internal class VizszintStatisztika
    {
        public int Hossz {  get; set; }
        public int Darab { get; set; }

        public VizszintStatisztika (int hossz)
        {
            this.Hossz = hossz;
            this.Darab = 1;
        }
    }
}
