using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Listener lsn  =new Listener();
            lsn.GetConfig();   //配置监听端口号
            lsn.StartUp();   //启动监听
        }
    }
}
