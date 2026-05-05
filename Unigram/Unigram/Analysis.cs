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
	/// Provides a comprehensive suite of statistical and mathematical analysis tools 
	/// for a collection of 2D points.
	/// </summary>
	/// <remarks>
	/// For accurate results in interpolation and calculus methods, points must be 
	/// sorted by their X-coordinate.
	/// </remarks>
	
		/* 
		 * LinearRegression(): Calculates the y=mx+d that best represents the trend of your points. returns slope of that line
		 * BoundingBox(): Returns a RectangleF that perfectly encloses all points.
		 * //ScaleY(float factor): Multiplies all Y values by a number (e.g., to convert units).
	 	 * //ShiftY(float offset): Adds a number to all Y values (e.g., to move a graph up or down)
		 */
		
	public class Analysis
	{
		List <PointF> points = new List<PointF>();
		/// <summary>
		/// Initializes a new instance of the Analysis class.
		/// </summary>
		/// <param name="pointsMath">The collection of points to be analyzed. X values should be pre-sorted.</param>
		public Analysis()
		{
		}
		/// <summary>
		/// Finds the point with the lowest Y-value in the collection.
		/// </summary>
		/// <returns>The <see cref="PointF"/> containing the minimum Y value.</returns>
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
		/// Finds the point with the highest Y-value in the collection.
		/// </summary>
		/// <returns>The <see cref="PointF"/> containing the maximum Y value.</returns>
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
		/// Calculates the arithmetic mean (average) of all Y-values.
		/// </summary>
		/// <returns>The average Y-value as a float.</returns>
		public float ArithmeticMean()
		{
			float sum = 0;
			for(int i = 0; i < points.Count; i++)
				sum += points[i].Y;
			
			return sum / points.Count;
		}
		/// <summary>
		/// Determines if the Y-values are monotonically increasing relative to X.
		/// </summary>
		/// <returns>True if every Y-value is greater than or equal to the previous Y-value.</returns>
		public bool IsMonotomicIncreasing()
		{
			for(int i = 0; i < points.Count - 1; i++)
			{
				if(points[i+1].Y < points[i].Y)
					return false;
			}
			return true;
		}
		/// <summary>
		/// Determines if the Y-values are monotonically decreasing relative to X.
		/// </summary>
		/// <returns>True if every Y-value is less than or equal to the previous Y-value.</returns>
		public bool IsMonotomicDecreasing()
		{
			for(int i = 0; i < points.Count - 1; i++)
			{
				if(points[i+1].Y > points[i].Y)
					return false;
			}
			return true;
		}
		/// <summary>
		/// Calculates the Y-value at a specific X-coordinate using linear interpolation.
		/// </summary>
		/// <param name="x">The X-coordinate to evaluate.</param>
		/// <returns>The interpolated Y-value, or 0 if X is outside the range of the point set.</returns>
		public float FindValueY(float x)
		{
			if (x == points[points.Count - 1].X) 
				return points[points.Count - 1].Y;
			
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
		/// Calculates the slope (rate of change) of the segment containing the specified X-coordinate.
		/// </summary>
		/// <param name="x">The X-coordinate to evaluate.</param>
		/// <returns>The slope (dy/dx) of the local segment.</returns>
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
		/// Calculates the definite integral (area under the curve) between two X-coordinates.
		/// </summary>
		/// <param name="a">The starting X-bound.</param>
		/// <param name="b">The ending X-bound.</param>
		/// <returns>The calculated area using the trapezoidal rule.</returns>
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
		/// Calculates the total area under the entire curve from the first to the last point.
		/// </summary>
		/// <returns>The total area as a float.</returns>
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
		/// Identifies local minima in the dataset based on a sensitivity threshold.
		/// </summary>
		/// <param name="offset">The minimum vertical difference required to consider a point a local minimum.</param>
		/// <returns>A list of points representing local minima.</returns>
		public List <PointF> LocalMin(float offset)
		{
			List <PointF> localMin = new List<PointF>();
			for( int i = 1; i < points.Count-1; i++)
			{
				if (points[i-1].Y + offset > points[i].Y && points[i+1].Y + offset > points[i].Y )  
					localMin.Add( points[i] );
			}
			return localMin;
		}
		/// <summary>
		/// Identifies local maxima in the dataset based on a sensitivity threshold.
		/// </summary>
		/// <param name="offset">The minimum vertical difference required to consider a point a local maximum.</param>
		/// <returns>A list of points representing local maxima.</returns>
		public List <PointF> LocalMax(float offset)
		{
			List <PointF> localMax = new List<PointF>();
			for( int i = 1; i < points.Count-1; i++)
			{
				if (points[i-1].Y - offset < points[i].Y && points[i+1].Y - offset < points[i].Y ) 
					localMax.Add( points[i] );
			}
			return localMax;
		}
		/// <summary>
		/// Appends a single point to the existing data collection.
		/// </summary>
		/// <param name="addPoint">The <see cref="PointF"/> to add.</param>
		public void AddPoint( PointF addPoint)
		{
			points.Add( addPoint);
		}
		/// <summary>
		/// Calculates the variance of the Y-values.
		/// </summary>
		/// <returns>The variance as a float.</returns>
		public float Variance()
		{
			float sum = 0;
			for(int i = 0; i < points.Count; i++)
			{
				sum += ( points[i].Y - ArithmeticMean() ) * ( points[i].Y - ArithmeticMean() );
			}
			return sum / points.Count;
		}
		/// <summary>
		/// Calculates the standard deviation of the Y-values to measure data dispersion. 
		/// </summary>
		/// <returns>The standard deviation as a float.</returns>
		public float StandardDevitation()
		{
			return (float)Math.Sqrt( Variance() );
		}
		/// <summary>
		/// Calculates the total Euclidean distance along the path connecting all points in sequence.
		/// </summary>
		/// <returns>The total length of the polyline path.</returns>
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
		/// Finds the X-intercepts (roots) where the curve crosses Y = 0.
		/// </summary>
		/// <returns>A list of points where the line segments intersect the X-axis.</returns>
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
		/// Calculates the geometric mean of the Y-values using the logarithmic sum method.
		/// </summary>
		/// <remarks>This calculation is only valid for datasets where all Y-values are greater than zero.</remarks>
		/// <returns>The geometric mean, or 0 if any value is non-positive.</returns>
		public float GeometricMean() //with ln sum
		{
			if( IsStrictlyPositive() == false)
				return 0;
			float sum = 0;
			for(int i = 0; i < points.Count; i++)
			{
				sum += (float)Math.Log( points[i].Y);
			}
			return (float)Math.Pow( Math.E, 1.0/points.Count * sum);
		}
		/// <summary>
		/// Validates if every Y-value in the dataset is strictly greater than zero.
		/// </summary>
		/// <returns>True if all Y-values are positive; otherwise, false.</returns>
		public bool IsStrictlyPositive()
		{
			int isStrictlyPositive = 0;
			for(int i = 0; i < points.Count; i++)
			{
				if(points[i].Y > 0)
					isStrictlyPositive++;
			}
			if( isStrictlyPositive == points.Count)
				return true;
		return false;
		}
		/// <summary>
		/// Estimates the average period (T) of the signal by calculating the distance between mean-crossing points.
		/// </summary>
		/// <returns>The average interval length between cycles.</returns>
		public float Period()
		{
		    float mean = ArithmeticMean();
		    List<float> crossX = new List<float>();
		
		    // wo Kurve den Mittelwert schneidet
		    for (int i = 0; i < points.Count - 1; i++)
		    {
		        if (points[i].Y < mean && points[i + 1].Y >= mean)
		        {
		            // Lineare Interpolation 
		            float dx = points[i + 1].X - points[i].X;
		            float dy = points[i + 1].Y - points[i].Y;
		            float preciseX = points[i].X + (mean - points[i].Y) * (dx / dy);
		            crossX.Add(preciseX);
		        }
		    }
		
		    if (crossX.Count < 2) 
		    	return 0; // Nicht genug Daten für eine Periode
		
		    float sumDist = 0;
		    for (int i = 0; i < crossX.Count - 1; i++)
		    {
		        sumDist += (crossX[i + 1] - crossX[i]);
		    }
		
		    return sumDist / (crossX.Count - 1);
		}
		
		/// <summary>
		/// Calculates the frequency (f) of the data, defined as the reciprocal of the period (1/T).
		/// </summary>
		/// <returns>The frequency as a float (cycles per X-unit).</returns>
		public float Frequency()
		{
		    float period = Period();
		    if (period == 0) 
		    	return 0;
		    return 1.0f / period;
		}
		/// <summary>
		/// Calculates the Root Mean Square (RMS) of the Y values.
		/// </summary>
		public float RootMeanSquare()
		{
		    float sumSquares = 0;
		    for( int i = 0; i < points.Count; i++)
		    {
		    	sumSquares += points[i].Y * points[i].Y;
		    }
		    return (float)Math.Sqrt(sumSquares / points.Count);
		}
		/*/// <summary>
		/// Finds all points where this graph intersects with another graph.
		/// </summary>
		/// <param name="other">The other Analysis object to compare against.</param>
		/// <returns>A list of PointF where the two curves cross.</returns>
		public List<PointF> IntersectionsWith(Analysis other)
		{
			return new List<PointF>();
		}*/
		/// <summary>
		/// Internal helper to calculate the first derivative of a specific list of points.
		/// </summary>
		/// <param name="pointsDerivative">List of points to differentiate.</param>
		/// <returns>A list of points representing the first derivative (slope at each point).</returns>
		private static List<PointF> FirstDerivative( List<PointF> pointsDerivative)
		{
			List<PointF> derivative = new List<PointF>();
			Analysis analysis = new Analysis( pointsDerivative);
			for(int i = 0; i < pointsDerivative.Count - 1; i++)
			{
				derivative.Add( new PointF( pointsDerivative[i].X, analysis.Slope( pointsDerivative[i].X) ) );
			}
			return derivative;
		}
		/// <summary>
		/// Calculates the n-th order derivative of the dataset.
		/// </summary>
		/// <param name="degree">The order of the derivative (e.g., 1 for first derivative, 2 for second).</param>
		/// <returns>A list of points representing the resulting derivative.</returns>
		public List<PointF> Derivative(int degree)
		{
			List<PointF> result = this.points;
			
			for (int i = 0; i < degree; i++) 
			{
				result = FirstDerivative(result);
			}
			return result;
			/*switch (degree) 
			{
				case 1:
					return FirstDerivative(points);
				case 2:
					return FirstDerivative(FirstDerivative(points) );
				case 3:
					return FirstDerivative(FirstDerivative(FirstDerivative(points) ) );
				
				default:
					return points
			}*/
		}
		/// <summary>
		/// Calculates the horizontal range of the dataset.
		/// </summary>
		/// <returns>The difference between the maximum and minimum X-values.</returns>
		public float RangeX()
		{
			return points[points.Count - 1].X - points[0].X;
		}
		/// <summary>
		/// Calculates the vertical range (peak-to-peak) of the dataset.
		/// </summary>
		/// <returns>The difference between the maximum and minimum Y-values.</returns>
		public float RangeY()
		{
			return Max().Y - Min().Y;
		}
		/// <summary>
		/// Normalizes the Y-values of the dataset so they range between -1 and 1.
		/// </summary>
		/// <returns>A new list of points where Y-values are scaled relative to the maximum absolute Y-value.</returns>
		public List<PointF> Normalize()
		{
			List <PointF> normalize = new List<PointF>();
			float max = (float)Math.Max( Math.Abs( Max().Y ), Math.Abs( Min().Y ) );
			/*if( Math.Abs(Max().Y ) > Math.Abs(Min().Y ) )
				max = Math.Abs( Max().Y );
			else 
				max = Math.Abs( Min().Y );
			*/
			for( int i  = 0; i < points.Count; i++)
			{
				normalize.Add( new PointF( points[i].X, points[i].Y / max ) );
			}
			return normalize;
		}
	}
}
