using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MZrepo
{
    public class ProduktListe
    {
        public string KategoriNavn { get; set; }

        public SEO SEO { get; set; }

        public List<Produkt> Produkter { get; set; }
    }
}
