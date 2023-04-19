﻿namespace la_mia_pizzeria_static.Models
{
    public class Ingrediente
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<Pizza>? Pizzas { get; set; }
    }
}
