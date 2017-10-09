using PcapDotNet.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Data_Monitor_GUI
{
    public partial class Main : Form
    {
        // Variables that store the graphic elements for easy access.
        public Label timerLabel;
        public Label byteTotal;
        private Panel holder;
        private Panel data;
        private Label[] ylabels;
        private Panel ylabel;

        // Variables that determine how data is displayed.
        private List<Point> points = new List<Point>();
        private ArrayList packetSize = new ArrayList();
        private short spacing = 64;

        // Network monitoring related variables.
        private IList<LivePacketDevice> devices = LivePacketDevice.AllLocalMachine;
        private PacketCollector collector;

        // Graphic elements are created and initialized.
        public Main()
        {
            InitializeComponent();
            timerLabel = (Label)Controls.Find("timer", true)[0];
            byteTotal = bytesUsed;

            AutoSize = false;
            Resize += new EventHandler(resize);

            holder = new Panel()
            {
                Name = "graphHolder",
                AutoScroll = true
            };
            holder.VerticalScroll.Enabled = false;
            holder.Location = new Point(80, 0);
            holder.MinimumSize = new Size((int)dataWrap.Width - 80, (int)dataWrap.Height - 80);
            holder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataWrap.Controls.Add(holder);

            data = new Panel()
            {
                Name = "data",
                Location = new Point(0, 0),
                Size = new Size(holder.Width - 2, holder.Height - 2)
            };
            data.Paint += new PaintEventHandler(paintGraph);
            holder.Controls.Add(data);

            // Contains y-axis labels.
            ylabel = new Panel();
            ylabels = new Label[9];
            ylabel.Name = "ylable";
            ylabel.Location = new Point(0, 0);
            ylabel.Size = new Size(80, holder.Height);
            dataWrap.Controls.Add(ylabel);

            // Create and position the y-axis labels.
            int ypos = data.Height / 10;
            for (int i = 0, bytes = 18000; i < 9; i++, bytes -= 2000)
            {
                Label y = new Label()
                {
                    Text = bytes.ToString(),
                    AutoSize = false,
                    Width = 80,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                y.Location = new Point(0, ypos - y.Height / 2);
                ylabel.Controls.Add(y);

                ylabels[i] = y;
                ypos += data.Height / 10;
            }

            // Adds the network devices to the drop down list.
            for (int i = 0; i < devices.Count; i++)
                deviceList.Items.Add(devices[i].Description);

            Shown += Main_Shown;
        }

        // The labels are white boxes on start up for some reason. This fixed it.
        private void Main_Shown(object sender, EventArgs e)
        {
            Update();
        }

        // Begins the sniffing of packets and the displaying that in graphical format.
        private void start_Click(object sender, EventArgs e)
        {
            if (collector != null) collector.stop();
            if (deviceList.SelectedIndex < 0) return;
            resetGraph();

            long millis = 0;
            int parse;

            // This section parses data from the H M S fields
            if (hours.Text.Length == 0) parse = 0;
            else if (!int.TryParse(hours.Text, out parse)) return;
            millis += ((long)parse) * 60 * 60 * 1000;

            if (mins.Text.Length == 0) parse = 0;
            else if (!int.TryParse(mins.Text, out parse)) return;
            millis += ((long)parse) * 60 * 1000;

            if (secs.Text.Length == 0) parse = 0;
            else if (!int.TryParse(secs.Text, out parse)) return;
            millis += ((long)parse) * 1000;

            bytesUsed.Text = "0 Bytes";
            collector = new PacketCollector(devices[deviceList.SelectedIndex], this);
            collector.start(millis);
        }

        private void stop_Click(object sender, EventArgs e)
        {
            if (collector != null) collector.stop();
            resetGraph();
        }

        // Clears the points from the lists and refreshes the graph.
        private void resetGraph()
        {
            points.Clear();
            packetSize.Clear();

            data.Invalidate();
        }

        // Paints the graph according to the scale of the window.
        private void paintGraph(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            bool heightChange = false;

            // Resizes display areas.
            holder.Size = new Size(dataWrap.Width - 80, dataWrap.Height - 80);

            if (points.Count > 0) {
                // A point is further to the right than the displayable area
                if (((Point)points[points.Count - 1]).X > holder.Width - 2 && data.Width != ((Point)points[points.Count - 1]).X)
                    data.Width = ((Point)points[points.Count - 1]).X;
                // Resize if there are points being displayed in the viewable area.
                else if (((Point)points[points.Count - 1]).X < holder.Width - 2 && data.Width != holder.Width - 2)
                    data.Width = holder.Width - 2;
            }
            else
                data.Width = holder.Width - 2;

            // Adjust the height if there is a horizontal scroll bar
            if (data.Width > holder.Width - 2 && data.Height != holder.Height - 2 - SystemInformation.HorizontalScrollBarHeight)
            {
                data.Height = holder.Height - 2 - SystemInformation.HorizontalScrollBarHeight;
                heightChange = true;
            }
            // Adjust the height if there is no horizontal scroll bar
            else if(data.Width == holder.Width - 2 && data.Height != holder.Height - 2)
            {
                data.Height = holder.Height - 2;
                heightChange = true;
            }

            ylabel.Size = new Size(80, dataWrap.Height - 80);

            if (heightChange)
                recalculatePoints();

            // Redraws graph.
            using (Graphics g = e.Graphics)
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                // Draw y-axis lines
                int ypos = data.Height / 10;
                for (int i = 0; i < 9; i++)
                {
                    g.DrawLine(new Pen(Color.Black, 1), new Point(0, ypos), new Point(data.Width, ypos));
                    ylabels[i].Location = new Point(0, ypos - ylabels[i].Height / 2);

                    ypos += data.Height / 10;
                }

                // Plots the points.
                if (points.Count > 1) g.DrawLines(new Pen(Color.Red, 1), points.ToArray());
            }
            holder.PerformLayout();
        }

        // Handles what happens when the window is resized.
        private void resize(object sender, EventArgs e)
        {
            data.Invalidate();
        }

        // Formats the bytes it was passed into a string that is displayed on the bytesUsed label.
        public void upadateBytes(long bytes)
        {
            double casted = bytes;
            if (casted / 1024 >= 1)
            {
                casted /= 1024;
                if (casted / 1024 >= 1)
                {
                    casted /= 1024;
                    if (casted / 1024 >= 1)
                    {
                        casted /= 1024;
                        byteTotal.Text = Math.Round(casted, 2) + " GB";
                    }
                    else byteTotal.Text = Math.Round(casted, 2) + " MB";
                }
                else byteTotal.Text = Math.Round(casted, 2) + " KB";
            }
            else byteTotal.Text = bytes + " Bytes";
        }

        // This will recalculate the position for each point.
        private void recalculatePoints()
        {
            points = new List<Point>();
            foreach (int i in packetSize)
                points.Add(calculateGraphPoint(i));
        }

        // Calculates a point to represent the given bytes.
        private Point calculateGraphPoint(int bytes)
        {
            Point location = new Point();
            location.X = (points.Count != 0 ? ((Point)points[points.Count - 1]).X + spacing : 0);
            location.Y = (int)(data.Height - ((double)bytes / 21000) * data.Height);
            return location;
        }

        // Adds a point for the given byte amount to the lists and refreshes the graph.
        public void addPoint(int bytes)
        {
            if (data.Width + spacing > 32767)
                spacing /= 2;
            if(spacing == 0)
            {
                collector.stop();
                return;
            }
            recalculatePoints();
            points.Add(calculateGraphPoint(bytes));
            packetSize.Add(bytes);
            data.Invalidate();
        }

        // Starts the monitoring when enter is pressed while ther cursor is in the timer setting text boxes.
        private void enterPickup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                start_Click(null, null);
        }
    }
}
