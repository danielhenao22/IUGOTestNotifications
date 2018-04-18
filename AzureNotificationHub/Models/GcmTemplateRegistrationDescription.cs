using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace AzureNotificationHub.Models
{
    public class GcmTemplateRegistrationDescription : GcmRegistrationDescription
    {
        public GcmTemplateRegistrationDescription()
        {

        }

       

        public GcmTemplateRegistrationDescription(string eTag, string expirationTime, string registrationId, string tags, string gcmRegistrationId, string v) : base(eTag, expirationTime, registrationId, tags, gcmRegistrationId)
        {
        }


        public GcmTemplateRegistrationDescription(string eTag, string expirationTime, string registrationId, string tags, string gcmRegistrationId, string bodyTemplate, string templateName) : base(eTag, expirationTime, registrationId, tags, gcmRegistrationId)
        {
            BodyTemplate = bodyTemplate;
            TemplateName = templateName;
        }

        public string BodyTemplate { get; set; }

        public string TemplateName { get; set; }

        public override RegistrationDescription Deserialize(IEnumerable<XElement> xml)
        {
            base.Deserialize(xml);

            BodyTemplate = xml.FirstOrDefault(f => f.Name.LocalName == "BodyTemplate")?.Value;
            TemplateName = xml.FirstOrDefault(f => f.Name.LocalName == "TemplateName")?.Value;

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

            XmlElement GcmTemplateRegistrationDescription = doc.CreateElement("GcmTemplateRegistrationDescription", "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect");
            GcmTemplateRegistrationDescription.SetAttribute("xmlns:i", "http://www.w3.org/2001/XMLSchema-instance");
            content.AppendChild(GcmTemplateRegistrationDescription);

            XmlElement tags = doc.CreateElement("Tags");
            tags.InnerXml = Tags;
            GcmTemplateRegistrationDescription.AppendChild(tags);

            XmlElement gcmRegistrationId = doc.CreateElement("GcmRegistrationId");
            gcmRegistrationId.InnerXml = GcmRegistrationId;
            GcmTemplateRegistrationDescription.AppendChild(gcmRegistrationId);

            XmlElement bodyTemplate = doc.CreateElement("BodyTemplate");
            bodyTemplate.InnerXml = BodyTemplate;
            GcmTemplateRegistrationDescription.AppendChild(bodyTemplate);

            return doc.OuterXml.Replace("xmlns=\"\"", "");
        }
    }
}
