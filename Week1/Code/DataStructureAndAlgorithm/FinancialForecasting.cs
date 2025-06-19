using System;

public class FinancialForecasting
{
    public static void Main(string[] args)
    {
        // Initial investment amount
        double presentValue = 10000;

        // Annual growth rate (8% in decimal)
        double annualGrowthRate = 0.08;

        // Number of years for forecast
        int years = 5;

        // Recursive calculation of future value
        double futureValue = CalculateFutureValue(presentValue, annualGrowthRate, years);
        Console.WriteLine($"Future Value after {years} years: {futureValue}");

        // Optimized future value using exponentiation by squaring
        double optimizedFV = presentValue * PowerOptimized(1 + annualGrowthRate, years);
        Console.WriteLine($"Optimized Future Value: {optimizedFV}");
    }

    // Recursive method to calculate future value
    public static double CalculateFutureValue(double pv, double rate, int years)
    {
        if (years == 0)
            return pv;
        return (1 + rate) * CalculateFutureValue(pv, rate, years - 1);
    }

    // Optimized power function using exponentiation by squaring
    public static double PowerOptimized(double baseVal, int exp)
    {
        if (exp == 0)
            return 1;
        if (exp % 2 == 0)
            return PowerOptimized(baseVal * baseVal, exp / 2);
        else
            return baseVal * PowerOptimized(baseVal, exp - 1);
    }
}
