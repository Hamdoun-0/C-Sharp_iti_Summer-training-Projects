using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;//For Regex , Confirm Pattern


namespace Mini_Inventory_System
{
    public class Functions
    {

        private string[] ProductNames;
        private double[] prices;
        private int[] quantities;
        private int count;
        private int MAX;

        public Functions(string[] ProductNames, double[] prices, int[] quantities, int count, int MAX)
        {
            this.ProductNames = ProductNames;
            this.prices = prices;
            this.quantities = quantities;
            this.count = count;
            this.MAX = MAX;
        }
        /*
        The @ before the Double quotes means:
        (Verbatim string)
        It tells C# to treat backslashes \ more literally as its backslash instead of typing \\

        ^ start
        [A_Za-z]  the pattern
        +         To allow entering more than one character
        $         Make the checker reach the end of input and don't stop in midway if matched
        */


        //Fucntion 1 (ADD)
        string ProductPattern = @"^[A-Za-z]+$";
        public void AddProduct()
        {
            bool isValid;
            if (count == MAX) { Console.WriteLine("ERROR the the inventory is full"); }
            else
            {
                Console.Write("Enter product name :");

                while (true)
                {
                    Console.Write("(foramt:[A-Z] only letters)\n");
                    string Name = Console.ReadLine();
                    isValid = Regex.IsMatch(Name, ProductPattern);
                    if (isValid) { ProductNames[count] = Name; break; }
                    else { Console.WriteLine("Invalid Name please enter ProductName again\n"); }
                }
                Console.Write("Enter product price\nnubmer must be greater than 0 \n");
                while (true)
                {

                    isValid = double.TryParse(Console.ReadLine(), out double ValidPrice);
                    if (isValid && ValidPrice > 0) { prices[count] = ValidPrice; break; }
                    else { Console.WriteLine("Invalid price please enter price again\n");
                        Console.WriteLine("number must be greater than 0\n");
                    }
                }
                Console.Write("Enter quantity\nquantity must be greater than 0:\n");
                while (true)
                {

                    isValid = int.TryParse(Console.ReadLine(), out int ValidQuantity);
                    if (isValid && ValidQuantity > 0) { quantities[count] = ValidQuantity; break; }
                    else { Console.WriteLine("Invalid qunatity please enter quantity again\n");
                        Console.WriteLine("quantity must be greater than 0\n"); }
                }

                count += 1;


                //recursive if user wants to enter another object
                Console.WriteLine("Do you want to enter another Product?");
                Console.WriteLine("1. Enter another Product\n2.Press any button to Return to the main menu");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1) { AddProduct(); }
            }



        }


        //FUCNTION 2 (Display)
        public void DisplayAllProducts()
        {
            if (count <= 0) { Console.WriteLine("No products in inventory"); return; }// return if inventory has no items
            Console.WriteLine("ProductName\tprice\tquantity");// Titles of the Inventory
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{this.ProductNames[i]}\t\t{this.prices[i]:F2}\t{this.quantities[i]}\t");
                if (this.prices[i] < 10) { Console.WriteLine("\t\tLow Price"); }
                Console.WriteLine("\n");
            }
        }

        //FUNCTION 3 (Search by name)
        public void SearchbyName()
        {
            bool flag = false;
            Console.WriteLine("Enter the Name of Product you want its details:");
            string Productname = Console.ReadLine();
            Console.WriteLine("ProductName\tprice\tquantity\t");
            for (int i = 0; i < count; i++)
            {
                if (Productname.ToLower() == this.ProductNames[i].ToLower()) //ToLower handles if user input captial or small letters
                {
                    Console.Write($"{this.ProductNames[i]}\t\t{this.prices[i]:F2}\t{this.quantities[i]}");
                    if (this.prices[i] < 10) { Console.WriteLine("\t\tLow Price"); }
                    flag = true;
                    break;
                }
            }
            if (flag == false) { Console.WriteLine("Product Not Found!!"); }

            Console.WriteLine("\nDo you want to Search for another Product?");
            Console.WriteLine("1. Search for another Product\n2.Press any button to Return to the main menu");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1) { SearchbyName(); }
        }
        //FUNCTION 4 Total
        public void GetTotalValue()
        {
            double PricesTotal = 0;
            int quantitiesTotal = 0;
            for (int i = 0; i < count; i++)
            {

                PricesTotal += this.prices[i];
                quantitiesTotal += this.quantities[i];
            }

            Console.WriteLine($"Total inventory Value : {PricesTotal},{quantitiesTotal},{count}");

        }
        //FUNCTION 5 get MAX &&& MIN  price
        public void max_min()
        {
            //loop to get max value
            int MaxIndex = 0;
            for(int i = 0;i < count; i++)
            {
                if(prices[i] >= prices[MaxIndex]) 
                {
                    MaxIndex = i;
                }
            }

            Console.WriteLine($"Index of highes value [{MaxIndex}], Name: {ProductNames[MaxIndex]}, Price: (${prices[MaxIndex]})");
            //loop to get min value
            int MinIndex = 0;
            for (int i = 0; i < count; i++)
            {
                if (prices[i] <= prices[MinIndex])
                {
                    MinIndex = i;
                }
            }

            Console.WriteLine($"Index of Lowest value [{MinIndex}], Name: {ProductNames[MinIndex]}, Price: (${prices[MinIndex]})");

        }
     }
   }
