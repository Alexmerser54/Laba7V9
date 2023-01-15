using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba7
{
    struct Book // структура книги
    {
        public string author; // публичное поле для фамилии автора
        public string name; // публичное поле для названии книги
        public int year; // публичное поле для года издания книги

        public Book(string name, string author, int year) // конструктор для создания экземпляра структуры
        { // this укзаывает на поле структуры
            this.name = name; // присваиваем название книги
            this.author = author; // присваиваем фамилию автора
            this.year = year; // присваиваем год издания
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string author; //переменная для фамилии автора, которую ищем
            Book[] books = new Book[10]
            {
                new Book("Бойцовский клуб","Паланик", 1996),
                new Book("Удушье","Паланик", 2001),
                new Book("Американский психопат", "Эллис", 1991),
                new Book("Война миров", "Уэллс", 1898),
                new Book("Война и Мир", "Толстой", 1867),
                new Book("Дюна", "Герберт", 1965),
                new Book("Старый блуждающий дом", "Герберт", 1958),
                new Book("Трудно быть Богом", "Стругацкие", 1958),
                new Book("Страна багровых туч", "Стругацкие", 1959),
                new Book("Пикник на обочине", "Стругацкие", 1972),
            }; // инициализация массива десятью книгами

            Console.WriteLine("Введите фамилию автора");
            author = Console.ReadLine(); // ввод фамилии автора

            Console.WriteLine(); // вывод новой строки для приятного восприятия информации
            Console.WriteLine("Книги данного автора, изданные с 1960 года:");
            foreach (var book in books) // перебор массива книг
            {
                if (book.author == author && book.year >= 1960) // если имя автора книги совпадает с введённым и год больше или равен 1960
                    Console.WriteLine(book.name); // выводим название книги
            }


        }
    }
}
