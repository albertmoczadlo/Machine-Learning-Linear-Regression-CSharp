
// Training data
double[] x = { 70, 75, 80, 85, 90 }; // Machine efficiency (%)
double[] y = { 140, 150, 160, 170, 180 }; // Production (units)

int n = x.Length;

// Calculating sums needed for the formulas
double sumX = 0;
double sumY = 0;
double sumXY = 0;
double sumX2 = 0;

Console.WriteLine("Calculating sums:");

for (int i = 0; i < n; i++)
{
    sumX += x[i];
    sumY += y[i];
    sumXY += x[i] * y[i];
    sumX2 += x[i] * x[i];

    Console.WriteLine($"i={i + 1}: x={x[i]}, y={y[i]}, x*y={x[i] * y[i]}, x^2={x[i] * x[i]}");
}

Console.WriteLine($"\nSum of x_i: {sumX}");
Console.WriteLine($"Sum of y_i: {sumY}");
Console.WriteLine($"Sum of x_i * y_i: {sumXY}");
Console.WriteLine($"Sum of x_i^2: {sumX2}");

// Calculating coefficients a and b
double numeratorA = n * sumXY - sumX * sumY;
double denominatorA = n * sumX2 - sumX * sumX;
double a = numeratorA / denominatorA;

double b = (sumY - a * sumX) / n;

Console.WriteLine($"\nCalculating coefficient a:");
Console.WriteLine($"Numerator: {numeratorA}");
Console.WriteLine($"Denominator: {denominatorA}");
Console.WriteLine($"a = {numeratorA} / {denominatorA} = {a}");

Console.WriteLine($"\nCalculating intercept b:");
Console.WriteLine($"b = ({sumY} - {a} * {sumX}) / {n} = {b}");

// Displaying the regression model
Console.WriteLine($"\nLinear regression model:");
Console.WriteLine($"y = {a}x + {b}");

// Prediction function
double Predict(double machineEfficiency)
{
    return a * machineEfficiency + b;
}

// Predicting production for user-provided machine efficiency
Console.Write("\nEnter machine efficiency (%): ");

if (double.TryParse(Console.ReadLine(), out double inputEfficiency))
{
    double predictedProduction = Predict(inputEfficiency);
    Console.WriteLine($"\nPredicted production: {predictedProduction} units");
}
else
{
    Console.WriteLine("Invalid value.");
}

Console.WriteLine("\nPress any key to exit.");
Console.ReadKey();

