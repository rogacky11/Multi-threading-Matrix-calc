using Multi_thread_Matrix_console;
using System.Diagnostics;


Console.WriteLine("Podaj rozmiar macierzy: ");
int matrixSize = int.Parse(Console.ReadLine());

Console.WriteLine("Podaj ilość wątków: ");
int n = int.Parse(Console.ReadLine());

Matrix matrix = new Matrix(matrixSize);

int numberOfMeasurements = 10; 

double threadTotalTime = 0;
double parallelTotalTime = 0;

for (int i = 0; i < numberOfMeasurements; i++)
{
    Stopwatch stopwatch1 = Stopwatch.StartNew();
    matrix.threadMultiply(n);
    stopwatch1.Stop();
    threadTotalTime += stopwatch1.ElapsedMilliseconds;
}
double threadAverageTime = threadTotalTime / numberOfMeasurements;

Console.WriteLine($"ThreadMultiply - number of threads: {n} average time: {threadAverageTime} ms");

for (int i = 0; i < numberOfMeasurements; i++)
{
    Stopwatch stopwatch2 = Stopwatch.StartNew();
    matrix.parallerMultiply(n);
    stopwatch2.Stop();
    parallelTotalTime += stopwatch2.ElapsedMilliseconds;
}

double parallelAverageTime = parallelTotalTime / numberOfMeasurements;

Console.WriteLine($"ParallelMultiply - number of threads: {n} average time: {parallelAverageTime} ms");
    



