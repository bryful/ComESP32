using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

public class Esp32DataSender
{
	public string Esp32Address { get; set; }
	public int Port { get; set; }
	public int ChunkSize { get; set; }

	public Esp32DataSender(string address, int port = 1234, int chunkSize = 1024)
	{
		Esp32Address = address;
		Port = port;
		ChunkSize = chunkSize;
	}

	public string SendText( string text)
	{
		byte[] data = Encoding.UTF8.GetBytes(text);


		using (TcpClient client = new TcpClient())
		{
			client.Connect(Esp32Address, Port);
			using (NetworkStream stream = client.GetStream())
			{
				stream.Write(data, 0, data.Length);
				// 読み取り（ACK受信）
				using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
				{
					return reader.ReadToEnd();
				}
			}
		}
	}


}
