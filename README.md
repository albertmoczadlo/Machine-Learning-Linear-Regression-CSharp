# Predicting Production Based on Machine Efficiency Using Linear Regression in C# (.NET)

---

## Introduction

The goal of this project is to demonstrate how to implement a **simple machine learning model** in C# using .NET technology. We will focus on **linear regression** as an example of supervised learning. Our task is to predict daily production based on machine efficiency.

**GitHub Repository:** [Machine-Learning-Linear-Regression-CSharp](https://github.com/albertmoczadlo/Machine-Learning-Linear-Regression-CSharp)

---

## Table of Contents

1. [Introduction to Supervised Learning](#1-introduction-to-supervised-learning)
2. [Linear Regression - Mathematical Explanation](#2-linear-regression---mathematical-explanation)
   - [Training Data](#training-data)
   - [Step-by-Step Calculations](#step-by-step-calculations)
3. [Implementation in C#](#3-implementation-in-c)
   - [Project Setup](#project-setup)
   - [Source Code](#source-code)
   - [Code Explanation](#code-explanation)
4. [Running the Application](#4-running-the-application)
5. [Summary](#5-summary)
6. [Additional Resources](#6-additional-resources)
7. [License](#license)
8. [Author](#author)
9. [Encouragement to Collaborate](#encouragement-to-collaborate)
10. [Files in the Repository](#files-in-the-repository)
11. [Contact](#contact)

---

## 1. Introduction to Supervised Learning

**Supervised learning** is a machine learning method where a model is trained on a dataset containing input features (**features**) with corresponding known outputs (**labels**). The model learns the relationship between the features and labels to predict outcomes for new data.

In our case, we want to predict daily **production** based on **machine efficiency**.

---

## 2. Linear Regression - Mathematical Explanation

Linear regression is a statistical technique used to model the relationship between a dependent variable `y` and an independent variable `x`. The linear regression model is defined as:

      y = a * x + b


Where:

- `y` – the predicted value (e.g., production).
- `x` – the input value (e.g., machine efficiency).
- `a` – the slope coefficient (**slope of the line**).
- `b` – the intercept (**point where the line crosses the y-axis**).

### Training Data

| Observation `i` | Machine Efficiency `x_i` (%) | Production `y_i` (units) |
|-----------------|------------------------------|--------------------------|
| 1               | 70                           | 140                      |
| 2               | 75                           | 150                      |
| 3               | 80                           | 160                      |
| 4               | 85                           | 170                      |
| 5               | 90                           | 180                      |

Number of observations: `n = 5`

### Step-by-Step Calculations

#### Step 1: Calculating Sums

1. **Sum of `x_i` and `y_i` values:**
      
         Σx_i = 70 + 75 + 80 + 85 + 90 = 400
         Σy_i = 140 + 150 + 160 + 170 + 180 = 800
      
      
2. **Sum of products `x_i * y_i`:**
   
         Σx_i * y_i = (70 * 140) + (75 * 150) + (80 * 160) + (85 * 170) + (90 * 180) 
                    = 9,800 + 11,250 + 12,800 + 14,450 + 16,200 
                    = 64,500



3. **Sum of squares `x_i^2`:**
      
         Σx_i^2 = 70^2 + 75^2 + 80^2 + 85^2 + 90^2 
                = 4,900 + 5,625 + 6,400 + 7,225 + 8,100 
                = 32,250



#### Step 2: Calculating Coefficient `a`

Formula:
      
         a = [n * Σx_i * y_i - Σx_i * Σy_i] / [n * Σx_i^2 - (Σx_i)^2]
      
      
      
      Substituting the calculated values:
      
         a = [5 * 64,500 - 400 * 800] / [5 * 32,250 - 400^2]
      
      
      Calculating the numerator:
      
         Licznik = (322,500) - (320,000) = 2,500
      
      Calculating the denominator:
      
         Denominator = (161,250) - (160,000) = 1,250


Calculating `a`:

      a = 2,500 / 1,250 = 2
      

#### Step 3: Calculating Intercept `b`

Formula:

      b = [Σy_i - a * Σx_i] / n



Substituting values:

     b = [800 - 2 * 400] / 5 = (800 - 800) / 5 = 0   



#### Step 4: Linear Regression Model

The resulting model:

       y = 2 * x + 0    


#### Step 5: Prediction

We predict the production for a machine efficiency of `x = 82%`:

      y = 2 * 82 + 0 = 164 jednostek


---

## 3. Implementation in C#

### Project Setup

1. **Create a new console project in Visual Studio:**

   - Open Visual Studio.
   - Select **File** > **New** > **Project**.
   - Choose **Console App (.NET Core)** or **Console App (.NET Framework)**.
   - Name the project, e.g., `Machine-Learning-Linear-Regression-CSharp`.

2. **File Structure:**

   - `Program.cs` – the main source code file.

### Source Code

Below is the full source code of the application, including calculations.

```csharp

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
                Console.WriteLine($"Predicted production: {predictedProduction} units");
            }
            else
            {
                Console.WriteLine("Invalid value.");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();

```


## Code Explanation

- **Calculations and Sum Display:**
  - In the for loop, we calculate the sums needed for the formulas and display individual values.
  - We display sums: $x_i$, $y_i$, $x_i * y_i$, $x_i^2$

- **Calculating Coefficients a and b:**
  - We calculate the numerator and denominator for a and display these values.
  - We calculate a and b using the formulas and display the results.

- **Prediction Function:**
  - We define a function that predicts production y based on machine efficiency x.

- **User Interaction:**
  - The program prompts the user to enter the machine efficiency.
  - Using the Predict function, we calculate and display the predicted production.
  - 
### Sample Output:

      Calculating sums:
      i=1: x=70, y=140, x*y=9800, x^2=4900
      i=2: x=75, y=150, x*y=11250, x^2=5625
      i=3: x=80, y=160, x*y=12800, x^2=6400
      i=4: x=85, y=170, x*y=14450, x^2=7225
      i=5: x=90, y=180, x*y=16200, x^2=8100
      
      Sum of x_i: 400
      Sum of y_i: 800
      Sum of x_i * y_i: 64500
      Sum of x_i^2: 32250
      
      Calculating coefficient a:
      Numerator: 2500
      Denominator: 1250
      a = 2500 / 1250 = 2
      
      Calculating intercept b:
      b = (800 - 2 * 400) / 5 = 0
      
      Linear regression model:
      y = 2x + 0
      
      Enter machine efficiency (%): 82
      Predicted production: 164 units
      
      Press any key to exit.
      

## 4. Running the Application


1. **Compilation:**
   - Ensure all files are saved.
   - Press Ctrl + Shift + B or select Build > Build Solution.

2. **Execution:**
   - Press F5 or click Start.
   - The console will display calculations and prompt for machine efficiency.

3. **Sample Input:**
   - Enter a value, e.g. `82`.
   - The program will display the predicted production along with previous calculations.
     

## 5. Summary


In this project, we demonstrated how to implement a simple linear regression model in C# using .NET technology, including detailed mathematical calculations. This helps to better understand how linear regression works mathematically and how it translates into code.


## 6. Additional Resources


### .NET Documentation:

- [Official .NET Documentation](https://docs.microsoft.com/dotnet/)

### Courses and Tutorials:

- [C# Fundamentals](https://learn.microsoft.com/dotnet/csharp/)
- [Introduction to Machine Learning](https://learn.microsoft.com/dotnet/machine-learning/)

### Books:

- *Machine Learning Using C# – Seyed M. M. Taheri
- *Statistics in Data Analysis Using C# – Marek Wójtowicz

## License

This project is released under the MIT License. You are free to modify and distribute it.

## Autor

[Albert Moczadło](https://github.com/albertmoczadlo)

## Kontakt

If you have any questions or need help, you can contact me through GitHub or email: [albertmoczadlo@gmail.com](mailto:albertmoczadlo@gmail.com)

## Files in the Repository:

- **Machine-Learning-Linear-Regression-CSharp/Program.cs – implementation including mathematical calculations.
- **README.md** – project documentation.

## Contact

If you have questions or need assistance, you can contact me via GitHub or email: albertmoczadlo@gmail.com

Thank you for your interest in the project!

