using System;
using System.Linq;

public class MathOperations
{
    public static double Add(double a, double b)
    {
        return a + b;
    }

    public static double[] Add(double[] array1, double[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return array1.Zip(array2, (x, y) => x + y).ToArray();
    }

    public static double[,] Add(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions.");

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] + matrix2[i, j];
            }
        }

        return result;
    }

    public static double[,,] Add(double[,,] tensor1, double[,,] tensor2)
    {
        int dim1 = tensor1.GetLength(0);
        int dim2 = tensor1.GetLength(1);
        int dim3 = tensor1.GetLength(2);

        if (dim1 != tensor2.GetLength(0) || dim2 != tensor2.GetLength(1) || dim3 != tensor2.GetLength(2))
            throw new ArgumentException("Tensors must have the same dimensions.");

        double[,,] result = new double[dim1, dim2, dim3];

        for (int i = 0; i < dim1; i++)
        {
            for (int j = 0; j < dim2; j++)
            {
                for (int k = 0; k < dim3; k++)
                {
                    result[i, j, k] = tensor1[i, j, k] + tensor2[i, j, k];
                }
            }
        }

        return result;
    }

    public static double Subtract(double a, double b)
    {
        return a - b;
    }

    public static double[] Subtract(double[] array1, double[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return array1.Zip(array2, (x, y) => x - y).ToArray();
    }

    public static double[,] Subtract(double[,] matrix1, double[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
            throw new ArgumentException("Matrices must have the same dimensions.");

        double[,] result = new double[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static double Multiply(double a, double b)
    {
        return a * b;
    }

    public static double[] Multiply(double[] array1, double[] array2)
    {
        if (array1.Length != array2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return array1.Zip(array2, (x, y) => x * y).ToArray();
    }

    public static double[,] Multiply(double[,] matrix1, double[,] matrix2)
    {
        int rows1 = matrix1.GetLength(0);
        int cols1 = matrix1.GetLength(1);
        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        if (cols1 != rows2)
            throw new ArgumentException("Number of columns in the first matrix must match the number of rows in the second matrix.");

        double[,] result = new double[rows1, cols2];

        for (int i = 0; i < rows1; i++)
        {
            for (int j = 0; j < cols2; j++)
            {
                for (int k = 0; k < cols1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        return result;
    }
}

class Program
{
    static void Main()
    {
        double a = 5, b = 3;
        Console.WriteLine("Add numbers: " + MathOperations.Add(a, b));

        double[] array1 = { 1, 2, 3 };
        double[] array2 = { 4, 5, 6 };
        Console.WriteLine("Add arrays: [" + string.Join(", ", MathOperations.Add(array1, array2)) + "]");

        double[,] matrix1 = { { 1, 2 }, { 3, 4 } };
        double[,] matrix2 = { { 5, 6 }, { 7, 8 } };
        double[,] resultMatrix = MathOperations.Add(matrix1, matrix2);

        Console.WriteLine("Add matrices:");
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                Console.Write(resultMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
