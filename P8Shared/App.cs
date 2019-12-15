using System;
using Xamarin.Forms;
namespace P8Shared
{
	public class App : Application
	{
		public App()
		{
			MainPage = new ContentPage
			{
				//Content = new TestForm()
				Content = new SettingsView()
			};
		}
	}
}
