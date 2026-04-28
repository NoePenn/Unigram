using System.Windows.Forms;
/*
 * Created by SharpDevelop.
 * User: noepe
 * Date: 14.04.2026
 * Time: 15:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Unigram
{
	partial class MainForm
	{
		float trackBarValue = 10;
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.button1 = new System.Windows.Forms.Button();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(1544, 895);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.Button1Paint);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(439, 826);
			this.trackBar1.Maximum = 50;
			this.trackBar1.Minimum = 10;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(710, 69);
			this.trackBar1.TabIndex = 1;
			this.trackBar1.Value = 50;
			this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1602, 924);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Unigram";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button1;
		
		public void Button1Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if ((e != null) && (e.ClipRectangle != null)) {
			}
			v.PixelCrafter(e, e.ClipRectangle.Width, e.ClipRectangle.Height, trackBarValue);

		}
		
		void Button1Click(object sender, System.EventArgs e)
		{
			
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			
		}
		
		void TrackBar1Scroll(object sender, System.EventArgs e)
		{
			trackBarValue= trackBar1.Value;
			button1.Invalidate();
		}
	}
}
