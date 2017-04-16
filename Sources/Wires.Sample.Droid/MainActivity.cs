using Android.App;
using Android.Widget;
using Android.OS;
using Wires;
using Wires.Sample.ViewModel;
using Java.Lang.Reflect;
using Android.Content;
using Java.Util.Logging;
using Android.Util;

namespace Wires.Sample.Droid
{
	[Activity(Label = "Wires.Sample.Droid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		HomeViewModel ViewModel { get; set; }

		TextView label;
		EditText field;
		Button button;
		Switch toggleSwitch;
		ImageView image;
		SeekBar slider;
		CalendarView datePicker;
		ProgressBar progressView;


		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
								
			this.ViewModel = new HomeViewModel();

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			label = FindViewById<TextView>(Resource.Id.textView1);
			field = FindViewById<EditText>(Resource.Id.editText1);
			button = FindViewById<Button>(Resource.Id.button1);
			toggleSwitch = FindViewById<Switch>(Resource.Id.switch1);
			image = FindViewById<ImageView>(Resource.Id.imageView1);
			datePicker = FindViewById<CalendarView>(Resource.Id.calendarView1);
			progressView = FindViewById<ProgressBar>(Resource.Id.progressBar1);
			slider = FindViewById<SeekBar>(Resource.Id.seekBar1);

			var customLabel = new CustomLabel(this);
			//TODO: add view

			this.ViewModel
			    .Bind(customLabel)
			    	.Text(vm => vm.Title)
				.Bind(this.label)
					.Text(vm => vm.Title, Converters.Uppercase)
				.Bind(this.field)
			    	.Text(vm => vm.Title)
				.Bind(this.image)
					.ImageAsync(vm => vm.Illustration)
					.Alpha(vm => vm.Amount)
					.Visibility(vm => vm.IsActive)
				.Bind(this.toggleSwitch)
			    	.Checked(vm => vm.IsActive)
				.Bind(this.datePicker)
					.Date(vm => vm.Birthday)
				.Bind(this.progressView)
					.Progress(vm => vm.Amount)
				.Bind(this.slider)
			    	.Progress(vm => vm.Amount, max:slider.Max)
			    //.Bind(this.activityIndicator)
				//	.IsAnimating(vm => vm.IsLoading)
				//.Bind(this.segmented)
				//	.Titles(vm => vm.Sections)
				//	.Selected(vm => vm.Selected)
				.Bind(this.button)
			    	.Click(vm => vm.LoadCommand)
			    ;
		}


		public class CustomLabel : TextView
		{
			public CustomLabel(Context context)
				: base(context)
			{
			}
		}
	}
}

