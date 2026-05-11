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
		float trackBarXMaxValue = 5;
		float trackBarXMinValue = -5;
		float trackBarYMaxValue = 5;
		float trackBarYMinValue = -5;
		
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
			this.trackBarXmax = new System.Windows.Forms.TrackBar();
			this.trackBarXmin = new System.Windows.Forms.TrackBar();
			this.trackBarYmin = new System.Windows.Forms.TrackBar();
			this.trackBarYmax = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.trackBarXmax)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarXmin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarYmin)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarYmax)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(1544, 895);
			this.button1.TabIndex = 0;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			this.button1.Paint += new System.Windows.Forms.PaintEventHandler(this.Button1Paint);
			// 
			// trackBarXmax
			// 
			this.trackBarXmax.Location = new System.Drawing.Point(0, 826);
			this.trackBarXmax.Minimum = -10;
			this.trackBarXmax.Name = "trackBarXmax";
			this.trackBarXmax.Size = new System.Drawing.Size(349, 69);
			this.trackBarXmax.TabIndex = 1;
			this.trackBarXmax.Value = 5;
			this.trackBarXmax.Scroll += new System.EventHandler(this.TrackBar1Scroll);
			// 
			// trackBarXmin
			// 
			this.trackBarXmin.Location = new System.Drawing.Point(355, 826);
			this.trackBarXmin.Minimum = -10;
			this.trackBarXmin.Name = "trackBarXmin";
			this.trackBarXmin.Size = new System.Drawing.Size(513, 69);
			this.trackBarXmin.TabIndex = 2;
			this.trackBarXmin.Value = -5;
			this.trackBarXmin.Scroll += new System.EventHandler(this.TrackBarXminScroll);
			// 
			// trackBarYmin
			// 
			this.trackBarYmin.Location = new System.Drawing.Point(1243, 826);
			this.trackBarYmin.Minimum = -10;
			this.trackBarYmin.Name = "trackBarYmin";
			this.trackBarYmin.Size = new System.Drawing.Size(301, 69);
			this.trackBarYmin.TabIndex = 4;
			this.trackBarYmin.Value = -5;
			this.trackBarYmin.Scroll += new System.EventHandler(this.TrackBarYminScroll);
			// 
			// trackBarYmax
			// 
			this.trackBarYmax.Location = new System.Drawing.Point(888, 826);
			this.trackBarYmax.Minimum = -10;
			this.trackBarYmax.Name = "trackBarYmax";
			this.trackBarYmax.Size = new System.Drawing.Size(349, 69);
			this.trackBarYmax.TabIndex = 3;
			this.trackBarYmax.Value = 5;
			this.trackBarYmax.Scroll += new System.EventHandler(this.TrackBarYmaxScroll);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1602, 924);
			this.Controls.Add(this.trackBarYmin);
			this.Controls.Add(this.trackBarYmax);
			this.Controls.Add(this.trackBarXmin);
			this.Controls.Add(this.trackBarXmax);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Unigram";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.trackBarXmax)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarXmin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarYmin)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarYmax)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TrackBar trackBarYmax;
		private System.Windows.Forms.TrackBar trackBarYmin;
		private System.Windows.Forms.TrackBar trackBarXmin;
		private System.Windows.Forms.TrackBar trackBarXmax;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button button1;
		
		public void Button1Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if ((e != null) && (e.ClipRectangle != null)) {
			}
			// v.PixelCrafter(e, e.ClipRectangle.Width, e.ClipRectangle.Height, trackBarValue);
			u.Paint(e.ClipRectangle.Width, e.ClipRectangle.Height, e.Graphics);
		}
		
		void Button1Click(object sender, System.EventArgs e)
		{
			
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			
		}
		
		void TrackBar1Scroll(object sender, System.EventArgs e)
		{
			trackBarXMaxValue= trackBarXmax.Value;
			u.Slider(trackBarXMaxValue, trackBarXMinValue, trackBarYMaxValue, trackBarYMinValue);
			button1.Invalidate();
		}
		
		void TrackBarXminScroll(object sender, System.EventArgs e)
		{
			trackBarXMinValue= trackBarXmin.Value;
			u.Slider(trackBarXMaxValue, trackBarXMinValue, trackBarYMaxValue, trackBarYMinValue);
			button1.Invalidate();
		}
		
		void TrackBarYmaxScroll(object sender, System.EventArgs e)
		{
			trackBarYMaxValue= trackBarYmax.Value;
			u.Slider(trackBarXMaxValue, trackBarXMinValue, trackBarYMaxValue, trackBarYMinValue);
			button1.Invalidate();
		}
		
		void TrackBarYminScroll(object sender, System.EventArgs e)
		{
			trackBarYMinValue= trackBarYmin.Value;
			u.Slider(trackBarXMaxValue, trackBarXMinValue, trackBarYMaxValue, trackBarYMinValue);
			button1.Invalidate();
		}
	}
}
