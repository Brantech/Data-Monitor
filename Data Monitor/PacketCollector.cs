using PcapDotNet.Core;
using PcapDotNet.Packets;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Data_Monitor_GUI
{
    class PacketCollector
    {
        private PacketDevice device;
        private Main main;
        private Timer timer;
        private Thread t;
        private long duration;

        public PacketCollector(PacketDevice device, Main main)
        {
            this.device = device;
            this.main = main;
        }

        // Main method for scanning packets.
        private void scan()
        {
            using (PacketCommunicator communicator = device.Open(65536, PacketDeviceOpenAttributes.MaximumResponsiveness, 0))
            {
                Packet packet;
                long startTimeMillis = (long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds;
                long endTimeMillis = startTimeMillis + duration;
                long second = startTimeMillis;
                long byteTotal = 0, miniTotal = 0;
                Queue<long> totals = new Queue<long>();

                timer = new Timer(endTimeMillis, main);

                // Sniffs packets until the specified duration has passed.
                while ((DateTime.Now - DateTime.MinValue).TotalMilliseconds < endTimeMillis)
                {
                    communicator.ReceivePacket(out packet);
                    if (packet != null)
                    {
                        byteTotal += packet.Length;
                        miniTotal += packet.Length;

                        // Updates the gui every 0.5 seconds or when the total within a 0.5s period is >= 18000.
                        if ((long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds - second >= 500 || miniTotal > 18000)
                        {
                            totals.Enqueue(miniTotal);
                            main.byteTotal.BeginInvoke((MethodInvoker)delegate
                            {
                                main.upadateBytes(byteTotal);
                                main.addPoint((int)totals.Dequeue());
                            });
                            second = (long)(DateTime.Now - DateTime.MinValue).TotalMilliseconds;
                            miniTotal = 0;
                        }
                    }
                }

                timer.stop();

                main.byteTotal.BeginInvoke((MethodInvoker)delegate
                {
                    main.upadateBytes(byteTotal);
                });
            }
        }

        // Starts scanning for packets in a new thread.
        public void start(long duration)
        {
            this.duration = duration;

            ThreadStart threadStart = new ThreadStart(scan);
            t = new Thread(threadStart);
            t.IsBackground = true;
            t.Start();
        }

        public void stop()
        {
            if (t != null) t.Abort();
            if (timer != null) timer.stop();
        }
    }
}
