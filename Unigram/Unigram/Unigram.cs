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
		Viewport viewport;
		List<Graph> graphs;
		Transformer transformer;

		public Unigram()
		{
		}

		public int AddGraph(Color color)
		{
			int idx = this.graphs.Count;
			this.graphs.Add(new Graph(color));
			return idx;
		}

		public void AddPoint(int graphIdx, PointF point)
		{
			this.graphs[graphIdx].AddPoint(point, this.transformer);
		}

		void UpdateTransformerPixel(int width, int height) {
			if (transformer.VPWidthPX != width || transformer.VPHeightPX != width) {
				transformer.VPWidthPX = width;
				transformer.VPHeightPX = height;
				transformer.UpdateTransformer();
				for (int i = 0; i < graphs.Count; i++) {
					this.graphs[i].UpdatePlot(this.transformer);
				}
			}
		}

		public void Paint(int width, int height, Graphics g) {
			this.UpdateTransformerPixel(width, height);
			this.viewport.PaintCoordinateSystem(transformer, g);
			for (int i = 0; i < graphs.Count; i++)  {
				this.viewport.PaintGraph(this.graphs[i]);
			}
		}
	}
}
