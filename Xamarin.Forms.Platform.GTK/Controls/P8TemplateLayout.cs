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
		private static ObservableCollection<VisualElement> P8Children = new ObservableCollection<VisualElement>();
		public event EventHandler<System.Collections.Specialized.NotifyCollectionChangedEventArgs> ViewCollectionChanged;
		public P8TemplateLayout()
		{
			HorizontalOptions = LayoutOptions.FillAndExpand;
			VerticalOptions = LayoutOptions.FillAndExpand;
			P8Children.CollectionChanged += (s, ev) => ViewCollectionChanged?.Invoke(s, ev);
		}
	
		public static bool RemoveView(Guid id)
		{
			if (Contains(id))
			{
				var element = P8Children.Single(e => e.Id.Equals(id));
				return P8Children.Remove(element);
			}
			return false;
		}
		public static bool AddView(VisualElement element)
		{
			if (element is Editor)
			{

			}
			if (Contains(element.Id))
				return false;
			P8Children.Add(element);
			return true;
		}
		public static bool Contains(Guid id)
		{
			if (P8Children.SingleOrDefault(c => c.Id.Equals(id)) != null)
				return true;
			else
				return false;
		}
	}
}
