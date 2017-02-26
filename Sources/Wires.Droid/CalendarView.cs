namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using Android.Widget;

	public static partial class UIExtensions
	{
#if __ANDROID_11__
		#region Text property
		public static Binder<TSource, CalendarView> Date<TSource, TPropertyType>(this Binder<TSource, CalendarView> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, long> converter = null)
			where TSource : class
		{
			return binder.Property<TPropertyType, long, CalendarView.DateChangeEventArgs>(property, b => b.Date, nameof(CalendarView.DateChange), converter);
		}
		#endregion
#endif
	}
}
