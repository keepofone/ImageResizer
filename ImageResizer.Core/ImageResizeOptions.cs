namespace ImageResizer.Core
{
	/// <summary>
	/// Options for a resize operation.
	/// </summary>
	public class ImageResizeOptions
		: IImageResizeOptions
	{
		/// <summary>
		/// Quality of the resulting image.
		/// </summary>
		public Quality Quality
		{
			get;
			set;
		}
		/// <summary>
		/// Maximum width of a resized image.
		/// </summary>
		public int MaxWidth
		{
			get;
			private set;
		}
		/// <summary>
		/// Maximum height of a resized image.
		/// </summary>
		public int MaxHeight
		{
			get;
			private set;
		}

		/// <summary>
		/// Initializes the options.
		/// </summary>
		/// <param name="maxWidth">Maximum width of a resized image.</param>
		/// <param name="maxHeight">Maximum height of a resized image.</param>
		public ImageResizeOptions(int maxWidth, int maxHeight)
		{
			this.MaxWidth	= maxWidth;
			this.MaxHeight	= maxHeight;
		}
	}
}