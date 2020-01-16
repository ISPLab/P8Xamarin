
namespace Xamarin.Forms.Platform.GTK
{
	public interface IVisualNativeElementRenderer : IVisualElementRenderer
	{
		INativeView Control { get; }
	}
}
