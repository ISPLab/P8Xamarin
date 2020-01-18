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

		protected override void OnChildAdded(VisualElement view)
		{
			var viewRenderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, viewRenderer);

			var fixedControl = Renderer.Control;
			if (view is Image || view is P8TemplateLayout)
			{
				fixedControl?.Add(viewRenderer.Container);
			}
			else
			{
				(fixedControl as GtkFixed).AddP8View(view);
			}

		
			//if(viewRenderer.Container)
			//if(viewRenderer is P8I)
			if(viewRenderer is ImageRenderer)
			viewRenderer.Container.ShowAll();
		}

		protected override void OnChildRemoved(VisualElement view)
		{
			var viewRenderer = Platform.GetRenderer(view);

			var fixedControl = Renderer.Control;
			fixedControl.RemoveFromContainer(viewRenderer.Container);
		}
	}
}
