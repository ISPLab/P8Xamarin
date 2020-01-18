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
		public ObservableCollection<VisualElement> P8Children = new ObservableCollection<VisualElement>();
		//public event EventHandler ChildAdded;
	}
}
