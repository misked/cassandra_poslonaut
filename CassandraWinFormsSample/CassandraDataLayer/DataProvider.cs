using Cassandra;
using CassandraDataLayer.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CassandraDataLayer
{
    public static class DataProvider
    {
        #region Radnik
        public static Radnik GetRadnik(string radnikEmail)
        {
            ISession session = SessionManager.GetSession();
            Radnik radnik = new Radnik();

            if (session == null)
                return null;

            Row radnikData = session.Execute("select * from \"Radnik\" where \"email\"='"+radnikEmail+"'").FirstOrDefault();

            if(radnikData != null)
            {
                radnik.brojgodina = radnikData["brojgodina"] != null ? radnikData["brojgodina"].GetHashCode() : 0;
                radnik.ime = radnikData["ime"] != null ? radnikData["ime"].ToString() : string.Empty;
                radnik.pol = radnikData["pol"] != null ? radnikData["pol"].ToString() : string.Empty;
                radnik.prezime = radnikData["prezime"] != null ? radnikData["prezime"].ToString() : string.Empty;
                radnik.brtelefona = radnikData["brtelefona"] != null ? radnikData["brtelefona"].ToString() : string.Empty;
                radnik.email = radnikData["email"] != null ? radnikData["email"].ToString() : string.Empty;
                radnik.sifra = radnikData["sifra"] != null ? radnikData["sifra"].ToString() : string.Empty;
            }            
            return radnik;
        }

        public static Radnik proveriSifruRadniku(string emailZaProveru,string sifraZaProveru)
        {
            ISession session = SessionManager.GetSession();
            List<Radnik> radnici = new List<Radnik>();
            Radnik radnikZaVracanje = new Radnik();

            if (session == null)
                return null;

            var radniciData = session.Execute("select * from \"Radnik\" where \"email\"='"+emailZaProveru+"'");


            foreach (var radnikData in radniciData)
            {
                Radnik radnik = new Radnik();
                radnik.brojgodina = radnikData["brojgodina"] != null ? radnikData["brojgodina"].GetHashCode() : 0;
                radnik.ime = radnikData["ime"] != null ? radnikData["ime"].ToString() : string.Empty;
                radnik.pol = radnikData["pol"] != null ? radnikData["pol"].ToString() : string.Empty;
                radnik.prezime = radnikData["prezime"] != null ? radnikData["prezime"].ToString() : string.Empty;
                radnik.brtelefona = radnikData["brtelefona"] != null ? radnikData["brtelefona"].ToString() : string.Empty;
                radnik.email = radnikData["email"] != null ? radnikData["email"].ToString() : string.Empty;
                radnik.sifra = radnikData["sifra"] != null ? radnikData["sifra"].ToString() : string.Empty;
                radnici.Add(radnik);
                if(radnik.email== emailZaProveru)
                {
                    radnikZaVracanje = radnik;
                }
            }
            //Row radnikData = session.Execute("select * from \"Radnik\" where email='"+email+"' and sifra='"+sifra+"'").FirstOrDefault();
            //ovo ne moze jer nas cassandra upozorava!
            if (radnikZaVracanje.email == null)
            {
                MessageBox.Show("Ne postoji takav email.");
                return null;
            }
            else {
                if (radnikZaVracanje.sifra != sifraZaProveru)
                {
                    MessageBox.Show("Nije tacna sifra.");
                    return null;
                }
            }

            return radnikZaVracanje;
        }

        public static Boolean emailZaRegistrovanjeRadnika(string noviEmail)
        {
            Boolean tacno = true;

            ISession session = SessionManager.GetSession();

            if (session == null)
                return false;

            var radniciData = session.Execute("select * from \"Radnik\"");
            
            foreach (var radnikData in radniciData)
            {
                Radnik radnik = new Radnik();
                radnik.brojgodina = radnikData["brojgodina"] != null ? radnikData["brojgodina"].GetHashCode() : 0;
                radnik.ime = radnikData["ime"] != null ? radnikData["ime"].ToString() : string.Empty;
                radnik.pol = radnikData["pol"] != null ? radnikData["pol"].ToString() : string.Empty;
                radnik.prezime = radnikData["prezime"] != null ? radnikData["prezime"].ToString() : string.Empty;
                radnik.brtelefona = radnikData["brtelefona"] != null ? radnikData["brtelefona"].ToString() : string.Empty;
                radnik.email = radnikData["email"] != null ? radnikData["email"].ToString() : string.Empty;
                radnik.sifra = radnikData["sifra"] != null ? radnikData["sifra"].ToString() : string.Empty;
                if (radnik.email == noviEmail)
                {
                    tacno = false;
                }
            }

            return tacno;
        }

        public static List<Radnik> GetRadnike()
        {
            ISession session = SessionManager.GetSession();
            List<Radnik> radnici = new List<Radnik>();
            

            if (session == null)
                return null;

            var radniciData = session.Execute("select * from \"Radnik\"");

            
            foreach(var radnikData in radniciData)
            {
                Radnik radnik = new Radnik();
                radnik.brojgodina = radnikData["brojgodina"] != null ? radnikData["brojgodina"].GetHashCode() : 0;
                radnik.ime = radnikData["ime"] != null ? radnikData["ime"].ToString() : string.Empty;
                radnik.pol = radnikData["pol"] != null ? radnikData["pol"].ToString() : string.Empty;
                radnik.prezime = radnikData["prezime"] != null ? radnikData["prezime"].ToString() : string.Empty;
                radnik.brtelefona = radnikData["brtelefona"] != null ? radnikData["brtelefona"].ToString() : string.Empty;
                radnik.email = radnikData["email"] != null ? radnikData["email"].ToString() : string.Empty;
                radnik.sifra = radnikData["sifra"] != null ? radnikData["sifra"].ToString() : string.Empty;
                radnici.Add(radnik);
            }
            return radnici;
        }

        public static void AddRadnik(Radnik novi)
        {
            //string radnikId = generateID();
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            RowSet radnikData = session.Execute("insert into \"Radnik\" (\"email\", brojgodina, brtelefona, ime, pol, prezime, sifra)  values ('" + novi.email + "', "+novi.brojgodina+", '"+novi.brtelefona+"', '"+novi.ime+"', '"+novi.pol+"' , '"+novi.prezime+"', '"+novi.sifra+"')");
            MessageBox.Show("Napravljen je novi nalog " + novi.email + ".");
        }
        
        public static void DeleteRadnik(string radnikEmail)
        {
            ISession session = SessionManager.GetSession();
            Radnik radnik = new Radnik();

            if (session == null)
                return;

            RowSet radnikData = session.Execute("delete from \"Radnik\" where \"email\" = '" + radnikEmail + "'");

        }

        #endregion

        #region Potrazivac
        /*public static Potrazivac GetPotrazivac(string potrazivacEmail)
        {
            ISession session = SessionManager.GetSession();
            Potrazivac potrazivac = new Potrazivac();

            if (session == null)
                return null;

            Row potrazivacData = session.Execute("select * from \"Potrazivac\" where \"potrazivacEmail\"='1'").FirstOrDefault();

            if (potrazivacData != null)
            {
                potrazivac.potrazivacEmail = potrazivacData["potrazivacEmail"] != null ? potrazivacData["potrazivacEmail"].ToString() : string.Empty;
                potrazivac.ime = potrazivacData["ime"] != null ? potrazivacData["ime"].ToString() : string.Empty;
                potrazivac.prezime = potrazivacData["prezime"] != null ? potrazivacData["prezime"].ToString() : string.Empty;
                potrazivac.brtelefona = potrazivacData["brtelefona"] != null ? potrazivacData["brtelefona"].ToString() : string.Empty;
                potrazivac.email = potrazivacData["email"] != null ? potrazivacData["email"].ToString() : string.Empty;
                potrazivac.sifra = potrazivacData["sifra"] != null ? potrazivacData["sifra"].ToString() : string.Empty;
            }

            return potrazivac;
        }
        */
        public static Potrazivac GetPotrazivac(string potrazivacEmail)
        {
            ISession session = SessionManager.GetSession();
            Potrazivac potrazivac = new Potrazivac();

            if (session == null)
                return null;

            Row potrazivacEmailata = session.Execute("select * from \"Potrazivac\" where email='"+potrazivacEmail+"'").FirstOrDefault();
            if (potrazivacEmail != null)
            {                
                potrazivac.ime = potrazivacEmailata["ime"] != null ? potrazivacEmailata["ime"].ToString() : string.Empty;
                potrazivac.pol = potrazivacEmailata["pol"] != null ? potrazivacEmailata["pol"].ToString() : string.Empty;
                potrazivac.prezime = potrazivacEmailata["prezime"] != null ? potrazivacEmailata["prezime"].ToString() : string.Empty;
                potrazivac.brtelefona = potrazivacEmailata["brtelefona"] != null ? potrazivacEmailata["brtelefona"].ToString() : string.Empty;
                potrazivac.email = potrazivacEmailata["email"] != null ? potrazivacEmailata["email"].ToString() : string.Empty;
                potrazivac.sifra = potrazivacEmailata["sifra"] != null ? potrazivacEmailata["sifra"].ToString() : string.Empty;
            }   
            return potrazivac;
        }

        public static Potrazivac proveriSifruPotrazivacu(string emailZaProveru, string sifraZaProveru)
        {
            ISession session = SessionManager.GetSession();
            
            Potrazivac potrazivacZaVracanje = new Potrazivac();

            if (session == null)
                return null;

            var potrazivacEmailata = session.Execute("select * from \"Potrazivac\" where \"email\"='"+emailZaProveru+"' and \"sifra\"='"+sifraZaProveru+"' ");


            foreach (var potrazivacData in potrazivacEmailata)
            {
                Potrazivac potrazivac = new Potrazivac();
                potrazivac.ime = potrazivacData["ime"] != null ? potrazivacData["ime"].ToString() : string.Empty;
                potrazivac.pol = potrazivacData["pol"] != null ? potrazivacData["pol"].ToString() : string.Empty;
                potrazivac.prezime = potrazivacData["prezime"] != null ? potrazivacData["prezime"].ToString() : string.Empty;
                potrazivac.brtelefona = potrazivacData["brtelefona"] != null ? potrazivacData["brtelefona"].ToString() : string.Empty;
                potrazivac.email = potrazivacData["email"] != null ? potrazivacData["email"].ToString() : string.Empty;
                potrazivac.sifra = potrazivacData["sifra"] != null ? potrazivacData["sifra"].ToString() : string.Empty;
                potrazivacZaVracanje = potrazivac;
            }
            if (potrazivacZaVracanje.email == null)
            {
                MessageBox.Show("Ne postoji takav email.");
                return null;
            }

            if (potrazivacZaVracanje.sifra != sifraZaProveru)
            {
                return null;
            }
            return potrazivacZaVracanje;
        }

        public static Boolean emailZaRegistrovanjePotrazivaca(string noviEmail)
        {
            Boolean tacno = true;

            ISession session = SessionManager.GetSession();

            if (session == null)
                return false;

            var potrazivacEmailata = session.Execute("select * from \"Potrazivac\"");


            foreach (var potrazivacData in potrazivacEmailata)
            {
                Potrazivac potrazivac = new Potrazivac();
                potrazivac.ime = potrazivacData["ime"] != null ? potrazivacData["ime"].ToString() : string.Empty;
                potrazivac.pol = potrazivacData["pol"] != null ? potrazivacData["pol"].ToString() : string.Empty;
                potrazivac.prezime = potrazivacData["prezime"] != null ? potrazivacData["prezime"].ToString() : string.Empty;
                potrazivac.brtelefona = potrazivacData["brtelefona"] != null ? potrazivacData["brtelefona"].ToString() : string.Empty;
                potrazivac.email = potrazivacData["email"] != null ? potrazivacData["email"].ToString() : string.Empty;
                potrazivac.sifra = potrazivacData["sifra"] != null ? potrazivacData["sifra"].ToString() : string.Empty;
                if (potrazivac.email == noviEmail)
                {
                    tacno = false;
                }
            }

            return tacno;
        }

        public static List<Potrazivac> GetPotrazivace()
        {
            ISession session = SessionManager.GetSession();
            List<Potrazivac> potrazivaci = new List<Potrazivac>();

            if (session == null)
                return null;

            var potrazivacEmailata = session.Execute("select * from \"Potrazivac\"");

            foreach (var potrazivacData in potrazivacEmailata)
            {
                Potrazivac potrazivac = new Potrazivac();
                potrazivac.ime = potrazivacData["ime"] != null ? potrazivacData["ime"].ToString() : string.Empty;
                potrazivac.pol = potrazivacData["pol"] != null ? potrazivacData["pol"].ToString() : string.Empty;
                potrazivac.prezime = potrazivacData["prezime"] != null ? potrazivacData["prezime"].ToString() : string.Empty;
                potrazivac.brtelefona = potrazivacData["brtelefona"] != null ? potrazivacData["brtelefona"].ToString() : string.Empty;
                potrazivac.email = potrazivacData["email"] != null ? potrazivacData["email"].ToString() : string.Empty;
                potrazivac.sifra = potrazivacData["sifra"] != null ? potrazivacData["sifra"].ToString() : string.Empty;
                potrazivaci.Add(potrazivac);
            }
            return potrazivaci;
        }

        public static void AddPotrazivac(Potrazivac novi)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet potrazivacData = session.Execute("insert into \"Potrazivac\" (\"email\", brtelefona, ime, pol, prezime, sifra)  values ('" + novi.email + "', '"+novi.brtelefona+"', '"+novi.ime+"', '"+novi.pol+"' , '"+novi.prezime+"', '"+novi.sifra+"')");
            MessageBox.Show("Napravljen je novi nalog " + novi.email+".");
        }
        
        public static void DeletePotrazivac(string email)
        {
            ISession session = SessionManager.GetSession();
            Potrazivac radnik = new Potrazivac();

            if (session == null)
                return;

            RowSet potrazivacData = session.Execute("delete from \"Potrazivac\" where \"email\" = '" + email + "'");

        }

        #endregion

        #region Oglas
        public static void AddOglas(Oglas oglas)
        {
            //string oglasId = generateID();
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet oglasData = session.Execute("insert into \"Oglas\" (\"nazivoglasa\", \"potrazivacEmail\", brojlajkova, brojradnika, mestoposla, trenutnibrojradnika, voznja)  values ('" + oglas.nazivoglasa + "', '" + oglas.potrazivacEmail + "', "+oglas.brojlajkova+", "+oglas.brojradnika+", '"+oglas.mestoposla+"', "+oglas.trenutnibrojradnika+", "+oglas.voznja+")");

        }

        public static List<Oglas> vratiSveOglasePrekoMejla(string potrazivacEmail)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;
            
            
            List<Oglas> oglasi = new List<Oglas>();
            var oglasiData = session.Execute("select * from \"Oglas\" where \"potrazivacEmail\"='"+potrazivacEmail+"' ");

            foreach(var oglasData in oglasiData)
            {
                Oglas oglas = new Oglas();
                oglas.nazivoglasa = oglasData["nazivoglasa"] != null ? oglasData["nazivoglasa"].ToString() : string.Empty;
                oglas.potrazivacEmail = oglasData["potrazivacEmail"] != null ? oglasData["potrazivacEmail"].ToString() : string.Empty;
                oglas.brojlajkova = oglasData["brojlajkova"] != null ? oglasData["brojlajkova"].GetHashCode() : 0;
                oglas.brojradnika = oglasData["brojradnika"] != null ? oglasData["brojradnika"].GetHashCode() : 0;
                oglas.mestoposla = oglasData["mestoposla"] != null ? oglasData["mestoposla"].ToString() : string.Empty;
                oglas.trenutnibrojradnika = oglasData["trenutnibrojradnika"] != null ? oglasData["trenutnibrojradnika"].GetHashCode() : 0;
                if (oglasData["voznja"].GetHashCode() == 1)
                    oglas.voznja = true;
                else oglas.voznja = false;
                if (oglas.brojradnika <= oglas.trenutnibrojradnika)
                    DeleteOglas(oglas.potrazivacEmail, oglas.nazivoglasa);
                else oglasi.Add(oglas);
            }
            return oglasi;
        }

        public static List<Oglas> vratiSveOglase()
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return null;


            List<Oglas> oglasi = new List<Oglas>();
            var oglasiData = session.Execute("select * from \"Oglas\"");

            foreach (var oglasData in oglasiData)
            {
                Oglas oglas = new Oglas();
                oglas.nazivoglasa = oglasData["nazivoglasa"] != null ? oglasData["nazivoglasa"].ToString() : string.Empty;
                oglas.potrazivacEmail = oglasData["potrazivacEmail"] != null ? oglasData["potrazivacEmail"].ToString() : string.Empty;
                oglas.brojlajkova = oglasData["brojlajkova"] != null ? oglasData["brojlajkova"].GetHashCode() : 0;
                oglas.brojradnika = oglasData["brojradnika"] != null ? oglasData["brojradnika"].GetHashCode() : 0;
                oglas.mestoposla = oglasData["mestoposla"] != null ? oglasData["mestoposla"].ToString() : string.Empty;
                oglas.trenutnibrojradnika = oglasData["trenutnibrojradnika"] != null ? oglasData["trenutnibrojradnika"].GetHashCode() : 0;
                if (oglasData["voznja"].GetHashCode() == 1)
                    oglas.voznja = true;
                else oglas.voznja = false;
                oglasi.Add(oglas);
            }
            return oglasi;
        }

        public static void DeleteOglas(string potrazivacEmail, string imeOglasa)
        {
            ISession session = SessionManager.GetSession();
            Oglas oglas = new Oglas();

            if (session == null)
                return;

            RowSet oglasData = session.Execute("delete from \"Oglas\" where \"potrazivacEmail\" = '" + potrazivacEmail + "' and nazivoglasa='"+imeOglasa+"'");
           
        }

        public static Oglas GetOglas(string potrazivacId, string naziv)
        {
            ISession session = SessionManager.GetSession();
            Oglas oglas = new Oglas();

            if (session == null)
                return null;

            Row oglasData = session.Execute("select * from \"Oglas\" where \"potrazivacEmail\"='" + potrazivacId + "' and nazivoglasa='"+naziv+"'").FirstOrDefault();

            if (oglasData != null)
            {
                oglas.nazivoglasa = oglasData["nazivoglasa"] != null ? oglasData["nazivoglasa"].ToString() : string.Empty;
                oglas.potrazivacEmail = oglasData["potrazivacEmail"] != null ? oglasData["potrazivacEmail"].ToString() : string.Empty;
                oglas.brojlajkova = oglasData["brojlajkova"] != null ? oglasData["brojlajkova"].GetHashCode() : 0;
                oglas.brojradnika = oglasData["brojradnika"] != null ? oglasData["brojradnika"].GetHashCode() : 0;
                oglas.mestoposla = oglasData["mestoposla"] != null ? oglasData["mestoposla"].ToString() : string.Empty;
                oglas.trenutnibrojradnika = oglasData["trenutnibrojradnika"] != null ? oglasData["trenutnibrojradnika"].GetHashCode() : 0;
                if (oglasData["voznja"].GetHashCode() == 1)
                    oglas.voznja = true;
                else oglas.voznja = false;
            }
            return oglas;
        }

        public static void updateLike(string potrazivacId, string naziv)
        {
            Oglas oglas = GetOglas(potrazivacId, naziv);

            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            oglas.brojlajkova++;
            RowSet likeUpdateData = session.Execute("update \"Oglas\" set brojlajkova=" + oglas.brojlajkova + ", trenutnibrojradnika="+oglas.trenutnibrojradnika+" where \"potrazivacEmail\"='" + oglas.potrazivacEmail + "' and " +
                "nazivoglasa='" + oglas.nazivoglasa + "' and voznja="+oglas.voznja+" and brojradnika="+oglas.brojradnika+" and mestoposla='"+oglas.mestoposla+"' ");
        }

        public static void updateBrojTrenutnihRadnika(string potrazivacId, string naziv)
        {
            Oglas oglas = GetOglas(potrazivacId, naziv);

            ISession session = SessionManager.GetSession();

            if (session == null)
                return;
            oglas.trenutnibrojradnika++;
            RowSet likeUpdateData = session.Execute("update \"Oglas\" set brojlajkova=" + oglas.brojlajkova + ", trenutnibrojradnika=" + oglas.trenutnibrojradnika + " where \"potrazivacEmail\"='" + oglas.potrazivacEmail + "' and " +
                "nazivoglasa='" + oglas.nazivoglasa + "' and voznja=" + oglas.voznja + " and brojradnika=" + oglas.brojradnika + " and mestoposla='" + oglas.mestoposla + "' ");
        }

        #endregion

        #region Zahtev
        public static void AddZahtev(Zahtev zahtev)
        {
            zahtev.zahtevId = generateID();
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet zahtevData = session.Execute("insert into \"Zahtev\" (\"potrazivacId\", \"oglasId\", \"zahtevId\", \"radnikId\", odobren)  values ('" + zahtev.potrazivacId + "', '"+ zahtev.oglasId + "', '"+ zahtev.zahtevId + "', '"+zahtev.radnikId+"', 0)");
        }

        public static List<Zahtev> vratiZahteveZaIzabranogPotrazivaca(string username)
        {
            ISession session = SessionManager.GetSession();
            List<Zahtev> zahtevi = new List<Zahtev>();
            
            if (session == null)
                return null;

            var zahteviData = session.Execute("select * from \"Zahtev\" where \"potrazivacId\"='"+username+"' ");
            
            foreach (var zahtevData in zahteviData)
            {
                Zahtev zahtev = new Zahtev();
                zahtev.potrazivacId = zahtevData["potrazivacId"] != null ? zahtevData["potrazivacId"].ToString() : string.Empty;
                zahtev.oglasId = zahtevData["oglasId"] != null ? zahtevData["oglasId"].ToString() : string.Empty;
                zahtev.radnikId = zahtevData["radnikId"] != null ? zahtevData["radnikId"].ToString() : string.Empty;
                zahtev.zahtevId = zahtevData["zahtevId"] != null ? zahtevData["zahtevId"].ToString() : string.Empty;
                zahtev.odobren = zahtevData["odobren"] != null ? zahtevData["odobren"].GetHashCode() : 0;
                zahtevi.Add(zahtev);
            }
            return zahtevi;
        }

        public static List<Zahtev> vratiZahteveZaIzabranogRadnika(string username)
        {
            ISession session = SessionManager.GetSession();
            List<Zahtev> zahtevi = new List<Zahtev>();

            if (session == null)
                return null;

            var zahteviData = session.Execute("select * from \"Zahtev\"");

            foreach (var zahtevData in zahteviData)
            {
                Zahtev zahtev = new Zahtev();
                zahtev.potrazivacId = zahtevData["potrazivacId"] != null ? zahtevData["potrazivacId"].ToString() : string.Empty;
                zahtev.oglasId = zahtevData["oglasId"] != null ? zahtevData["oglasId"].ToString() : string.Empty;
                zahtev.radnikId = zahtevData["radnikId"] != null ? zahtevData["radnikId"].ToString() : string.Empty;
                zahtev.zahtevId = zahtevData["zahtevId"] != null ? zahtevData["zahtevId"].ToString() : string.Empty;
                zahtev.odobren = zahtevData["odobren"] != null ? zahtevData["odobren"].GetHashCode() : 0;
                if (zahtev.radnikId==username)
                {
                    zahtevi.Add(zahtev);
                }
            }
            return zahtevi;
        }
        
        public static void updateZahtev(Zahtev zahtev)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet zahtevUpdateData = session.Execute("update \"Zahtev\" set odobren="+zahtev.odobren+" where \"potrazivacId\"='" + zahtev.potrazivacId + "' and \"oglasId\" = '" + zahtev.oglasId + "' and \"zahtevId\"='"+zahtev.zahtevId+"' and \"radnikId\"='"+zahtev.radnikId+"'");
        }

        public static void DeleteZahtev(string potrazivacId, string oglasId)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet zahtevData = session.Execute("delete from \"Zahtev\" where \"potrazivacId\"='" + potrazivacId + "' and \"oglasId\" = '" + oglasId + "'");
        }
        #endregion

        #region Komentar
        public static void AddKomentar(string radnikId, string oglasId)
        {
            string komentarId = generateID();
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet KomentarData = session.Execute("insert into \"Komentar\" (\"komentarId\", \"radnikId\", \"oglasId\", poruka)  values ('" + komentarId + "', '" + radnikId + "', '" + oglasId + "', 'false')");
        }

        public static void DeleteKomentar(string KomentarId)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet KomentarData = session.Execute("delete from \"Komentar\" where \"KomentarId\" = '" + KomentarId + "'");
        }
        #endregion

        public static string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }


        /*#region Hotel
        public static Hotel GetHotel(string hotelID)
        {
            ISession session = SessionManager.GetSession();
            Hotel hotel = new Hotel();

            if (session == null)
                return null;

            Row hotelData = session.Execute("select * from \"Hotel\" where \"hotelID\"='1'").FirstOrDefault();

            if(hotelData != null)
            {
                hotel.hotelID = hotelData["hotelID"] != null ? hotelData["hotelID"].ToString() : string.Empty;
                hotel.name = hotelData["name"] != null ? hotelData["name"].ToString() : string.Empty;
                hotel.address = hotelData["address"] != null ? hotelData["address"].ToString() : string.Empty;
                hotel.city = hotelData["city"] != null ? hotelData["city"].ToString() : string.Empty;
                hotel.phone = hotelData["phone"] != null ? hotelData["phone"].ToString() : string.Empty;
                hotel.state = hotelData["state"] != null ? hotelData["state"].ToString() : string.Empty;
                hotel.zip = hotelData["zip"] != null ? hotelData["zip"].ToString() : string.Empty;
            }
            
            return hotel;
        }

        public static List<Hotel> GetHotels()
        {
            ISession session = SessionManager.GetSession();
            List<Hotel> hotels = new List<Hotel>();
            

            if (session == null)
                return null;

            var hotelsData = session.Execute("select * from \"Hotel\"");

            
            foreach(var hotelData in hotelsData)
            {
                Hotel hotel = new Hotel();
                hotel.hotelID = hotelData["hotelID"] != null ? hotelData["hotelID"].ToString() : string.Empty;
                hotel.name = hotelData["name"] != null ? hotelData["name"].ToString() : string.Empty;
                hotel.address = hotelData["address"] != null ? hotelData["address"].ToString() : string.Empty;
                hotel.city = hotelData["city"] != null ? hotelData["city"].ToString() : string.Empty;
                hotel.phone = hotelData["phone"] != null ? hotelData["phone"].ToString() : string.Empty;
                hotel.state = hotelData["state"] != null ? hotelData["state"].ToString() : string.Empty;
                hotel.zip = hotelData["zip"] != null ? hotelData["zip"].ToString() : string.Empty;
                hotels.Add(hotel);
            }
                
            

            return hotels;
        }

        public static void AddHotel(string hotelID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet hotelData = session.Execute("insert into \"Hotel\" (\"hotelID\", address, city, name, phone, state, zip)  values ('" + hotelID +"', 'Vozda Karadjordja 12', 'Nis', 'Grand', '123', 'Srbija', '18000')");

        }

        public static void DeleteHotel(string hotelID)
        {
            ISession session = SessionManager.GetSession();
            Hotel hotel = new Hotel();

            if (session == null)
                return;

            RowSet hotelData = session.Execute("delete from \"Hotel\" where \"hotelID\" = '" + hotelID + "'");

        }

        #endregion
         * 
         * 
        #region Room

        public static Room GetRoom(string hotelID, string roomID)
        {
            ISession session = SessionManager.GetSession();
            Room room = new Room();

            if (session == null)
                return null;

            Row roomData = session.Execute("select * from \"Room\" where \"hotelID\"='" + hotelID +"' and \"roomID\"='" + roomID + "'").FirstOrDefault();

            if (roomData != null)
            {
                room.hotelID = roomData["hotelID"] != null ? roomData["hotelID"].ToString() : string.Empty;
                room.roomID = roomData["roomID"] != null ? roomData["roomID"].ToString() : string.Empty;
                room.hottub = roomData["hottub"] != null ? roomData["hottub"].ToString() : string.Empty;
                room.num = roomData["num"] != null ? roomData["num"].ToString() : string.Empty;
                room.rate = roomData["rate"] != null ? roomData["rate"].ToString() : string.Empty;
                room.tv = roomData["tv"] != null ? roomData["tv"].ToString() : string.Empty;
                room.type = roomData["type"] != null ? roomData["type"].ToString() : string.Empty;
            }

            return room;
        }

        public static List<Room> GetRooms()
        {
            ISession session = SessionManager.GetSession();
            List<Room> rooms = new List<Room>();

            if (session == null)
                return null;

            var roomsData = session.Execute("select * from \"Room\"");

            foreach(var row in roomsData)
            {
                Room room = new Room();
                room.hotelID = row["hotelID"] != null ? row["hotelID"].ToString() : string.Empty;
                room.roomID = row["roomID"] != null ? row["roomID"].ToString() : string.Empty;
                room.hottub = row["hottub"] != null ? row["hottub"].ToString() : string.Empty;
                room.num = row["num"] != null ? row["num"].ToString() : string.Empty;
                room.rate = row["rate"] != null ? row["rate"].ToString() : string.Empty;
                room.tv = row["tv"] != null ? row["tv"].ToString() : string.Empty;
                room.type = row["type"] != null ? row["type"].ToString() : string.Empty;

                rooms.Add(room);
            }

            return rooms;
        }

        public static void AddRoom(string hotelID, string roomID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet roomData = session.Execute("insert into \"Room\"(\"hotelID\",\"roomID\", hottub, num, rate, tv, \"type\") values ('" + hotelID + "', '" + roomID + "', 'yes', '101', '25', 'yes', 'appartment')");

        }

        public static void DeleteRoom(string hotelID, string roomID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet roomData = session.Execute("delete from \"Room\" where \"hotelID\" = '" + hotelID + "' and \"roomID\" = '" + roomID + "'");

        }

        #endregion

        #region Geust

        public static Guest GetGuest(string phone)
        {
            ISession session = SessionManager.GetSession();
            Guest guest = new Guest();

            if (session == null)
                return null;

            Row guestData = session.Execute("select * from \"Guest\" where phone='" + phone + "'").FirstOrDefault();

            if (guestData != null)
            {
                guest.phone = guestData["phone"] != null ? guestData["phone"].ToString() : string.Empty;
                guest.email = guestData["email"] != null ? guestData["email"].ToString() : string.Empty;
                guest.fname = guestData["fname"] != null ? guestData["fname"].ToString() : string.Empty;
                guest.lname = guestData["lname"] != null ? guestData["lname"].ToString() : string.Empty;
            }

            return guest;
        }

        public static List<Guest> GetGuests()
        {
            ISession session = SessionManager.GetSession();
            List<Guest> guests = new List<Guest>();

            if (session == null)
                return null;

            var guestsData = session.Execute("select * from \"Guest\"");

           
            foreach (var guestData in guestsData)
            {
                Guest guest = new Guest();
                guest.phone = guestData["phone"] != null ? guestData["phone"].ToString() : string.Empty;
                guest.email = guestData["email"] != null ? guestData["email"].ToString() : string.Empty;
                guest.fname = guestData["fname"] != null ? guestData["fname"].ToString() : string.Empty;
                guest.lname = guestData["lname"] != null ? guestData["lname"].ToString() : string.Empty;
                    
                guests.Add(guest);
            }
           

            return guests;
        }

        public static void AddGuest(string phone)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet guestData = session.Execute("insert into \"Guest\"(phone, email, fname, lname) values ('" + phone + "', 'email@email.com', 'test', 'test')");

        }

        public static void DeleteGuest(string phone)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet guestData = session.Execute("delete from \"Guest\" where phone = '" + phone + "'");

        }

        #endregion*/

        //#region Reservation

        //public static Reservation GetReservation(string resID)
        //{
        //    ISession session = SessionManager.GetSession();
        //    Reservation reservation = new Reservation();

        //    if (session == null)
        //        return null;

        //    Row reservationData = session.Execute("select * from \"Reservation\" where \"resID\"='" + resID +"'").FirstOrDefault();

        //    if (reservationData != null)
        //    {
        //        reservation.hotelID = reservationData["hotelID"] != null ? reservationData["hotelID"].ToString() : string.Empty;
        //        reservation.roomID = reservationData["roomID"] != null ? reservationData["roomID"].ToString() : string.Empty;
        //        reservation.resID = reservationData["resID"] != null ? reservationData["resID"].ToString() : string.Empty;
        //        reservation.arrive = reservationData["arrive"] != null ? reservationData["arrive"].ToString() : string.Empty;
        //        reservation.depart = reservationData["depart"] != null ? reservationData["depart"].ToString() : string.Empty;
        //        reservation.name = reservationData["name"] != null ? reservationData["name"].ToString() : string.Empty;
        //        reservation.phone = reservationData["phone"] != null ? reservationData["phone"].ToString() : string.Empty;
        //        reservation.rate = reservationData["rate"] != null ? reservationData["rate"].ToString() : string.Empty;
        //    }

        //    return reservation;
        //}

        //public static List<Reservation> GetReservations()
        //{
        //    ISession session = SessionManager.GetSession();
        //    List<Reservation> reservations = new List<Reservation>();

        //    if (session == null)
        //        return null;

        //    var reservationsData = session.Execute("select * from \"Reservation\"");

            
        //    foreach (Row reservationData in reservationsData)
        //    {
        //        Reservation reservation = new Reservation();
        //        reservation.hotelID = reservationData["hotelID"] != null ? reservationData["hotelID"].ToString() : string.Empty;
        //        reservation.roomID = reservationData["roomID"] != null ? reservationData["roomID"].ToString() : string.Empty;
        //        reservation.resID = reservationData["resID"] != null ? reservationData["resID"].ToString() : string.Empty;
        //        reservation.arrive = reservationData["arrive"] != null ? reservationData["arrive"].ToString() : string.Empty;
        //        reservation.depart = reservationData["depart"] != null ? reservationData["depart"].ToString() : string.Empty;
        //        reservation.name = reservationData["name"] != null ? reservationData["name"].ToString() : string.Empty;
        //        reservation.phone = reservationData["phone"] != null ? reservationData["phone"].ToString() : string.Empty;
        //        reservation.rate = reservationData["rate"] != null ? reservationData["rate"].ToString() : string.Empty;

        //        reservations.Add(reservation);
        //    }
            

        //    return reservations;
        //}

        //public static void AddReservation(string resID)
        //{
        //    ISession session = SessionManager.GetSession();

        //    if (session == null)
        //        return;

        //    RowSet reservationData = session.Execute("insert into \"Reservation\"(\"resID\", \"hotelID\",\"roomID\", arrive, depart, name, phone, rate) values ('" + resID + "', '1', '101', 'date', 'date', 'test', '018181818', '25')");

        //}

        //public static void DeleteReservation(string resID)
        //{
        //    ISession session = SessionManager.GetSession();

        //    if (session == null)
        //        return;

        //    RowSet reservationData = session.Execute("delete from \"Reservation\" where \"resID\" = '" + resID + "'");

        //}

        //#endregion

    }
}
