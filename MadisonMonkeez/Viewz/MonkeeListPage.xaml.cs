using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MadisonMonkeez
{
	public partial class MonkeeListPage : ContentPage
	{
		MonkeeListViewModel viewModel;
		public MonkeeListPage ()
		{
			InitializeComponent ();

			viewModel = new MonkeeListViewModel ();
			ButtonGet.Clicked += async (sender, e) => 
			{
				try {
					ButtonGet.IsEnabled = false;
					await viewModel.GetMonkeezAsync();
					ButtonGet.IsEnabled = true;
				} catch (Exception ex) {
					DisplayAlert("Oh no!", "Unable to get monkeez " + ex.Message, "Fml");
				}
			};

			ListyMcList.ItemTapped += async (sender, e) => 
			{
				var monkee = e.Item;
				var details = new MonkeePage
				{
					BindingContext = monkee
				};
				await Navigation.PushAsync(details);

				ListyMcList.SelectedItem = null;
			};

			BindingContext = viewModel;
		}
	}
}

