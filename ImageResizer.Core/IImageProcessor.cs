using System;
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
		/// <param name="image">The image to resize.</param>
		/// <param name="options">The resize options.</param>
		void Resize(Image image, IImageResizeOptions options);
	}
}
