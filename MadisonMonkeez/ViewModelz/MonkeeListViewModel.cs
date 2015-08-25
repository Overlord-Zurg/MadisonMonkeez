using System;
//using MadisonMonkeez.Models;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Newtonsoft.Json;
using System.Net.Http;

namespace MadisonMonkeez
{
	public class MonkeeListViewModel : System.ComponentModel.INotifyPropertyChanged
	{
		#region INotifyPropertyChanged implementation

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged (this, new PropertyChangedEventArgs (propertyName));
		}

		#endregion

		private bool busy = false;
		public bool IsBusy
		{
			get { return busy; }
			set {
				busy = value;
				RaisePropertyChanged ("IsBusy");
			}
		}

		public ObservableCollection<Monkee> MonkeeList {get; set;}

		public MonkeeListViewModel ()
		{
			MonkeeList = new ObservableCollection<Monkee> ();
		}

		public async Task GetMonkeezAsync()
		{
			if (IsBusy)
				return;

			try
			{
				IsBusy = true;
				var client = new HttpClient();
				var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");
				var x = 1;
				var list = JsonConvert.DeserializeObject<List<Monkee>>(json);
				MonkeeList.Clear();
				foreach (var item in list)
					MonkeeList.Add(item);
			}
			catch (Exception e) {
				System.Diagnostics.Debug.WriteLine (e.Message);
			}
			finally {
				IsBusy = false;
			}
			// IzBuzy = true;
			// Get monkeez and stuffz
			// IzBuzy = false;
		}
	}
}

