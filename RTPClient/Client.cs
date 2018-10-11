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
        //视频
        private Capture _capture;
        private bool _captureInProgress;
        private int _videoFps;//视频帧率

        //RTP
        private const int MTU = 1000;//一个rtp包如果是经过UDP传输的原则上不要超过1460
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
                //初始化RTPSession
                var rtpIp = txt_RTPIP.Text;
                var rtpPort = Convert.ToInt32(txt_RTPPort.Text);
                var rtcpIp = txt_RTCPIP.Text;
                var rtcpPort = Convert.ToInt32(txt_RTCPPort.Text);
                var forwardIp = txt_TargetIP.Text;
                var forwardPort = Convert.ToInt32(txt_TargetPort.Text);

                _rtpFramer = new RtpFramer(rtpIp, rtpPort, rtcpIp, rtcpPort, forwardIp, forwardPort); //配置好
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //打开摄像头
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

        //打开视频
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

        //播放 | 暂停
        private void btn_Play_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    //stop the capture
                    btn_Play.Text = @"播放";
                    _capture.Pause();
                }
                else
                {
                    //start the capture
                    btn_Play.Text = @"暂停";
                    _capture.Start();
                }
                _captureInProgress = !_captureInProgress;
            }
        }

        //处理视频数据，并显示在ImageBox中
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

                if (StartedToSend)//如果可以开始传送
                {
                    var ms = new MemoryStream();
                    frame.Bitmap.Save(ms, ImageFormat.Jpeg);
                    var data = ms.ToArray(); //图片数据
                    ms.Close();

                    //Rtp 协议发送 构建rtp包
                    var timeStamp = DateTime.Now.ToUniversalTime().Ticks;
                    const int packetSize = MTU - 12;//一个rtp包如果是经过UDP传输的原则上不要超过1460
                    while (data.Length > 0)
                    {
                        var rtpPacket = new RTPPacket
                        {
                            Timestamp = (int)timeStamp,//时间戳
                            DataPointer = data.Take(packetSize).ToArray(),//帧数据
                            Marker = data.Length <= packetSize
                        };
                        _rtpFramer.Sender.Send(rtpPacket);//发送RTP包
                        data = data.Skip(packetSize).ToArray();
                    }
                }
                if (_capture.CaptureSource != Emgu.CV.Capture.CaptureModuleType.Camera)
                {
                    System.Threading.Thread.Sleep((int)(1000.0 / _videoFps - 5));//线程根据帧率 延迟帧速度，不然会播放很快                    
                }
            }
        }

        //连接按钮
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (_rtpFramer != null)
            {
                StartedToSend = !StartedToSend; //启动服务
                btn_Connect.Text = StartedToSend ? "断开服务器连接" : "与服务器建立连接";
            }
            else
            {
                MessageBox.Show(@"请先初始化RTP");
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

            Environment.Exit(0);//这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。
        }
    }
}