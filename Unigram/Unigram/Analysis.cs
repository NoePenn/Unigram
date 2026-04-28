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
	/// Analyses a set of points
	/// </summary>
	public class Analysis
	{
		List <PointF> points = new List<PointF>();
		/// <summary>
		/// x values must be sorted
		/// </summary>
		/// <param name="pointsMath">points that get analysed</param>
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
		/// <para>Warning: x must be between 1. and last x, else returns empty PointF</para>
		/// <returns>y as float</returns>
		public float FindValueY(float x)
		{
			for( int i = 0; i < points.Count - 1; i++)
			{
		        PointF p1 = points[i];
		        PointF p2 = points[i + 1];

		        if(x >= p1.X && x <= p2.X)
		        {
		            float dx = p2.X - p1.X;
		
					// x = p1
		            if(dx == 0) 
		            	return p1.Y;
					
		            // % x zwischen p1 und p2
		            float t = (x - p1.X) / dx;
		
		            float y = p1.Y + t * (p2.Y - p1.Y);
		
		            return y;
		        }
		    }
		
		    // x nicht zwischen x1 und xn 
		    return 0; 		
		}
		/// <summary>
		/// Finds slope to next given point
		/// </summary>
		/// <para>Warning: x must be between 1. and last x, else returns 0
		/// <returns>slope as float</returns>
		public float Slope(float x)
		{
			if(x == points[ points.Count - 1].X)
				return 0;
			
			float y = FindValueY(x);
				 
			for( int i = 0; i < points.Count - 1; i++)
			{
		        if(x >= points[i].X && x <= points[i + 1].X)
		        {
					float dx = points[i + 1].X - points[i].X;
            		float dy = points[i + 1].Y - points[i].Y;
					
            		if (dx == 0) 
            			continue; // nächster punkt wird gesucht

            		return dy / dx; // (y2 - y1) / (x2 - x1)
		        }
			}
			// nicht in list
			return 0;
		}
		/// <summary>
		/// area under curve from a to b
		/// </summary>
		/// <param name="a">start x</param>
		/// <param name="b">end x</param>
		/// <returns>aera as float</returns>
		public float Integral(float a, float b)
		{
			if (a > b)
				return -Integral(b, a);

		    float area = 0;
		
		    for (int i = 0; i < points.Count - 1; i++)
		    {
		        float x1 = points[i].X;
		        float x2 = points[i + 1].X;
		
		        float left = Math.Max(a, x1);
		        float right = Math.Min(b, x2);
		
		        // Nur rechnen wenn zwischen a und b
		        if (left < right)
		        {
		            float width = right - left;
		
		            float yLeft = FindValueY(left);
		            float yRight = FindValueY(right);
		
		            float avgHeight = (yLeft + yRight) / 2.0f;
		            area += width * avgHeight;
		        }
		    }
		
		    return area;
		}
		/// <summary>
		/// area under total curve
		/// </summary>
		/// <returns>aera as float</returns>
		public float Integral()
		{
			float area = 0;
			
			for (int i = 0; i < points.Count - 1; i++)
			{
				float width = points[i + 1].X - points[i].X;
				float avgHeight = (points[i].Y + points[i + 1].Y) / 2;
				area += width * avgHeight;
			}
			return area;
		}
		/// <summary>
		/// finds all turning Points
		/// </summary>
		/// <param = "offset"> what must be min offset to be turningPoint</param>
		/// <returns>List of PointF</returns>
		public List <PointF> TurningPoints(float offset)
		{
			List <PointF> turningPoints = new List<PointF>();
			for( int i = 1; i < points.Count-1; i++)
			{
				if(points[i-1].Y + offset > points[i].Y && points[i+1].Y + offset > points[i].Y ) || (points[i-1].Y - offset < points[i].Y && points[i+1].Y - offset < points[i].Y ) )
					turningPoints.Add( points[i] );
			}
			return turningPoints;
		}
		/// <summary>
		/// adds new point to list
		/// </summary>
		/// <param name="addPoint"> new PointF</param>
		public void AddPoint( PointF addPoint)
		{
			points.Add( addPoint);
		}
		/// <summary>
		/// standart devitation
		/// </summary>
		/// <returns>standart devitation as float</returns>
		public float StandartDevitation()
		{
			float sum = 0;
			for(int i = 0; i < points.Count; i++)
			{
				sum += ( points[i].Y - ArithmeticMean() ) * ( points[i].Y - ArithmeticMean() );
			}
			return (float)Math.Sqrt(sum / points.Count);
		}
		/// <summary>
		/// calculates lengh of path if points are connected
		/// </summary>
		/// <returns>lengh as float</returns>
		public float PathLength()
		{
			float pathLength = 0;
			for (int i = 0; i < points.Count - 1; i++)
			{
				float dx = points[i + 1].X - points[i].X;
				float dy = points[i + 1].Y - points[i].Y;
				pathLength += (float)Math.Sqrt(dx * dx + dy * dy);
			}
			return pathLength;
		}
		/// <summary>
		/// finds Points where Y = 0
		/// </summary>
		/// <returns>List of PointF</returns>
		public List<PointF> InterceptsX()
		{
			List<PointF> interceptsX = new List<PointF>();
			for (int i = 0; i < points.Count - 1; i++)
			{
				if ((points[i].Y > 0 && points[i+1].Y < 0) || (points[i].Y < 0 && points[i+1].Y > 0))
				{
					float dx = points[i+1].X - points[i].X;
					float dy = points[i+1].Y - points[i].Y;
					// Lineare interpolation
					PointF rootX = new PointF( points[i].X - points[i].Y * (dx / dy), 0);
					interceptsX.Add(rootX);
				}
				else if (points[i].Y == 0) 
				{
					interceptsX.Add(points[i]);
				}
			}
			return interceptsX;
		}
		/// <summary>
		/// finds geometric Mean with sum of ln formula
		/// <para>Only works if values are greater than zero</para>
		/// </summary>
		/// <returns>geometric Mean as float</returns>
		public float GeometricMean() //mit ln summe
		{
			if( IsStrictlyPositive() == 0)
				return 0;
			float sum = 0;
			for(int i = 0; i < points.Count; i++)
			{
				sum += (float)Math.Log( points[i].Y);
			}
			return (float)Math.Pow( Math.E, 1.0/points.Count * sum);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public int IsStrictlyPositive()
		{
			int isStrictlyPositive = 0;
			for(int i = 0; i < points.Count; i++)
			{
				if(points[i].Y > 0)
					isStrictlyPositive++;
			}
			if( isStrictlyPositive == points.Count)
				return 1;
		return 0;
		}
	}
}
