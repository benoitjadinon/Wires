namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using Android.Widget;

	public static partial class UIExtensions
	{
#if __ANDROID_11__
		#region Text property
		public static Binder<TSource, NumberPicker> Value<TSource, TPropertyType>(this Binder<TSource, NumberPicker> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, int> converter = null)
			where TSource : class
		{
			return binder.Property<TPropertyType, int, NumberPicker.ValueChangeEventArgs>(property, b => b.Value, nameof(NumberPicker.ValueChanged), converter);
		}
		#endregion
#endif
	}
}
