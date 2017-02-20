namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using Android.Widget;

	public static partial class UIExtensions
	{
		#region Checked property

		public static Binder<TSource, TComponent> Checked<TSource, TComponent, TPropertyType>(this Binder<TSource, TComponent> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, bool> converter = null)
			where TSource : class
			where TComponent : CompoundButton
		{
			return binder.Property<TPropertyType, bool, CompoundButton.CheckedChangeEventArgs>(property, b => b.Checked, nameof(CompoundButton.CheckedChange), converter);
		}

		#endregion
	}
}
