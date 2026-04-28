/*
 * Created by SharpDevelop.
 * User: noepe
 * Date: 14.04.2026
 * Time: 15:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Unigram
{
	/// <summary>
	/// Description of Viewport.
	/// </summary>
	public class Viewport
	{


		
		
		public void PixelCrafter(System.Windows.Forms.PaintEventArgs e, int scaleX, int scaleY, float trackBarValue)
		{

			
			float linesOffset = trackBarValue;
			float viewportOffsetX = scaleX/2;
			float viewportOffsetY = scaleY/2;
			
			Pen penMiddle = new Pen(Color.Black, 4);
			Pen penBackgroundThick = new Pen(Color.Gray, 2);
			Pen penBackgroundThin = new Pen(Color.Gray, 1);
			Pen functionPen = new Pen(Color.Red, 3);
			Font axisFont = new Font("Arial", 12);	
            Brush textBrush = Brushes.Black;
			
            
            
            float centerX = viewportOffsetX; //how far away the Middle lines are drawn from Origin
            float centerY = viewportOffsetY;
            
			int labelStep = linesOffset > 30 ? 1 : linesOffset > 15 ? 2 : 5; //If zoomed into Graph via Trackbar more lines appear
			
			float linesCountX = scaleX / (linesOffset); //Linesoffset should be split into X and Y soon!
            float linesCountY = scaleY / (linesOffset);
            
			StringFormat centerFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far };
			StringFormat rightFormat = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center };
			
			// Draw central horizontal axis (thick black)
			e.Graphics.DrawLine(penMiddle, 0, centerY, scaleX, centerY);
	
			// Draw central vertical axis (thick black) 
			e.Graphics.DrawLine(penMiddle, centerX, 0, centerX, scaleY);
				
							
		    for (int i = 1; i < linesCountX; i++) //draw Lines from Middle lines two the edge (thick and thin)
				{
			    float offsetX = linesOffset * i; //Offset from the middle Lines
			    
			    PointF HorizontalPoint1 = new PointF(0, centerY + offsetX);
			    PointF HorizontalPoint2 = new PointF(scaleX, centerY + offsetX);
			    PointF HorizontalPoint3 = new PointF(0, centerY - offsetX);
			    PointF HorizontalPoint4 = new PointF(scaleX, centerY - offsetX);
			
			
			
			    if (i % labelStep == 0) //
			    {
			        e.Graphics.DrawString(i.ToString(), axisFont, textBrush, centerY + 5, centerX + offsetX);
			        //e.Graphics.DrawString((-i).ToString(), axisFont, textBrush, centerY + 5, centerX - offsetX);
			
					var pen = (i % 2) <= 0 ? penBackgroundThick : penBackgroundThin;
			        e.Graphics.DrawLine(pen, HorizontalPoint1, HorizontalPoint2);
			        e.Graphics.DrawLine(pen, HorizontalPoint3, HorizontalPoint4);
			    }


	}
		    for (int i = 1; i < linesCountX; i++) //draw Lines from Middle lines two the edge (thick and thin)
				{
			    float offsetY = linesOffset * i; //Offset from the middle Lines
			    
			    PointF VerticalPoint1 = new PointF(centerX + offsetY, 0);
			    PointF VerticalPoint2 = new PointF(centerX + offsetY, scaleY);
			    PointF VerticalPoint3 = new PointF(centerX - offsetY, 0);
			    PointF VerticalPoint4 = new PointF(centerX - offsetY, scaleY);
			
			
			
			    if (i % labelStep == 0) //
			    {
			        e.Graphics.DrawString(i.ToString(), axisFont, textBrush, centerY + linesOffset, centerX + 5, centerFormat);
			        e.Graphics.DrawString((-i).ToString(), axisFont, textBrush, centerY - linesOffset, centerX + 5, centerFormat);
			        e.Graphics.DrawString(i.ToString(), axisFont, textBrush, centerY - 5, centerX - linesOffset, rightFormat);
			        e.Graphics.DrawString((-i).ToString(), axisFont, textBrush, centerY - 5, centerX + linesOffset, rightFormat);
			        
					var pen = (i % 2) <= 0 ? penBackgroundThick : penBackgroundThin;
			        e.Graphics.DrawLine(pen, VerticalPoint1, VerticalPoint2);
			        e.Graphics.DrawLine(pen, VerticalPoint3, VerticalPoint4);

			    }


	}
			
			
		}
	}
}
