namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using Android.Text;
	using Android.Views;
	using Android.Widget;

	public static partial class UIExtensions
	{
		#region Text property

		public static Binder<TSource, TView> Text<TSource, TView, TPropertyType>(this Binder<TSource, TView> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, string> converter = null)
			where TSource : class
			where TView : TextView
		{
			TView view;
			if (binder.TryGetTarget(out view) && view != null && view is EditText)
				return binder.Property<TPropertyType, string, TextChangedEventArgs>(property, b => b.Text, nameof(EditText.TextChanged), converter);

			return binder.Property(property, b => b.Text, converter);
		}

		#endregion
	}
}
