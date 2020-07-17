using System.Xml.Serialization;

namespace Net.RafaelEstevam.rAPI
{
    public class DadosCEP
    {
        [XmlElement("End")]
        public string Endereco { get; set; }
        [XmlElement("Cid")]
        public string Cidade { get; set; }
        [XmlElement("Bai")]
        public string Bairro { get; set; }
        [XmlElement("UF")]
        public string UF { get; set; }
        [XmlElement("Lat")]
        public double Latitude { get; set; }
        [XmlElement("Lon")]
        public double Longitude { get; set; }
    }
}