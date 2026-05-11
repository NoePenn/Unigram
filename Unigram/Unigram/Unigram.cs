/*
 * Created by SharpDevelop.
 * User: noepe
 * Date: 14.04.2026
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Unigram
{
	/// <summary>
	/// Description of Unigram.
	/// </summary>
	public class Unigram
	{
		public Viewport Viewport { get; private set; }
		List<Graph> graphs;
		Transformer transformer;

		public Unigram()
		{
			Viewport = new Viewport();
			graphs = new List<Graph>();
			transformer = new Transformer();
		}

		public int AddGraph(Color color)
		{
			int idx = this.graphs.Count;
			this.graphs.Add(new Graph(color));
			return idx;
		}

		public void SetCoordinateSystemBoundary(RectangleF coordinateSystemBoundaries)
		{
			transformer.XMin = coordinateSystemBoundaries.Left;
			transformer.XMax = coordinateSystemBoundaries.Right;
			transformer.YMin = coordinateSystemBoundaries.Top;
			transformer.YMax = coordinateSystemBoundaries.Bottom;
			transformer.UpdateTransformer();
		}

		public RectangleF GetCoordinateSystemBoundary()
		{
			return new RectangleF(transformer.XMin, transformer.YMin, transformer.XMax - transformer.XMin, transformer.YMax - transformer.YMin);
		}

		public PointF PixelToMath(float x, float y)
		{
			return transformer.PixelToMath(new PointF(x, y));
		}
		
		public void MoveCoordinateSystemCenter(float xOff, float yOff)
		{
			transformer.XMin += xOff;
			transformer.XMax += xOff;
			transformer.YMin += yOff;
			transformer.YMax += yOff;
			transformer.UpdateTransformer();
		}

		public void AddPoint(int graphIdx, PointF point)
		{
			this.graphs[graphIdx].AddPoint(point, this.transformer);
		}

		void UpdateTransformerPixel(int width, int height)
		{
			if (transformer.VPWidthPX != width || transformer.VPHeightPX != width)
			{
				transformer.VPWidthPX = width;
				transformer.VPHeightPX = height;
				transformer.UpdateTransformer();
				for (int i = 0; i < graphs.Count; i++)
				{
					this.graphs[i].UpdatePlot(this.transformer);
				}
			}
		}

		public void Paint(int width, int height, Graphics g)
		{
			this.UpdateTransformerPixel(width, height);
			this.Viewport.PaintCoordinateSystem(transformer, g);
			for (int i = 0; i < graphs.Count; i++)
			{
				this.Viewport.PaintGraph(this.graphs[i], g);
			}
		}
		public Analysis GetAnalysis(int graphIdx)
		{
			return graphs[graphIdx].Analysis;
		}
	}
}
