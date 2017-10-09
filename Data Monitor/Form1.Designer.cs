namespace Data_Monitor_GUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hours = new System.Windows.Forms.TextBox();
            this.mins = new System.Windows.Forms.TextBox();
            this.secs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataWrap = new System.Windows.Forms.Panel();
            this.bytesUsed = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stop = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Label();
            this.deviceList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataWrap.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // hours
            // 
            this.hours.Location = new System.Drawing.Point(3, 18);
            this.hours.MaxLength = 2;
            this.hours.Name = "hours";
            this.hours.Size = new System.Drawing.Size(39, 20);
            this.hours.TabIndex = 0;
            this.hours.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterPickup);
            // 
            // mins
            // 
            this.mins.Location = new System.Drawing.Point(48, 18);
            this.mins.MaxLength = 2;
            this.mins.Name = "mins";
            this.mins.Size = new System.Drawing.Size(39, 20);
            this.mins.TabIndex = 1;
            this.mins.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mins.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterPickup);
            // 
            // secs
            // 
            this.secs.Location = new System.Drawing.Point(93, 18);
            this.secs.MaxLength = 2;
            this.secs.Name = "secs";
            this.secs.Size = new System.Drawing.Size(39, 20);
            this.secs.TabIndex = 2;
            this.secs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.secs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enterPickup);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "H";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "M";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "S";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.start_Click);
            // 
            // dataWrap
            // 
            this.dataWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataWrap.BackColor = System.Drawing.SystemColors.Control;
            this.dataWrap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataWrap.Controls.Add(this.bytesUsed);
            this.dataWrap.Location = new System.Drawing.Point(12, 59);
            this.dataWrap.Name = "dataWrap";
            this.dataWrap.Size = new System.Drawing.Size(660, 590);
            this.dataWrap.TabIndex = 7;
            this.dataWrap.Tag = "graph";
            // 
            // bytesUsed
            // 
            this.bytesUsed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bytesUsed.Location = new System.Drawing.Point(398, 566);
            this.bytesUsed.Name = "bytesUsed";
            this.bytesUsed.Size = new System.Drawing.Size(261, 22);
            this.bytesUsed.TabIndex = 2;
            this.bytesUsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.stop);
            this.panel2.Controls.Add(this.mins);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.secs);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.hours);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(204, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(224, 41);
            this.panel2.TabIndex = 8;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(180, 2);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(39, 35);
            this.stop.TabIndex = 7;
            this.stop.Text = "Stop";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stop_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.timer);
            this.panel3.Location = new System.Drawing.Point(573, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(99, 41);
            this.panel3.TabIndex = 0;
            // 
            // timer
            // 
            this.timer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.timer.Location = new System.Drawing.Point(22, 16);
            this.timer.Name = "timer";
            this.timer.Size = new System.Drawing.Size(57, 20);
            this.timer.TabIndex = 7;
            this.timer.Text = "00:00:00";
            this.timer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deviceList
            // 
            this.deviceList.DropDownWidth = 400;
            this.deviceList.FormattingEnabled = true;
            this.deviceList.Location = new System.Drawing.Point(12, 28);
            this.deviceList.Name = "deviceList";
            this.deviceList.Size = new System.Drawing.Size(186, 21);
            this.deviceList.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Device:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 661);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.deviceList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataWrap);
            this.MinimumSize = new System.Drawing.Size(700, 700);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Monitor";
            this.dataWrap.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox hours;
        private System.Windows.Forms.TextBox mins;
        private System.Windows.Forms.TextBox secs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel dataWrap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.Label timer;
        private System.Windows.Forms.ComboBox deviceList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Label bytesUsed;
    }
}

