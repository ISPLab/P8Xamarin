using System;
using Gtk;
using Xamarin.Forms.Platform.GTK;

namespace Xamarin.Forms.Platform.P8
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			RunP8Platform();
	    }
		static void RunGtkPlatform()
		{
			Gtk.Application.Init();
			MainWindow win = new MainWindow();
			win.Show();
			Gtk.Application.Run();
		}

		static void RunP8Platform()
		{
			Gtk.Application.Init();
			Forms.Init();
			var app = new P8Shared.App();
			var window = new FormsWindow();
			window.LoadApplication(app);
			window.WindowPosition = WindowPosition.Mouse;
			window.SetDefaultSize(300, 400);
			window.SetApplicationTitle("UI Kernel Tests");
			window.Show();
			Gtk.Application.Run();
		}
	}
}
