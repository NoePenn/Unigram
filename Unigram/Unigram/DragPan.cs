// MainForm.DragPan.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unigram
{
    public partial class MainForm
    {
        private bool _drag;
        private PointF _dragOrigin; // math-space point under the cursor on MouseDown

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            button1.MouseDown += (s, ev) =>
            {
                _drag = true;
                // convert the click pixel to a math-space anchor point
                _dragOrigin = u.PixelToMath(ev.X, ev.Y);
                button1.Cursor = Cursors.SizeAll;
            };

            button1.MouseMove += (s, ev) =>
            {
                if (!_drag) return;
                // where is the mouse NOW in math space?
                PointF current = u.PixelToMath(ev.X, ev.Y);
                // shift the axis so the anchor point stays under the cursor
                float dx = _dragOrigin.X - current.X;
                float dy = _dragOrigin.Y - current.Y;
                u.MoveCoordinateSystemCenter(dx, dy);
                button1.Invalidate();
            };

            button1.MouseUp += (s, ev) =>
            {
                _drag = false;
                button1.Cursor = Cursors.Hand;
            };

            button1.Cursor = Cursors.Hand;
            button1.Cursor = Cursors.Hand;
            button1.MouseWheel += (s, ev) =>
            {
            	var currentBounds = u.GetCoordinateSystemBoundary();
                float zoomFactor = ev.Delta > 0 ? 0.9f : 1.1f;
                PointF mouseInMath = u.PixelToMath(ev.X, ev.Y);
                float newWidth = currentBounds.Width * zoomFactor;
                float newHeight = currentBounds.Height * zoomFactor;
                float relativeX = (mouseInMath.X - currentBounds.X) / currentBounds.Width;
                float relativeY = (mouseInMath.Y - currentBounds.Y) / currentBounds.Height;
                float newX = mouseInMath.X - (relativeX * newWidth);
                float newY = mouseInMath.Y - (relativeY * newHeight);
                u.SetCoordinateSystemBoundary(new RectangleF(newX, newY, newWidth, newHeight));
                u.Viewport.MajorX = (float)Math.Pow(10, Math.Floor(Math.Log10(newHeight * 5))) / 10;
                u.Viewport.MajorY = u.Viewport.MajorX;
                u.Viewport.MinorX = u.Viewport.MajorX / 5;
                u.Viewport.MinorY = u.Viewport.MajorY / 5;
                button1.Invalidate();
            };

            // Wichtig: Damit das MouseWheel-Event gefeuert wird, muss der Button fokussierbar sein
            button1.MouseEnter += (s, ev) => button1.Focus();
        }
    }
}