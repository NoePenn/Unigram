using System;
using System.Drawing;
using System.Collections.Generic;

namespace Unigram
{
	/// <summary>
	/// Represents a visual graph object that manages geometric transformation and analysis of plotted points.
	/// </summary>
	public class Graph {
		List <PointF> points = new List<PointF>();
		List <PointF> plotPoints = new List<PointF>();
		Analysis analysis;
		
		public Graph(Color color) {
			this.Color = color;
			this.analysis = new Analysis();
		}	
		
		/// <summary>
		/// Gets or sets the color used to render the graph visualization.
		/// </summary>
		public Color Color { get; set; }
		/// <summary>
		/// Gets the analysis object that provides computational analysis of the plotted graph data.
		/// </summary>
		public Analysis Analysis { get {return analysis; } }
		
		public List<PointF> Points { get { return this.points; } }
		public List<PointF> PlotPoints { get { return this.plotPoints; } }
		
		
		/// <summary>
		/// Adds a point to the graph and transforms it according to the viewport dimensions.
		/// </summary>
		/// <param name="point">The point coordinates to add to the graph.</param>
		public void AddPoint(PointF point, Transformer transformer) {
			points.Add(point);
			plotPoints.Add(transformer.MathToPixel(point));
			Analysis.AddPoint(point);
		}

		public void UpdatePlot(Transformer transformer) {
			for (int i = 0; i < this.Points.Count; i++) {
				this.PlotPoints[i] = transformer.MathToPixel(this.Points[i]);
			}
		}
	}
}
