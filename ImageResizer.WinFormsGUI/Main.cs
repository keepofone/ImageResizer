using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

using ImageResizer.Core;

namespace ImageResizer.WinFormsGUI
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();
		}

		#region Private Methods
		/// <summary>
		/// Creates a path to the destination file.
		/// </summary>
		/// <param name="path">A path to the source file.</param>
		/// <returns>A path to the destination file.</returns>
		string CreateDestinationPath(string path)
		{
			var destDir = Path.Combine(
				Path.GetDirectoryName( path ),
				"Resized"
			);
			var destPath = Path.Combine(
				destDir,
				Path.GetFileName( path )
			);
			if ( !Directory.Exists( destDir ) )
				Directory.CreateDirectory( destDir );
			return	destPath;
		}
		/// <summary>
		/// Creates options for a resize operation.
		/// </summary>
		/// <returns>Options.</returns>
		ImageResizeOptions CreateResizeOptions()
		{
			return	new ImageResizeOptions( 
						maxWidth:	(int)maxWidth.Value, 
						maxHeight:	(int)maxHeight.Value 
					);
		}
		#endregion

		#region Event Handlers
		/// <summary>
		/// Handles click event of the <see cref="browseImages"/> button.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		void browseImages_Click(object sender, EventArgs e)
		{
			browseImageFolder.ShowNewFolderButton = false;
			DialogResult result = browseImageFolder.ShowDialog();
			if ( result == DialogResult.OK )
				selectedImageFolder.Text = browseImageFolder.SelectedPath;
		}
		/// <summary>
		/// Handles click event of the <see cref="start"/> button.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">Event arguments.</param>
		/// <exception cref="DirectoryNotFoundException">The specified directory doesn't exist.</exception>
		void start_Click(object sender, EventArgs e)
		{
			string dir = selectedImageFolder.Text;
			if ( !Directory.Exists( dir ) )
				throw new DirectoryNotFoundException( "The specified directory doesn't exist." );
			// process images.
			string lastFile = null;
			var processor = new ImageProcessor();
			ImageResizeOptions resizeOptions = CreateResizeOptions();
			foreach ( string file in Directory.EnumerateFiles( dir, searchPattern: "*.jpg" ) ) {
				processor.Resize(
					imagePath:			file,
					options:			resizeOptions,
					destinationPath:	(lastFile = CreateDestinationPath( file ))
				);
			}
			MessageBox.Show( owner: this, text: "Готово!" );
			Process.Start( Path.GetDirectoryName( lastFile ) );
		}
		#endregion
	}
}
