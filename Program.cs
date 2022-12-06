namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Samochod s1 = new Samochod("audi", 10, 140, 10);
            Kabriolet s2 = new Kabriolet("bmw", 10, 140, 10);
            Console.WriteLine("1 samochod");
            s1.Jedz(140,100);
            Console.WriteLine("2 samochod(kabriolet) zamkniety dach");
            s2.Jedz(140, 100);
            s2.OtworzDach();
            Console.WriteLine("2 samochod(kabriolet) otwarty dach");
            s2.Jedz(140, 100);
        }
    }
    internal class Samochod 
    {
        protected string _marka;
        protected double _poj_baku;
        protected int _predkosc_max;
        protected double _zuzycie_paliwa;

        public Samochod(string marka, double poj_baku, int predkosc_max, double zuzycie_paliwa)
        {
            _marka = marka;
            _poj_baku = poj_baku;
            _predkosc_max = predkosc_max;
            _zuzycie_paliwa = zuzycie_paliwa;
        }

        public void Jedz(float jakSzybko, float jakDaleko)
        {
            int ileRazy = (int)(jakDaleko / (_poj_baku * 100 / _zuzycie_paliwa));
            Console.WriteLine($"{_marka} pojedzie {jakDaleko} km z predkoscia {(jakSzybko <= _predkosc_max ? jakSzybko : _predkosc_max)} km/h");
            Console.WriteLine($"Bedzie musial tankowac {ileRazy} razy\n");
        }
    }

    internal class Kabriolet : Samochod
    {
        bool _dach_otwarty;
        public Kabriolet(string marka, double poj_baku, int predkosc_max, double zuzycie_paliwa) : base(marka, poj_baku, predkosc_max, zuzycie_paliwa)
        {
            _dach_otwarty = false;
        }
        public void OtworzDach()
        {
            _dach_otwarty = true;
        }
        public void ZamknijDach()
        {
            _dach_otwarty = false;
        }

        public void Jedz(float jakSzybko, float jakDaleko)
        {
            //jesli dach otwarty * 1.15
            if(_dach_otwarty == true) _zuzycie_paliwa *= 1.15;
            
            int ileRazy = (int)(jakDaleko / (_poj_baku * 100 / _zuzycie_paliwa));
            Console.WriteLine($"{_marka} pojedzie {jakDaleko} km z predkoscia {(jakSzybko <= _predkosc_max ? jakSzybko : _predkosc_max)} km/h");
            Console.WriteLine($"Bedzie musial tankowac {ileRazy} razy"); 
            Console.WriteLine("Zuzycie paliwa to " + _zuzycie_paliwa + "\n");  
        }
    }
}