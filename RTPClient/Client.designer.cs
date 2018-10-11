namespace RTPDemo
{
    partial class Client
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
            ReleaseResource();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_Camera = new System.Windows.Forms.Button();
            this.btn_ConfigureRTP = new System.Windows.Forms.Button();
            this.txt_TargetIP = new System.Windows.Forms.TextBox();
            this.txt_TargetPort = new System.Windows.Forms.TextBox();
            this.txt_RTCPIP = new System.Windows.Forms.TextBox();
            this.txt_RTCPPort = new System.Windows.Forms.TextBox();
            this.txt_RTPPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_RTPIP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_OpenCapture = new System.Windows.Forms.Button();
            this.captureImageBox = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_Play
            // 
            this.btn_Play.Location = new System.Drawing.Point(113, 116);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(75, 21);
            this.btn_Play.TabIndex = 26;
            this.btn_Play.Text = "播放";
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Camera
            // 
            this.btn_Camera.Location = new System.Drawing.Point(5, 100);
            this.btn_Camera.Name = "btn_Camera";
            this.btn_Camera.Size = new System.Drawing.Size(102, 21);
            this.btn_Camera.TabIndex = 25;
            this.btn_Camera.Text = "打开摄像头";
            this.btn_Camera.UseVisualStyleBackColor = true;
            this.btn_Camera.Click += new System.EventHandler(this.btn_Camera_Click);
            // 
            // btn_ConfigureRTP
            // 
            this.btn_ConfigureRTP.Location = new System.Drawing.Point(347, 87);
            this.btn_ConfigureRTP.Name = "btn_ConfigureRTP";
            this.btn_ConfigureRTP.Size = new System.Drawing.Size(123, 21);
            this.btn_ConfigureRTP.TabIndex = 24;
            this.btn_ConfigureRTP.Text = "配置RTP";
            this.btn_ConfigureRTP.UseVisualStyleBackColor = true;
            this.btn_ConfigureRTP.Click += new System.EventHandler(this.btn_ConfigureRTP_Click);
            // 
            // txt_TargetIP
            // 
            this.txt_TargetIP.Location = new System.Drawing.Point(69, 63);
            this.txt_TargetIP.Name = "txt_TargetIP";
            this.txt_TargetIP.Size = new System.Drawing.Size(192, 21);
            this.txt_TargetIP.TabIndex = 22;
            this.txt_TargetIP.Text = "127.0.0.1";
            // 
            // txt_TargetPort
            // 
            this.txt_TargetPort.Location = new System.Drawing.Point(347, 60);
            this.txt_TargetPort.Name = "txt_TargetPort";
            this.txt_TargetPort.Size = new System.Drawing.Size(64, 21);
            this.txt_TargetPort.TabIndex = 21;
            this.txt_TargetPort.Text = "20000";
            this.txt_TargetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_RTCPIP
            // 
            this.txt_RTCPIP.Location = new System.Drawing.Point(69, 33);
            this.txt_RTCPIP.Name = "txt_RTCPIP";
            this.txt_RTCPIP.Size = new System.Drawing.Size(192, 21);
            this.txt_RTCPIP.TabIndex = 20;
            this.txt_RTCPIP.Text = "127.0.0.1";
            // 
            // txt_RTCPPort
            // 
            this.txt_RTCPPort.Location = new System.Drawing.Point(347, 30);
            this.txt_RTCPPort.Name = "txt_RTCPPort";
            this.txt_RTCPPort.Size = new System.Drawing.Size(64, 21);
            this.txt_RTCPPort.TabIndex = 18;
            this.txt_RTCPPort.Text = "10012";
            this.txt_RTCPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_RTPPort
            // 
            this.txt_RTPPort.Location = new System.Drawing.Point(347, 11);
            this.txt_RTPPort.Name = "txt_RTPPort";
            this.txt_RTPPort.Size = new System.Drawing.Size(64, 21);
            this.txt_RTPPort.TabIndex = 23;
            this.txt_RTPPort.Text = "10011";
            this.txt_RTPPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(272, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "目的地端口";
            // 
            // txt_RTPIP
            // 
            this.txt_RTPIP.Location = new System.Drawing.Point(69, 11);
            this.txt_RTPIP.Name = "txt_RTPIP";
            this.txt_RTPIP.Size = new System.Drawing.Size(192, 21);
            this.txt_RTPIP.TabIndex = 19;
            this.txt_RTPIP.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "rtcpPort";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "目的地IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "rtpPort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "rtcpIp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "rtpIp";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Location = new System.Drawing.Point(347, 143);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(123, 21);
            this.btn_Connect.TabIndex = 11;
            this.btn_Connect.Text = "开始视频数据传输";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_OpenCapture
            // 
            this.btn_OpenCapture.Location = new System.Drawing.Point(5, 126);
            this.btn_OpenCapture.Name = "btn_OpenCapture";
            this.btn_OpenCapture.Size = new System.Drawing.Size(102, 21);
            this.btn_OpenCapture.TabIndex = 10;
            this.btn_OpenCapture.Text = "打开视频";
            this.btn_OpenCapture.UseVisualStyleBackColor = true;
            this.btn_OpenCapture.Click += new System.EventHandler(this.btn_OpenCapture_Click);
            // 
            // captureImageBox
            // 
            this.captureImageBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.captureImageBox.Location = new System.Drawing.Point(5, 178);
            this.captureImageBox.Name = "captureImageBox";
            this.captureImageBox.Size = new System.Drawing.Size(475, 273);
            this.captureImageBox.TabIndex = 27;
            this.captureImageBox.TabStop = false;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 454);
            this.Controls.Add(this.captureImageBox);
            this.Controls.Add(this.btn_Play);
            this.Controls.Add(this.btn_Camera);
            this.Controls.Add(this.btn_ConfigureRTP);
            this.Controls.Add(this.txt_TargetIP);
            this.Controls.Add(this.txt_TargetPort);
            this.Controls.Add(this.txt_RTCPIP);
            this.Controls.Add(this.txt_RTCPPort);
            this.Controls.Add(this.txt_RTPPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_RTPIP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.btn_OpenCapture);
            this.Name = "Client";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发送端";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_Camera;
        private System.Windows.Forms.Button btn_ConfigureRTP;
        private System.Windows.Forms.TextBox txt_TargetIP;
        private System.Windows.Forms.TextBox txt_TargetPort;
        private System.Windows.Forms.TextBox txt_RTCPIP;
        private System.Windows.Forms.TextBox txt_RTCPPort;
        private System.Windows.Forms.TextBox txt_RTPPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_RTPIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_OpenCapture;
        private Emgu.CV.UI.ImageBox captureImageBox;
    }
}

