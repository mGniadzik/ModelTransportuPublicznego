using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Model;
using NUnit.Framework;

namespace ModelTransportuPublicznegoTest.Model {
    
    [TestFixture]
    public class ZarzadTransportuTest {

        [Test]
        public void KonstruktorDomyslnyZmienneNieNull() {
            var zt = new DomyslnyZarzadTranspotu();
            
            Assert.AreNotEqual(null, zt.SiecPrzystankow);
            Assert.AreNotEqual(null, zt.ListaFirm);
        }

        [Test]
        public void KonstruktorListaPrzystankowListaPosiadaElementy() {
            
            var siecPrzystankow = new List<Przystanek> { new DomyslnyPrzystanek(""), new DomyslnyPrzystanek("") };
            var zt = new DomyslnyZarzadTranspotu(siecPrzystankow);

            Assert.AreNotEqual(null, zt.SiecPrzystankow);
            // Assert.AreEqual(2, zt.SiecPrzystankow.Count());
        }
        
        [Test]
        public void KonstruktorListaFirmListaPosiadaElementy() {
            
            var listaFirm = new List<Firma> { new DomyslnaFirma(""), new DomyslnaFirma("") };
            var zt = new DomyslnyZarzadTranspotu(listaFirm);

            Assert.AreNotEqual(null, zt.ListaFirm);
            Assert.AreEqual(2, zt.ListaFirm.Count());
        }
        
        [Test]
        public void KonstruktorListyPosiadajaElementy() {
            var siecPrzystankow = new List<Przystanek> { new DomyslnyPrzystanek(""), new DomyslnyPrzystanek("") };
            var listaFirm = new List<Firma> { new DomyslnaFirma(""), new DomyslnaFirma("") };
            var zt = new DomyslnyZarzadTranspotu(siecPrzystankow, listaFirm);

            Assert.AreNotEqual(null, zt.SiecPrzystankow);
            Assert.AreNotEqual(null, zt.ListaFirm);
            Assert.AreEqual(2, zt.SiecPrzystankow.Count());
            Assert.AreEqual(2, zt.ListaFirm.Count());
        }
    }
}