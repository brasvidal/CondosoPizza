using ContosoPizza.Models;
using System.Collections.Generic;
using System.Linq;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static int nextId = 3;
        static PizzaService()
        {
            Pizzas = new List<Pizza>
               {

                new Pizza {id = 1, Name="Classic Italian",isGlutenFree = false},
                new Pizza { id = 2, Name = "Veggie", isGlutenFree = true }
               };
        }
        public static List<Pizza> GetAll() => Pizzas;
        public static Pizza Get(int id) => Pizzas.FirstOrDefault(p => p.id == id);
        public static void Add(Pizza pizza)
        {
            pizza.id = nextId++;
            Pizzas.Add(pizza);
        }
        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null)
                return;
            Pizzas.Remove(pizza);
        }
        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(pizza => pizza.id == pizza.id);
            if (index == -1)
                return;
            Pizzas[index] = pizza;
        }
    }
}