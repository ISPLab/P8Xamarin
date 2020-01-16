using Gdk;
using Gtk;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.GTK.Extensions;
using Xamarin.Forms.Platform.GTK.Helpers;
using NativeLabel = Gtk.Label;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	/*public class LabelRenderer : ViewRenderer<Label, NativeLabel>
	{
		private SizeRequest _perfectSize;
		private bool _perfectSizeValid;
		private bool _allocated;

		public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			if (!_allocated && PlatformHelper.GetGTKPlatform() == GTKPlatform.Windows)
			{
				return default(SizeRequest);
			}

			if (!_perfectSizeValid)
			{
				_perfectSize = GetPerfectSize();
				_perfectSize.Minimum = new Size(Math.Min(10, _perfectSize.Request.Width), _perfectSize.Request.Height);
				_perfectSizeValid = true;
			}

			var widthFits = widthConstraint >= _perfectSize.Request.Width;
			var heightFits = heightConstraint >= _perfectSize.Request.Height;

			if (widthFits && heightFits)
				return _perfectSize;

			var result = GetPerfectSize((int)widthConstraint);
			var tinyWidth = Math.Min(10, result.Request.Width);
			result.Minimum = new Size(tinyWidth, result.Request.Height);

			if (widthFits || Element.LineBreakMode == LineBreakMode.NoWrap)
			{
				return new SizeRequest(
					new Size(result.Request.Width, _perfectSize.Request.Height),
					new Size(result.Minimum.Width, _perfectSize.Request.Height));
			}

			bool containerIsNotInfinitelyWide = !double.IsInfinity(widthConstraint);

			if (containerIsNotInfinitelyWide)
			{
				bool textCouldHaveWrapped = Element.LineBreakMode == LineBreakMode.WordWrap || Element.LineBreakMode == LineBreakMode.CharacterWrap;
				bool textExceedsContainer = result.Request.Width > widthConstraint;

				if (textExceedsContainer || textCouldHaveWrapped)
				{
					var expandedWidth = Math.Max(tinyWidth, widthConstraint);
					result.Request = new Size(expandedWidth, result.Request.Height);
				}
			}

			return result;
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new NativeLabel());
				}

				UpdateText();
				UpdateColor();
				UpdateLineBreakMode();
				UpdateTextAlignment();
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Label.TextColorProperty.PropertyName)
				UpdateColor();
			else if (e.PropertyName == Label.FontProperty.PropertyName)
				UpdateText();
			else if (e.PropertyName == Label.TextProperty.PropertyName)
				UpdateText();
			else if (e.PropertyName == Label.FontAttributesProperty.PropertyName)
				UpdateText();
			else if (e.PropertyName == Label.FormattedTextProperty.PropertyName)
				UpdateText();
			else if (e.PropertyName == Label.HorizontalTextAlignmentProperty.PropertyName || e.PropertyName == Label.VerticalTextAlignmentProperty.PropertyName)
				UpdateTextAlignment();
			else if (e.PropertyName == Label.LineBreakModeProperty.PropertyName)
				UpdateLineBreakMode();
		}

		protected override void SetAccessibilityLabel()
		{
			var elemValue = (string)Element?.GetValue(AutomationProperties.NameProperty);

			if (string.IsNullOrWhiteSpace(elemValue) 
				&& Control?.Accessible.Description == Control?.Text)
				return;

			base.SetAccessibilityLabel();
		}

		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			base.OnSizeAllocated(allocation);

			_allocated = true;

			Control.Layout.Width = Pango.Units.FromPixels((int)Element.Bounds.Width);
		}

		private void UpdateText()
		{
			_perfectSizeValid = false;

			string markupText = string.Empty;
			FormattedString formatted = Element.FormattedText;

			if (formatted != null)
			{
				Control.SetTextFromFormatted(formatted);
			}
			else
			{
				var span = new Span()
				{
					FontAttributes = Element.FontAttributes,
					FontFamily = Element.FontFamily,
					FontSize = Element.FontSize,
					Text = Element.Text ?? string.Empty
				};

				Control.SetTextFromSpan(span);
			}
		}

		protected override void Draw(Gdk.Rectangle area, Cairo.Context cr)
		{
			Xamarin.Forms.Color _color = Xamarin.Forms.Color.Blue;
			Gdk.Pixbuf pix;
			var alloc = Allocation;
			var imgInfo = new SKImageInfo(alloc.Width, alloc.Height, SKImageInfo.PlatformColorType, SKAlphaType.Premul);
			pix = new Gdk.Pixbuf(Gdk.Colorspace.Rgb, true, 8, imgInfo.Width, imgInfo.Height);
            var source = cr.GetSource();
			//Free object
			pix.Dispose();
			source?.Dispose();
			source = null;
			pix = new Gdk.Pixbuf(Gdk.Colorspace.Rgb, true, 8, imgInfo.Width, imgInfo.Height);
			Gdk.CairoHelper.SetSourcePixbuf(cr,pix,0,0);
			cr.Fill();

           // cr.SetSource()
			
/*
			var surface = SKSurface.Create(imgInfo, pix.Pixels, imgInfo.RowBytes);
			using (new SKAutoCanvasRestore(surface.Canvas, true))
			{
				OnPaintSurface(new SKPaintSurfaceEventArgs(surface, imgInfo));
			}
			

			if (_color.IsDefaultOrTransparent())
			{
				return;
			}
			int _width = 10;
			var source =cr.GetSource();
		    
			int _height = 10;
			double _topLeftRadius = 4;
			double _topRightRadius = 10;
			double _bottomLeftRadius = 2;
			double _bottomRightRadius = 3;

			double radius = _topLeftRadius;
			int x = 20;
			int y = 0;
			int width = _width;
			int height = _height;
		
			cr.MoveTo(x, y);
			cr.Arc(x + width - _topRightRadius, y + _topRightRadius, _topRightRadius, Math.PI * 1.5, Math.PI * 2);
			cr.Arc(x + width - _bottomRightRadius, y + height - _bottomRightRadius, _bottomRightRadius, 0, Math.PI * .5);
			cr.Arc(x + _bottomLeftRadius, y + height - _bottomLeftRadius, _bottomLeftRadius, Math.PI * .5, Math.PI);
			cr.Arc(x + _topLeftRadius, y + _topLeftRadius, _topLeftRadius, Math.PI, Math.PI * 1.5);

			cr.SetSourceRGBA(_color.R, _color.G, _color.B, _color.A);

			cr.Fill();*/
	/*	}

		private void UpdateColor()
		{
			if (Control == null)
				return;

			var textColor = Element.TextColor != Color.Default ? Element.TextColor : Color.Black;

			Control.ModifyFg(StateType.Normal, textColor.ToGtkColor());
		}

		private void UpdateTextAlignment()
		{
			var hAlignmentValue = GetAlignmentValue(Element.HorizontalTextAlignment);
			var vAlignmentValue = GetAlignmentValue(Element.VerticalTextAlignment);

			Control.SetAlignment(hAlignmentValue, vAlignmentValue);
		}

		private void UpdateLineBreakMode()
		{
			_perfectSizeValid = false;

			switch (Element.LineBreakMode)
			{
				case LineBreakMode.NoWrap:
					Control.LineWrap = false;
					Control.Ellipsize = Pango.EllipsizeMode.None;
					break;
				case LineBreakMode.WordWrap:
					Control.LineWrap = true;
					Control.LineWrapMode = Pango.WrapMode.Word;
					Control.Ellipsize = Pango.EllipsizeMode.None;
					break;
				case LineBreakMode.CharacterWrap:
					Control.LineWrap = true;
					Control.LineWrapMode = Pango.WrapMode.Char;
					Control.Ellipsize = Pango.EllipsizeMode.None;
					break;
				case LineBreakMode.HeadTruncation:
					Control.LineWrap = false;
					Control.LineWrapMode = Pango.WrapMode.Word;
					Control.Ellipsize = Pango.EllipsizeMode.Start;
					break;
				case LineBreakMode.TailTruncation:
					Control.LineWrap = false;
					Control.LineWrapMode = Pango.WrapMode.Word;
					Control.Ellipsize = Pango.EllipsizeMode.End;
					break;
				case LineBreakMode.MiddleTruncation:
					Control.LineWrap = false;
					Control.LineWrapMode = Pango.WrapMode.Word;
					Control.Ellipsize = Pango.EllipsizeMode.Middle;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private float GetAlignmentValue(TextAlignment alignment)
		{
			_perfectSizeValid = false;

			switch (alignment)
			{
				case TextAlignment.Start:
					return 0f;
				case TextAlignment.End:
					return 1f;
				default:
					return 0.5f;
			}
		}

		private SizeRequest GetPerfectSize(int widthConstraint = -1)
		{
			int w, h;
			Control.Layout.Width = Pango.Units.FromPixels(widthConstraint);
			Control.Layout.GetPixelSize(out w, out h);

			return new SizeRequest(new Size(w, h));
		}
	}*/
}
