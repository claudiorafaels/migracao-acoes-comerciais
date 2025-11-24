using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;

public class ConnectionString
{
    public String ConnString;
    public String ProviderName;

    public ConnectionString()
    {
        String str = ConfigurationManager.AppSettings["config"];

        var doc = new XmlDocument();
        doc.Load(str);

        XmlNodeList tagAdd = doc.GetElementsByTagName("add");
        XmlNode data = tagAdd.Item(0);

        this.ConnString = data.Attributes["connectionString"].Value;
        this.ProviderName = data.Attributes["providerName"].Value;
    }
}
