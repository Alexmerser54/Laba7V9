using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Laba18._9
{
    struct Train // структура поезда
    {
        public string dest; // публичное поле для пункта назначения
        public int id; // публитное поле для номера поезда
        public int[] time; // публичное поле для времени (массив: первый элемент - часы, второй - минуты)

        public Train(int id, string dest, int[] time) // конструктор
        {   // использование ключевого слова this для указания к элементам структуры
            this.id = id; // присваивание номера
            this.dest = dest; // присваивание пункта назначения
            this.time = time; // присваивания даты
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            string act; // переменная для выбора действия
            Train[] trains = new Train[8]; // массив из 8 экземпляров структуры поездов

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1) Записать 8 поездов в файл, упорядочив его по номерам поездов");
            Console.WriteLine("2) Считать файл");
            Console.WriteLine("3) Вывести информацию о поезде по его номеру");

            act = Console.ReadLine(); // считываем действие пользователя

            switch (act) // консутркция switch для выбора действия
            {
                case "1": // первый случай
                    string input; // переменная для ввода поездов

                    File.WriteAllText("trains.txt", ""); // создаём пустой файл или очищаем его, если он уже создан

                    for (int i = 0; i < trains.Length; i++) // перебор каждого элемента массива
                    {
                        input = Console.ReadLine(); // считываем ввода типа номер-назначение-часы:минуты
                        string[] trainLine = input.Split('-'); // разбиваем входную строку, чтобы создать структуру

                        string[] tmp = trainLine[2].Split(':'); // разбиваем третий элемент массива trainLine, чтобы создать массив со временем
                        int[] time = // создаём массив со временем
                        {
                            Int32.Parse(tmp[0]), // первый элемент - часы
                            Int32.Parse(tmp[1]) // второй элемент - минуты
                        };

                        trains[i] = new Train(Int32.Parse(trainLine[0]), trainLine[1], time); // создаём структуру при помощи конструктра и присваимваем её элементу массива


                    }

                    for (int i = 0; i < trains.Length; i++) // пузырьковая сортировка массива структур
                    {
                        for (int j = i + 1; j < trains.Length; j++)
                        {
                            if (trains[i].id > trains[j].id) // сортируем по номеру поезда
                            {
                                Train tmp = trains[i];
                                trains[i] = trains[j];
                                trains[j] = tmp;
                            }
                        }
                    }

                    foreach (var train in trains) // перебор всех элементов массива
                    {
                        File.AppendAllText("trains.txt", $"{train.id}-{train.dest}-{train.time[0]}:{train.time[1]}\n"); // записываем каждый элемент структру в нашем формате и в конце ставим символ новой строки
                    }
                    break;

                case "2": // второй случай
                    Console.WriteLine(File.ReadAllText("trains.txt")); // просто выводим всё содержимое файла
                    break;
                case "3": // третий случай
                    Console.WriteLine("Введите номер поезда");
                    int num = Int32.Parse(Console.ReadLine()); // вводим номер поезда
                    bool founded = false; // флаг для проверки наличия данного поезда

                    string[] lines = File.ReadAllLines("trains.txt"); // считываем все строки файла
                    foreach (var line in lines) //перебор строк файла
                    {
                        string[] tmp = line.Split('-'); // разбиваем строку на три строки при помощи делителя '-'
                        if (Int32.Parse(tmp[0]) == num) // если номер поезда из файла равен введённому номеруы
                        {
                            Console.WriteLine(line); // выводим строку
                            founded = true; // поднимаем флаг
                        }
                    }

                    if (!founded) Console.WriteLine("Поезда с таким номером нет"); // если флаг не был поднят, выводим сообщение об отсутствии поезда

                    break;
                default: // если введёно не то действие
                    Console.WriteLine("Такого действия не существует"); // выводим информацию об этом
                    break;
            }

        }
    }
}
