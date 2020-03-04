
namespace Xamarin.Forms.Platform.GTK
{
	public interface IVisualNativeElementRenderer : IVisualElementRenderer
	{
		IGTKNativeView Control { get; }
	}
}
