using System;

namespace SudokuCombinatorialEvolutionSolver
{
  internal static class Program
  {
    private static void Main(string[] args)
    {
      Console.WriteLine("Begin solving Sudoku using combinatorial evolution");
      Console.WriteLine("The Sudoku is:");

      var sudoku = Sudoku.Difficult;
      Console.WriteLine(sudoku.ToString());

      const int numOrganisms = 200;
      const int maxEpochs = 5000;
      const int maxRestarts = 40;
      Console.WriteLine($"Setting numOrganisms: {numOrganisms}");
      Console.WriteLine($"Setting maxEpochs: {maxEpochs}");
      Console.WriteLine($"Setting maxRestarts: {maxRestarts}");

      var solver = new SudokuSolver();
      var solvedSudoku = solver.Solve(sudoku, numOrganisms, maxEpochs, maxRestarts);

      Console.WriteLine("Best solution found:");
      Console.WriteLine(solvedSudoku.ToString());
      Console.WriteLine(solvedSudoku.Error == 0 ? "Success" : "Did not find optimal solution");
      Console.WriteLine("End Sudoku using combinatorial evolution");
    }
  }
}