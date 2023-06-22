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
            private set
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
            private set
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

        public abstract double CopyData(double memoryFor);
        public abstract double FreeSpace(double size);
        public abstract double FreeSpace(double[] size);
        public abstract string GetGeneralInfo();
    }

    internal class HDD : Storage
    {
        private double _memoryInSection;
        private int _sections;
        private double _speedUSB;
        private double _memory;

        public double MemoryInSection
        {
            get
            {
                return _memoryInSection;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                        throw new FormatException();
                    _memoryInSection = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(_memoryInSection));
                }

            }
        }
        public int Sections 
        {
            get
            {
                return _sections;
            }
            private set
            {
                try
                {
                    if (value <= 0)
                        throw new FormatException();
                    _sections = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(Sections));
                }

            }
        }
        public double SpeedUSB
        {
            get { return _speedUSB; }
            private set
            {
                if (value < 0)
                    throw new FormatException(nameof(SpeedUSB));
                _speedUSB = value;
            }
        }
        public double Memory
        {
            get { return _memory; }
            private set
            {
                if (value < 0)
                    throw new FormatException(nameof(Memory));
                _memory = value;
            }
        }

        public HDD(double sUBS, double m, int s, double mIS, string n, string mod) : base(n, mod)
        {
            SpeedUSB = sUBS;
            Memory = m;
            Sections = s;
            MemoryInSection = mIS;
        }

        public override double CopyData(double memoryFor)
        {
            if (memoryFor < 0)
                throw new FormatException(nameof(memoryFor));
            return Math.Round(memoryFor / Memory);
        }

        public override double FreeSpace(double size)
        {
            if (size < 0)
                throw new FormatException(nameof(size));
            double freeSpace = Memory - size;
            if (freeSpace < 0)
            {
                throw new FormatException(nameof(freeSpace));
            }
            return freeSpace;
        }
        public override double FreeSpace(double[] size)
        {
            double freeSpace = 0;
            for (int i = 0; i < size.Length; i++)
            {
                if (size[i] < 0)
                    throw new FormatException(nameof(size));
                freeSpace += size[i];
            }

            freeSpace = Memory - freeSpace;

            if (freeSpace < 0)
                throw new FormatException(nameof(freeSpace));

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
        private double _speedWriting= 0;
        private string _type;
        private double _memory = 0;

        public double SpeedReading
        {
            get { return _speedReading; }
            private set
            {
                try
                {
                    if (value <= 0)
                        throw new FormatException();
                    _speedReading = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(SpeedReading));
                }
            }
        }
        public double SpeedWriting
        {
            get { return _speedWriting; }
            private set
            {
                try
                {
                    if (value <= 0)
                        throw new FormatException();
                    _speedWriting = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(SpeedWriting));
                }
            }
        }
        public string Type
        {
            get { return _type; }
            private set
            {
                try
                {
                    _type = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(Type));
                }
            }
        }
        public double Memory
        {
            get { return _memory; }
            private set
            {
                try
                {
                    if (value <= 0)
                        throw new FormatException();
                    _memory = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(Memory));
                }
            }
        }


        public DVD(double SpeedReading, double SpeedWriting, string Type, string Name, string Model) : base(Name, Model)
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
                throw new FormatException(nameof(memoryFor));

            return Math.Round(memoryFor / Memory);
        }

        public override double FreeSpace(double size)
        {

            if (size < 0) throw new FormatException(nameof(size));

            double freeSpace = Memory - size;

            if (freeSpace < 0) throw new FormatException(nameof(freeSpace));

            return freeSpace;
        }
        public override double FreeSpace(double[] size)
        {
            double freeSpace = 0;

            for (int i = 0; i < size.Length; i++)
            {
                if (size[i] < 0)
                    throw new FormatException(nameof(size));
                freeSpace += size[i];
            }

            freeSpace = Memory - freeSpace;

            if (freeSpace < 0) throw new FormatException(nameof(freeSpace));

            return freeSpace;
        }

        public override string GetGeneralInfo()
        {
            return $"Name - {Name}\nModel - {Model}\nSpeed Reading - {SpeedReading}\n Speed Writing - {SpeedWriting} \nMemory - {Memory}";
        }

    }


    internal class Flash : Storage
    {
        private double _speedUSB;
        private double _memory;
        public double SpeedUSB
        {
            get
            {
                return _speedUSB;
            }
            private set
            {
                try
                {
                    if (value < 0)
                        throw new FormatException();
                    _speedUSB = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(SpeedUSB));
                }
            }
        }
        public double Memory
        {
            get
            {
                return _memory;
            }
            private set
            {
                try
                {
                    if (value < 0)
                        throw new FormatException();
                    _memory = value;
                }
                catch (FormatException)
                {
                    throw new FormatException(nameof(Memory));
                }
            }
        }

        public Flash(double sUBS, double m, string n, string mod) : base(n, mod)
        {
            SpeedUSB = sUBS;
            Memory = m;
        }

        public override double CopyData(double memoryFor)
        {
            if (memoryFor < 0)
                throw new FormatException(nameof(memoryFor));
            return Math.Round(memoryFor / Memory);
        }

        public override double FreeSpace(double size)
        {
            if (size < 0)
                throw new FormatException(nameof(size));
            double freeSpace = Memory - size;
            if (freeSpace < 0)
            {
                throw new FormatException(nameof(freeSpace));
            }
            return freeSpace;
        }
        public override double FreeSpace(double[] size)
        {
            double freeSpace = 0;
            for (int i = 0; i < size.Length; i++)
            {
                if (size[i] < 0)
                    throw new FormatException(nameof(size));
                freeSpace += size[i];
            }

            freeSpace = Memory - freeSpace;

            if (freeSpace < 0)
            {
                throw new FormatException(nameof(freeSpace));
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
        private Storage[] storages;
        int lenght = 0;

         


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

            Console.Clear();
            switch (k)
            {
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '0':
                    break;
                default:
                    Console.ReadKey();
                    break;
            }
        }

        private void NewFlash()
        {
            string name;
            string model;
            double speedUSB;
            double memory;
            Console.WriteLine("Новый Flash");
            Console.WriteLine("Введите имя устройства: "); name = Console.ReadLine();
            Console.WriteLine("Введите модель устройства: "); model = Console.ReadLine();
            Console.WriteLine("Введите скорость USB устройства: "); speedUSB = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите память устройства: "); memory = double.Parse(Console.ReadLine());

            Array.Resize(ref storages, lenght++);
            try
            {
                storages[lenght - 1] = new Flash(speedUSB, memory, name, model);
            }
            catch(FormatException)
            {
                throw;
            }
        }

        private void NewDVD()
        {
            string name;
            string model;
            double speedReading, speedWriting;
            string type;
            Console.WriteLine("Новый DVD");
            Console.WriteLine("Введите имя устройства: "); name = Console.ReadLine();
            Console.WriteLine("Введите модель устройства: "); model = Console.ReadLine();
            Console.WriteLine("Введите скорость считывания: "); speedReading = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите скорость записи: "); speedWriting = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите тип устройства: "); type = Console.ReadLine();

            Array.Resize(ref storages, lenght++);
            try
            {
                storages[lenght - 1] = new DVD(speedReading, speedWriting, type, name, model);
            }
            catch (FormatException)
            {
                throw;
            }
        }

        private void NewHDD()
        {
            string name;
            string model;
            int sections;
            double memoryInSection;
            double speedUSB;
            double memory;
            Console.WriteLine("Новый HDD");
            Console.WriteLine("Введите имя устройства: "); name = Console.ReadLine();
            Console.WriteLine("Введите модель устройства: "); model = Console.ReadLine();
            Console.WriteLine("Введите скорость USB устройства: "); speedUSB = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество секций устройства: "); sections = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите память в одной секции: "); memoryInSection = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите память устройства: "); memory = double.Parse(Console.ReadLine());

            Array.Resize(ref storages, lenght++);
            try
            {
                storages[lenght - 1] = new HDD(speedUSB, memory, sections, memoryInSection, name, model);
            }
            catch (FormatException)
            {
                throw;
            }
        }


        private double GeneralMemory()
        {
            double generalMemory = 0;
            foreach (Storage s in storages)
            {
                if (s is Flash)
                    generalMemory += (s as Flash).Memory;
                else if (s is DVD)
                    generalMemory += (s as DVD).Memory;
                else if (s is HDD)
                    generalMemory += (s as HDD).Memory;
            }
            return generalMemory;
        }




        public void Main()
        {
            char k = ' ';
            while (k != '0')
            {
                Console.Clear();
                Console.WriteLine($"1||Расчет общего количества памяти на всех " +
                    $"устройствах (текущее количество - {lenght})");    //+
                Console.WriteLine("2||Копирование информации на устройства");  //-
                Console.WriteLine("3||Расчет времени необходимого для копирование");  //-
                Console.WriteLine("4||расчет необходимого количества носителей " + 
                    "информации представленных типов для переноса информации."); //-
                Console.WriteLine("5||Добавить новое устройство");   //+
                Console.WriteLine("6||Удалить устройство");     //-
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

            }

        }



    }

}
