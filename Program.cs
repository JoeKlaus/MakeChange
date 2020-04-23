using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeChange
{
    class Program
    {
        public static void Main(string[] args)
        {

            double purchaseAmount = GetAmount("Purchase Amount: ");

            double paymentAmount = GetAmount("Payment Amount: ");

            do
            {
                if (purchaseAmount > paymentAmount)
                {
                    Console.WriteLine("Insufficient Funds");
                    purchaseAmount = GetAmount("Purchase Amount: ");
                    paymentAmount = GetAmount("Payment Amount: ");
                }
            } while (purchaseAmount > paymentAmount); // end while

            if (paymentAmount == purchaseAmount)
            {
                Console.WriteLine("Payment Processed");
            }
            else if (purchaseAmount < paymentAmount)
            {
                double changeDue = ComputeChange(purchaseAmount, paymentAmount);
                int twenties = 20;
                changeDue = CalculateDenomination(changeDue, twenties, twenties, "Twenties");

                int tens = 10;
                changeDue = CalculateDenomination(changeDue, tens, tens, "Tens");

                int fives = 5;
                changeDue = CalculateDenomination(changeDue, fives, fives, "Fives");

                int ones = 1;
                changeDue = CalculateDenomination(changeDue, ones, ones, "Ones");

                double quarters = 0.25;
                changeDue = CalculateDenomination(changeDue, quarters, quarters, "Quarters");

                double dimes = 0.10;
                changeDue = CalculateDenomination(changeDue, dimes, dimes, "Dimes");

                double nickels = 0.05;
                changeDue = CalculateDenomination(changeDue, nickels, nickels, "Nickels");

                double pennies = 0.01;
                changeDue = CalculateDenomination(changeDue, pennies, pennies, "Pennies");
            }
        } // end Main ()

        static double GetAmount(string prompt)
        {
            double amount;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    amount = double.Parse(Console.ReadLine());
                    if (amount > 0)
                    {
                        break;
                    }

                    if (amount <= 0)
                    {
                        Console.WriteLine("Invalid Amount");
                        amount = GetAmount("Purchase Amount: ");
                        break;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("That's Not a Number.");
                    Console.WriteLine("Enter a NUMBER.");
                }
            }
            return amount;
        }

        static double ComputeChange(double purchaseAmount, double paymentAmount)
        {
            double changeDue = (paymentAmount - purchaseAmount);
            Console.WriteLine($"Change Due: ${changeDue}");
            return changeDue += 0.000001;
        }

        static double CalculateDenomination(double changeDue, double denomination, double value, string prompt)
        {
            denomination = (int)(changeDue / denomination);
            if (denomination != 0)
            {
                Console.WriteLine(prompt + ": " + denomination);
            }
            changeDue %= value;
            return changeDue;
        }
    }
}


