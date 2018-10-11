using System;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using StreamCoders.Network;

namespace RTPDemo
{
    public partial class Client : Form
    {
        //��Ƶ
        private Capture _capture;
        private bool _captureInProgress;
        private int _videoFps;//��Ƶ֡��

        //RTP
        private const int MTU = 1000;//һ��rtp������Ǿ���UDP�����ԭ���ϲ�Ҫ����1460
        private RtpFramer _rtpFramer;

        public bool StartedToSend { get; set; }

        public Client()
        {
            InitializeComponent();
            StartedToSend = false;
        }

        private void btn_ConfigureRTP_Click(object sender, EventArgs e)
        {
            try
            {
                //��ʼ��RTPSession
                var rtpIp = txt_RTPIP.Text;
                var rtpPort = Convert.ToInt32(txt_RTPPort.Text);
                var rtcpIp = txt_RTCPIP.Text;
                var rtcpPort = Convert.ToInt32(txt_RTCPPort.Text);
                var forwardIp = txt_TargetIP.Text;
                var forwardPort = Convert.ToInt32(txt_TargetPort.Text);

                _rtpFramer = new RtpFramer(rtpIp, rtpPort, rtcpIp, rtcpPort, forwardIp, forwardPort); //���ú�
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //������ͷ
        private void btn_Camera_Click(object sender, EventArgs e)
        {
            try
            {
                _capture = new Capture();
                _videoFps = (int)CvInvoke.cvGetCaptureProperty(_capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        //����Ƶ
        private void btn_OpenCapture_Click(object sender, EventArgs e)
        {
            var initDirectory = Application.StartupPath.Replace(@"\bin\Debug", "");
            var initFile = Path.Combine(initDirectory, "Dream.wmv");

            openFileDialog1.InitialDirectory = initDirectory;
            openFileDialog1.FileName = initFile;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fName = openFileDialog1.FileName;
                _capture = new Capture(fName);
                _videoFps = (int)CvInvoke.cvGetCaptureProperty(_capture, Emgu.CV.CvEnum.CAP_PROP.CV_CAP_PROP_FPS);
                _capture.ImageGrabbed += ProcessFrame;
            }
        }

        //���� | ��ͣ
        private void btn_Play_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    btn_Play.Text = @"����";
                    _capture.Pause();
                }
                else
                {
                    //start the capture
                    btn_Play.Text = @"��ͣ";
                    _capture.Start();
                }
                _captureInProgress = !_captureInProgress;
            }
        }

        //������Ƶ���ݣ�����ʾ��ImageBox��
        private void ProcessFrame(object sender, EventArgs arg)
        {
            var frame = _capture.RetrieveBgrFrame();
            if (frame != null)
            {
                try
                {
                    captureImageBox.Image = frame;
                }
                catch (ObjectDisposedException)
                {
                    return;
                }

                if (StartedToSend)//������Կ�ʼ����
                {
                    var ms = new MemoryStream();
                    frame.Bitmap.Save(ms, ImageFormat.Jpeg);
                    var data = ms.ToArray(); //ͼƬ����
                    ms.Close();

                    //Rtp Э�鷢�� ����rtp��
                    var timeStamp = DateTime.Now.ToUniversalTime().Ticks;
                    const int packetSize = MTU - 12;//һ��rtp������Ǿ���UDP�����ԭ���ϲ�Ҫ����1460
                    while (data.Length > 0)
                    {
                        var rtpPacket = new RTPPacket
                        {
                            Timestamp = (int)timeStamp,//ʱ���
                            DataPointer = data.Take(packetSize).ToArray(),//֡����
                            Marker = data.Length <= packetSize
                        };
                        _rtpFramer.Sender.Send(rtpPacket);//����RTP��
                        data = data.Skip(packetSize).ToArray();
                    }
                }
                if (_capture.CaptureSource != Emgu.CV.Capture.CaptureModuleType.Camera)
                {
                    System.Threading.Thread.Sleep((int)(1000.0 / _videoFps - 5));//�̸߳���֡�� �ӳ�֡�ٶȣ���Ȼ�Ქ�źܿ�                    
                }
            }
        }

        //���Ӱ�ť
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (_rtpFramer != null)
            {
                StartedToSend = !StartedToSend; //��������
                btn_Connect.Text = StartedToSend ? "�Ͽ�����������" : "���������������";
            }
            else
            {
                MessageBox.Show(@"���ȳ�ʼ��RTP");
            }
        }

        private void ReleaseResource()
        {
            StartedToSend = false;
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_capture != null)
            {
                _capture.ImageGrabbed -= ProcessFrame;
                _capture.Dispose();
            }
            if (_rtpFramer != null)
            {
                _rtpFramer.Session.Dispose();
            }

            Environment.Exit(0);//������׵��˳���ʽ������ʲô�̶߳���ǿ���˳����ѳ�������ĺܸɾ���
        }
    }
}