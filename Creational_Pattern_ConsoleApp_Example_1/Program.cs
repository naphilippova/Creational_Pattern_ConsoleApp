// Пример порождающющего шаблона - Одиночка (Singleton)
// Гарантирующий, что в однопоточном приложении будет единственный экземпляр некоторого класса, и предоставляющий глобальную точку доступа к этому экземпляру
using System;

namespace Creational_Pattern_ConsoleApp_Example_1
{
    public sealed class Singleton
    {
        private static Singleton m_instance = null;
        private static readonly object m_lockobject = new object();
        // Конструктор класса Singleton
        private Singleton()
        {
            // Приватный конструктор, чтобы предотвратить создание экземпляров класса снаружи
        }
        // Публичная статичная переменная Instance
        public static Singleton Instance
        {
            get
            {
                if (m_instance == null)
                {
                    lock (m_lockobject)
                    {
                        // Двойная проверка для потокобезопасности
                        if (m_instance == null)
                        {
                            m_instance = new Singleton();
                        }
                    }
                }
                return m_instance;
            }
        }
        // DoSomething() - публичный метод класса Singleton
        public void DoSomething()
        {
            Console.WriteLine("Делаем что-то в Singleton");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton = Singleton.Instance;
            singleton.DoSomething();
            Console.ReadKey();
        }
    }
}
