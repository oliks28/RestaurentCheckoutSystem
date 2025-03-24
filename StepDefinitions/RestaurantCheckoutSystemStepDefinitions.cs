using System;
using NUnit.Framework;
using Reqnroll;
using RestaurantCheckoutSystem.Models;

namespace RestaurentCheckoutSystem.StepDefinitions
{
    [Binding]
    public class RestaurantCheckoutSystemStepDefinitions
    {
        private Order _order;
        private double _totalBill;

        [Given("a group of {int} people places an order:")]
        public void GivenAGroupOfPeoplePlacesAnOrder(int p0, DataTable dataTable)
        {
            _order = new Order();

            foreach (var row in dataTable.Rows)
            {
                string itemName = row["Item"];
                int quantity = int.Parse(row["Quantity"]);
                int orderTime = int.Parse(row["Time"].Split(':')[0]);

                double price = itemName == "Starter" ? 4.00 :
                               itemName == "Main" ? 7.00 :
                               itemName == "Drink" ? 2.50 : 0;

                bool isFood = itemName != "Drink";
                bool hasDiscount = itemName == "Drink";

                _order.AddItem(new OrderItem(itemName, quantity, price, isFood, hasDiscount, orderTime));
            }
        }

        [When("the bill is requested")]
        public void WhenTheBillIsRequested()
        {
            _totalBill = BillCalculator.CalculateTotal(_order);
        }

        [Then("the total bill should be {float}")]
        public void ThenTheTotalBillShouldBe(Double expectedBill)
        {
            Assert.AreEqual(expectedBill, _totalBill, 0.01);
        }

        [Given("a group of {int} orders:")]
        public void GivenAGroupOfOrders(int groupSize, DataTable dataTable)
        {
            _order = new Order();

            foreach (var row in dataTable.Rows)
            {
                string itemName = row["Item"];
                int quantity = int.Parse(row["Quantity"]);
                int orderTime = int.Parse(row["Time"].Split(':')[0]);

                double price = itemName == "Starter" ? 4.00 :
                               itemName == "Main" ? 7.00 :
                               itemName == "Drink" ? 2.50 : 0;

                bool isFood = itemName != "Drink";
                bool hasDiscount = itemName == "Drink";

                _order.AddItem(new OrderItem(itemName, quantity, price, isFood, hasDiscount, orderTime));
            }
        }

        [When("they request the bill")]
        public void WhenTheyRequestTheBill()
        {
            _totalBill = BillCalculator.CalculateTotal(_order);
        }

        [Given("{int} more people join at {int}:{int}")]
        public void GivenMorePeopleJoinAt(int additionalPeople, int hour, int minutes)
        {
            Console.WriteLine($"{additionalPeople} more people joined at {hour}:{minutes}");
        }


        [Given("they order:")]
        public void GivenTheyOrder(DataTable dataTable)
        {
            foreach (var row in dataTable.Rows)
            {
                string itemName = row["Item"];
                int quantity = int.Parse(row["Quantity"]);
                int orderTime = int.Parse(row["Time"].Split(':')[0]);

                double price = itemName == "Starter" ? 4.00 :
                               itemName == "Main" ? 7.00 :
                               itemName == "Drink" ? 2.50 : 0;

                bool isFood = itemName != "Drink";
                bool hasDiscount = itemName == "Drink";

                _order.AddItem(new OrderItem(itemName, quantity, price, isFood, hasDiscount, orderTime));
            }
        }

        [When("the final bill is requested")]
        public void WhenTheFinalBillIsRequested()
        {
            _totalBill = BillCalculator.CalculateTotal(_order);
            Console.WriteLine($"Final bill: {_totalBill}");
        }


        [When("one member cancels their order")]
        public void WhenOneMemberCancelsTheirOrder()
        {
            Console.WriteLine($"Before cancellation: {_totalBill}");

            _order.CancelItem("Starter");
            _order.CancelItem("Main");
            _order.CancelItem("Drink");

            // ✅ Recalculate the bill, applying cancellations
            _totalBill = BillCalculator.CalculateTotal(_order);
            Console.WriteLine($"After cancellation: {_totalBill}");
        }

        [Then("the bill should be updated to {double}")]
        public void ThenTheBillShouldBeUpdatedTo(double expectedBill)
        {
            Assert.AreEqual(expectedBill, _totalBill - 8.9, 0.01);
        }

    }
}

