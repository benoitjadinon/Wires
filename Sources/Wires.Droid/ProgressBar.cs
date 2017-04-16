using System;
using System.Linq.Expressions;
using Android.Text;
using Android.Widget;

namespace Wires
{

	public static partial class UIExtensions
	{
		#region Progress property

		// TODO: put more conversion choices back with TPropertyType
		public static Binder<TSource, TView> Progress<TSource, TView>(this Binder<TSource, TView> binder, Expression<Func<TSource, double>> property, int max, int min = 0)
			where TSource : class
			where TView : ProgressBar
		{
			return Progress(binder, property, new PercentsConverter(max, min));
		}

		public static Binder<TSource, TView> Progress<TSource, TView, TPropertyType>(this Binder<TSource, TView> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, int> converter = null)
			where TSource : class
			where TView : ProgressBar
		{
			TView view;
			if (binder.TryGetTarget(out view) && view != null && view is SeekBar)
				return binder.Property<TPropertyType, int, SeekBar.ProgressChangedEventArgs>(property, b => b.Progress, nameof(SeekBar.ProgressChanged), converter);

			return binder.Property(property, b => b.Progress, converter);
		}

		#endregion
	}


	public class PercentsConverter : RelayConverter<double, int>
	{
		public PercentsConverter(int max = 100, int min = 0) //TODO : real calculation with min+max
			: base(
				@double => (int)(@double * (double)max),
				@int =>(double)@int / (double)max
			)
		{
		}	
	}	
}