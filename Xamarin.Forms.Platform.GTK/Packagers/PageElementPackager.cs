using Xamarin.Forms.Platform.GTK.Renderers;

namespace Xamarin.Forms.Platform.GTK.Packagers
{
	public class PageElementPackager : VisualElementPackager<PageRenderer>
	{
		public PageElementPackager(PageRenderer renderer) 
			: base(renderer)
		{
		}

		public override void Load()
		{
			if(ElementController.LogicalChildren.Count>1)
			{
				throw new System.Exception("Support only p8 tepmlate");
			}
			for (var i = 0; i < ElementController.LogicalChildren.Count; i++)
			{
				var child = ElementController.LogicalChildren[i] as VisualElement;
				if (child != null)
					//OnChildAdded(child);
					AddP8Template(child);
			}
		}
		public void AddP8Template(VisualElement view)
		{
			var viewRenderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, viewRenderer);

			Gtk.Container container = Renderer.Container;
			//if (view is Image || view is P8Xamarin.Controls.P8TemplateLayout)
			{
				container?.Add(viewRenderer.Container);
				viewRenderer.Container.ShowAll();
			}
			/*else
			if (container is GtkFixed)
			{
				(container as GtkFixed).AddP8View(view);
			}*/
		}

		protected override void OnChildAdded(VisualElement view)
		{
			var viewRenderer = Platform.CreateRenderer(view);
			Platform.SetRenderer(view, viewRenderer);

			Controls.Page page = Renderer.Control;
			page.Content = viewRenderer.Container;

			viewRenderer.Container.ShowAll();
		}

		protected override void OnChildRemoved(VisualElement view)
		{
		}
	}
}
