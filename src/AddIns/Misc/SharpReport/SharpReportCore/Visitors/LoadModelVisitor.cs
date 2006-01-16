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

using SharpReportCore;

	/// <summary>
	/// Fill's the ReportModel from File
	/// </summary>
	/// <remarks>
	/// 	created by - Forstmeier Peter
	/// 	created on - 03.03.2005 16:36:09
	/// </remarks>
namespace SharpReportCore {	
	public class LoadModelVisitor : SharpReportCore.AbstractModelVisitor {
		
		private string fileName;
		private ReportModel model;
		SharpReportCore.XmlFormReader xmlFormReader;
		BaseItemFactory baseItemFactory;
		
		public LoadModelVisitor(ReportModel reportModel,string fileName){
			this.fileName = fileName;
			this.model = reportModel;
			baseItemFactory = new BaseItemFactory();
		}
		
		
		#region overrides
		public override void Visit(ReportModel model) {
			if (model != null) {
				XmlDocument xmlDoc;
				try {
					xmlDoc = XmlHelper.OpenSharpReport (fileName);
					xmlFormReader = new XmlFormReader();
					model.ReportSettings.SetSettings ((XmlElement)xmlDoc.DocumentElement.FirstChild);
					SetSections (xmlDoc);
				} catch (Exception ) {
					throw;
				}
			} else {
				System.ArgumentNullException e = new System.ArgumentNullException ("LoadModelVisitor:Visit -> No valid Model");
				throw e;
			}
		}
		#endregion
		
		#region setsections
		void SetSections (XmlDocument doc) {
			XmlNodeList sectionNodes = doc.DocumentElement.ChildNodes;
			//Start with node(1)
			XmlNode node;
			BaseSection baseSection;
			for (int i = 1;i < sectionNodes.Count ; i++ ) {
				node = sectionNodes[i];
				
				if (node is XmlElement) {
					XmlElement sectionElem = (XmlElement)node;
					baseSection = (BaseSection)model.SectionCollection.Find(sectionElem.GetAttribute("name"));
					if (baseSection != null) {
						XmlHelper.SetSectionValues (xmlFormReader,sectionElem,baseSection);
						XmlNodeList ctrlList = sectionElem.SelectNodes ("controls/control");
						if (ctrlList.Count > 0) {
							foreach (XmlNode ctrlNode in ctrlList) {
								if (ctrlNode is XmlElement) {
									XmlElement ctrlElem = (XmlElement)ctrlNode;
									BaseReportItem rpt = null;
									try {
										//Read the <BaseClassName> Element
										rpt = (BaseReportItem)baseItemFactory.Create(ctrlElem.GetAttribute("basetype"));
										if (rpt != null) {
											rpt.SuspendLayout();
											rpt.Parent = baseSection;
											baseSection.Items.Add (rpt);
											XmlHelper.BuildControl (xmlFormReader,ctrlElem,rpt);
											rpt.Visible = true;
											rpt.ResumeLayout();
										} else {
											SharpReportUnkownItemException e = new SharpReportUnkownItemException();
											throw e;
										}
									} catch (Exception ) {
										throw;
									}
								}
							}
						}
					}else {
						SharpReportException ex = new SharpReportException ("Wrong Section Name <" + sectionElem.GetAttribute("name") + ">");
						throw ex;
					}
				}else {
					throw new System.Xml.XmlException ("Report : SetSection Wrong Node in Report");
				}
			}
		}
		
		#endregion
		
	}
}
