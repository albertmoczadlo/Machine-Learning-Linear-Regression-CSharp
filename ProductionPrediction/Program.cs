// Dane treningowe
double[] x = { 70, 75, 80, 85, 90 }; // Wydajnośc maszyny (%)
double[] y = { 140, 150, 160, 170, 180 }; // Produkcja (jednostki)

int n = x.Length;

// Obliczanie sum potrzebnych do wzorów
double sumX = 0;
double sumY = 0;
double sumX2 = 0;
double sumXY = 0;

Console.WriteLine("Obliczanie sum:");

for (int i = 0; i < n; i++)
{
    sumX += x[i];
    sumY += y[i];
    sumX2 += x[i] * x[i];
    sumXY += x[i] * y[i];

    Console.WriteLine($"i={i + 1}: x={x[i]}, y={y[i]}, x*y={x[i] * y[i]}, x^2={x[i] * x[i]}");
}

Console.WriteLine($"\nSuma x_i: {sumX}");
Console.WriteLine($"Suma y_i: {sumY}");
Console.WriteLine($"Suma x_i * y_i: {sumXY}");
Console.WriteLine($"Suma x_i^2: {sumX2}");

// Obliczanie współczynników a i b
double numeratorA = n * sumXY - sumX * sumY;
double denominatorA = n * sumX2 - sumX * sumX;
double a = numeratorA / denominatorA;

double b = (sumY - a * sumX) / n;

Console.WriteLine($"\nObliczenia współczynnika a:");
Console.WriteLine($"Licznik: {numeratorA}");
Console.WriteLine($"Mianownik: {denominatorA}");
Console.WriteLine($"a = {numeratorA} / {denominatorA} = {a}");

Console.WriteLine($"\nObliczenia wyrazu wolnego b:");
Console.WriteLine($"b = ({sumY} - {a} * {sumX}) / {n} = {b}");

// Wyświetlanie modelu regresji
Console.WriteLine($"\nModel regresji liniowej:");
Console.WriteLine($"y = {a}x + {b}");

// Funkcja predykcji
double Predict(double machineEfficiency)
{
    return a * machineEfficiency + b;
}

// Przewidywanie produkcji dla wydajności maszyny podanej przez użytkownika

Console.Write("\nPodaj wydajność maszyny (%): ");

if (double.TryParse(Console.ReadLine(), out double inputEfficiency))
{
    double predictedProduction = Predict(inputEfficiency);

    Console.WriteLine($"\nPrzewidywana produkcja: {predictedProduction} jednostek");
}
else
{
    Console.WriteLine("Nieprawidłowa wartość.");
}

Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć.");
Console.ReadKey();
