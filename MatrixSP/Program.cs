namespace MatrixSP
{
    internal class Program
    {
        static async Task Main()
        {
            int[,] matrix1 = { { 1, 2 }, { 3, 4 }, { 5, 6 } };
            int[,] matrix2 = { { 1, 2, 3 }, { 4, 5, 6 } };
            int[,] result = await MultiplyMatricesAsync(matrix1, matrix2);
            PrintMatrix(result);
        }

        private static void PrintMatrix(int[,] matrix1)
        {
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    Console.WriteLine(matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static async Task<int[,]> MultiplyMatricesAsync(int[,] matrix1, int[,] matrix2)
        {
            int matrix1Rows = matrix1.GetLength(0);
            int matrix1Cols = matrix1.GetLength(1);
            int matrix2Rows = matrix2.GetLength(0);
            int matrix2Cols = matrix2.GetLength(1);

            if (matrix1Cols != matrix2Rows)
            {
                throw new Exception("...");
            }

            int[,] result = new int[matrix1Rows, matrix2Cols];
            await Task.Run(() =>
            {
                for (int i = 0; i < matrix1Rows; i++)
                {
                    for (int j = 0; j < matrix2Cols; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k < matrix1Cols; k++)
                        {
                            sum += matrix1[i, k] * matrix2[k, j];
                        }
                        result[i, j] = sum;
                    }
                }
            });
            return result;
        }
    }
}