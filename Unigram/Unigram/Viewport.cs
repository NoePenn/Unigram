/*
 * Created by SharpDevelop.
 * User: noepe
 * Date: 14.04.2026
 * Time: 15:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Unigram
{
	/// <summary>
	/// Description of Viewport.
	/// </summary>
	public class Viewport
	{
		float scaleX = 300;
		float scaleY = 200;
		float viewportOffsetX = 150;
		float viewportOffsetY = 100;
		float linesOffset = 10;
		
		public Viewport()
		{
			
			
		}
		
		private void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			
			
			Pen penMiddle = new Pen(Color.Black, 4);
			Pen penBackgroundThick = new Pen(Color.Gray, 2);
			Pen penBackgroundThin = new Pen(Color.Gray, 1);
			Pen functionPen = new Pen(Color.Red, 3);
			Font axisFont = new Font("Arial", 12);	
            Brush textBrush = Brushes.Black;
            
            float linesCountX = scaleX / (linesOffset*2); //Linesoffset should be split into X and Y soon!
            float linesCountY = scaleY / (linesOffset*2);
            
            float centerY = viewportOffsetX; //how far away the Middle lines are drawn from Origin
            float centerX = viewportOffsetY;
            
			int labelStep = linesOffset > 60 ? 1 : linesOffset > 30 ? 2 : 5; //If zoomed into Graph via Trackbar more lines appear
			
		    for (int i = 1; i < linesCountX; i++) //draw Lines from Middle lines two the edge (thick and thin)
				{
			    float offsetX = linesOffset * i; //Offset from the middle Lines
			    
			    PointF HorizontalPoint1 = new PointF(0, centerY + offsetX);
			    PointF HorizontalPoint2 = new PointF(scaleX, centerY + offsetX);
			    PointF HorizontalPoint3 = new PointF(0, centerY - offsetX);
			    PointF HorizontalPoint4 = new PointF(scaleX, centerY - offsetX);
			
			
			
			    if (i % labelStep == 0) //
			    {
			        e.Graphics.DrawString(i.ToString(), axisFont, textBrush, centerX + offset, centerY + 5, centerFormat);
			        e.Graphics.DrawString((-i).ToString(), axisFont, textBrush, centerX - offset, centerY + 5, centerFormat);
			        e.Graphics.DrawString(i.ToString(), axisFont, textBrush, centerX - 5, centerY - offset, rightFormat);
			        e.Graphics.DrawString((-i).ToString(), axisFont, textBrush, centerX - 5, centerY + offset, rightFormat);
			
			
			        e.Graphics.DrawLine(((i % 2) <= 0) ? penBackgroundThick : penBackgroundThin, VerticalPoint1, VerticalPoint2);
			        e.Graphics.DrawLine(((i % 2) <= 0) ? penBackgroundThick : penBackgroundThin, VerticalPoint3, VerticalPoint4);
			        e.Graphics.DrawLine(((i % 2) <= 0) ? penBackgroundThick : penBackgroundThin, HorizontalPoint1, HorizontalPoint2);
			        e.Graphics.DrawLine(((i % 2) <= 0) ? penBackgroundThick : penBackgroundThin, HorizontalPoint3, HorizontalPoint4);
			    }


}
			
			
		}
	}
}
