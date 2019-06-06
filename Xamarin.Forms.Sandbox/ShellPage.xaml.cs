using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Sandbox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShellPage : Shell
	{
		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			var page = new ContentPage()
			{
				Content =
					new ScrollView()
					{
						Content = new StackLayout()
						{
							Children =
							{
								new Label()
								{
									Text = "Top Label"
								},

								new Label()
								{
									Text = "test"
								},

								new Label()
								{
									Text = "test"
								},

								new Label()
								{
									Text = "Do you see the Top Label?"
								},
								new Button()
								{
									Text = "Pop The Page",
									Command = new Command(async () =>
									{
										await Navigation.PopAsync();
									})
								},
							}
						}
					}
			};

			Shell.SetNavBarIsVisible(page, isChecked.IsChecked);
			page.On<PlatformConfiguration.iOS>().SetUseSafeArea(false);

			if (paddingToUse().HasValue)
			{
				page.Padding = new Thickness(0, paddingToUse().Value, 0, 0);
			}

			await Navigation.PushAsync(page);
		}



		async void Handle2_Clicked(object sender, System.EventArgs e)
		{
			var page = new ContentPage()
			{
				Content = new StackLayout()
				{
					Children =
					{
						new Label()
						{
							Text = "top"
						},
						new Label()
						{
							Text = "test1"
						},

						new Label()
						{
							Text = "test1"
						},

						new Label()
						{
							Text = "test1"
						},

						new Label()
						{
							Text = "test1"
						},

						new Label()
						{
							Text = "test1"
						},
					}
				}
			};

			if(paddingToUse().HasValue)
			{
				page.Padding = new Thickness(0, paddingToUse().Value, 0, 0);
			}

			Shell.SetBackgroundColor(page, Color.Purple);
			Shell.SetNavBarIsVisible(page, isChecked.IsChecked);
			page.On<PlatformConfiguration.iOS>().SetUseSafeArea(false);
			await Navigation.PushAsync(page);
		}

		int? paddingToUse()
		{
			int thing;

			if (int.TryParse(PaddingToUse.Text, out thing))
				return thing;

			return null;
		}
		public ShellPage()
		{
			InitializeComponent();
		}
	}
}