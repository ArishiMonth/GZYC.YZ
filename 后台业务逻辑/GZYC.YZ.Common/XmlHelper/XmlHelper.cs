using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GZYC.YZ.Common.XmlHelper
{
    public   class XmlHelper
    {
        public static Dictionary<string, string> XmlDeserialize(string s, string nodeStr,string key,string value)
        {
            var local = new Dictionary<string, string>();
            if (String.IsNullOrEmpty(s))
            {
                throw new ArgumentNullException("s", "反序列化的字符串为空");
            }

            //   XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlDocument doc = new XmlDocument();
            doc.Load(s);

            XmlElement root = null;
            root = doc.DocumentElement;

            XmlNodeList listNodes = null;
            listNodes = root.SelectNodes(nodeStr);
            foreach (XmlNode node in listNodes)
            {
                local.Add(node.Attributes[key].InnerText.Trim(), node.Attributes[value].InnerText.Trim());

            }
            return local;
        }
    }
}
