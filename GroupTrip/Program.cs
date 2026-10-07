/*
* Name: Connor M Fitzgerald
* Course: CSCI 1250, Section 002
* Assignment: Lab 04, The Group Trip
* Date: October 7, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

System.Console.WriteLine("Welcome to the Trip Calculator!"); //Title of Program

// Miles, MPG, Gas Cost, Total Gallons
System.Console.WriteLine(""); //Each of these is just for visual organization - separates sections

System.Console.Write("How many miles will the round trip be? ");
double totalMiles = Convert.ToDouble(Console.ReadLine()); //Double because the value may contain a decimal but idk what convert to use for float + Double is more precise than float (32vs64bit)

System.Console.Write("How many miles per gallon does your car get? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

System.Console.Write("How much will gas cost per gallon? $");
double gasCost = Convert.ToDouble(Console.ReadLine()); //Decimal because involves money

double fuelCost = FuelCost(totalMiles, milesPerGallon, gasCost);

// Food Factors
System.Console.WriteLine("");
const int PIZZA_SLICES = 8; //const is required because this value is constant

System.Console.Write("How many people are going on this trip? ");
int totalPeople = Convert.ToInt32(Console.ReadLine()); //Int because value should never include a decimal

System.Console.Write("How many pizzas will you purchase? ");
int totalPizzas = Convert.ToInt32(Console.ReadLine());

System.Console.Write("How much does each pizza cost? $");
double pizzaCost = Convert.ToDouble(Console.ReadLine());

//Paycheck
System.Console.WriteLine("");
const float TAX_RATE = .18f;

System.Console.Write("How many hours did you work this week? ");
double hoursWorked = Convert.ToDouble(Console.ReadLine());

System.Console.Write("How much money do you make an hour? $");
double wageHourly = Convert.ToDouble(Console.ReadLine());
System.Console.WriteLine("");

TakeHomePay(hoursWorked, wageHourly, TAX_RATE);

//Final Section
System.Console.WriteLine("=== Part 1: The Trip ===");
System.Console.WriteLine($"Fuel cost: {fuelCost:C}");
System.Console.WriteLine($"Pizza cost: {pizzaCost:C}");
System.Console.WriteLine($"Trip total: {fuelCost+pizzaCost:C}");

// LAB 4

static double FuelCost(double miles, double milesPerGallon, double pricePerGallon)
{
    double totalGallons = miles/milesPerGallon;  
    return totalGallons * pricePerGallon;
}
static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours*hourlyRate;
    double takeHomePay = grossPay-(grossPay*taxRate);
    return takeHomePay;

}