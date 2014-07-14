using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ILPatcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ilFile = File.ReadAllLines(args[0]).ToList();

            int targetIndex = -1;
            for (int i = 0; i < ilFile.Count; i++)
                if (ilFile[i].Equals(args[1], StringComparison.InvariantCultureIgnoreCase))
                {
                    targetIndex = i;
                    break;
                }

            if (targetIndex < 0)
            {
                Console.WriteLine("Line not found.");
                return;
            }

            ilFile.InsertRange(targetIndex + 1, File.ReadAllLines(args[2]));

            File.WriteAllLines(args[0], ilFile);
        }
    }
}