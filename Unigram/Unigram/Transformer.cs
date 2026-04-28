/*
 * Created by SharpDevelop.
 * User: noepe
 * Date: 14.04.2026
 * Time: 15:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace Unigram
{
	/// <summary>
	/// Description of Transformer.
	/// </summary>
	public class Transformer
	{
		
	    public int VPHeightPX { get; set; }
	    public int VPWidthPX  { get; set; }
	    public bool XLog    { get; set; }
	    public bool YLog    { get; set; }
	    public float XMin   { get; set; }
	    public float XMax   { get; set; }
	    public float YMin   { get; set; }
	    public float YMax   { get; set; }
	
	    // Precomputed in UpdateTransformer()
	    private float _scaleX, _scaleY, _logXMin, _logYMin;
		
	    Transformer(){
	    	XLog = false;
	    	YLog = false;
	    	
	    	XMin = 	5;
	    	XMax = 5;
	    	
	    	YMin = 	5;
	    	YMax = 5;
		}
	    
	    public void UpdateTransformer()
	    {
	        _scaleX  = XLog ? VPWidthPX  / (float)Math.Log(XMax / XMin) : VPWidthPX  / (XMax - XMin);
	        _scaleY  = YLog ? VPHeightPX / (float)Math.Log(YMax / YMin) : VPWidthPX / (YMax - YMin);
	        _logXMin = XLog ? (float)Math.Log(XMin) : 0;
	        _logYMin = YLog ? (float)Math.Log(YMin) : 0;
	    }
	
	    public PointF MathToPixel(PointF point)
	    {
	        float u = XLog ? ((float)Math.Log(point.X) - _logXMin) * _scaleX : (point.X - XMin) * _scaleX;
	        float v = YLog ? ((float)Math.Log(point.Y) - _logYMin) * _scaleY : (point.Y - YMin) * _scaleY;
	        return new PointF(u, VPHeightPX - v);
	    }
	}
}
