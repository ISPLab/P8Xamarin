using Gdk;
using Gtk;
using Xamarin.Forms.Platform.GTK.Controls;
using Xamarin.Forms.Platform.GTK.Packagers;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	public class CFixed : Gtk.Fixed, INativeView
	{
		public INativeView Control { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public ImageAspect Aspect { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public Pixbuf Pixbuf { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		AccessibleDesc INativeView.Accessible { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public void Add(GtkFormsContainer container)
		{
			throw new System.NotImplementedException();
		}

		public SizeRequest GetDesiredSize(double width, double height)
		{
			throw new System.NotImplementedException();
		}

		public void RemoveFromContainer(GtkFormsContainer container)
		{
			throw new System.NotImplementedException();
		}

		public void ResetBorderColor()
		{
			throw new System.NotImplementedException();
		}

		public void ResetColor()
		{
			throw new System.NotImplementedException();
		}

		public void SetAlpha(double opacity)
		{
			throw new System.NotImplementedException();
		}

		public void SetBackgroundColor(Color backgroundColor)
		{
			throw new System.NotImplementedException();
		}

		public void SetBorderColor(Gdk.Color? color)
		{
			throw new System.NotImplementedException();
		}

		public void SetBorderWidth(uint borderWidth)
		{
			throw new System.NotImplementedException();
		}

		public void Start()
		{
			throw new System.NotImplementedException();
		}

		public void Stop()
		{
			throw new System.NotImplementedException();
		}

		public void UpdateBorderRadius(int topLeft, int topRight, int bottomLeft, int bottomRight)
		{
			throw new System.NotImplementedException();
		}

		public void UpdateBorderRadius()
		{
			throw new System.NotImplementedException();
		}

		public void UpdateColor(Color color)
		{
			throw new System.NotImplementedException();
		}

		public void UpdateSize(int height, int width)
		{
			throw new System.NotImplementedException();
		}
	}
	public class LayoutRenderer : ViewRenderer<Layout, CFixed>
	{
		private CFixed _fixed;
		private LayoutElementPackager _packager;

		protected override void OnElementChanged(ElementChangedEventArgs<Layout> e)
		{
			if (e.OldElement != null)
			{
				e.OldElement.LayoutChanged -= LayoutChanged;
			}

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					if(_fixed == null)
					{
						// Use a Gtk.Fixed, a container which you to position widgets at fixed coordinates.
						// This allows apply transformations.
						_fixed = new CFixed();
					}

					SetNativeControl(_fixed);
				}

				e.NewElement.LayoutChanged += LayoutChanged;

				if (_packager == null)
				{
					_packager = new LayoutElementPackager(this);
				}

				_packager.Load();
			}

			base.OnElementChanged(e);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Element != null)
				{
					Element.LayoutChanged -= LayoutChanged;
				}
			}

			base.Dispose(disposing);
		}

		private void LayoutChanged(object sender, System.EventArgs e)
		{
			QueueResize();
		}
	}
}
