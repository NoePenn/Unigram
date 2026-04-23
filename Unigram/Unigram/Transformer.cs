/*
 * Created by SharpDevelop.
 * User: noepe
 * Date: 14.04.2026
 * Time: 15:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
// using System.Drawing;

namespace Unigram
{
	/// <summary>
	/// This class can convert mathematical points to pixel coordinates and viceversa, every time the coordinate system changes, UpdateTransformer() MUST be called.
	/// </summary>
	public class Transformer
	{
	    int VPHeight { get; set; }
		int VPWidth { get; set; }
		
		/// <summary>
		/// Is the X-axis logarithmic?
		/// </summary>
		bool XLog { get; set; }
		/// <summary>
		/// Is the Y-axis logarithmic?
		/// </summary>
		bool YLog { get; set; }
		
		
		
		/// <summary>
		/// Returns the lowest value for X (at the bottom of the graph) 
		/// </summary>
		float XMin { get; set; }
		/// <summary>
		/// Returns the maximum value for X (at the top of the graph)
		/// </summary>
		float XMax { get; set; }
		
		/// <summary>
		/// Returns the lowest value for Y (at the left of the graph) 
		/// </summary>
		float YMin { get; set; }
		/// <summary>
		/// Returns the maximum value for Y (at the right of the graph)
		/// </summary>
		float YMax { get; set; }
	
	    // Precomputed in UpdateTransformer()
	    private float _scaleX, _scaleY, _logXMin, _logYMin;
	
	    public void UpdateTransformer()
	    {
	        _scaleX  = XLog ? VPWidth  / (float)Math.Log(XMax / XMin) : VPWidth  / (XMax - XMin);
	        _scaleY  = YLog ? VPHeight / (float)Math.Log(YMax / YMin) : VPHeight / (YMax - YMin);
	        _logXMin = XLog ? (float)Math.Log(XMin) : 0;
	        _logYMin = YLog ? (float)Math.Log(YMin) : 0;
	    }
	
	    public PointF MathToPixel(PointF point)
	    {
	        float u = XLog ? ((float)Math.Log(point.X) - _logXMin) * _scaleX : (point.X - XMin) * _scaleX;
	        float v = YLog ? ((float)Math.Log(point.Y) - _logYMin) * _scaleY : (point.Y - YMin) * _scaleY;
	        return new PointF(u, VPHeight - v);
	    }
	    
	    public PointF PixelToMath(PointF pixel)
		{
		    float u = pixel.X / _scaleX;
		    float v = (VPHeight - pixel.Y) / _scaleY;
		
		    float x = XLog ? (float)Math.Exp(u + _logXMin) : u + XMin;
		    float y = YLog ? (float)Math.Exp(v + _logYMin) : v + YMin;
		
		    return new PointF(x, y);
		}
	}
}
