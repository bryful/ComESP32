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

	public string SendData(string headerId, byte[] data)
	{
		if (headerId.Length != 4)
			throw new ArgumentException("Header ID must be exactly 4 characters.");

		byte[] headerBytes = Encoding.ASCII.GetBytes(headerId);

		using (TcpClient client = new TcpClient())
		{
			client.Connect(Esp32Address, Port);
			using (NetworkStream stream = client.GetStream())
			{
				int offset = 0;
				while (offset < data.Length)
				{
					int currentSize = Math.Min(ChunkSize, data.Length - offset);
					byte[] chunk = new byte[currentSize];
					Array.Copy(data, offset, chunk, 0, currentSize);

					byte isLast = (byte)((offset + currentSize >= data.Length) ? 0x01 : 0x00);
					byte[] sizeBytes = BitConverter.GetBytes(currentSize);
					Array.Reverse(sizeBytes); // Big Endian

					stream.Write(headerBytes, 0, 4);
					stream.WriteByte(isLast);
					stream.Write(sizeBytes, 0, 4);
					stream.Write(chunk, 0, currentSize);

					offset += currentSize;
				}

				// 読み取り（ACK受信）
				using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
				{
					return reader.ReadToEnd();
				}
			}
		}
	}

	public string SendFile(string filePath)
	{
		string ext = Path.GetExtension(filePath).ToLowerInvariant();
		string header = ext switch
		{
			".txt" => "TEXT",
			".jpg" => "JPEG",
			".jpeg" => "JPEG",
			".png" => "PNGf",
			_ => "DATA"
		};

		byte[] data = File.ReadAllBytes(filePath);
		return SendData(header, data);
	}

	public string SendText(string text)
	{
		byte[] data = Encoding.UTF8.GetBytes(text);
		return SendData("TEXT", data);
	}

	public string SendInfoRequest()
	{
		return SendData("INFO", new byte[0]);
	}
}
