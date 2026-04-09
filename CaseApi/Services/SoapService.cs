namespace CaseApi.Services;

using System.Xml.Linq;

public class SoapService
{
  public string ParseXmlResponse(string xml)
  {
    var doc = XDocument.Parse(xml);
    var element = doc.Root?.Element("value")
        ?? throw new InvalidOperationException("<value> element not found in XML.");
    return element.Value;
  }

}
