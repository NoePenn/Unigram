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
using System.Windows.Forms;

namespace Unigram
{
	/// <summary>
	/// Description of Viewport.
	/// </summary>
	public class Viewport
	{
		float MajorX { get; set; }
		float MajorY { get; set; }
		float MinorX { get; set; }
		float MinorY { get; set; }

		public Viewport() {
			MajorX = 1;
			MajorY = 1;
			MinorX = 0.25f;
			MinorY = 0.25f;
		}

		public void PaintCoordinateSystem(Transformer transformer, Graphics g) {
			Font axisFont = new Font(FontFamily.GenericMonospace, 12);	
            Brush textBrush = Brushes.Black;

			PointF zero = transformer.MathToPixel(new PointF(0, 0));

			var minorPen = new Pen(Color.LightGray);
			for (float xBar = (float)Math.Floor(transformer.XMin / this.MinorX) *  this.MinorX; xBar <= transformer.XMax; xBar += this.MinorX) {
				float x = transformer.MathToPixel(new PointF(xBar, 1)).X;
				g.DrawLine(minorPen, x, 0, x, transformer.VPHeightPX);
			}

			for (float yBar = (float)Math.Floor(transformer.YMin / this.MinorY) *  this.MinorY; yBar <= transformer.YMax; yBar += this.MinorY) {
				float y = transformer.MathToPixel(new PointF(1, yBar)).Y;
				g.DrawLine(minorPen, 0, y, transformer.VPWidthPX, y);
			}

			var majorPen = new Pen(Color.Gray);
			for (float xBar = (float)Math.Floor(transformer.XMin / this.MajorX) *  this.MajorX; xBar <= transformer.XMax; xBar += this.MajorX) {
				float x = transformer.MathToPixel(new PointF(xBar, 1)).X;
				g.DrawLine(majorPen, x, 0, x, transformer.VPHeightPX);
				g.DrawString("" + xBar, axisFont, textBrush, x, zero.Y);
			}

			for (float yBar = (float)Math.Floor(transformer.YMin / this.MajorY) *  this.MajorY; yBar <= transformer.YMax; yBar += this.MajorY) {
				float y = transformer.MathToPixel(new PointF(1, yBar)).Y;
				g.DrawLine(majorPen, 0, y, transformer.VPWidthPX, y);
				g.DrawString("" + yBar, axisFont, textBrush, zero.X, y);
			}
			
			var zeroPen = new Pen(Color.Black);
			g.DrawLine(zeroPen, zero.X, 0, zero.X, transformer.VPHeightPX);
			g.DrawLine(zeroPen, 0, zero.Y, transformer.VPWidthPX, zero.Y);
		}
		
		public void PaintGraph(Graph graph, Graphics g){
			Pen penGraph = new Pen(graph.Color, 1);
			g.DrawCurve(penGraph, graph.PlotPoints.ToArray(), 0.5f);
		}
	}

}
