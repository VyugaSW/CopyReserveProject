using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Storage
    {
        private string _name;
        private string _model;
        public string Name
        {
            get { return _name; }
            set
            {
                try
                {
                    _name = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(value));
                }

            }
        }
        public string Model
        {
            get { return _model; }
            set
            {
                try
                {
                    _model = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(value));
                }
            }
        }

        public Storage(string n, string m)
        {
            Name = n;
            Model = m;
        }

        public abstract double GetMemory();
        public abstract double CopyData(double memoryFor);
        public abstract double FreeSpace(double size);
        public abstract double FreeSpace(double[] size);
        public abstract string GetGeneralInfo();
    }

    internal class HDD : Storage
    {
        int Sections { get; set; } = 0;//количество разделов
        //double TotalMemory { get; set; } = 0;//общий объем
        //double MemoryInSection { get; set; }//память в одном разделе
        private int _speedUSB;
        private int _memory;


        public int SpeedUSB
        {
            get { return _speedUSB; }
            set
            {
                if (value < 0)
                    throw new Exception(nameof(value));
            }
        }
        public int Memory
        {
            get { return _memory; }
            set
            {
                if (value < 0)
                    throw new Exception(nameof(value));
            }
        }

        public HDD(int sUBS, int m, string n, string mod) : base(n, mod)
        {
            SpeedUSB = sUBS;
            Memory = m;
        }

        public override double GetMemory() { return Memory; }

        public override double CopyData(double memoryFor)
        {
            if (memoryFor < 0)
                throw new Exception(nameof(memoryFor));
            return memoryFor / Memory;
        }

        public override double FreeSpace(double size)
        {
            if (size < 0)
                throw new Exception(nameof(size));
            double freeSpace = Memory - size;
            if (freeSpace < 0)
            {
                throw new Exception(nameof(freeSpace));
            }
            return freeSpace;
        }
        public override double FreeSpace(double[] size)
        {
            double freeSpace = 0;
            for (int i = 0; i < size.Length; i++)
            {
                if (size[i] < 0)
                    throw new Exception(nameof(size));
                freeSpace += size[i];
            }

            freeSpace = Memory - freeSpace;

            if (freeSpace < 0)
                throw new Exception();

            return freeSpace;
        }

        public override string GetGeneralInfo()
        {
            return $"Name - {Name}\nModel - {Model}\nSpeed USB 2.0 - {SpeedUSB}\nMemory - {Memory}";
        }

    }

    internal class DVD : Storage
    {
        private double _speedReading = 0;
        private double _speedWriting { get; set; } = 0;
        private string _type { get; set; }
        private double _memory { get; set; } = 0;

        public double SpeedReading
        {
            get { return _speedReading; }
            set
            {
                if (value <= 0)
                    throw new Exception(nameof(SpeedReading));
            }
        }

        public double SpeedWriting
        {
            get { return _speedWriting; }
            set
            {
                if (value <= 0)
                    throw new Exception(nameof(SpeedWriting));
            }
        }
        public string Type
        {
            get { return _type; }
            set { value = _type; }
        }
        public double Memory
        {
            get { return (double)_memory; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception(nameof(Memory));
                }
            }
        }

        public DVD(int SpeedReading, int SpeedWriting, string Type, string Name, string Model) : base(Name, Model)
        {
            this.SpeedReading = SpeedReading;
            this.SpeedWriting = SpeedWriting;
            this.Type = Type;

            if (Type == "one_sided")
            {
                Memory = 4.7;
            }
            else
            {
                Memory = 9;
            }
        }

        public override double CopyData(double memoryFor)
        {
            if (memoryFor < 0)
                throw new Exception(nameof(memoryFor));

            return Memory / memoryFor;
        }

        public override double FreeSpace(double size)
        {

            if (size < 0) throw new Exception(nameof(size));

            double freeSpace = Memory - size;

            if (freeSpace < 0) throw new Exception(nameof(freeSpace));

            return freeSpace;
        }
        public override double FreeSpace(double[] size)
        {
            double freeSpace = 0;

            for (int i = 0; i < size.Length; i++)
            {
                if (size[i] < 0)
                    throw new Exception(nameof(size));
                freeSpace += size[i];
            }

            freeSpace = Memory - freeSpace;

            if (freeSpace < 0) throw new Exception(nameof(freeSpace));

            return freeSpace;
        }

        public override string GetGeneralInfo()
        {
            return $"Name - {Name}\nModel - {Model}\nSpeed Reading - {SpeedReading}\n Speed Writing - {SpeedWriting} \nMemory - {Memory}";
        }

        public override double GetMemory()
        {
            return Memory;
        }
    }

    internal class Flash : Storage
    {
        private int _speedUSB;
        private int _memory;
        public int SpeedUSB
        {
            get
            {
                return _speedUSB;
            }
            set
            {
                if (value < 0)
                    throw new Exception(nameof(value));
            }
        }
        public int Memory
        {
            get
            {
                return _memory;
            }
            set
            {
                if (value < 0)
                    throw new Exception(nameof(value));
            }
        }

        public Flash(int sUBS, int m, string n, string mod) : base(n, mod)
        {
            SpeedUSB = sUBS;
            Memory = m;
        }

        public override double GetMemory()
        {
            return Memory;
        }

        public override double CopyData(double memoryFor)
        {
            if (memoryFor < 0)
                throw new Exception(nameof(memoryFor));
            return memoryFor / Memory;
        }

        public override double FreeSpace(double size)
        {
            if (size < 0)
                throw new Exception(nameof(size));
            double freeSpace = Memory - size;
            if (freeSpace < 0)
            {
                throw new Exception(nameof(freeSpace));
            }
            return freeSpace;
        }
        public override double FreeSpace(double[] size)
        {
            double freeSpace = 0;
            for (int i = 0; i < size.Length; i++)
            {
                if (size[i] < 0)
                    throw new Exception(nameof(size));
                freeSpace += size[i];
            }

            freeSpace = Memory - freeSpace;

            if (freeSpace < 0)
            {
                throw new Exception();
            }

            return freeSpace;
        }

        public override string GetGeneralInfo()
        {
            return $"Name - {Name}\nModel - {Model}\nSpeed USB 3.0 - {SpeedUSB}\nMemory - {Memory}";
        }
    }


    internal class CopyReserve
    {
        public Storage[] storages { get; private set; }
        int lenght = 0;


        private double GeneralMemory()
        {
            double generalMemory = 0;
            foreach (Storage s in storages)
            {
                if (s is Flash)
                    generalMemory += (s as Flash).Memory;
                /*else if (s is DVD)
                    generalMemory+= (s as DVD).Memory;
                else if (s is HDD)
                    generalMemory+= (s as HDD).TotalMemory;*/
            }
            return generalMemory;
        }


        private void New()
        {
            char k = ' ';
            Console.WriteLine("1\nFlash\n2 - DVD\n3 - HDD\n 0 - выход");
            k = Console.ReadKey().KeyChar;
            if (k != '1' && k != '2' && k != '3' && k != '0')
            {
                Console.WriteLine("k - неверный аргумент");
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
            }

            switch (k)
            {
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                case '0':
                    break;
                default:
                    Console.ReadKey();
                    break;
            }
        }

        private void NewFlash()
        {

        }

        private void NewDVD()
        {

        }

        private void NewHDD()
        {

        }

        public void Main()
        {
            char k = ' ';
            while (k != '0')
            {
                Console.Clear();
                Console.WriteLine($"1||Расчет общего количества памяти на всех " +
                    $"устройствах (текущее количество - {lenght})");
                Console.WriteLine("2||Копирование информации на устройства");
                Console.WriteLine("3||Расчет времени необходимого для копирование");
                Console.WriteLine("4||расчет необходимого количества носителей " +
                    "информации представленных типов для переноса информации.");
                Console.WriteLine("5||Добавить новое устройство");
                Console.WriteLine("6||Удалить устройство");
                Console.WriteLine("0||Завершить программу и выйти");

                k = Console.ReadKey().KeyChar;
                if (k != '1' && k != '2' && k != '3' && k != '4' && k != '5' && k != '6' && k != '0')
                {
                    Console.WriteLine("k - неверный аргумент");
                    Console.WriteLine("Попробуйте снова\nНажмите любую клавишу для продолжения...");
                }
                try
                {
                    switch (k)
                    {
                        case '1':
                            break;
                        case '2':
                            break;
                        case '3':
                            break;
                        case '4':
                            break;
                        case '5':
                            break;
                        case '6':
                            break;
                        case '0':
                            break;
                        default:
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message, e.InnerException);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message, e.InnerException);
                }


            }

        }



    }

}
