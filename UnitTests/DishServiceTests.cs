﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            bool expected = true;
            bool actual = _dishService.AddDish(new Dish
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
            });


            Assert.AreEqual(expected, actual);
        }
    }
}