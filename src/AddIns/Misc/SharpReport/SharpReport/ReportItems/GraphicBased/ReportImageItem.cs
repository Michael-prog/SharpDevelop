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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using SharpReportCore;
using SharpReport.Designer;	
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 	created by - Forstmeier Peter
	/// 	created on - 04.10.2005 11:15:23
	/// </remarks>
namespace SharpReport.ReportItems {	
	
	public class ReportImageItem : BaseImageItem,SharpReport.Designer.IDesignable {
		
		private	ReportImageControl visualControl;
		private bool initDone;
		
		public ReportImageItem() :base(){
			visualControl = new ReportImageControl();
			this.visualControl.Click += new EventHandler(OnControlSelect);
			this.visualControl.VisualControlChanged += new EventHandler (OnControlChanged);
			this.visualControl.BackColorChanged += new EventHandler (OnControlChanged);
			this.visualControl.FontChanged += new EventHandler (OnControlChanged);
			this.visualControl.ForeColorChanged += new EventHandler (OnControlChanged);
			base.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler (BasePropertyChange);
			
			ItemsHelper.UpdateGraphicControl (this.visualControl,this);
			
			this.initDone = true;
		}
		
		#region overrides
		public override void Dispose() {
			base.Dispose();
			this.visualControl.Dispose();
		}
		
		public override string ToString(){
			return this.Name;
		}
		
		#endregion
		
		#region EventHandling
		
		private void BasePropertyChange (object sender, PropertyChangedEventArgs e){
			if (initDone == true) {

				this.visualControl.Location = base.Location;
				this.visualControl.Size = base.Size;
				
				if (base.Image != null) {
					this.visualControl.Image = base.Image;
					this.visualControl.ScaleImageToSize = base.ScaleImageToSize;
					this.visualControl.Invalidate();
				}
			}
		}
		
		private void OnControlChanged (object sender, EventArgs e) {
			ItemsHelper.UpdateGraphicControl (this.visualControl,this);
			this.FirePropertyChanged("OnControlChanged");
		}
		
		private void OnControlSelect(object sender, EventArgs e){
			if (Selected != null)
				Selected(this,e);
		}	
		
		/// <summary>
		/// A Property in ReportItem has changed, inform the Designer
		/// to set the View's 'IsDirtyFlag' to true
		/// </summary>
		
		protected void FirePropertyChanged(string info) {
			if ( !base.Suspend) {
				if (PropertyChanged != null) {
					PropertyChanged (this,new PropertyChangedEventArgs(info));
				}
			}
			
		}
		
		#endregion
		
		#region SharpReport.Designer.IDesignable interface implementation
		[System.Xml.Serialization.XmlIgnoreAttribute]
		[Browsable(false)]
		public ReportObjectControlBase VisualControl {
			get {
				return visualControl;
			}
		}
		
		public new event PropertyChangedEventHandler PropertyChanged;
		public event SelectedEventHandler Selected;
		#endregion
		
	}
}
