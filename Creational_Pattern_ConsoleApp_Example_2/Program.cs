// Пример порождающющего шаблона - Фабричный Метод (Factory Method)
// Предоставляющий подклассам интерфейс для создания экземпляров некоторого класса, в момент создания наследники могут определить, какой класс создавать
using System;
using System.Collections.Generic;

namespace Creational_Pattern_ConsoleApp_Example_2
{
    // Ingredient - абстрактный класс ингредиент
    abstract class Ingredient { }
    // Bread (хлеб) - конкретный ингредиент
    class Bread : Ingredient { }
    // Chicken (курица) - конкретный ингредиент
    class Chicken : Ingredient { }
    // Salad (салат) - конкретный ингредиент
    class Salad : Ingredient { }
    // Mayonnaise (майонез) - конкретный ингредиент
    class Mayonnaise : Ingredient { }
    // Sandwich - абстрактный класс сэндвича
    abstract class Sandwich
    {
        // Приватный лист ингредиент сэндвича
        private List<Ingredient> m_ingredients = new List<Ingredient>();
        // Конструктор для класс Sandwich
        public Sandwich()
        {
            CreateIngredients();
        }
        // Абстрактный фабричный метод (паттерн Factory method)
        public abstract void CreateIngredients();
        // Доступ к приватному списоку ингредиентов сэндвича
        public List<Ingredient> Ingredients
        {
            get { return m_ingredients; }
        }
    }
    // Конкретный сэндвича с курицой, наследован от абстрактного класса Sandwich
    class SandwichWithChicken : Sandwich
    {
        // Конкретная реализация CreateIngredients() в SandwichWithChicken
        public override void CreateIngredients()
        {
            // Добавляем хлеб
            Ingredients.Add(new Bread());
            // Добавляем майонез
            Ingredients.Add(new Mayonnaise());
            // Добавляем салат
            Ingredients.Add(new Salad());
            // Добавляем курицу
            Ingredients.Add(new Chicken());
            // Добавляем майонез
            Ingredients.Add(new Mayonnaise());
            // Добавляем хлеб
            Ingredients.Add(new Bread());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаём лист сэндвичей
            List<Sandwich> sandwiches = new List<Sandwich>();
            // Добавляем в него обычный сэндвича
            sandwiches.Add(new SandwichWithChicken());
            // Создаём переменную sandwichWithChickenDouble как обычный сэндвич
            Sandwich sandwichWithChickenDouble = new SandwichWithChicken();
            // Добавляем ингредиенты
            sandwichWithChickenDouble.Ingredients.Add(new Salad());
            sandwichWithChickenDouble.Ingredients.Add(new Mayonnaise());
            sandwichWithChickenDouble.Ingredients.Add(new Chicken());
            sandwichWithChickenDouble.Ingredients.Add(new Mayonnaise());
            sandwichWithChickenDouble.Ingredients.Add(new Bread());
            // Добавляем в лист sandwiches сэндвич с двойной курицей
            sandwiches.Add(sandwichWithChickenDouble);
            // Выводим ингредиенты каждого сэндвич из лист sandwiches
            foreach (var sandwich in sandwiches)
            {
                Console.WriteLine($"Сэндвич: {sandwich.GetType().Name}");
                foreach (var ingredient in sandwich.Ingredients)
                {
                    Console.WriteLine($"Ингредиенты: {ingredient.GetType().Name}");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
