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


		public override Android.Views.View OnCreateView(string name, Android.Content.Context context, Android.Util.IAttributeSet attrs)
		{
			label = FindViewById<TextView>(Resource.Id.textView1);
			field = FindViewById<EditText>(Resource.Id.editText1);
			button = FindViewById<Button>(Resource.Id.button1);
			toggleSwitch = FindViewById<Switch>(Resource.Id.switch1);

			this.ViewModel
				.Bind(this.label)
					.Text(vm => vm.Title, Converters.Uppercase)
				.Bind(this.field)
					.Text(vm => vm.Title)
				/*
			    .Bind(this.textView)
					.Text(vm => vm.Title)
					.UserInteractionEnabled(vm => vm.IsActive)
				.Bind(this.image)
					.ImageAsync(vm => vm.Illustration)
					.Alpha(vm => vm.Amount)
					.Visible(vm => vm.IsActive)
					*/
				.Bind(this.toggleSwitch)
			    	.Checked(vm => vm.IsActive)
			    	//.On(vm => vm.IsActive)
			    /*
				.Bind(this.slider)
					.Value(vm => vm.Amount)
				.Bind(this.datePicker)
					.Date(vm => vm.Birthday)
				.Bind(this.progressView)
					.Progress(vm => vm.Amount)
				.Bind(this.activityIndicator)
					.IsAnimating(vm => vm.IsLoading)
				.Bind(this.segmented)
					.Titles(vm => vm.Sections)
					.Selected(vm => vm.Selected)
			    */
				.Bind(this.button)
					.TouchUpInside(vm => vm.LoadCommand)
			    ;

			return base.OnCreateView(name, context, attrs);
		}
	}
}

