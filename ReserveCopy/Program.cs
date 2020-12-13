using System;
using System.Collections.Generic;

namespace ReserveCopy
{


    class Program
    {
        static void Main(string[] args)
        {
            int? age = 123;

            if (age.HasValue)
            {
                Console.WriteLine($"Age is {age.Value}");
            }
        }
    }

    public enum StorageType
    {
        Ssd,
        Dvd,
    }

    class Storage
    {
        public string Name { get; set; }
        public StorageType StorageType { get; set; }
        public int VolumeMb { get; set; }

        protected int usedVolumeMb;
        protected decimal readWriteSpeedMbPerSec;

        public Storage(StorageType storageType, int volumeMb)
        {
            StorageType = storageType;
            VolumeMb = volumeMb;
        }

        public int GetFreeSpaceMb()
        {
            return VolumeMb - usedVolumeMb;
        }

        public decimal GetCopySpeed(Storage copyTo, int mbsToCopy)
        {
            decimal readTime = mbsToCopy / copyTo.readWriteSpeedMbPerSec;
            decimal writeTime = mbsToCopy / readWriteSpeedMbPerSec;

            return readTime + writeTime;
        }

        public int CountOfStoragesToCopy(Storage storage)
        {
            return VolumeMb / storage.VolumeMb;
        }
    }
}
