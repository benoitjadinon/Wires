namespace Wires
{
	using Android.Views;
	using Android.Widget;

	/// <summary>
	/// This class will force to include symbols that are used by reflection and may be ignored during linking phases.
	/// Kinda hacky, but is still the best option for now.
	/// </summary>
	public static class Linking
	{
		public static void All()
		{
			var x1 = new Button(null);
			x1.Click += (s, e) => { };
			x1.Text = x1.Text;

			var x2 = new Switch(null);
			x2.CheckedChange += (s, e) => { };
			x2.Checked = x2.Checked;

			var x3 = new EditText(null);
			x3.TextChanged += (s, e) => { };
			x3.Text = x3.Text;

			var x4 = new View(null);
			x4.Visibility = x4.Visibility;
			x4.Background = x4.Background;
			x4.Alpha = x4.Alpha;

			var xTV = new TextView(null);
			xTV.Text = xTV.Text;
		
			var xCal = new CalendarView(null);
			xCal.Date = xCal.Date;

			var xCP = new CheckBox(null);
			xCP.Checked = xCP.Checked;

			var xNP = new NumberPicker(null);
			xNP.Value = xNP.Value;

			var xPB = new ProgressBar(null);
			xPB.Progress = xPB.Progress;

			var xTH = new TabHost(null);
			xTH.CurrentTab = xTH.CurrentTab;

			var xTP = new TimePicker(null);
			xTP.Hour = xTP.Hour;
			xTP.Minute = xTP.Minute;
		}
	}
}
