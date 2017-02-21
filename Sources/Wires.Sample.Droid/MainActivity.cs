using Android.App;
using Android.Widget;
using Android.OS;
using Wires;
using Wires.Sample.ViewModel;
using Java.Lang.Reflect;

namespace Wires.Sample.Droid
{
	[Activity(Label = "Wires.Sample.Droid", MainLauncher = true)]
	public class MainActivity : Activity
	{
		HomeViewModel ViewModel { get; set; }

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
								
			this.ViewModel = new HomeViewModel();

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
		}

		TextView label;
		EditText field;
		Button button;
		Switch toggleSwitch;
		ImageView image;
		SeekBar slider;
		DatePicker datePicker;
		ProgressBar progressView;


		public override Android.Views.View OnCreateView(string name, Android.Content.Context context, Android.Util.IAttributeSet attrs)
		{
			label = FindViewById<TextView>(Resource.Id.textView1);
			field = FindViewById<EditText>(Resource.Id.editText1);
			button = FindViewById<Button>(Resource.Id.button1);
			toggleSwitch = FindViewById<Switch>(Resource.Id.switch1);
			image = FindViewById<ImageView>(Resource.Id.imageView1);
			slider = FindViewById<SeekBar>(Resource.Id.seekBar1);
			datePicker = FindViewById<DatePicker>(Resource.Id.datePicker1);
			progressView = FindViewById<ProgressBar>(Resource.Id.progressBar1);

			this.ViewModel
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
			    .Bind(this.slider)
					.Progress(vm => vm.Amount)
				//Bind(this.datePicker)
					//.Date(vm => vm.Birthday)
			    .Bind(this.progressView)
					.Progress(vm => vm.Amount)
			    //.Bind(this.activityIndicator)
				//	.IsAnimating(vm => vm.IsLoading)
				//.Bind(this.segmented)
				//	.Titles(vm => vm.Sections)
				//	.Selected(vm => vm.Selected)
			    .Bind(this.button)
			    	.Click(vm => vm.LoadCommand)
			    ;

			return base.OnCreateView(name, context, attrs);
		}
	}
}

