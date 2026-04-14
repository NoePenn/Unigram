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
		/// <returns>PointF</returns>
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
		/// <returns>PointF</returns>
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
		public float Average()
		{
			float sum = 0;
			for(int i = 0; i < points.Count; i++)
				sum += points[i].Y;
			
			return sum / points.Count;
		}
	}
}
