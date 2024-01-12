

namespace MoominsApi.Repo
{
    /// <summary>
    /// Luokka muumien hallinnointiin
    /// </summary>
    public class MoominsRepository
    {
        private List<Moomin> moomins;

        public MoominsRepository()
        {
            // Alustetaan moomit
            // muutettu number -> id ei varmaan haittaa? helpompi hahmottaa itselle..
            moomins = new List<Moomin>();
            moomins.Add(new Moomin { Id = 1, Name = "Muumipeikko" });
            moomins.Add(new Moomin { Id = 2, Name = "Muumimamma" });
            moomins.Add(new Moomin { Id = 3, Name = "Muumipappa" });
            moomins.Add(new Moomin { Id = 4, Name = "Nuuskamuikkunen" });
            moomins.Add(new Moomin { Id = 5, Name = "Pikku Myy" });
            moomins.Add(new Moomin { Id = 6, Name = "Nipsu" });
            moomins.Add(new Moomin { Id = 7, Name = "Niiskuneiti" });
            moomins.Add(new Moomin { Id = 8, Name = "Niisku" });
            moomins.Add(new Moomin { Id = 9, Name = "Mymmeli" });
            moomins.Add(new Moomin { Id = 10, Name = "Hattivatti" });
            moomins.Add(new Moomin { Id = 11, Name = "Hemuli" });
        }

        // ************* näytä kaikki nimet
        public List<Moomin> GetAllMoomins()
        {
            return moomins;
        }


        // ************* näytä muumi nimi parametrin perusteella esim. Nipsu

        public List<Moomin> GetAllMoomins(string name)
        {
            var moominsFound = moomins.Where(moomin => moomin.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return moominsFound;
        }

        // ************* näytä tietty muumi by id
        public List<Moomin> GetMoomin()
        {

            return moomins;
        }


        // ************* lisää uusi muumi

        public void AddMoomin(Moomin moomin)
        {
           moomins.Add(moomin);
        }

        // ************* päivitä jo olemassa oleva muumi
        public void UpdateMoomin(Moomin moomin)
        {
            foreach (var p in moomins)
            {
                if (p.Id == moomin.Id)
                {
                    p.Name = moomin.Name;
                    break;
                }
            }
        }



        // ************* poista muumi by id
        public bool DeleteMoomin(Moomin moomin)
        {
            return DeleteMoomin(moomin.Id);
        }

        public bool DeleteMoomin(int id)
        {
            Moomin delete = null;

            foreach (var p in moomins)
            {
                if (p.Id == id)
                {
                    delete = p;
                    break;
                }
            }
            if (delete != null)
            {
                moomins.Remove(delete);
                return true;
            }

            return false;

        }

    }
    public class Moomin
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}