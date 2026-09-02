using System;
using System.Collections.Generic;
using Mini_Inventory_System;

namespace Mini_Inventory_System
{

    class Program
    {
        static void Main(string[] args)
        {


            const int MAX = 10;

            string[] ProductNames = new string[MAX];
            double[] prices = new double[MAX];
            int[] quantities = new int[MAX];

            int count = 0;

            Functions fun = new Functions(ProductNames, prices,quantities,count,MAX);

            int choice;
            

            do
            {
                
                Console.WriteLine("\tINVENTORY MANGAER\n");
                Console.WriteLine("1. Add Product\n2. Display All Products\n3. Search by Name\n4. Show Total Value\n5. Most & Least Exspensive\n6. Exit");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        fun.AddProduct();
                        break;
                    case 2:
                        fun.DisplayAllProducts();
                        break;
                    case 3:
                        fun.SearchbyName();
                        break;
                    case 4:
                        fun.GetTotalValue();
                        break;
                    case 5:
                        fun.max_min();
                        break;
                    default:
                        break;
                }
            } while (choice != 6);
           
            






        }
    }

}