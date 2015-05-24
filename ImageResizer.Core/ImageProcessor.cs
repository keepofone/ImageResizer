using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace ImageResizer.Core
{
	/// <summary>
	/// Processes images. Resizes, compresses, etc.
	/// </summary>
	public class ImageProcessor
		: IImageProcessor
	{
		#region Private Methods
		/// <summary>
		/// Sets quality.
		/// </summary>
		/// <param name="graphics">The graphics to set quality of.</param>
		/// <param name="quality">The quality to set.</param>
		void SetQuality(Graphics graphics, Quality quality)
		{
			switch ( quality ) {
				case Quality.TheHighest:
					graphics.CompositingMode	= CompositingMode.SourceCopy;
					graphics.CompositingQuality	= CompositingQuality.HighQuality;
					graphics.InterpolationMode	= InterpolationMode.HighQualityBicubic;
					graphics.SmoothingMode		= SmoothingMode.HighQuality;
					graphics.PixelOffsetMode	= PixelOffsetMode.HighQuality;
					break;
				default:
					throw new NotSupportedException(
						message: string.Format( "{0} quality is not supported.", quality.ToString() )
					);
			}
		}
		/// <summary>
		/// Sets quality.
		/// </summary>
		/// <param name="wrapMode">The attributes to set quality of.</param>
		/// <param name="quality">The quality to set.</param>
		void SetQuality(ImageAttributes wrapMode, Quality quality)
		{
			switch ( quality ) {
				case Quality.TheHighest:
					wrapMode.SetWrapMode( WrapMode.TileFlipXY );
					break;
				default:
					throw new NotSupportedException(
						message: string.Format( "{0} quality is not supported.", quality.ToString() )
					);
			}
		}
		/// <summary>
		/// Creates size of resized image.
		/// </summary>
		/// <param name="image">An original image.</param>
		/// <param name="options">Resize options.</param>
		/// <returns>Size of the resized image.</returns>
		Size CreateDestImageSize(Image image, IImageResizeOptions options)
		{
			var k = Math.Min(
				val1:	(double)options.MaxWidth / image.Width,
				val2:	(double)options.MaxHeight / image.Height
			);
			return	new Size(
						width:	(int)(image.Width * k),
						height:	(int)(image.Height * k)
					);
		}
		#endregion

		/// <summary>
		/// Resizes an image using specified options.
		/// </summary>
		/// <param name="imagePath">Path to the image to resize.</param>
		/// <param name="options">The resize options.</param>
		/// <returns>Resizes the image.</returns>
		public Image Resize(string imagePath, IImageResizeOptions options)
		{
			using ( var image = Image.FromFile( imagePath ) )
				return	Resize( image, options );
		}
		/// <summary>
		/// Resizes an image using specified options.
		/// </summary>
		/// <param name="image">The image to resize.</param>
		/// <param name="options">The resize options.</param>
		/// <returns>Resizes the image.</returns>
		public Image Resize(Image image, IImageResizeOptions options)
		{
			Size destSize = CreateDestImageSize( image, options );
			var destImage = new Bitmap( width: destSize.Width, height: destSize.Height );
			try {
				destImage.SetResolution( image.HorizontalResolution, image.VerticalResolution );
				// initialize Graphics.
				using ( var graphics = Graphics.FromImage( destImage ) ) {
					SetQuality( graphics, options.Quality );
					// resize the image.
					using ( var wrapMode = new ImageAttributes() ) {
						SetQuality( wrapMode, options.Quality );
						var destRect = new Rectangle( 0, 0, width: destSize.Width, height: destSize.Height );
						graphics.DrawImage( image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode );
					}
				}
				// done.
				return	destImage;
			} catch {
				destImage.Dispose();
				throw;
			}
		}
		/// <summary>
		/// Resizes an image using specified options.
		/// </summary>
		/// <param name="imagePath">Path to the image to resize.</param>
		/// <param name="options">The resize options.</param>
		/// <param name="destinationPath">Path to the destination image.</param>
		/// <exception cref="NotSupportedException">Unable to find an encoder.</exception>
		public void Resize(string imagePath, IImageResizeOptions options, string destinationPath)
		{
			using ( Image image = Resize( imagePath, options ) ) {
				// search for an appropriate encoder.
				ImageCodecInfo encoder = null;
				foreach ( ImageCodecInfo enc in ImageCodecInfo.GetImageEncoders() ) {
					if ( enc.MimeType == "image/jpeg" )
						encoder = enc;
				}
				if ( null == encoder )
					throw new NotSupportedException( "Unable to find an encoder." );
				// save compressed image.
				var ep = new EncoderParameters();
				ep.Param[ 0 ] = new EncoderParameter( Encoder.Quality, (long)65 );
				image.Save( destinationPath, encoder, ep );
			}
		}
	}
}