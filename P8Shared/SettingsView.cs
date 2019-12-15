using System;
using Xamarin.Forms;

namespace P8Shared
{
	public class SettingsView : ContentView
	{
		public SettingsView()
		{
			ScrollView page_scroll = new ScrollView
			{
				// HeightRequest = 1200
			};

			FlexLayout layout_page = new FlexLayout
			{
				Direction = FlexDirection.Column,
				AlignContent = FlexAlignContent.Start,
				AlignItems = FlexAlignItems.Start,
				//HeightRequest = 1200
			};
			page_scroll.Content = layout_page;

			Frame header_basestattion_frame = new Frame
			{
				Margin = 0,
				HasShadow = false,
				BorderColor =Xamarin.Forms.Color.Black,
				VerticalOptions= LayoutOptions.StartAndExpand
		    };
			layout_page.Children.Add(header_basestattion_frame);

			FlexLayout header_basestation_layout = new FlexLayout
			{
				Direction = FlexDirection.Row,
				HeightRequest = 32,
				JustifyContent= FlexJustify.SpaceBetween
			};
			header_basestattion_frame.Content = header_basestation_layout;
			Label header_basestationcomp_name = new Label
			{
				Text = "Base Station",
				FontSize = 27,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End
			};
			FlexLayout.SetAlignSelf(header_basestationcomp_name, FlexAlignSelf.Start);
			header_basestation_layout.Children.Add(header_basestationcomp_name);

			Frame basestation_values_frame =null;
		
			Button add_basestation_button = new Button
			{
				Text = "+",
				FontSize = 30,
				TextColor = Xamarin.Forms.Color.Blue,
				BackgroundColor = Xamarin.Forms.Color.White,
				BorderColor = Xamarin.Forms.Color.White
			};
			add_basestation_button.Clicked += (s,ev)=>{
			
			    int ind=layout_page.Children.IndexOf(header_basestattion_frame);

	            if(basestation_values_frame!=null)
	            layout_page.Children.Remove(basestation_values_frame);
				
				basestation_values_frame = AddBaseStation();
			
			    layout_page.Children.Insert(ind+1, basestation_values_frame);
				basestation_values_frame.IsVisible = true;
			};
			header_basestation_layout.Children.Add(add_basestation_button);

			Frame header_rover_frame = new Frame
			{
				Margin = 0,
				HasShadow = false,
				BorderColor = Xamarin.Forms.Color.Black,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
			layout_page.Children.Add(header_rover_frame);

			FlexLayout header_rover_layout = new FlexLayout
			{
				Direction = FlexDirection.Row,
				HeightRequest = 32,
				JustifyContent = FlexJustify.SpaceBetween
			};
			header_rover_frame.Content = header_rover_layout;
			Label header_rover_stationcomp_name = new Label
			{
				Text = "Rover",
				FontSize = 27,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End
			};
			FlexLayout.SetAlignSelf(header_rover_stationcomp_name, FlexAlignSelf.Start);
			header_rover_layout.Children.Add(header_rover_stationcomp_name);
			Frame roverstation_values_frame = null;
			Button add_rover_button = new Button
			{
				Text = "+",
				FontSize = 30,
				BackgroundColor = Xamarin.Forms.Color.White,
				TextColor = Xamarin.Forms.Color.Blue,
				BorderColor = Xamarin.Forms.Color.White
			};
		    	add_rover_button.Clicked += (s, ev) => {
				if (roverstation_values_frame != null)
					layout_page.Children.Remove(roverstation_values_frame);
				roverstation_values_frame = AddRover();
				layout_page.Children.Add(roverstation_values_frame);
			};
			header_rover_layout.Children.Add(add_rover_button);

			this.Content = page_scroll;
		}


		public Frame AddBaseStation()
		{
			//values
			Frame values_frame = new Frame
			{
				BorderColor = Xamarin.Forms.Color.Black,
				Margin = 0,
				Padding = 0,
				//HeightRequest =1200,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HasShadow = false
			};
			FlexLayout.SetAlignSelf(values_frame, FlexAlignSelf.Start);


			FlexLayout values_layout = new FlexLayout
			{
				Direction = FlexDirection.Column,
				//BackgroundColor = Xamarin.Forms.Color.Gray,
				AlignItems = FlexAlignItems.Start,
				AlignContent = FlexAlignContent.Start,
				HeightRequest = 5
			};
			values_frame.Content = values_layout;
			BaseStationConfig config = new BaseStationConfig();
			config.Active = true;
			config.Url = "https://129.98.22.24:5937";
			var value_frame = GetEditor(config, BaseStationConfig.UrlProperty, FlexDirection.Column);
			values_layout.HeightRequest += 70;
			values_layout.Children.Add(value_frame);


			value_frame = GetEditor(config, BaseStationConfig.ActiveProperty);
			values_layout.HeightRequest += 70;
			values_layout.Children.Add(value_frame);


			value_frame = GetEditor(config, BaseStationConfig.DumpRTMProperty);
			values_layout.HeightRequest += 70;
			values_layout.Children.Add(value_frame);

			value_frame = GetEditor(config, BaseStationConfig.AutoStartProperty);

			values_layout.Children.Add(value_frame);

			Label showallsetting_label = new Label
			{
				Text = "Show all settings",
				FontSize = 15,
				TextColor = Xamarin.Forms.Color.Blue,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				Margin = new Thickness(0, 0, 5, 0)
			};
			FlexLayout.SetAlignSelf(showallsetting_label, FlexAlignSelf.End);
			values_layout.Children.Add(showallsetting_label);

			return values_frame;
		}


		public Frame AddRover()
		{
			//values
			Frame values_frame = new Frame
			{
				BorderColor = Xamarin.Forms.Color.Black,
				Margin = 0,
				Padding = 0,
				//HeightRequest =1200,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HasShadow = false
			};
			FlexLayout.SetAlignSelf(values_frame, FlexAlignSelf.Start);
		

			FlexLayout values_layout = new FlexLayout
			{
				Direction = FlexDirection.Column,
				//BackgroundColor = Xamarin.Forms.Color.Gray,
				AlignItems = FlexAlignItems.Start,
				AlignContent = FlexAlignContent.Start,
				HeightRequest = 5
			};
			values_frame.Content = values_layout;
			BaseStationConfig config = new BaseStationConfig();
			config.Active = true;
			config.Url = "https://109.01.34.28:1937";
			var value_frame = GetEditor(config, BaseStationConfig.UrlProperty, FlexDirection.Column);
			values_layout.HeightRequest += 70;
			values_layout.Children.Add(value_frame);


			value_frame = GetEditor(config, BaseStationConfig.ActiveProperty);
			values_layout.HeightRequest += 70;
			values_layout.Children.Add(value_frame);
			

			/*value_frame = GetEditor(config, BaseStationConfig.DumpRTMProperty);
			values_layout.HeightRequest += 70;
			values_layout.Children.Add(value_frame);*/

			value_frame = GetEditor(config, BaseStationConfig.AutoStartProperty);
			
			values_layout.Children.Add(value_frame);


			Label showallsetting_label = new Label
			{
				Text = "Show all settings",
				FontSize = 15,
				TextColor = Xamarin.Forms.Color.Blue,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.End,
				Margin = new Thickness(0, 0, 5, 0)
			};
			FlexLayout.SetAlignSelf(showallsetting_label, FlexAlignSelf.End);
			values_layout.Children.Add(showallsetting_label);

			return values_frame;
		}
		

		public Frame GetEditor(object obj, BindableProperty property, FlexDirection direction = FlexDirection.Row)
		{
			//BindableProperty BindProperty = BindableProperty.CreateAttached("LayoutBounds", typeof(Rectangle), typeof(AbsoluteLayout), new Rectangle(0, 0, AutoSize, AutoSize));
			int frame_height = 31;
			if (direction == FlexDirection.Column || direction == FlexDirection.ColumnReverse)
				frame_height = frame_height * 2;
			Frame frame = new Frame
			{
				HasShadow = false,
				//BorderColor = Xamarin.Forms.Color.Black,
				VerticalOptions = LayoutOptions.StartAndExpand,
				CornerRadius = 0,
				HeightRequest = frame_height,
				Padding = 0,
				Margin = 0
			};
	
			FlexLayout value_layout = new FlexLayout
			{
				Direction = direction
			};
			frame.Content = value_layout;

	        View target_editor = null;
			Binding binding = new Binding(property.PropertyName, BindingMode.TwoWay, source: obj);
			if (property.ReturnType == typeof(String))
			{
				target_editor = new Entry
				{
					Margin = new Thickness(0, 0, 0, 10),
					HeightRequest = 31,
					FontSize = 18
					 
				};
				target_editor.SetBinding(Entry.TextProperty, binding);
				FlexLayout.SetAlignSelf(target_editor, FlexAlignSelf.Stretch);
			}
			if(property.ReturnType == typeof(bool))
			{
				target_editor = new CheckBox
				{
					HeightRequest =62,
					WidthRequest =62
				};
				target_editor.SetBinding(CheckBox.IsCheckedProperty, binding);
			}

			value_layout.Children.Add(target_editor);

			Label label = new Label
			{
				Margin = new Thickness(0,0,0,5),
				Text = property.PropertyName,	//.fromdictionary
				FontSize = 17
			};

			if (direction == FlexDirection.Row || direction == FlexDirection.RowReverse)
				FlexLayout.SetBasis(label, new FlexBasis(0.7f, true));
			else
				FlexLayout.SetAlignSelf(label, FlexAlignSelf.Center);
			value_layout.Children.Add(label);
		
			return frame;
		}
	}
}
