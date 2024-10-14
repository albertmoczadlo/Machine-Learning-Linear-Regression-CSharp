# Przewidywanie Produkcji na Podstawie Wydajności Maszyny za pomocą Regresji Liniowej w C# (.NET)

---

## Wprowadzenie

Celem tego projektu jest zademonstrowanie, jak zaimplementować **prosty model uczenia maszynowego** w języku C# z wykorzystaniem technologii .NET. Skupimy się na **regresji liniowej** jako przykładzie uczenia nadzorowanego. Naszym zadaniem będzie przewidywanie dziennej produkcji na podstawie wydajności maszyny.

**Repozytorium GitHub:** [Machine-Learning-Linear-Regression-CSharp](https://github.com/albertmoczadlo/Machine-Learning-Linear-Regression-CSharp)

---

## Spis Treści

1. [Wprowadzenie do Uczenia Nadzorowanego](#1-wprowadzenie-do-uczenia-nadzorowanego)
2. [Regresja Liniowa - Wyjaśnienie Matematyczne](#2-regresja-liniowa---wyjaśnienie-matematyczne)
   - [Dane Treningowe](#dane-treningowe)
   - [Obliczenia Krok po Kroku](#obliczenia-krok-po-kroku)
3. [Implementacja w C#](#3-implementacja-w-c)
   - [Przygotowanie Projektu](#przygotowanie-projektu)
   - [Kod Źródłowy](#kod-źródłowy)
   - [Wyjaśnienie Kodu](#wyjaśnienie-kodu)
4. [Uruchomienie Aplikacji](#4-uruchomienie-aplikacji)
5. [Podsumowanie](#5-podsumowanie)
6. [Materiały Dodatkowe](#6-materiały-dodatkowe)

---

## 1. Wprowadzenie do Uczenia Nadzorowanego

**Uczenie nadzorowane** to metoda uczenia maszynowego, w której model jest trenowany na zestawie danych wejściowych (**cechy**) z odpowiadającymi im znanymi wynikami (**etykiety**). Model uczy się zależności między cechami a etykietami, aby przewidywać wyniki dla nowych danych.

W naszym przypadku chcemy przewidzieć dzienną **produkcję** na podstawie **wydajności maszyny**.

---

## 2. Regresja Liniowa - Wyjaśnienie Matematyczne


Regresja liniowa to technika statystyczna służąca do modelowania zależności między zmienną zależną `y` a zmienną niezależną `x`. Model regresji liniowej ma postać:

      y = a * x + b

Gdzie:

- `y` – przewidywana wartość (np. produkcja).
- `x` – wartość wejściowa (np. wydajność maszyny).
- `a` – współczynnik kierunkowy (**nachylenie prostej**).
- `b` – wyraz wolny (**punkt przecięcia z osią** `y`).

### Dane Treningowe

| Numer obserwacji `i` | Wydajność maszyny `x_i` (%) | Produkcja `y_i` (jednostki) |
|----------------------|------------------------------|-----------------------------|
| 1                    | 70                           | 140                         |
| 2                    | 75                           | 150                         |
| 3                    | 80                           | 160                         |
| 4                    | 85                           | 170                         |
| 5                    | 90                           | 180                         |

Liczba obserwacji: `n = 5`

### Obliczenia Krok po Kroku

#### Krok 1: Obliczenie Sum

      1. Sumy wartości `x_i` i `y_i`:
      
         Σx_i = 70 + 75 + 80 + 85 + 90 = 400
         Σy_i = 140 + 150 + 160 + 170 + 180 = 800
      
      2. Suma iloczynów `x_i * y_i`:
      
         Σx_i * y_i = (70 * 140) + (75 * 150) + (80 * 160) + (85 * 170) + (90 * 180) 
                    = 9,800 + 11,250 + 12,800 + 14,450 + 16,200 
                    = 64,500


      3. Suma kwadratów `x_i^2`:
      
         Σx_i^2 = 70^2 + 75^2 + 80^2 + 85^2 + 90^2 
                = 4,900 + 5,625 + 6,400 + 7,225 + 8,100 
                = 32,250


#### Krok 2: Obliczenie Współczynnika `a`

      Wzór:
      
         a = [n * Σx_i * y_i - Σx_i * Σy_i] / [n * Σx_i^2 - (Σx_i)^2]
      
      
      Podstawiamy obliczone wartości:
      
         a = [5 * 64,500 - 400 * 800] / [5 * 32,250 - 400^2]
      
      Obliczamy licznik:
      
         Licznik = (322,500) - (320,000) = 2,500


      Obliczamy mianownik:
      
         Mianownik = (161,250) - (160,000) = 1,250

Obliczamy `a`:

      a = 2,500 / 1,250 = 2


#### Krok 3: Obliczenie Wyrazu Wolnego `b`

Wzór:

      b = [Σy_i - a * Σx_i] / n


Podstawiamy wartości:

     b = [800 - 2 * 400] / 5 = (800 - 800) / 5 = 0   


#### Krok 4: Model Regresji Liniowej

Otrzymany model:

    y = 2 * x + 0    

#### Krok 5: Predykcja


Przewidujemy produkcję dla wydajności maszyny `x = 82%`:

      y = 2 * 82 + 0 = 164 jednostek


---

## 3. Implementacja w C#


### Przygotowanie Projektu

1. **Utwórz nowy projekt konsolowy w Visual Studio:**

   - Otwórz Visual Studio.
   - Wybierz **Plik** > **Nowy** > **Projekt**.
   - Wybierz **Aplikacja konsolowa (.NET Core)** lub **Aplikacja konsolowa (.NET Framework)**.
   - Nazwij projekt, np. `Machine-Learning-Linear-Regression-CSharp`.

2. **Struktura Plików:**

   - `Program.cs` – główny plik z kodem źródłowym.

### Kod Źródłowy

Poniżej przedstawiamy pełny kod źródłowy aplikacji z uwzględnieniem obliczeń.

```csharp
         using System;
         
         namespace MachineLearningLinearRegressionCSharp
         {
             class Program
             {
                 static void Main(string[] args)
                 {
                     // Dane treningowe
                     double[] x = { 70, 75, 80, 85, 90 }; // Wydajność maszyny (%)
                     double[] y = { 140, 150, 160, 170, 180 }; // Produkcja (jednostki)
         
                     int n = x.Length;
         
                     // Obliczanie sum potrzebnych do wzorów
                     double sumX = 0;
                     double sumY = 0;
                     double sumXY = 0;
                     double sumX2 = 0;
         
                     Console.WriteLine("Obliczanie sum:");
         
                     for (int i = 0; i < n; i++)
                     {
                         sumX += x[i];
                         sumY += y[i];
                         sumXY += x[i] * y[i];
                         sumX2 += x[i] * x[i];
         
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
                         Console.WriteLine($"Przewidywana produkcja: {predictedProduction} jednostek");
                     }
                     else
                     {
                         Console.WriteLine("Nieprawidłowa wartość.");
                     }
         
                     Console.WriteLine("\nNaciśnij dowolny klawisz, aby zakończyć.");
                     Console.ReadKey();
                 }
             }
         }
```

## Wyjaśnienie Kodu

- **Obliczenia i Wyświetlanie Sum:**
  - W pętli `for` obliczamy sumy potrzebne do wzorów i wyświetlamy poszczególne wartości.
  - Wyświetlamy sumy: $x_i$, $y_i$, $x_i * y_i$, $x_i^2$

- **Obliczanie Współczynników a i b:**
  - Obliczamy licznik i mianownik dla $a$ i wyświetlamy te wartości.
  - Obliczamy $a$ i $b$ według wzorów i wyświetlamy wyniki.

- **Funkcja `Predict`:**
  - Definiujemy funkcję, która na podstawie wydajności maszyny $x$ przewiduje produkcję $y$.

- **Interakcja z Użytkownikiem:**
  - Program prosi użytkownika o podanie wydajności maszyny.
  - Używając funkcji `Predict`, obliczamy i wyświetlamy przewidywaną produkcję.

### Przykładowe Wyjście:

      Obliczanie sum:
      i=1: x=70, y=140, x*y=9800, x^2=4900
      i=2: x=75, y=150, x*y=11250, x^2=5625
      i=3: x=80, y=160, x*y=12800, x^2=6400
      i=4: x=85, y=170, x*y=14450, x^2=7225
      i=5: x=90, y=180, x*y=16200, x^2=8100
      
      Suma x_i: 400
      Suma y_i: 800
      Suma x_i * y_i: 64500
      Suma x_i^2: 32250
      
      Obliczenia współczynnika a:
      Licznik: 2500
      Mianownik: 1250
      a = 2500 / 1250 = 2
      
      Obliczenia wyrazu wolnego b:
      b = (800 - 2 * 400) / 5 = 0
      
      Model regresji liniowej:
      y = 2x + 0
      
      Podaj wydajność maszyny (%): 82
      Przewidywana produkcja: 164 jednostek
      
      Naciśnij dowolny klawisz, aby zakończyć.


## 4. Uruchomienie Aplikacji


1. **Kompilacja:**
   - Upewnij się, że wszystkie pliki są zapisane.
   - Naciśnij Ctrl + Shift + B lub wybierz Kompiluj > Kompiluj rozwiązanie.

2. **Uruchomienie:**
   - Naciśnij F5 lub kliknij Start.
   - W konsoli zostaną wyświetlone obliczenia i prośba o podanie wydajności maszyny.

3. **Przykładowe Wejście:**
   - Podaj wartość, np. `82`.
   - Program wyświetli przewidywaną produkcję wraz z wcześniejszymi obliczeniami.

## 5. Podsumowanie


W projekcie zademonstrowaliśmy, jak zaimplementować prosty model regresji liniowej w języku C# z wykorzystaniem technologii .NET, uwzględniając szczegółowe obliczenia matematyczne. Dzięki temu można lepiej zrozumieć, jak działa regresja liniowa od strony matematycznej i jak przekłada się to na kod.

## 6. Materiały Dodatkowe


### Dokumentacja .NET:
- [Oficjalna dokumentacja .NET](https://docs.microsoft.com/dotnet/)

### Kursy i Tutoriale:
- [Podstawy programowania w C#](https://learn.microsoft.com/dotnet/csharp/)
- [Wprowadzenie do uczenia maszynowego](https://learn.microsoft.com/dotnet/machine-learning/)

### Książki:
- *Uczenie Maszynowe z językiem C#* – Seyed M. M. Taheri
- *Statystyka w analizie danych z użyciem języka C#* – Marek Wójtowicz

## Licencja

Ten projekt jest udostępniony na licencji MIT. Możesz go dowolnie modyfikować i udostępniać.

## Autor

[Albert Moczadło](https://github.com/albertmoczadlo)

## Kontakt

Jeśli masz pytania lub potrzebujesz pomocy, możesz się ze mną skontaktować przez GitHub lub e-mail: [albertmoczadlo@gmail.com](mailto:albertmoczadlo@gmail.com)

## Pliki w Repozytorium:
- **Machine-Learning-Linear-Regression-CSharp/Program.cs** – implementacja z uwzględnieniem obliczeń matematycznych.
- **README.md** – dokumentacja projektu.
Dziękuję za zainteresowanie projektem!
