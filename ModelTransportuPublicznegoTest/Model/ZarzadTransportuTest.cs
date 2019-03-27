using System.Collections.Generic;
using System.Linq;
using ModelTransportuPublicznego.Implementacja;
using ModelTransportuPublicznego.Implementacja.Firmy;
using ModelTransportuPublicznego.Model;
using NUnit.Framework;

namespace ModelTransportuPublicznegoTest.Model {
    
    [TestFixture]
    public class ZarzadTransportuTest {

        [Test]
        public void KonstruktorDomyslnyZmienneNieNull() {
            var zt = new DomyslnyZarzadTranspotu("ZT1");
            
            Assert.AreNotEqual(null, zt.SiecPrzystankow);
            Assert.AreNotEqual(null, zt.ListaFirm);
        }

        [Test]
        public void KonstruktorListaPrzystankowListaPosiadaElementy() {
            var zt = new DomyslnyZarzadTranspotu("ZT1");
            var siecPrzystankow = new List<Przystanek> { new Przystanek("", zt, 30), new Przystanek("", zt, 30) };
            zt.DodajPrzystanki(siecPrzystankow);

            Assert.AreNotEqual(null, zt.SiecPrzystankow);
            // Assert.AreEqual(2, zt.SiecPrzystankow.Count());
        }
        
        [Test]
        public void KonstruktorListaFirmListaPosiadaElementy() {
            
            var listaFirm = new List<Firma> { new FirmaLosowa(""), new FirmaLosowa("") };
            var zt = new DomyslnyZarzadTranspotu("ZT1", listaFirm);

            Assert.AreNotEqual(null, zt.ListaFirm);    
            Assert.AreEqual(2, zt.ListaFirm.Count());
        }
        
        [Test]
        public void KonstruktorListyPosiadajaElementy() {
            var zt = new DomyslnyZarzadTranspotu("");
            var siecPrzystankow = new List<Przystanek> { new Przystanek("", zt, 30), new Przystanek("", zt, 30) };
            var listaFirm = new List<Firma> { new FirmaLosowa(""), new FirmaLosowa("") };
            zt.DodajPrzystanki(siecPrzystankow);
            zt.DodajFirmy(listaFirm);

            Assert.AreNotEqual(null, zt.SiecPrzystankow);
            Assert.AreNotEqual(null, zt.ListaFirm);
            Assert.AreEqual(2, zt.SiecPrzystankow.Count());
            Assert.AreEqual(2, zt.ListaFirm.Count());
        }
    }
}