using System;
using System.Collections.Generic;
using System.Linq;
using P8Xamarin.Controls;
using Xamarin.Forms.Platform.GTK.Extensions;
using Xamarin.Forms.Platform.GTK.Renderers;

namespace Xamarin.Forms.Platform.GTK.Packagers
{
	public class LayoutElementPackager : VisualElementPackager<LayoutRenderer>
	{
		public LayoutElementPackager(LayoutRenderer renderer) 
			: base(renderer)
		{
		}

		
		static List<VisualElement> cash_view = new List<VisualElement>();
		protected override void OnChildAdded(VisualElement view)
		{
			try
			{
				var viewRenderer = Platform.CreateRenderer(view);
				Platform.SetRenderer(view, viewRenderer);
				cash_view.Add(view);
				if (Renderer.Control != null && Renderer.Control is CFixed)
				{
						cash_view.ForEach(i => (Renderer.Control as CFixed).Add(i));
						cash_view.Clear();
				}
			if (viewRenderer is ImageRenderer)
				viewRenderer.Container.ShowAll();
			} catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
		}

		protected override void OnChildRemoved(VisualElement view)
		{
			try
			{
				var res = P8Xamarin.Controls.P8TemplateLayout.P8Children.ToList().SingleOrDefault(c => c.Id == view.Id);
				if(res!=null)
				P8Xamarin.Controls.P8TemplateLayout.P8Children.Remove(res);
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
			var viewRenderer = Platform.GetRenderer(view);

			var fixedControl = Renderer.Control;
			if(fixedControl!=null)
			fixedControl.RemoveFromContainer(viewRenderer.Container);
		}
	}
}
