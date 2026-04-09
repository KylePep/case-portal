using System.Xml.Linq;

public class SoapService
{
  public string ParseXmlResponse(string xml)
  {
    var doc = XDocument.Parse(xml);
    return doc.Root?.Element("value")?.Value;
  }
}
