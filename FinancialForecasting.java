public class FinancialForecasting {
    public static void main(String[] args) {

        // Initial investment amount
        double presentValue = 10000;

        // Annual growth rate (8% in decimal)
        double annualGrowthRate = 0.08;

        // Number of years for forecast
        int years = 5;

        // Recursive calculation of future value
        double futureValue = calculateFutureValue(presentValue, annualGrowthRate, years);
        System.out.println("Future Value after " + years + " years: " + futureValue);

        // Optimized future value using exponentiation by squaring
        double optimizedFV = presentValue * powerOptimized(1 + annualGrowthRate, years);
        System.out.println("Optimized Future Value: " + optimizedFV);
    }

    // Recursive method to calculate future value
    // FV = PV * (1 + r)^n using repeated multiplication
    public static double calculateFutureValue(double pv, double rate, int years) {
        if (years == 0)
            return pv;  
        return (1 + rate) * calculateFutureValue(pv, rate, years - 1);
    }

    // Optimized power function using exponentiation by squaring
    // Reduces time complexity from O(n) to O(log n)
    public static double powerOptimized(double base, int exp) {
        if (exp == 0)
            return 1;  
        if (exp % 2 == 0)
            return powerOptimized(base * base, exp / 2);
        else
            return base * powerOptimized(base, exp - 1);
    }
}