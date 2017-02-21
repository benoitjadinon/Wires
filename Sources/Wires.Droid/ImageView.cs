namespace Wires
{
	using System;
	using System.Linq.Expressions;
	using System.Threading.Tasks;
	using Android.Graphics;
	using Android.Graphics.Drawables;
	using Android.Text;
	using Android.Widget;

	public static partial class UIExtensions
	{
		#region Image property

		public static Binder<TSource, ImageView> Image<TSource, TPropertyType>(this Binder<TSource, ImageView> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, Bitmap> converter = null)
			where TSource : class
		{
			return binder.Property(property, b => ((BitmapDrawable)b.Drawable).Bitmap,  (b,v) => b.SetImageBitmap(v), converter);
		}

		public static Binder<TSource, ImageView> ImageAsync<TSource, TPropertyType>(this Binder<TSource, ImageView> binder, Expression<Func<TSource, TPropertyType>> property, IConverter<TPropertyType, Task<Bitmap>> converter = null, Bitmap loading = null)
			where TSource : class
		{
			if (converter == null)
				converter = (Wires.IConverter<TPropertyType, System.Threading.Tasks.Task<Android.Graphics.Bitmap>>)
					PlatformConverters.AsyncStringToCachedImage(TimeSpan.FromSeconds(30), 250, 250);
			
			return binder.PropertyAsync(property, b => ((BitmapDrawable)b.Drawable).Bitmap, (b, v) => b.SetImageBitmap(v), converter, loading);
		}

		#endregion
	}
}