namespace ImageResizer.Core
{
	/// <summary>
	/// Options for a resize operation.
	/// </summary>
	public interface IImageResizeOptions
	{
		/// <summary>
		/// Quality of the resulting image.
		/// </summary>
		Quality Quality
		{
			get;
			set;
		}
		/// <summary>
		/// Maximum width of a resized image.
		/// </summary>
		int MaxWidth
		{
			get;
		}
		/// <summary>
		/// Maximum height of a resized image.
		/// </summary>
		int MaxHeight
		{
			get;
		}
	}
}