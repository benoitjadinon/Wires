using System;
using System.Linq.Expressions;
using Android.Text;
using Android.Widget;

namespace Wires
{

	public static partial class UIExtensions
	{
		#region Progress property

		public static Binder<TSource, TView> Progress<TSource, TView, TPropertyType>(this Binder<TSource, TView> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, int> converter = null)
			where TSource : class
			where TView : ProgressBar
		{
			return binder.Property(property, b => b.Progress, converter);
		}

		#endregion
	}
}