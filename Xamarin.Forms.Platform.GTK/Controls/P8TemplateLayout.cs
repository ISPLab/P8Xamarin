using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;

namespace P8Xamarin.Controls
{
	public class P8TemplateLayout : AbsoluteLayout
	{
		private static object syncRoot = new Object();

	//	public virtual void Inititialize()
	//	{ }


		public static ObservableCollection<VisualElement> P8Children = new ObservableCollection<VisualElement>();
		public P8TemplateLayout()
		{
			HorizontalOptions = LayoutOptions.FillAndExpand;
			VerticalOptions = LayoutOptions.FillAndExpand;
		//	Inititialize();
			//WidthRequest = 555;
			//HeightRequest = 555;
		}


		//public event EventHandler ChildAdded;
	}
}
