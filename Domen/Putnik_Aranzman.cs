﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Putnik_Aranzman : IDomenskiObjekat
    {
        private string jmbg;

        public string JMBG
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        private int aranzmanID;

        public int AranzmanID
        {
            get { return aranzmanID; }
            set { aranzmanID = value; }
        }

        private DateTime datumRezervacije;

        public DateTime DatumRezervacije
        {
            get { return datumRezervacije; }
            set { datumRezervacije = value; }
        }

        public string NazivTabele => "Putnik_Aranzman";

        public string VrednostiZaInsert => $"'{JMBG}', {AranzmanID}, '{DatumRezervacije}'";

        public string VrednostZaUpdate => null;

        public string KriterijumiZaPretragu
        {
            get
            {
                if (AranzmanID != 0 && JMBG == null)
                {
                    return $"AranzmanID = {AranzmanID}";
                }
                else if (AranzmanID == 0 && JMBG != null)
                {
                    return $"JMBG = '{JMBG}'";
                }
                else
                {
                    return $"AranzmanID = {AranzmanID} AND JMBG = '{JMBG}'";
                }
            }
        }

        public string PrimarniKljuc => null;

        public IDictionary Kriterijumi { get; set; }

        public void PostaviVrednost(IDomenskiObjekat ido)
        {
            if (!(ido is Putnik_Aranzman))
                return;

            Putnik_Aranzman pa = ido as Putnik_Aranzman;

            JMBG = pa.jmbg;
            AranzmanID = pa.AranzmanID;
            DatumRezervacije = pa.DatumRezervacije;
        }

        public void PostaviVrednostPodDomena(IDomenskiObjekat ido)
        {
            return;
        }

        public List<IDomenskiObjekat> VratiListu(SqlDataReader reader)
        {
            List<IDomenskiObjekat> asocijati = new List<IDomenskiObjekat>();
            while (reader.Read())
            {
                Putnik_Aranzman pa = new Putnik_Aranzman
                {
                    JMBG = (string)reader["JMBG"],
                    AranzmanID = (int)reader["AranzmanID"],
                    DatumRezervacije = (DateTime)reader["DatumRezervacije"]
                };

                asocijati.Add(pa);
            }

            return asocijati;
        }

        public IDomenskiObjekat VratiPodDomen()
        {
            return null;
        }
        public bool AdekvatnoPopunjen()
        {
            if (JMBG == null)
                return false;

            if (AranzmanID <= 0)
                return false;

            if (DatumRezervacije == new DateTime())
                return false;

            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Putnik_Aranzman aranzman &&
                   JMBG == aranzman.JMBG &&
                   AranzmanID == aranzman.AranzmanID;
        }

        public string UslovFiltera()
        {
            return null;
        }
    }
}
