namespace WebServersDispatcherApp
{
    partial class frmDiagnose
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            webServersDispatcher.Stop();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStart = new Button();
            btnStop = new Button();
            tbaLog = new TextBox();
            label1 = new Label();
            tbxDispatchInterval = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.ForeColor = Color.Green;
            btnStart.Location = new Point(22, 62);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(100, 25);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start Dispatcher";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.ForeColor = Color.Red;
            btnStop.Location = new Point(133, 62);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(100, 25);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop Dispatcher";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // tbaLog
            // 
            tbaLog.BorderStyle = BorderStyle.FixedSingle;
            tbaLog.Enabled = false;
            tbaLog.Location = new Point(22, 140);
            tbaLog.Multiline = true;
            tbaLog.Name = "tbaLog";
            tbaLog.Size = new Size(242, 167);
            tbaLog.TabIndex = 2;
            tbaLog.TextChanged += tbaLog_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 23);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 3;
            label1.Text = "Dispatch Interval (ms):";
            // 
            // tbxDispatchInterval
            // 
            tbxDispatchInterval.BorderStyle = BorderStyle.FixedSingle;
            tbxDispatchInterval.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            tbxDispatchInterval.Location = new Point(186, 21);
            tbxDispatchInterval.Name = "tbxDispatchInterval";
            tbxDispatchInterval.Size = new Size(41, 23);
            tbxDispatchInterval.TabIndex = 4;
            tbxDispatchInterval.Text = "600";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 113);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 5;
            label2.Text = "Dispatching Output:";
            label2.Click += label2_Click;
            // 
            // frmDispatcher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 330);
            Controls.Add(label2);
            Controls.Add(tbxDispatchInterval);
            Controls.Add(label1);
            Controls.Add(tbaLog);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Name = "frmDispatcher";
            Text = "Servers Dispatcher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        internal Button btnStop;
        private TextBox tbaLog;
        private Button button2;
        private Label label1;
        private TextBox tbxDispatchInterval;
        private Label label2;
    }
}
