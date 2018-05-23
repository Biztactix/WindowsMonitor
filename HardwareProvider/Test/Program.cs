using System;
using NvAPIWrapper;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            NVIDIA.Initialize();

            var cc = NvAPIWrapper.GPU.PhysicalGPU.GetPhysicalGPUs();

            var m = new Mainboard.Hardware.Mainboard.Mainboard(null);

            Console.WriteLine("Hello World!");
        }
    }
}
