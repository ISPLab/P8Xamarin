using Xamarin.Forms.Platform.GTK.Packagers;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	public class PageRenderer : AbstractPageRenderer<Controls.Page, Page>
	{
		private PageElementPackager _packager;

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (_packager != null)
			{
				_packager.Dispose();
				_packager = null;
			}
		}

		protected override void OnShown()
		{
			base.OnShown();

			if (_packager == null)
			{
				_packager = new PageElementPackager(this);
			}
			_packager.Load();
		}
		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			if (!Sensitive)
				return;
			double ratio = 72d;
			var platform = Helpers.PlatformHelper.GetGTKPlatform();
			if(platform== Helpers.GTKPlatform.Windows)
			  ratio = 96d;
			ratio = ratio /Gdk.Display.Default.DefaultScreen.Resolution;
			Gdk.Rectangle s_allocation = new Gdk.Rectangle(0, 0, (int)(allocation.Width / ratio), (int)(allocation.Height / ratio));
			base.OnSizeAllocated(s_allocation); 		
		}
	}
}
