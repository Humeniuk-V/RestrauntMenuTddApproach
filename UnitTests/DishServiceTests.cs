using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestarauntMenu;
using RestarauntMenu.Models;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class DishServiceTests
    {
        private DishService _dishService = new DishService();

        [TestMethod]
        public void AddDish_DishObject_ReturnTheSameDish()
        {
            var expected = new Dish
            {
                Id = 1,
                Name = "Salad1",
                Cuisine = new CuisineType { Name = "American1" },
                DishType = new DishType { Name = "Salad1" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Tomato" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 1000,
                Votes = 0
            };

            var actual = _dishService.AddDish(expected);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveDish_DishObject_DishesInOrderCountIs0()
        {
            var dish = new Dish
            {
                Id = 1,
                Name = "Salad1",
                Cuisine = new CuisineType { Name = "American1" },
                DishType = new DishType { Name = "Salad1" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Tomato" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 1000,
                Votes = 0
            };
            _dishService.AddDish(dish);

            _dishService.RemoveDish(dish);

            Assert.IsTrue(_dishService.DishesInOrder.Count == 0);
        }

        [TestMethod]
        public void UpdateDish_DishObject_ReturnsUpdatedDish()
        {
            var expected = new Dish
            {
                Id = 1,
                Name = "Salad2",
                Cuisine = new CuisineType { Name = "American2" },
                DishType = new DishType { Name = "Salad2" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Tomato2" },
                    new DishIngredient { Name = "Potato2" },
                    new DishIngredient { Name = "Salad2" }
                },
                Price = 2000,
                Votes = 0
            };

            var dish = new Dish
            {
                Id = 1,
                Name = "Salad1",
                Cuisine = new CuisineType { Name = "American1" },
                DishType = new DishType { Name = "Salad1" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Tomato" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 1000,
                Votes = 0
            };
            _dishService.AddDish(dish);

            _dishService.UpdateDish(dish.Id, expected);

            Assert.AreEqual(expected, _dishService.FindDish(expected.Id));
        }

        [TestMethod]
        public void GetListOfDishesByPopularity_DishObject_ReturnsSortedList()
        {
            var dish1 = new Dish
            {
                Id = 1,
                Name = "Salad1",
                Cuisine = new CuisineType { Name = "American1" },
                DishType = new DishType { Name = "Salad1" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Tomato" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 1000,
                Votes = 10
            };
            var dish2 = new Dish
            {
                Id = 2,
                Name = "Salad2",
                Cuisine = new CuisineType { Name = "American2" },
                DishType = new DishType { Name = "Salad2" },
                Ingredients = new List<DishIngredient> {
                    new DishIngredient { Name = "Egg" },
                    new DishIngredient { Name = "Potato" },
                    new DishIngredient { Name = "Salad" }
                },
                Price = 2000,
                Votes = 20
            };
            _dishService.AddDish(dish1);
            _dishService.AddDish(dish2);

            var expected = new List<Dish> { dish2, dish1 };

            var actual = _dishService.GetListOfDishesByPopularity();

            Assert.AreEqual(JsonConvert.SerializeObject(actual), JsonConvert.SerializeObject(expected));
        }

    }
}
