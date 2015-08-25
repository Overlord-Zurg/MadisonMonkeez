using System;
using System.Collections.Generic;

using System.Threading.Tasks;

using Xamarin.Forms;

namespace MadisonMonkeez
{
	public partial class MonkeePage : ContentPage
	{
		public MonkeePage ()
		{
			InitializeComponent ();
		}

		public string[] monkeeAdjectives = {
			"beautiful",
			"smelly",
			"voracious",
			"widely-feared",
			"silly",
			"disaster-prone",
			"precious",
			"salubrious",
			"coy",
		};
		public Random randoM = new Random();
		public string getRandomAdjective()
		{
			var index = randoM.Next(monkeeAdjectives.Length);
			return monkeeAdjectives[index];
		}

		public Monkee Monkee { get { return BindingContext as Monkee; } }

		public bool isTalking = false;
		public System.Threading.CancellationTokenSource tokenSource = null;
		public void buttonReadClicked(object sender, EventArgs e)
		{
			Refractored.Xam.TTS.CrossTextToSpeech.Current.Speak (Monkee.Name, true, speakRate: (float)0.4, pitch: (float)0.05);
			var monkeyLocationLine = string.Format ("The {0} is a {1} monkey generally found in {2}.", Monkee.Name, getRandomAdjective(), Monkee.Location);
			Refractored.Xam.TTS.CrossTextToSpeech.Current.Speak (monkeyLocationLine, true);
			Refractored.Xam.TTS.CrossTextToSpeech.Current.Speak (Monkee.Details, true);
		}
	}
}

