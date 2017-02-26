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
			return binder.Property(property, b => b.Text, converter);
		}

		#endregion
	}
}
