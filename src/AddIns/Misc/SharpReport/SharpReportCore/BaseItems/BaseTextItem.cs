//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.2032
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace SharpReportCore {
	using System;
	using System.ComponentModel;
	using System.Drawing;
	
	using SharpReportCore;
	
	
	/// <summary>
	/// Parent for all TextBased Items
	/// </summary>
	/// <remarks>
	
	public class BaseTextItem : SharpReportCore.BaseReportItem,IItemRenderer {
		private string text;

		private string formatString = String.Empty;
		private StringAlignment stringAlignment = StringAlignment.Near;
		private StringFormat standartStringFormat;
		private TextDrawer textDrawer = new TextDrawer();
	
		public BaseTextItem() {
			this.standartStringFormat = GlobalValues.StandartStringFormat();
		}
		
		public override void Render(ReportPageEventArgs e) {
			base.Render(e);
			RectangleF rect = PrepareRectangle (e,this.Text);
			PrintTheStuff (e,this.Text,rect);
			base.OnAfterPrint (e.LocationAfterDraw);
		}
		
		public override string ToString() {
			return "BaseTextItem";
		}
		
		private void Decorate (ReportPageEventArgs rpea,Rectangle border) {
			using (SolidBrush brush = new SolidBrush(base.BackColor)) {
				rpea.PrintPageEventArgs.Graphics.FillRectangle(brush,border);
			}
			if (base.DrawBorder == true) {
				using (Pen pen = new Pen(Color.Black, 1)) {
					rpea.PrintPageEventArgs.Graphics.DrawRectangle (pen,border);
				}
			}
		}
		
		protected RectangleF PrepareRectangle (ReportPageEventArgs e,string text) {
			SizeF measureSize = new SizeF ();
			measureSize = MeasureReportItem (e,text);			
			RectangleF rect = base.DrawingRectangle (e,measureSize);
			Decorate (e,System.Drawing.Rectangle.Ceiling (rect));
			return rect;
		}
		///<summary>
		/// Measure the Size of the String rectangle
		/// </summary>
		
		private SizeF MeasureReportItem (ReportPageEventArgs e,string text) {
			SizeF measureSizeF = new SizeF ();

			measureSizeF = e.PrintPageEventArgs.Graphics.MeasureString(text,
			                                                          this.Font,
			                                                          this.Size.Width,
			                                                          StandartStringFormat);
			return measureSizeF;
		}
		
		/// <summary>
		/// Standart Function to Draw Strings
		/// </summary>
		/// <param name="e">ReportpageEventArgs</param>
		/// <param name="toPrint">Formatted String toprint</param>
		/// <param name="rectangle">rectangle where to draw the string</param>
	
		protected void PrintTheStuff (ReportPageEventArgs e,
		                              string toPrint,
		                              RectangleF rectangle ) {
			
			
			StringFormat fmt = StandartStringFormat;
			fmt.Alignment = this.StringAlignment;
			
			textDrawer.DrawString(e.PrintPageEventArgs.Graphics,
			                      toPrint,
			                      this.Font,
			                      new SolidBrush(this.ForeColor),
			                      rectangle,
			                      fmt);

			e.LocationAfterDraw = new PointF (this.Location.X + this.Size.Width,
			                                  this.Location.Y + this.Size.Height);
		}
	
		///<summary>
		/// Formatstring like in MSDN
		/// </summary>
		[Browsable(true),
		 Category("Appearance"),
		 Description("String to format Number's Date's etc")]
		
		public virtual string FormatString {
			get {
				return formatString;
			}
			set {
				formatString = value;
				base.NotifyPropertyChanged("FormatString");
			}
		}
		
		
		///<summary>
		/// StringAlignment Near = Left,Center,Far = Right
		/// </summary>
		
		[Browsable(true),
		 Category("Appearance"),
		 Description("Alignment of Output Near,Center,Far")]
		public virtual StringAlignment StringAlignment {
			get {
				return stringAlignment;
			}
			set {
				stringAlignment = value;
				base.NotifyPropertyChanged("StringAligment");
			}
		}
		
		
		public virtual string Text {
			get {
				return text;
			}
			set {
				text = value;
				base.NotifyPropertyChanged("Text");
			}
		}
		
		[Browsable(false)]
		public StringFormat StandartStringFormat {
			get {
				return standartStringFormat;
			}
			set {
				standartStringFormat = value;
			}
		}

	}
}
