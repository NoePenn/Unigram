// SerialReader.cs
// Reads analog samples sent by AnalogRead.ino over a COM port
// and feeds them into a Unigram graph in real-time.
//
// Usage in MainForm.cs:
//
//   SerialReader reader = new SerialReader(u, graphIndex, "COM3");
//   reader.Start();
//   // ... later:
//   reader.Stop();
//
// X-axis = time in seconds since Start().
// Y-axis = raw ADC value (0-1023) or voltage (0-5 V), see UseVoltage.

using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace Unigram
{
    /// <summary>
    /// Reads CSV lines ("raw,voltage") from an Arduino Nano over a serial port
    /// and adds the samples as (time, value) points to a Unigram graph.
    /// </summary>
    public class SerialReader
    {
        // ── Configuration ──────────────────────────────────────────────────────

        /// <summary>COM port name, e.g. "COM3".</summary>
        public string PortName { get; set; }

        /// <summary>Must match BAUD_RATE in AnalogRead.ino (default 115200).</summary>
        public int BaudRate { get; set; }

        /// <summary>
        /// When true, Y is the voltage (0-5 V).
        /// When false, Y is the raw ADC value (0-1023).
        /// </summary>
        public bool UseVoltage { get; set; }

        /// <summary>
        /// Set to your button1 or MainForm for thread-safe UI refresh.
        /// </summary>
        public Control InvokeTarget { get; set; }

        // ── Private state ───────────────────────────────────────────────────────
        private readonly Unigram _unigram;
        private readonly int     _graphIndex;
        private SerialPort       _port;
        private DateTime         _startTime;
        private bool             _running;

        // ── Constructor ─────────────────────────────────────────────────────────
        public SerialReader(Unigram unigram, int graphIndex, string portName)
        {
            if (unigram  == null) throw new ArgumentNullException("unigram");
            if (portName == null) throw new ArgumentNullException("portName");

            _unigram    = unigram;
            _graphIndex = graphIndex;
            PortName    = portName;
            BaudRate    = 115200;
            UseVoltage  = false;
        }

        // ── Public API ───────────────────────────────────────────────────────────

        /// <summary>Opens the serial port and begins receiving samples.</summary>
        public void Start()
        {
            if (_running) return;

            _port = new SerialPort(PortName, BaudRate);
            _port.NewLine      = "\n";
            _port.ReadTimeout  = 2000;
            _port.WriteTimeout = 500;

            _port.DataReceived += OnDataReceived;
            _port.Open();

            _startTime = DateTime.UtcNow;
            _running   = true;
        }

        /// <summary>Closes the serial port and stops receiving.</summary>
        public void Stop()
        {
            _running = false;

            if (_port != null && _port.IsOpen)
            {
                _port.DataReceived -= OnDataReceived;
                _port.Close();
                _port.Dispose();
                _port = null;
            }
        }

        // ── Internal ─────────────────────────────────────────────────────────────

        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_running) return;

            try
            {
                string line = _port.ReadLine().Trim();

                // Expected format from Arduino: "512,2.5000"
                string[] parts = line.Split(',');
                if (parts.Length < 2) return;

                int   raw     = 0;
                float voltage = 0f;

                if (!int.TryParse(parts[0], out raw)) return;
                if (!float.TryParse(parts[1],
                        System.Globalization.NumberStyles.Float,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out voltage)) return;

                float x     = (float)(DateTime.UtcNow - _startTime).TotalSeconds;
                float y     = UseVoltage ? voltage : (float)raw;
                PointF point = new PointF(x, y);

                // Must update UI on the main thread
                if (InvokeTarget != null && InvokeTarget.InvokeRequired)
                {
                    PointF captured = point;
                    InvokeTarget.Invoke(new Action(delegate { AddAndRefresh(captured); }));
                }
                else
                {
                    AddAndRefresh(point);
                }
            }
            catch (TimeoutException)
            {
                // ignore read timeouts
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("[SerialReader] " + ex.Message);
            }
        }

        private void AddAndRefresh(PointF point)
        {
            _unigram.AddPoint(_graphIndex, point);
            if (InvokeTarget != null)
                InvokeTarget.Invalidate();
        }
    }
}