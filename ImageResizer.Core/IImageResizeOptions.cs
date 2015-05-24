namespace ImageResizer.Core
{
	/// <summary>
	/// Options for a resize operation.
	/// </summary>
	public interface IImageResizeOptions
	{
		/// <summary>
		/// Maximum width of an image.
		/// </summary>
		int MaxWidth
		{
			get;
		}
		/// <summary>
		/// Maximum height of an image.
		/// </summary>
		int MaxHeight
		{
			get;
		}
	}
}