using System.ComponentModel;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	/*public class C_ActivityIndicator : Controls.ActivityIndicator, INativeView
	{
		public INativeView Control { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

		public SizeRequest GetDesiredSize(double width, double height)
		{
			throw new System.NotImplementedException();
		}
	}


	public class ActivityIndicatorRenderer : ViewRenderer<ActivityIndicator, C_ActivityIndicator>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					C_ActivityIndicator activityIndicator = new C_ActivityIndicator();
					SetNativeControl(activityIndicator);
				}
				UpdateColor();
				UpdateIsRunning();
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == ActivityIndicator.ColorProperty.PropertyName)
				UpdateColor();
			else if (e.PropertyName == ActivityIndicator.IsRunningProperty.PropertyName)
				UpdateIsRunning();
		}

		private void UpdateColor()
		{
			if (Element == null || Control == null)
				return;

			Control.UpdateColor(Element.Color);
		}

		private void UpdateIsRunning()
		{
			if (Element == null || Control == null)
				return;

			if (Element.IsRunning)
				Control.Start();
			else
				Control.Stop();
		}
	}*/
	}
