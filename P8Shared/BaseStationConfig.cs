using System;
using Xamarin.Forms;

namespace P8Shared
{
	public class BaseStationConfig : BindableObject
	{
		//		public static readonly BindableProperty UrlProperty = BindableProperty.CreateAttached("LayoutFlags", typeof(string), typeof(BaseStationConfig), "");

		public static  BindableProperty UrlProperty =
		BindableProperty.Create(nameof(Url), typeof(string), typeof(BaseStationConfig), String.Empty,
								propertyChanged: (bindable, oldvalue, newvalue) => { });
		public string Url
		{
			get { return (string)GetValue(UrlProperty); }
			set { SetValue(UrlProperty, value); }
		}

		public static BindableProperty ActiveProperty =
	    BindableProperty.Create(nameof(Active), typeof(bool), typeof(BaseStationConfig), false,
							propertyChanged: (bindable, oldvalue, newvalue) => { });
		public bool Active
		{
			get { return (bool)GetValue(ActiveProperty); }
			set { SetValue(ActiveProperty, value); }
		}

		public static BindableProperty AutoStartProperty =  
	    BindableProperty.Create(nameof(AutoStart), typeof(bool), typeof(BaseStationConfig), false,
						propertyChanged: (bindable, oldvalue, newvalue) => { });
		public bool AutoStart
		{
			get { return (bool)GetValue(AutoStartProperty); }
			set { SetValue(AutoStartProperty, value); }
		}


		public static BindableProperty DumpRTMProperty =
        BindableProperty.Create(nameof(DumpRTM), typeof(bool), typeof(BaseStationConfig), false,
				propertyChanged: (bindable, oldvalue, newvalue) => { });
		public bool DumpRTM
		{
			get { return (bool)GetValue(DumpRTMProperty); }
			set { SetValue(DumpRTMProperty, value); }
		}
	}
}
