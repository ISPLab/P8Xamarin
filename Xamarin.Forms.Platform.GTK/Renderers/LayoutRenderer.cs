using Gdk;
using Gtk;
using P8Xamarin.Controls;
using Xamarin.Forms.Platform.GTK.Controls;
using Xamarin.Forms.Platform.GTK.Packagers;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	public class GtkFixed : Gtk.Fixed, IGTKNativeView
	{
		public IGTKNativeView Control { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public ImageAspect Aspect { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public Pixbuf Pixbuf { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
		public AccessibleDesc C_Accessible { get => new AccessibleDesc(); set { } }

		public void Add(GtkFormsContainer container)
		{
			P8Parent.Add(container);
			/*base.Add(container);
			if (Children.Length < 3)
			{ //this p8 render 
				container.WidthRequest = int.MaxValue;
				//container.HeightRequest = int.MaxValue;
			}
			/*else
			{
		
				
			  //to our control
			}*/
		}
		public void AddP8View(VisualElement visualelement)
		{
			P8Parent.Add(visualelement);
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

		public CFixed P8Parent { get; internal set; }
	}

	public class CFixed :/* Gtk.Fixed,*/ IGTKNativeView
	{
		//public GtkFixed _fixed { get; set; }

		P8TemplateLayout layout;
		public CFixed(P8TemplateLayout layout): base()
		{
			this.layout = layout;
		   //	_fixed = new GtkFixed();
		   //	_fixed.P8Parent = this;
		  
		}
		public IGTKNativeView Control { get; set; }
		public ImageAspect Aspect { get; set; }
		public Pixbuf Pixbuf { get; set; }
		public bool Sensitive { get; set; }
		AccessibleDesc IGTKNativeView.C_Accessible { get => new AccessibleDesc(); set => throw new System.NotImplementedException(); }
		public bool IsFocus { get; set; }

		public event ButtonPressEventHandler ButtonPressEvent;

		public void OnButtonPressed()
		{
			ButtonPressEvent?.Invoke(this, new ButtonPressEventArgs());
		}
		public void Add(VisualElement container)
		{
			P8Xamarin.Controls.P8TemplateLayout.AddView(container);
		}

		public void Destroy()
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}

		public SizeRequest GetDesiredSize(double width, double height)
		{
			throw new System.NotImplementedException();
		}

		public void RemoveFromContainer(GtkFormsContainer container)
		{
			//throw new System.NotImplementedException();
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

		public void SetSizeRequest(int width, int height)
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

		public void Add(GtkFormsContainer container)
		{
			
		}
	}
	public class LayoutRenderer : ViewRenderer<Layout, CFixed>
	{
		private CFixed _p8layout;
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
					if(_p8layout == null)
					{
						// Use a Gtk.Fixed, a container which you to position widgets at fixed coordinates.
						// This allows apply transformations.
						if (e.NewElement is P8TemplateLayout)
							_p8layout = new CFixed(e.NewElement as P8TemplateLayout);
					}

					SetNativeControl(_p8layout);
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
