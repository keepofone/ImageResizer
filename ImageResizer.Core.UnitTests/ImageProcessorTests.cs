using System;
using System.Drawing;
using System.Collections.Generic;

using NUnit.Framework;

namespace ImageResizer.Core.UnitTests
{
	[TestFixture]
	class ImageProcessorTests
	{
		List<object> _toDispose;
		IImageProcessor _sut;

		[SetUp]
		public void BeforeTest()
		{
			_toDispose = new List<object>();
			// System Under Test.
			_sut = new ImageProcessor();
		}
		[TearDown]
		public void AfterTest()
		{
			foreach ( object obj in _toDispose ) {
				var disposable = obj as IDisposable;
				if ( null != disposable )
					disposable.Dispose();
			}
		}

		#region Test Helpers
		Image CreateImage(Size size)
		{
			return	CreateImage( width: size.Width, height: size.Height );
		}
		Image CreateImage(int width, int height)
		{
			return	new Bitmap( width, height );
		}
		void DisposeAfterTest(object obj)
		{
			_toDispose.Add( obj );
		}
		#endregion

		#region Resize(Image)
		IEnumerable<TestCaseData> TestCases_Resize_CanResizeImage_ReturnsResizedImage()
		{
			yield return	new TestCaseData(
								// initial size.
								new Size( width: 2000, height: 1000 ),
								// resize options.
								new ImageResizeOptions( maxWidth: 1600, maxHeight: 600 ),
								// expected.
								new Size( width: 1200, height: 600 )
							);
			yield return	new TestCaseData(
								// initial size.
								new Size( width: 1000, height: 2000 ),
								// resize options.
								new ImageResizeOptions( maxWidth: 600, maxHeight: 1600 ),
								// expected.
								new Size( width: 600, height: 1200 )
							);
		}
		[Test]
		[TestCaseSource( "TestCases_Resize_CanResizeImage_ReturnsResizedImage" )]
		public void Resize_CanResizeImage_ReturnsResizedImage(
			Size initial, IImageResizeOptions options, Size expected)
		{
			// Arrange.
			Image image = CreateImage( initial );
			DisposeAfterTest( image );

			// Act.
			Image resized = _sut.Resize( image, options );
			DisposeAfterTest( resized );

			// Assert.
			Assert.AreEqual(
				expected:	expected.Width,
				actual:		resized.Width
			);
			Assert.AreEqual(
				expected:	expected.Height,
				actual:		resized.Height
			);
		}
		#endregion
	}
}
