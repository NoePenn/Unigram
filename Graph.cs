using System;
using System.Drawing;

namespace Unigram
{
	/// <summary>
	/// Gasser muas do no inni kochn
	/// </summary>
	public class Graph {
				
		public Graph(Color color, Transformer transformer, Analysis analysis) {
			this.Color = color;
			this.Transformer = transformer;
			
		}
		/// <summary>
		/// Gasser muas do no inni kochn
		/// </summary>
		Color Color { get; set; }
		/// <summary>
		/// Gasser muas do no inni kochn
		/// </summary>
		Transformer Transformer { get; set; }
		/// <summary>
		/// Gasser muas do no inni kochn
		/// </summary>
		Analysis Analysis { get; } 
		
		public void AddPoint(PointF point, float viewPortHeight, float viewPortWidth) {
			
		}
	}
}
