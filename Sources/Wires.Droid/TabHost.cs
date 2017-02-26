namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using Android.Text;
	using Android.Widget;

	public static partial class UIExtensions
	{
		#region Text property

		public static Binder<TSource, TabHost> CurrentTab<TSource, TPropertyType>(this Binder<TSource, TabHost> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, int> converter = null)
			where TSource : class
		{
			return binder.Property<TPropertyType, int, TabHost.TabChangeEventArgs>(property, b => b.CurrentTab, nameof(TabHost.TabChanged), converter);
		}

		#endregion
	}
}
