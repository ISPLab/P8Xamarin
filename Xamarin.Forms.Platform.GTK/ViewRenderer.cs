using System;
using Cairo;
using Gdk;
using GLib;
using Gtk;
using Xamarin.Forms.Platform.GTK.Controls;
//using NativeView = Gtk.Widget;

namespace Xamarin.Forms.Platform.GTK
{
	public class AccessibleDesc
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
	public interface INativeView
	{
		INativeView Control { get; set; }
		bool Sensitive { get; set; }
		ImageAspect Aspect { get; set; }
		Pixbuf Pixbuf { get; set; }
	    AccessibleDesc C_Accessible { get; set; }

		SizeRequest GetDesiredSize(Double width, Double height);
		void Add(GtkFormsContainer container);
		void RemoveFromContainer(GtkFormsContainer container);
		void Dispose();

		event ButtonPressEventHandler ButtonPressEvent;
		void Destroy();
		void SetBorderWidth(uint borderWidth);
		void ResetBorderColor();
		void SetBorderColor(Gdk.Color?  color);
		void SetAlpha(double opacity);
		void UpdateSize(int height, int width);
		void UpdateBorderRadius(int topLeft, int topRight, int bottomLeft, int bottomRight);
		void UpdateBorderRadius();
		void ResetColor();
		void UpdateColor(Color color);
		void SetBackgroundColor(Color backgroundColor);
		void Start();
		void Stop();
		void SetSizeRequest(int width, int height);
	}
	/*public interface INativeElement
	{
		void Destroy();
	}*/
	public class NativeView : Gtk.Widget, INativeView
	{
		public INativeView Control { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public ImageAspect Aspect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Pixbuf Pixbuf { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		AccessibleDesc INativeView.C_Accessible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void Add(GtkFormsContainer container)
		{
			throw new NotImplementedException();
		}

		public SizeRequest GetDesiredSize(double width, double height)
		{
			throw new NotImplementedException();
		}

		public void RemoveFromContainer(GtkFormsContainer container)
		{
			throw new NotImplementedException();
		}

		public void ResetBorderColor()
		{
			throw new NotImplementedException();
		}

		public void ResetColor()
		{
			throw new NotImplementedException();
		}

		public void SetAlpha(double opacity)
		{
			throw new NotImplementedException();
		}

		public void SetBackgroundColor(Color backgroundColor)
		{
			throw new NotImplementedException();
		}

		public void SetBorderColor(Gdk.Color? color)
		{
			throw new NotImplementedException();
		}

		public void SetBorderWidth(uint borderWidth)
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			throw new NotImplementedException();
		}

		public void Stop()
		{
			throw new NotImplementedException();
		}

		public void UpdateBorderRadius(int topLeft, int topRight, int bottomLeft, int bottomRight)
		{
			throw new NotImplementedException();
		}

		public void UpdateBorderRadius()
		{
			throw new NotImplementedException();
		}

		public void UpdateColor(Color color)
		{
			throw new NotImplementedException();
		}

		public void UpdateSize(int height, int width)
		{
			throw new NotImplementedException();
		}
	}
	public class P8NativeView : INativeView
	{
		public INativeView Control { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public bool Sensitive { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public ImageAspect Aspect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public Pixbuf Pixbuf { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
		public AccessibleDesc C_Accessible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public event ButtonPressEventHandler ButtonPressEvent;

		public void Add(GtkFormsContainer container)
		{
			ButtonPressEvent.Invoke(this, new ButtonPressEventArgs());
			throw new NotImplementedException();
		}

		public void Destroy()
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}

		public SizeRequest GetDesiredSize(double width, double height)
		{
			throw new NotImplementedException();
		}

		public void RemoveFromContainer(GtkFormsContainer container)
		{
			throw new NotImplementedException();
		}

		public void ResetBorderColor()
		{
			throw new NotImplementedException();
		}

		public void ResetColor()
		{
			throw new NotImplementedException();
		}

		public void SetAlpha(double opacity)
		{
			throw new NotImplementedException();
		}

		public void SetBackgroundColor(Color backgroundColor)
		{
			throw new NotImplementedException();
		}

		public void SetBorderColor(Gdk.Color? color)
		{
			throw new NotImplementedException();
		}

		public void SetBorderWidth(uint borderWidth)
		{
			throw new NotImplementedException();
		}

		public void SetSizeRequest(int width, int height)
		{
			throw new NotImplementedException();
		}

		public void Start()
		{
			throw new NotImplementedException();
		}

		public void Stop()
		{
			throw new NotImplementedException();
		}

		public void UpdateBorderRadius(int topLeft, int topRight, int bottomLeft, int bottomRight)
		{
			throw new NotImplementedException();
		}

		public void UpdateBorderRadius()
		{
			throw new NotImplementedException();
		}

		public void UpdateColor(Color color)
		{
			throw new NotImplementedException();
		}

		public void UpdateSize(int height, int width)
		{
			throw new NotImplementedException();
		}
	}


	public abstract class ViewRenderer<TView, TNativeView> : VisualElementRenderer<TView, TNativeView>
		where TView : View where TNativeView : INativeView
	{
		private string _defaultAccessibilityLabel;
		private string _defaultAccessibilityHint;

		protected override void Dispose(bool disposing)
		{
			if (Control != null)
			{
				Control.Destroy();
				Control = null;
			}
			base.Dispose(disposing);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<TView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				UpdateBackgroundColor();
			}
		}

		protected override void SetNativeControl(TNativeView view)
		{
			base.SetNativeControl(view);

			Add(view as Widget);
		}

		protected override void SetAccessibilityHint()
		{
			if (Control == null)
			{
				base.SetAccessibilityHint();
				return;
			}

			if (Element == null)
				return;

			if (_defaultAccessibilityHint == null)
				_defaultAccessibilityHint = Control.C_Accessible.Name;

			var helpText = (string)Element.GetValue(AutomationProperties.HelpTextProperty) ?? _defaultAccessibilityHint;

			if (!string.IsNullOrEmpty(helpText))
			{
				Control.C_Accessible.Name = helpText;
			}
		}

		protected override void SetAccessibilityLabel()
		{
			if (Control == null)
			{
				base.SetAccessibilityLabel();
				return;
			}

			if (Element == null)
				return;

			if (_defaultAccessibilityLabel == null)
				_defaultAccessibilityLabel = Control.C_Accessible.Description;

			var name = (string)Element.GetValue(AutomationProperties.NameProperty) ?? _defaultAccessibilityLabel;

			if (!string.IsNullOrEmpty(name))
			{
				Control.C_Accessible.Description = name;
			}
		}
	}
}
