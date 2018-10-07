using System;
using System.IO;
using System.Threading;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;
using Unosquare.RaspberryIO.Camera;
using System.Threading.Tasks;

namespace Blinky
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //var pin = Pi.Gpio.GetGpioPinByBcmPinNumber(18);
            //pin.PinMode = GpioPinDriveMode.Output;
            //pin.PwmMode = PwmMode.Balanced;
            byte[] image = Pi.Camera.CaptureImage(new CameraStillSettings
            {
                CaptureEncoding = CameraImageEncodingFormat.Png,
                CaptureHeight = 0,
                CaptureWidth = 0
            });
            //CaptureImageJpeg(5000, 5000);
           

            byte[] image2 = Pi.Camera.CaptureImageJpeg(0, 0);
            //CaptureImageJpeg(5000, 5000);
            Task t1 =  File.WriteAllBytesAsync("camera.png", image);
            Task t2 =  File.WriteAllBytesAsync("camera.jpg", image2);

            await Task.WhenAll(t1, t2);

            Console.WriteLine($" CpuArchitecture :  {Pi.Info.CpuArchitecture}");
            Console.WriteLine($" CpuImplementer :  {Pi.Info.CpuImplementer}");
            Console.WriteLine($" CpuPart :  {Pi.Info.CpuPart}");
            Console.WriteLine($" CpuRevision :  {Pi.Info.CpuRevision}");
            Console.WriteLine($" CpuVariant :  {Pi.Info.CpuVariant}");
            Console.WriteLine($" Features :  ");
            foreach (string feature in Pi.Info.Features)
            {
                Console.WriteLine(feature);
            }
            Console.WriteLine($" Hardware :  {Pi.Info.Hardware}");
            Console.WriteLine($" InstalledRam :  {Pi.Info.InstalledRam}");
            Console.WriteLine($" IsLittleEndian :  {Pi.Info.IsLittleEndian}");
            Console.WriteLine($" ModelName :  {Pi.Info.ModelName}");
            Console.WriteLine($" OperatingSystem :  {Pi.Info.OperatingSystem}");
            Console.WriteLine($" ProcessorCount :  {Pi.Info.ProcessorCount}");
            Console.WriteLine($" RaspberryPiVersion :  {Pi.Info.RaspberryPiVersion}");
            Console.WriteLine($" Revision :  {Pi.Info.Revision}");
            Console.WriteLine($" Serial :  {Pi.Info.Serial}");
            Console.WriteLine($" Uptime :  {Pi.Info.Uptime}");
            Console.WriteLine($" WiringPiBoardRevision :  {Pi.Info.WiringPiBoardRevision}");
            Console.WriteLine($" WiringPiVersion :  {Pi.Info.WiringPiVersion}");


            //while (true)
            //{
            //    pin.Write(true);
            //    Thread.Sleep(1000);
            //    pin.Write(false);
            //    Thread.Sleep(1000);
            //}
        }
    }
}
