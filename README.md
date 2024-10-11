# Przewidywanie Produkcji na Podstawie Wydajności Maszyny za pomocą Regresji Liniowej w C# (.NET)

---

## Wprowadzenie

Celem tego projektu jest zademonstrowanie, jak zaimplementować **prosty model uczenia maszynowego** w języku C# z wykorzystaniem technologii .NET. Skupimy się na **regresji liniowej** jako przykładzie uczenia nadzorowanego. Naszym zadaniem będzie przewidywanie dziennej produkcji na podstawie wydajności maszyny.

**Repozytorium GitHub:** [Machine-Learning-Linear-Regression-CSharp](https://github.com/TwojNickGitHub/Machine-Learning-Linear-Regression-CSharp)

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
      
         Σx_i * y_i = (70 * 140) + (75 * 150) + (80 * 160) + (85 * 170) + (90 * 180) = 9,800 + 11,250 + 12,800 + 14,450 + 16,200 = 64,500


      3. Suma kwadratów `x_i^2`:
      
         Σx_i^2 = 70^2 + 75^2 + 80^2 + 85^2 + 90^2 = 4,900 + 5,625 + 6,400 + 7,225 + 8,100 = 32,250


#### Krok 2: Obliczenie Współczynnika `a`

      Wzór:
      
         a = [n * Σx_i * y_i - Σx_i * Σy_i] / [n * Σx_i^2 - (Σx_i)^2]
      
      
      Podstawiamy obliczone wartości:
      
         a = [5 * 64,500 - 400 * 800] / [5 * 32,250 - 400^2]
      
      Obliczamy licznik:
      
         Licznik = (322,500) - (320,000) = 2,500


      Obliczamy mianownik:
      
         Mianownik = (161,250) - (160,000) = 1,250

