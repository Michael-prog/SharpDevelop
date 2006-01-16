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
using System.Reflection;
using System.Text;

using SharpReportCore;
	
	/// <summary>
	/// Factories used by the Designer
	/// </summary>
	/// <remarks>
	/// 	created by - Forstmeier Peter
	/// 	created on - 18.07.2005 23:12:24
	/// </remarks>
	
namespace SharpReport.Designer {
	
	public class FunctionFactory : SharpReportCore.GenericFactory {
		
		public FunctionFactory () :base(Assembly.GetExecutingAssembly(),typeof(BaseFunction)){
			
		}
		
		public new BaseFunction Create(string name) {
			return (BaseFunction) base.Create(name);
		}
	}
		
		public class IDesignableFactory : SharpReportCore.GenericFactory {
			
			public IDesignableFactory() :base(Assembly.GetExecutingAssembly(),typeof(IDesignable)){
			}
			
			public new  BaseReportItem Create(string name) {
				if (name.LastIndexOf('.') > 0) {
				StringBuilder b = new StringBuilder (name);
				b.Remove (0,name.LastIndexOf('.') +1);
				name = b.ToString();
			}
			return (BaseReportItem) base.Create (name);
			}
			
		}
}
