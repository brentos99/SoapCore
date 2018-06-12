using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Xml;
using System.Xml.Serialization;

namespace SoapCore
{
	public class CustomMessage : Message
	{
		private readonly Message _message;
		private readonly XmlSerializerNamespaces _xmlNs;

		public CustomMessage(Message message, XmlSerializerNamespaces xmlNs)
		{
			_message = message;
			_xmlNs = xmlNs;
		}

		protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
		{
			writer.WriteStartDocument();
			if (_message.Version.Envelope == EnvelopeVersion.Soap11)
			{
				writer.WriteStartElement("s", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
			}
			else
			{
				writer.WriteStartElement("s", "Envelope", "http://www.w3.org/2003/05/soap-envelope");
			}
			writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
			writer.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");

			foreach (var ns in _xmlNs?.ToArray())
			{
				writer.WriteXmlnsAttribute(ns.Name, ns.Namespace);
			}

		}

		protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
		{
			_message.WriteBodyContents(writer);
		}

		public override MessageHeaders Headers
		{
			get { return _message.Headers; }
		}

		public override MessageProperties Properties
		{
			get { return _message.Properties; }
		}

		public override MessageVersion Version
		{
			get { return _message.Version; }
		}
	}
}
