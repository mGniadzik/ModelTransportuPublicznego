using ModelTransportuPublicznego.Implementacja.Autobusy;
using System.Xml;
using System.Xml.Serialization;

namespace ModelTransportuPublicznego.Misc
{
    static class AutobusDeserializer
    {
        public static AutobusLiniowy ZwrocAutobus(string sciezkaPliku)
        {
            var serializer = new XmlSerializer(typeof(AutobusLiniowy));
            AutobusLiniowy rezultat;

            using (var reader = XmlReader.Create(sciezkaPliku))
            {
                rezultat = (AutobusLiniowy)serializer.Deserialize(reader);
            }

            return rezultat;
        }
    }
}
