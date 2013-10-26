using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace Client
{


    class TCPConnection
    {
        private IPAddress _ip = null;
        private int _port;
        private TcpClient _tcpc = null;

        //构造函数，得到IP地址的端口号
        public TCPConnection(IPAddress ip, int port)
        {
            _ip = ip;
            _port = port;
        }

        //连接服务器的函数
        public TcpClient Connect()
        {
            try
            {
                _tcpc = new TcpClient();
                //连接
                _tcpc.Connect(_ip, _port);
            }
            catch (Exception)
            {
                return null;
            }
            return _tcpc;
        }

    }
}
