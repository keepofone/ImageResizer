namespace ImageResizer.WinFormsGUI
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if ( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.browseImageFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.browseImages = new System.Windows.Forms.Button();
			this.selectedImageFolder = new System.Windows.Forms.Label();
			this.start = new System.Windows.Forms.Button();
			this.maxWidth = new System.Windows.Forms.NumericUpDown();
			this.maxHeight = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.maxWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.maxHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// browseImages
			// 
			this.browseImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.browseImages.Location = new System.Drawing.Point(12, 6);
			this.browseImages.Name = "browseImages";
			this.browseImages.Size = new System.Drawing.Size(260, 23);
			this.browseImages.TabIndex = 0;
			this.browseImages.Text = "Выбрать папку с картинками";
			this.browseImages.UseVisualStyleBackColor = true;
			this.browseImages.Click += new System.EventHandler(this.browseImages_Click);
			// 
			// selectedImageFolder
			// 
			this.selectedImageFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.selectedImageFolder.Location = new System.Drawing.Point(12, 32);
			this.selectedImageFolder.Name = "selectedImageFolder";
			this.selectedImageFolder.Size = new System.Drawing.Size(260, 44);
			this.selectedImageFolder.TabIndex = 1;
			this.selectedImageFolder.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(12, 122);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(260, 23);
			this.start.TabIndex = 2;
			this.start.Text = "Старт";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// maxWidth
			// 
			this.maxWidth.Location = new System.Drawing.Point(15, 96);
			this.maxWidth.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
			this.maxWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.maxWidth.Name = "maxWidth";
			this.maxWidth.Size = new System.Drawing.Size(120, 20);
			this.maxWidth.TabIndex = 3;
			this.maxWidth.Value = new decimal(new int[] {
            1600,
            0,
            0,
            0});
			// 
			// maxHeight
			// 
			this.maxHeight.Location = new System.Drawing.Point(152, 96);
			this.maxHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
			this.maxHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.maxHeight.Name = "maxHeight";
			this.maxHeight.Size = new System.Drawing.Size(120, 20);
			this.maxHeight.TabIndex = 4;
			this.maxHeight.Value = new decimal(new int[] {
            1200,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Максимальная Ширина";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(149, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Максимальная высота";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 154);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.maxHeight);
			this.Controls.Add(this.maxWidth);
			this.Controls.Add(this.start);
			this.Controls.Add(this.selectedImageFolder);
			this.Controls.Add(this.browseImages);
			this.Name = "Main";
			this.Text = "Картинкоразмероизменятель";
			((System.ComponentModel.ISupportInitialize)(this.maxWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.maxHeight)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog browseImageFolder;
		private System.Windows.Forms.Button browseImages;
		private System.Windows.Forms.Label selectedImageFolder;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.NumericUpDown maxWidth;
		private System.Windows.Forms.NumericUpDown maxHeight;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;

	}
}

