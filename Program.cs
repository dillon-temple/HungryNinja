using System;
using System.Collections.Generic;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet pigout = new Buffet();
            Ninja Bobby = new Ninja();
            Bobby.Eat(pigout.Serve());
            Bobby.Eat(pigout.Serve());
            Bobby.Eat(pigout.Serve());
            Bobby.Eat(pigout.Serve());
            Bobby.Eat(pigout.Serve());



        }
    }

    class Food
    {
        public string Name;
        public int Calories;
        // Foods can be Spicy and/or Sweet
        public bool IsSpicy;
        public bool IsSweet;
        // add a constructor that takes in all four parameters: Name, Calories, IsSpicy, IsSweet

        public Food(string name, int calories, bool isSpicy, bool isSweet)
        {
            Name = name;
            Calories = calories;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        }
    }
    class Buffet
    {
        public List<Food> Menu;

        //constructor
        public Buffet()
        {
            Menu = new List<Food>()
        {
            new Food("Water", 0, false, false),
            new Food("Apple", 80, false, true),
            new Food("Banana", 110, false, true),
            new Food("Tacos", 300, true, false),
            new Food("Bald Eagle", 800, true, true),
            new Food("Fresh Panda", 1400, true, true),
            new Food("Rice", 120, false, false)
        };
        }

        public Food Serve()
        {
            Random random = new Random();
            Food selection = this.Menu[random.Next(0,7)];
            Console.WriteLine(selection.Name);
            return selection;
        }
    }

    class Ninja
    {
        private int calorieIntake;
        private bool isFull;

        bool IsFull{

            get{ 
                if(calorieIntake > 1200){
                    return true;
                }
                else{
                    return false;
                }
            }
                
        }
        public List<Food> FoodHistory = new List<Food>();

        public Ninja(){
            calorieIntake = 0;
        }

        public void Eat(Food item)
        {
            if (this.IsFull)
            {
                Console.WriteLine("Your Ninja is full and can't eat anymore!");
                return;
            }

            calorieIntake += item.Calories;

            if(this.IsFull){

                if(item.IsSpicy == false && item.IsSweet == false){
                     Console.WriteLine("Your Ninja is full after that!");
                }
                if(item.IsSpicy == true && item.IsSweet == false){
                      Console.WriteLine("Your Ninja is full after that! The item was Spicy!");
    
                }
                if(item.IsSpicy == false && item.IsSweet == true){
                      Console.WriteLine($"Your Ninja is full after that! The item was Sweet!");

                }
                if(item.IsSpicy == true && item.IsSweet == true){
                      Console.WriteLine($"Your Ninja is full after that! The item was Sweet and Spicy!");
                }
                return;
            }
            else{
                FoodHistory.Add(item);
                if (item.IsSpicy == false && item.IsSweet == false)
                {
                    Console.WriteLine("That item was bland");
                }
                if (item.IsSpicy == true && item.IsSweet == false)
                {
                    Console.WriteLine("That item was Spicy!");

                }
                if (item.IsSpicy == false && item.IsSweet == true)
                {
                    Console.WriteLine("That item was Sweet!");

                }
                if (item.IsSpicy == true && item.IsSweet == true)
                {
                    Console.WriteLine("That item was Sweet and Spicy!");
                }
                return;
            }
        }
    }
}