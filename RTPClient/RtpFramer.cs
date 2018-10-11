using System;
using System.Net;
using StreamCoders.Network;

namespace RTPDemo
{
    /// <summary>
    /// RTP类
    /// </summary>
    public class RtpFramer
    {

        /// <summary>
        /// 只读RTP会话端
        /// </summary>
        public readonly RTPSession Session;
        /// <summary>
        /// RTP发送端
        /// </summary>
        public RTPSender Sender;//发送者
        /// <summary>
        /// RTP接收端
        /// </summary>
        public RTPReceiver Receiver;//接收者

        private RTPParticipant participant;
        private RTPParticipant senderParticipant;
        /// <summary>
        /// RTP工厂构造方法
        /// </summary>
        /// <param name="RTPipAddress">RTP发送ip地址</param>
        /// <param name="RTPport">RTP发送端口</param>
        /// <param name="RTCPipAddress">RTP接收端ip地址</param>
        /// <param name="RTCPport">RTP接收端口</param>
        /// <param name="forwardIP"></param>
        /// <param name="forwardPort"></param>
        public RtpFramer(String RTPipAddress, int RTPport, String RTCPipAddress, int RTCPport, String forwardIP, int forwardPort)
        {
            //实例化RTP会话端
            Session = new RTPSession();
            //实例化RTP发送端
            Sender = new RTPSender();
            //实例化RTP接收端
            Receiver = new RTPReceiver();
            //生成网络端点
            var senderEp = new IPEndPoint(IPAddress.Parse(forwardIP), forwardPort);
            //RTP参与者
            senderParticipant = new RTPParticipant(senderEp);
            //给RTP发送端添加RTP参与者
            Sender.AddParticipant(senderParticipant);
            //RTP会话端添加RTP发送端
            Session.AddSender(Sender);
            //生成RTP网络端点
            var rtpEp = new IPEndPoint(IPAddress.Parse(RTPipAddress), RTPport);
            //生成RTP接收端网络端点
            var rtcpEp = new IPEndPoint(IPAddress.Parse(RTCPipAddress), RTCPport);
            //新建RTP参与者绑定发送者端口以及接受者端口
            participant = new RTPParticipant(rtpEp, rtcpEp);
            Session.NewRTPPacket = NewRTPPacket;
            Session.NewRTCPPacket = NewRTCPPacket;
            Session.NewSSRC = NewSSRC;
            Receiver.AddParticipant(participant);
            Session.AddReceiver(Receiver);
        }

        private bool NewRTPPacket(RTPPacket packet)
        {
            return true;
        }

        private void NewRTCPPacket(RTCPCompoundPacket packet)
        {
        }

        private void NewSSRC(uint ssrc)
        {
        }
    }
}