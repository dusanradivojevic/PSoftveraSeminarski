using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public interface IDomenskiObjekat
    {
        string NazivTabele { get; }
        string VrednostiZaInsert { get; }
        string KriterijumiZaPretragu { get; }

        List<IDomenskiObjekat> VratiListu(SqlDataReader reader);
        IDomenskiObjekat VratiPodDomen();
        void PostaviVrednost(IDomenskiObjekat ido);
        void PostaviVrednostPodDomena(IDomenskiObjekat ido);
    }
}
