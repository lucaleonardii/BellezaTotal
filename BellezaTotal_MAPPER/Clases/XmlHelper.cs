using BellezaTotal_BE.Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BellezaTotal_MAPPER.Clases
{
    public static class XMLHelper<T>
    {

        private static readonly XmlSerializer serializador = new XmlSerializer(typeof(T));

        public static void Serializar(T objeto, string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta)) throw new ExcepcionNegocio("EXP_RutaNull");

            XmlWriterSettings ajustes = new XmlWriterSettings
            {
                Indent = true,
                Encoding = new UTF8Encoding(false)
            };

            using (FileStream flujo = new FileStream(ruta, FileMode.Create, FileAccess.Write))
            using (XmlWriter escritor = XmlWriter.Create(flujo, ajustes))
            {
                serializador.Serialize(escritor, objeto);
            }
        }

        public static T Deserializar(string ruta)
        {
            if (string.IsNullOrWhiteSpace(ruta)) throw new ExcepcionNegocio("EXP_RutaNull");

            if (!File.Exists(ruta)) throw new ExcepcionNegocio("EXP_ArchivoXmlNoExiste");

            XmlReaderSettings ajustes = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Prohibit,
                XmlResolver = null
            };

            try
            {
                using (FileStream flujo = new FileStream(ruta, FileMode.Open, FileAccess.Read))
                using (XmlReader lector = XmlReader.Create(flujo, ajustes))
                {
                    return (T)serializador.Deserialize(lector);
                }
            }
            catch (System.InvalidOperationException)
            {
                throw new ExcepcionNegocio("EXP_XmlInvalido");
            }
            catch (XmlException)
            {
                throw new ExcepcionNegocio("EXP_XmlInvalido");
            }
        }
    }
}
