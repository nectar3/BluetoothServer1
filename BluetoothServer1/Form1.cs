using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Net.Sockets;

namespace BluetoothServer1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Guid serviceUUID = BluetoothService.TcpProtocol; // new Guid("00000004-0000-1000-8000-00805F9B34FB");

            BluetoothEndPoint bep = new BluetoothEndPoint(BluetoothAddress.None, BluetoothService.TcpProtocol);
            BluetoothListener blueListener = new BluetoothListener(bep);

            blueListener.Start();

            rich1.Text += "대기중.." + "\n";

            while (true)
            {
                Socket socket = blueListener.AcceptSocket();

                string text = socket.ReadString();
                rich1.Text += text + "\n";
                socket.Close();
            }
        }
    }
}
