using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AzureNotificationHub.Models
{
    public class AppleTemplateRegistrationDescription : AppleRegistrationDescription
    {

        public AppleTemplateRegistrationDescription()
        {

        }

        public string BodyTemplate { get; set; }

        public AppleTemplateRegistrationDescription(string registrationId, string tags, string deviceToken, string bodyTemplate) : base(registrationId, tags, registrationId, tags, deviceToken)
        {
            BodyTemplate = bodyTemplate;
        }

        public override RegistrationDescription Deserialize(IEnumerable<XElement> xml)
        {
            base.Deserialize(xml);

            BodyTemplate = xml.FirstOrDefault(f => f.Name.LocalName == "BodyTemplate")?.Value;

            return this;
        }

        public override string SerializeAsEntry()
        {
            //T
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement entry = doc.CreateElement(string.Empty, "entry", "http://www.w3.org/2005/Atom");
            doc.AppendChild(entry);

            XmlElement content = doc.CreateElement("content");
            content.SetAttribute("type", "application/xml");
            entry.AppendChild(content);

            XmlElement AppleTemplateRegistrationDescription = doc.CreateElement("AppleTemplateRegistrationDescription", "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect");
            AppleTemplateRegistrationDescription.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
            content.AppendChild(AppleTemplateRegistrationDescription);

            XmlElement tags = doc.CreateElement("Tags");
            tags.InnerXml = Tags;
            AppleTemplateRegistrationDescription.AppendChild(tags);

            XmlElement gcmRegistrationId = doc.CreateElement("DeviceToken");
            gcmRegistrationId.InnerXml = DeviceToken;
            AppleTemplateRegistrationDescription.AppendChild(gcmRegistrationId);

            XmlElement bodyTemplate = doc.CreateElement("BodyTemplate");
            bodyTemplate.InnerXml = BodyTemplate;
            AppleTemplateRegistrationDescription.AppendChild(bodyTemplate);

            return doc.OuterXml.Replace("xmlns=\"\"", "");
        }
    }
}
