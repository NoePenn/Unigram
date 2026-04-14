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
		
		/// <summary>
		/// Is the X-axis logarithmic?
		/// </summary>
		bool XLog { get; set; }
		/// <summary>
		/// Is the Y-axis logarithmic?
		/// </summary>
		bool YLog { get; set; }
		
		/// <summary>
		/// Returns how many units there are from left to right (Example: from -2 to 5 => width=7)
		/// </summary>
		float width { get; set; }
		// Transformer.Xzoom < 0 ? Transformer.Xzoom = 0;
		/// <summary>
		/// Returns how many units there are from top to bottom (Example: from -2 to 5 => width=7)
		/// </summary>
		float height { get; set; }
		
		/// <summary>
		/// Returns the distance in units from the bottom to the X-axis
		/// </summary>
		float offXaxis { get; set; }
		/// <summary>
		/// Returns the distance in units from the left to the Y-axis
		/// </summary>
		float offYaxis { get; set; }
		
		PointF MathToPixel (PointF point, float VPHeight, float VPWidth) // VP: size in Pixels
		{
			
		}
		
		
		
	}
}
