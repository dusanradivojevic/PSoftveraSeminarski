using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajednicki
{
    public enum Status
    {
        OK,
        ERR
    }

    [Serializable]
    public class Odgovor
    {
        public string Poruka { get; set; }
        public object Objekat { get; set; }
        public Status Status { get; set; }
    }
}
