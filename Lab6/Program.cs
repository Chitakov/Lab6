using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        //функция для ввода элементов массива для заданий 1 и 2
        public static void EnterArray(params double[] a)
        {
            for (int i = 0; i < a.Length; ++i)
                a[i] = Convert.ToDouble(Console.ReadLine());
        }
        //функция для вывода элементов массива для заданий 1 и 2
        public static void PrintArray(string header, params double[] a)
        {
            Console.WriteLine(header);
            foreach (var n in a)
            {
                Console.Write("\t" + n);
            }
            Console.WriteLine();
        }
        //функция для ввода элементов массива для задания 3
        public static void EnterArray3(double[,] a, int n, int m)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    a[i, j] = Convert.ToDouble(Console.ReadLine());
        }
        //функция для вывода элементов массива для задания 3
        public static void PrintArray3(string header, double[,] a, int n1, int m1)
        {
            Console.WriteLine(header);
            for (int i = 0; i < n1; ++i)
            {
                for (int j = 0; j < m1; ++j)
                    Console.Write("\t" + a[i, j]);
                Console.WriteLine();
            }
        }
        //задание 1
        static void Task1()
        {
            Console.WriteLine("Введите количество элементов в массиве:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите C: ");
            double C = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите элементы массива:");
            double[] array = new double[n];
            double pr;

            //ввод массива
            EnterArray(array);
            Console.WriteLine();
            //вывод массива
            PrintArray("Исходный массив:", array);
            //обработка и вывод результата
            ObrArray(array, n, C, out pr);

            if (pr != 1) Console.WriteLine("Произведение элементов массива, которые больше {0} = {1}", C, pr);
            else Console.WriteLine("Элементов, которые больше {0} нет", C);
            Console.ReadLine();
            Console.Clear();
        }
        //функция для обработки и вывода результата для задания 1
        public static void ObrArray(double[] array, int n, double C, out double pr)
        {
            pr = 1;
            for (int i = 0; i < n; i++)
                if (array[i] > C) pr *= array[i];
        }
        //задание 2
        static void Task2()
        {
            Console.WriteLine("Введите количество элементов в массиве:");
            int n = Convert.ToInt32(Console.ReadLine());
            int index_fpos = -1;
            Console.WriteLine("Введите элементы массива");
            double[] array = new double[n];
            //ввод массива
            EnterArray(array);
            Console.WriteLine();
            //вывод массива
            PrintArray("Исходный массив:", array);
            //обработка
            ObrArray2(n, index_fpos, array);
            //вывод результата
            PrintArray("Искомый массив:", array);
            Console.ReadLine();
            Console.Clear();
        }
        //функция для обработки массива для задания 2
        public static void ObrArray2(int n, int index_fpos, double[] array)
        {
            double temp;
            for (int i = 0; i < n; i++)
            {
                if (array[i] > 0)
                {
                    index_fpos = i;
                    break;
                }
            }

            if (index_fpos != -1)
            {
                for (int i = 0; i < index_fpos - 1; i++)
                {
                    for (int j = i + 1; j < index_fpos; j++)
                    {
                        if (array[i] > array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (array[i] > array[j])
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }
        //задание 3
        static void Task3()
        {
            int count;
            Console.WriteLine("Введите количество строк в массиве:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество столбцов в массиве:");
            int m = Convert.ToInt32(Console.ReadLine());
            double[,] array = new double[n, m];
            Console.WriteLine("Введите C:");
            double C = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите элементы массива");
            //ввод массива
            EnterArray3(array, n, m);
            Console.WriteLine();
            //вывод массива
            PrintArray3("Исходный массив", array, n, m);
            //обработка и вывод результата
            ObrArray3(array, n, m, C, out count);
            Console.WriteLine("Количество строк, среднее арифметическое элементов которых меньше {0}  =  {1}", C, count);
            Console.ReadLine();
            Console.Clear();
        }
        //функция для обработки массива для задания 3
        public static void ObrArray3(double[,] array, int n, int m, double C, out int count)
        {
            count = 0;
            for (int i = 0; i < n; i++)
            {
                double avr_row = 0;
                for (int j = 0; j < m; j++)
                {
                    avr_row += array[i, j];
                }
                avr_row /= m;
                if (avr_row < C)
                {
                    count++;
                }
            }
        }
        //задание 4
        static void Task4() 
        {
            Console.WriteLine("Введите наименование: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите тип: ");
            string type = Console.ReadLine();
            Console.WriteLine("Введите дату изготовления (DD.MM.YYYY): ");
            DateTime date_of_manufacture = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите цену: ");
            double price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            var myTuple = Corteg(name, type, date_of_manufacture, price);
            Console.WriteLine("Название: {0}\n" + "Код мебели: {1}\n" + "Средняя цена: {2}\n"
                + "Совпадает тип: {3}\n", myTuple.Item1, myTuple.Item2, myTuple.Item3, myTuple.Item4);
            Console.ReadLine();
            Console.Clear();
        }
        //структура для задания 4
        struct furniture
        {
            public string name;
            public string material;
            public string type;
            public int price1, price2, price3;
        }
        //кортеж для задания 4
        static Tuple<string, string, double, string> Corteg(string name, string type, DateTime date_of_manufacture, double price4)
        {
            string p = name, code_of_furniture, otv = "нет";
            double sum = 0, sr;

            furniture[] furn = new furniture[6];
            furn[0].name = "Кресло";
            furn[0].material = "Дуб";
            furn[0].type = "Для богатых";
            furn[0].price1 = 47; furn[0].price2 = 58; furn[0].price3 = 69;

            furn[1].name = "Диван";
            furn[1].material = "Клён";
            furn[1].type = "Для среднего класса";
            furn[1].price1 = 100; furn[1].price2 = 75; furn[1].price3 = 82;

            furn[2].name = "Пуфик";
            furn[2].material = "Пенопласт";
            furn[2].type = "Для бюджетников";
            furn[2].price1 = 12; furn[1].price2 = 1; furn[1].price3 = 8;

            furn[3].name = "Стол";
            furn[3].material = "Осина";
            furn[3].type = "Для всех";
            furn[3].price1 = 5; furn[1].price2 = 23; furn[1].price3 = 1;

            furn[4].name = "Стул";
            furn[4].material = "Берёза";
            furn[4].type = "Для бедных";
            furn[4].price1 = 4; furn[1].price2 = 5; furn[1].price3 = 1;

            int nom = -1;
            for (int i = 0; i <= 5; i++)
                if (furn[i].name == name)
                {
                    nom = i;
                    break;
                }
            if (nom != -1)
            {
                code_of_furniture = furn[nom].material + " " + date_of_manufacture;
                sum = furn[nom].price1 + furn[nom].price2 + furn[nom].price3 + price4;
                sr = sum / 4;
                if (type == furn[nom].type) otv = "да";
            }
            else { code_of_furniture = "не определена"; sr = price4 / 4; }
            return Tuple.Create<string, string, double, string>(p, code_of_furniture, sr, otv);
        }
        //функция для вывода главного меню
        static void PrintMenu()
        {
            Console.WriteLine("1. Задание 1");
            Console.WriteLine("2. Задание 2");
            Console.WriteLine("3. Задание 3");
            Console.WriteLine("4. Задание 4");
            Console.WriteLine("Если желаете выйти, введите 0\n");
        }
        static void Main(string[] args)
        {
            int ch, a = 1;
            try
            {
                do
                {
                    PrintMenu();
                    Console.WriteLine("Выберите номер задания: ");
                    ch = Convert.ToInt32(Console.ReadLine());
                    switch (ch)
                    {
                        case 1:
                            Console.Clear();
                            Task1();
                            break;
                        case 2:
                            Console.Clear();
                            Task2();
                            break;
                        case 3:
                            Console.Clear();
                            Task3();
                            break;
                        case 4:
                            Console.Clear();
                            Task4();
                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("   Такого задания нет.\n");
                            break;
                    }
                } while (a == a);
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный ввод");
            }
                Console.ReadLine();
        }
    }
}