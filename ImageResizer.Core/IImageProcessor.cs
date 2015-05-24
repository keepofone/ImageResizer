using System.Drawing;

namespace ImageResizer.Core
{
	/// <summary>
	/// Processes images.
	/// </summary>
	public interface IImageProcessor
	{
		/// <summary>
		/// Resizes an image using specified options.
		/// </summary>
		/// <param name="imagePath">Path to the image to resize.</param>
		/// <param name="options">The resize options.</param>
		/// <returns>Resizes the image.</returns>
		Image Resize(string imagePath, IImageResizeOptions options);
		/// <summary>
		/// Resizes an image using specified options.
		/// </summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="options">The resize options.</param>
		/// <returns>Resizes the image.</returns>
		Image Resize(Image image, IImageResizeOptions options);
		/// <summary>
		/// Resizes an image using specified options.
		/// </summary>
		/// <param name="imagePath">Path to the image to resize.</param>
		/// <param name="options">The resize options.</param>
		/// <param name="destinationPath">Path to the destination image.</param>
		void Resize(string imagePath, IImageResizeOptions options, string destinationPath);
	}
}
