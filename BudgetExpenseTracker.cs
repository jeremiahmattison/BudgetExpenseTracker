/* Begin App: Display welcome message, create dictionary to store expenses
create a menu with options to add expenses, see total expenses, see them by category
create user input prompts for expenses
create user input prompts for category
add the expense to the list
separate them by category
display grouped category
exit application */

using System;
using System.Collections.Generic;
namespace BudgetExpenseTracker
{
  class Program
    {
        // create dictionary to store expenses
        static Dictionary<string, List<double>> expenses = new Dictionary<string, List<double>>();

        static void Main(string[] args)
        {
        Console.WriteLine("Budget/Expense Tracker");
        DisplayMenu();
        }
        static void DisplayMenu()
        {
            while  (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View Total Expense");
                Console.WriteLine("3. View Expense By Category");
                Console.WriteLine("4. Exit");

                Console.Write("\nEnter your choice number: ");
                // Ensure that user enters a number
                int choice; if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddExpense();
                        break;
                    case 2: 
                        ViewTotalExpenses();
                        break;
                    case 3: 
                        ViewExpenseByCategory();
                        break;
                    case 4: 
                        Program.Exit();
                        break;
                    default: 
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Create methods for the above listed cases to handle user input

        // View Add Expense Method
        static void AddExpense()
        {
            Console.Write("\nEnter expense amount: ");
            double amount = double.Parse(Console.ReadLine());

            Console.Write("Enter expense category: ");
            string category = Console.ReadLine();

            if (expenses.ContainsKey(category))
            {
                expenses[category].Add(amount);
            }
            else
            {
                expenses.Add(category, new List<double> {amount});
            }

            Console.WriteLine("Expense successfully added.");
        }

        // View Total Expenses Method
        static void ViewTotalExpenses()
        {
            double total = 0;
            
            // iterating over each category in expenses
            foreach (var catergoryExpenses in expenses.Values)
            {
                // iterating over each expense amount in the current category
                foreach (var expenseAmount in catergoryExpenses)
                {
                    // adding current expense amount to total
                    total += expenseAmount;
                }
            }
            // Display total expenses to user
            Console.WriteLine($"\nTotal Expenses: ${total}");
        }

        // View Expenses By  Category Method
        static void ViewExpenseByCategory()
        {
            foreach (var category in expenses.Keys)
            {
                // Display the category name
                Console.WriteLine($"\nExpenses for {category}:");

                // Iterate over each expense amount in current category
                foreach (var expenseAmount in expenses[category])
                {
                    // Display each expense amount
                    Console.WriteLine($"- ${expenseAmount}");
                }
            }
        }
    }
}