using Multi_thread_Matrix_console;
using System.Diagnostics;


Console.WriteLine("Podaj rozmiar macierzy: ");
int matrixSize = int.Parse(Console.ReadLine());

Console.WriteLine("Podaj ilość wątków: ");
int n = int.Parse(Console.ReadLine());

Matrix matrix = new Matrix(matrixSize);

Stopwatch stopwatch1 = new Stopwatch();
Stopwatch stopwatch2 = new Stopwatch();


stopwatch1.Start();
matrix.threadMultiply(n);
stopwatch2.Stop();
Console.WriteLine($"Thread- number of threads: {n} time: {stopwatch1.ElapsedMilliseconds} ms");
//matrix.displayAllMatrixes();


stopwatch2.Start();
matrix.parallerMultiply(n);
stopwatch2.Stop();
Console.WriteLine($"Parallel- number of threads: {n} time: {stopwatch2.ElapsedMilliseconds} ms");
//matrix.displayAllMatrixes();



