using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private PizzaBasic currentPizza = new CheesePizza();

        public Form1()
        {
            InitializeComponent();
            choosePizza.Items.Add("Сырная пицца");
            choosePizza.Items.Add("Барбекю пицца");

            addToPizza.Items.Add("Томат");
            addToPizza.Items.Add("Сыр");
            addToPizza.Items.Add("Мясо");
        }

        private void UpdateForm()
        {
            ChoseElem.Text = currentPizza.GetDescription();
            priceBox.Text = $"{currentPizza.GetCost()} руб.";
        }

        // Абстрактный класс базовой пиццы
        public abstract class PizzaBasic
        {
            public abstract int GetCost();
            public abstract string GetDescription();
        }

        // Класс сырной пиццы
        public class CheesePizza : PizzaBasic
        {
            public override int GetCost()
            {
                // Цена сырной пиццы
                return 450;
            }

            public override string GetDescription()
            {
                return "Сырная пицца";
            }
        }

        // Класс барбекю пиццы
        public class BarbecuePizza : PizzaBasic
        {
            public override int GetCost()
            {
                // Цена барбекю пиццы
                return 560;
            }

            public override string GetDescription()
            {
                return "Барбекю пицца";
            }
        }

        // Класс добавки томата
        public class Tomato : PizzaBasic
        {
            private PizzaBasic pizza;

            public Tomato(PizzaBasic pizza)
            {
                this.pizza = pizza;
            }

            public override int GetCost()
            {
                // Дополнительная цена за томаты
                return pizza.GetCost() + 15;
            }

            public override string GetDescription()
            {
                return pizza.GetDescription() + ", Добавка: Томат";
            }
        }

        // Класс добавки сыра
        public class Cheese : PizzaBasic
        {
            private PizzaBasic pizza;

            public Cheese(PizzaBasic pizza)
            {
                this.pizza = pizza;
            }

            public override int GetCost()
            {
                // Дополнительная цена за сыр
                return pizza.GetCost() + 30;
            }

            public override string GetDescription()
            {
                return pizza.GetDescription() + ", Добавка: Сыр";
            }
        }

        // Класс добавки мяса
        public class Meat : PizzaBasic
        {
            private PizzaBasic pizza;

            public Meat(PizzaBasic pizza)
            {
                this.pizza = pizza;
            }

            public override int GetCost()
            {
                // Дополнительная цена за мясо
                return pizza.GetCost() + 50;
            }

            public override string GetDescription()
            {
                return pizza.GetDescription() + ", Добавка: Мясо";
            }
        }

        private void choosePizza_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (choosePizza.Text)
            {
                case "Сырная пицца":
                    currentPizza = new CheesePizza();
                    break;
                case "Барбекю пицца":
                    currentPizza = new BarbecuePizza();
                    break;
                default:
                    currentPizza = null; // Если пицца не выбрана, устанавливаем выбранный объект в null
                    break;
            }
            priceBox.Text = $"{currentPizza.GetCost()} руб.";
            UpdateForm();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            switch (addToPizza.Text)
            {
                case "Томат":
                    currentPizza = new Tomato(currentPizza);
                    break;
                case "Сыр":
                    currentPizza = new Cheese(currentPizza);
                    break;
                case "Мясо":
                    currentPizza = new Meat(currentPizza);
                    break;
                default:
                    currentPizza = null; // Если добавка не выбрана, устанавливаем выбранный объект в null
                    break;
            }
            UpdateForm();
        }
    }
}
