/*
* Name: Connor M Fitzgerald
* Course: CSCI 1250, Section 002
* Assignment: Lab 04, The Group Trip
* Date: October 7, 2026
* Description: Rebuilds the trip calculator with methods and arrays so it
* reports on a whole group instead of one person.
*/

System.Console.WriteLine("Welcome to the Trip Calculator!\n\n");

// Miles, MPG, Gas Cost, Total Gallons

System.Console.Write("How many miles will the round trip be? ");
double totalMiles = Convert.ToDouble(Console.ReadLine());
System.Console.Write("How many miles per gallon does your car get? ");
double milesPerGallon = Convert.ToDouble(Console.ReadLine());

System.Console.Write("How much will gas cost per gallon? $");
double gasCost = Convert.ToDouble(Console.ReadLine());

//People
string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };
const float TAX_RATE = .18f;

// Food Factors
System.Console.WriteLine("");
const int PIZZA_SLICES = 8;
int totalPeople = names.Length;
System.Console.Write("How many pizzas will you purchase? ");
int totalPizzas = Convert.ToInt32(Console.ReadLine());
System.Console.Write("How much does each pizza cost? $");
double pizzaCost = Convert.ToDouble(Console.ReadLine());

//New numbers
double fuelCost = FuelCost(totalMiles, milesPerGallon, gasCost);
double tripTotal = fuelCost+pizzaCost*totalPizzas;
double slicesEach = totalPizzas*PIZZA_SLICES/names.Length;
double costPerPerson = tripTotal/names.Length;
double totalHours = 0;
double totalTakeHomePay = 0;
double longest = 0;

//Final Section
System.Console.WriteLine("=== Part 1: The Trip ===");
System.Console.WriteLine($"Fuel cost: {fuelCost:C}");
System.Console.WriteLine($"Pizza cost: {pizzaCost:C}");
System.Console.WriteLine($"Trip total: {tripTotal:C}");

System.Console.WriteLine("\n=== Part 2: The Group ===");
System.Console.WriteLine($"People going: {totalPeople}");
System.Console.WriteLine($"Slices each: {slicesEach}");
System.Console.WriteLine($"Cost per person: {costPerPerson:C}");

System.Console.WriteLine("\n=== Part 3: Who Works How Long ===");
for (int i = 0; i < names.Length; i++)
{
    double takeHomePay = TakeHomePay(hoursWorked[i], hourlyRates[i], TAX_RATE);
    double takeHomePayPerHour = takeHomePay/hoursWorked[i];
    double hoursToCover = HoursToCover(costPerPerson, takeHomePayPerHour);
    totalHours = totalHours += hoursWorked[i];
    totalTakeHomePay = totalTakeHomePay += takeHomePay;
    longest = Math.Max(longest, hoursToCover);
    System.Console.WriteLine($"{names[i]}: takes home {takeHomePay:C} for {hoursWorked[i]} hours, {takeHomePayPerHour:C} per hour, must work {hoursToCover:F2}");
}

System.Console.WriteLine($"\nTotal hours worked: {totalHours:F2}");
System.Console.WriteLine($"Total take home pay: {totalTakeHomePay:C}");
System.Console.WriteLine($"Longest anyone must work {longest:F2}");

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
static double HoursToCover(double amountOwed, double takeHomePerHour)
{
    return amountOwed/takeHomePerHour;
}