using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapCore
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class XmlNamespaceAttribute : Attribute
	{
		public XmlNamespaceAttribute(string Prefix, string Namespace)
		{
			this.Prefix = Prefix;
			this.Namespace = Namespace;
		}
		public string Prefix { get; set; }
		public string Namespace { get; set; }
	}
}
