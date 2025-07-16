// 画像ファイルを読み込み、RGB565形式に変換し、.hファイルとRGB565 BMPを出力するコンソールアプリ
using System.Drawing;
using System.IO;

if (args.Length < 1)
{
    Console.WriteLine("Usage: c16bmp <input_image(s)> [output_header.h]");
    return;
}

string inputPattern = args[0];
string? outputPath = args.Length > 1 ? args[1] : null;

// ワイルドカード対応
string dir = Path.GetDirectoryName(inputPattern);
if (string.IsNullOrEmpty(dir)) dir = Directory.GetCurrentDirectory();
string pattern = Path.GetFileName(inputPattern);
if (string.IsNullOrEmpty(pattern)) pattern = "*.*";

string[] files = Directory.GetFiles(dir, pattern);
if (files.Length == 0)
{
    Console.WriteLine($"No input files found: {inputPattern}");
    return;
}

foreach (var inputFile in files)
{
    try
    {
        using var bmp = new Bitmap(inputFile);
        int width = bmp.Width;
        int height = bmp.Height;
        string arrayName = Path.GetFileNameWithoutExtension(inputFile).Replace(" ", "_");
        string outFile = outputPath ?? Path.Combine(dir, arrayName + ".h");
        // 出力ファイル名が明示指定されている場合は1ファイルのみ変換
        if (outputPath != null && files.Length > 1)
        {
            Console.WriteLine("When output file is specified, only one input file is allowed.");
            return;
        }
        var converter = new ImageToRgb565Converter();
        var rgb565 = converter.ConvertToRgb565(bmp);
        converter.WriteHeaderFile(outFile, arrayName, width, height, rgb565);
        Console.WriteLine($"Header file generated: {outFile}");
        // RGB565 BMPも出力
        string bmpOutFile = Path.Combine(dir, arrayName + "_rgb565.bmp");
        converter.WriteRgb565Bmp(bmpOutFile, width, height, rgb565);
        Console.WriteLine($"RGB565 BMP generated: {bmpOutFile}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing {inputFile}: {ex.Message}");
    }
}
