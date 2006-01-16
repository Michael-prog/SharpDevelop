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
using System.Collections;
using System.ComponentModel;

using System.Drawing;	
	
/// <summary>
/// TODO - Add class summary
/// </summary>
/// <remarks>
/// 	created by - Forstmeier Peter
/// 	created on - 29.09.2005 11:57:30
/// </remarks>
namespace SharpReportCore {	
	public class BaseRectangleItem : SharpReportCore.BaseGraphicItem,IContainer {
		
		private ArrayList arrayList = null;
		RectangleShape shape = new RectangleShape();
		
		public BaseRectangleItem() {
			arrayList = new ArrayList();
		}
		
		public override void Render(ReportPageEventArgs rpea) {
			base.Render(rpea);
			SizeF measureSize = base.MeasureReportItem (rpea,this);
			RectangleF rect = base.DrawingRectangle (rpea,this.Size);
			
			shape.FillShape(rpea.PrintPageEventArgs.Graphics,
			                new SolidFillPattern(this.BackColor),
			                rect);
			
			shape.DrawShape (rpea.PrintPageEventArgs.Graphics,
			                 new BaseLine (this.ForeColor,base.DashStyle,base.Thickness),
			                 rect);
		}
		
		
		public override string ToString() {
			return "BaseRectangleItem";
		}
		
		
		
		#region System.ComponentModel.IContainer interface implementation
		public System.ComponentModel.ComponentCollection Components {
			get {
				IComponent[] datalist = new BaseReportItem[arrayList.Count];
            arrayList.CopyTo(datalist,0);
            return new ComponentCollection(datalist);
			}
		}
		
		public void Remove(System.ComponentModel.IComponent component) {
			throw new NotImplementedException();
		}
		
		public void Add(System.ComponentModel.IComponent component, string name) {
			throw new NotImplementedException();
		}
		
		public void Add(System.ComponentModel.IComponent component) {
			throw new NotImplementedException();
		}
		#endregion
		
		
		#region System.IDisposable interface implementation
		public override void Dispose() {
			base.Dispose();
			for (int i = 0; i < arrayList.Count;i ++ ) {
				IComponent curObj = (IComponent)arrayList[i];
            curObj.Dispose();
			}
			arrayList = null;
		}
		#endregion
		
		
	}
}
