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
			//P8Template
			try
			{
				var viewRenderer = Platform.CreateRenderer(view);
				Platform.SetRenderer(view, viewRenderer);
				P8TemplateLayout.AddView(view);
			//	viewRenderer.Container.ShowAll();
			//	return;
				//(Renderer.Control as CFixed).Add(view);
				/*
				if(Renderer.Control == null)
				cash_view.Add(view);
				if(view is Editor)
				{

				}
				if (Renderer.Control != null && Renderer.Control is CFixed )
				{
			    	cash_view.ForEach(i => (Renderer.Control as CFixed).Add(i));
				    cash_view.Clear();
					//first_load = false;
				}
			    if (viewRenderer is ImageRenderer)
				{
		    		viewRenderer.Container.ShowAll();
				}*/
			} catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}
		}

		protected override void OnChildRemoved(VisualElement view)
		{
			
			P8Xamarin.Controls.P8TemplateLayout.RemoveView(view.Id);
			var viewRenderer = Platform.GetRenderer(view);
			var fixedControl = Renderer.Control;
			if(fixedControl!=null)
			fixedControl.RemoveFromContainer(viewRenderer.Container);
		}
	}
}
