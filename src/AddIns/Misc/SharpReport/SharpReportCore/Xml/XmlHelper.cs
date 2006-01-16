//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Xml;
using System.Windows.Forms;
	
	
	
/// <summary>
/// This class contains some basic methodes to handel Xml related stuff
/// </summary>
/// <remarks>
/// 	created by - Forstmeier Helmut
/// 	created on - 31.08.2005 17:14:18
/// </remarks>
/// 
namespace SharpReportCore {	
	public class XmlHelper : object {
		
		///<summary>
		/// Build a XmlDocument
		/// </summary>
	
		public static XmlDocument BuildXmlDocument() {
			XmlDocument doc = new XmlDocument();
			XmlDeclaration dec =  doc.CreateXmlDeclaration("1.0",null, "yes");
			doc.PrependChild ( dec );
			return doc;
		}
		
		/// <summary>
		/// SharpReport must start with DocumentElement.Name == "SharpReport"
		/// defiened in GlobalEums
		/// </summary>
		/// <param name="elem">DocumentElemen of XmlDocument</param>
		/// <returns>"Report is SharpReport or not</returns>/returns>
		/// 
		public static bool IsSharpReport (XmlElement elem) {
			bool isOk = false;
			try {
				if (elem.Name.Equals (SharpReportCore.GlobalValues.SharpReportString)) {
			    	isOk = true;
			 	}
			} catch (Exception e) {
				throw e;
			}
			return isOk;
		}
		
		/// <summary>
		/// Read a SharpReport from File and check's if the document is a valid SharpReport
		/// valid mean's DocumentElement.Text = "SharpReport"
		/// This function does no check if the File
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns>XmlDocument</returns>
		
		public static XmlDocument OpenSharpReport (string fileName) {
			XmlTextReader reader = null;
			
			XmlDocument xmlDoc = new XmlDocument();
			try {
				reader = new XmlTextReader (fileName);
				reader.WhitespaceHandling = WhitespaceHandling.All;
				xmlDoc.Load (reader);
				if (xmlDoc.DocumentElement != null) {
					if (XmlHelper.IsSharpReport (xmlDoc.DocumentElement)) {
						// Valid Document
						return xmlDoc;
					} else {
						throw new SharpReportException ("XmlHelper.OpenSharpReport - > No SharpReport");
					}
				} else {
					throw new SharpReportException ("XmlHelper.OpenSharpReport - >  No valid DocumentElement");
				}
			}
			catch (System.Xml.XmlException) {
				IllegalFileFormatException wf = new IllegalFileFormatException("XmlHelper.OpenSharpReport - > Wrong File Format");
				throw wf;
			}
			catch (Exception) {
				throw;
			} finally {
				if (reader != null) {
					reader.Close();
				}
			}
		}
		
		/// <summary>
		/// Fill a  <see cref="ReportSection"></see> with value from
		/// an XmlElement
		/// </summary>
		/// <param name="reader"><see cref="XmlFormreader"></see> 
		/// </param>
		/// <param name="element">Valid XmlElement</param>
		/// <param name="section"> Section to fill with values</param>
		public static void SetSectionValues (XmlFormReader reader,
		                                     XmlElement element,
		                                     BaseReportObject section) {
			XmlNodeList nodeList = element.ChildNodes;
			
			foreach (XmlNode node in nodeList) {
				if (node is XmlElement) {
					XmlElement elem = (XmlElement) node;
					if (elem.HasAttribute("value")) {
						try {
							reader.SetValue (section,elem.Name,elem.GetAttribute("value"));
						} catch (Exception e) {
							MessageBox.Show (elem.Name + " / " + elem.GetAttribute("value"));
							MessageBox.Show (e.Message);
						}
						
					}
				} else {
					throw new System.Xml.XmlException ("Report : SetValues Wrong Node in Report");
				}
			}
		}
		
		/// <summary>
		/// Set the values for each Control
		/// </summary>
		/// <param name="reader">See XMLFormReader</param>
		/// <param name="item">The Control for wich the values are</param>
		/// <param name="ctrlElem">Element witch contains the values</param>
		public static void BuildControl (XmlFormReader reader,
		                                 XmlElement ctrlElem,
		                                BaseReportItem item) {
			
			try {
				XmlNodeList nodeList = ctrlElem.ChildNodes;
				foreach (XmlNode node in nodeList) {
				if (node is XmlElement) {
					XmlElement elem = (XmlElement)node;
					if (elem.HasAttribute("value")) {
						if (elem.Name == "Font") {
							
//							MessageBox.Show ("FOnt " + elem.GetAttribute("value").ToString(),"BuildCOntrol");
							item.Font = XmlFormReader.MakeFont (elem.GetAttribute("value"));
						}
						reader.SetValue (item,elem.Name,elem.GetAttribute("value"));
					}
				}
			}
			} catch (Exception) {
				throw;
			}
		}
	}
}
