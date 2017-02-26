namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using Android.Widget;

	public static partial class UIExtensions
	{
		#region Text property

		public static Binder<TSource, TimePicker> Hour<TSource, TPropertyType>(this Binder<TSource, TimePicker> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, int> converter = null)
			where TSource : class
		{
			return binder.Property<TPropertyType, int, TimePicker.TimeChangedEventArgs>(property, b => b.Hour, nameof(TimePicker.TimeChanged), converter);
		}

		public static Binder<TSource, TimePicker> Minute<TSource, TPropertyType>(this Binder<TSource, TimePicker> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, int> converter = null)
			where TSource : class
		{
			return binder.Property<TPropertyType, int, TimePicker.TimeChangedEventArgs>(property, b => b.Minute, nameof(TimePicker.TimeChanged), converter);
		}

		#endregion
	}
}
