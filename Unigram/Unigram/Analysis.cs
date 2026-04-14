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
using System.Collections.Generic;

namespace Unigram
{
	/// <summary>
	/// Description of Analysis.
	/// </summary>
	public class Analysis
	{
		List <PointF> points = new List<PointF>();
		
		public Analysis(List <PointF> pointsMath)
		{
			points.AddRange( pointsMath);
		}
		/// <summary>
		/// minimum Y
		/// </summary>
		/// <returns>PointF with smalest Y value</returns>
		public PointF Min()
		{
			PointF min = points[0];
			for( int i = 0; i < points.Count ; i++)
			{
				if(points[i].Y < min.Y)
				{
					min = points[i];					
				}
			}
			return min;
		}
		/// <summary>
		/// maximum Y
		/// </summary>
		/// <returns>PointF with biggest Y value</returns>
		public PointF Max()
		{
			PointF max = points[0];
			for( int i = 0; i < points.Count ; i++)
			{
				if(points[i].Y > max.Y)
				{
					max = points[i];					
				}
			}
			return max;
		}
		/// <summary>
		/// Arithmetic Mean of Y
		/// </summary>
		/// <returns>float </returns>
		public float ArithmeticMean()
		{
			float sum = 0;
			for(int i = 0; i < points.Count; i++)
				sum += points[i].Y;
			
			return sum / points.Count;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>1 if y is increasing as x is increasing</returns>
		public int IsMonotomicIncreasing()
		{
			for(int i = 0; i < points.Count - 1; i++)
			{
				if(points[i+1].Y < points[i].Y)
					return 0;
			}
			return 1;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>1 if y is decreasing as x is increasing</returns>
		public int IsMonotomicDecreasing()
		{
			for(int i = 0; i < points.Count - 1; i++)
			{
				if(points[i+1].Y > points[i].Y)
					return 0;
			}
			return 1;
		}
		/// <summary>
		/// finds or calculates y value at x
		/// </summary>
		/// <para>Warning:  x must be between 1. and last x, else returns 0</para>
		/// <returns>PointF with x and y</returns>
		public PointF FindValueY(float x)
		{
			for( int i = 0; i < points.Count - 1; i++)
			{
		        PointF p1 = points[i];
		        PointF p2 = points[i + 1];

		        if (x >= p1.X && x <= p2.X)
		        {
		            float dx = p2.X - p1.X;
		
					// x = p1
		            if (dx == 0) 
		            	return p1;
					
		            // % x zwischen p1 und p2
		            float t = (x - p1.X) / dx;
		
		            float y = p1.Y + t * (p2.Y - p1.Y);
		
		            return new PointF(x, y);
		        }
		    }
		
		    // x nicht zwischen x1 und xn 
		    return PointF.Empty; 		
		}
	}
}
