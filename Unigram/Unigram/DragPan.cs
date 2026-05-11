// MainForm.DragPan.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Unigram
{
    public partial class MainForm
    {
        private bool   _drag;
        private PointF _dragOrigin; // math-space point under the cursor on MouseDown

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            button1.MouseDown += (s, ev) => {
                _drag = true;
                // convert the click pixel to a math-space anchor point
                _dragOrigin = u.PixelToMath(ev.X, ev.Y);
                button1.Cursor = Cursors.SizeAll;
            };

            button1.MouseMove += (s, ev) => {
                if (!_drag) return;
                // where is the mouse NOW in math space?
                PointF current = u.PixelToMath(ev.X, ev.Y);
                // shift the axis so the anchor point stays under the cursor
                float dx = _dragOrigin.X - current.X;
                float dy = _dragOrigin.Y - current.Y;
                trackBarXMinValue += dx;
                trackBarXMaxValue += dx;
                trackBarYMinValue += dy;
                trackBarYMaxValue += dy;
                u.Slider(trackBarXMaxValue, trackBarXMinValue,
                         trackBarYMaxValue, trackBarYMinValue);
                button1.Invalidate();
            };

            button1.MouseUp += (s, ev) => {
                _drag = false;
                button1.Cursor = Cursors.Hand;
            };

            button1.Cursor = Cursors.Hand;
        }
    }
}