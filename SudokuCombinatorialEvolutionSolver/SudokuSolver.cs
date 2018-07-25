using System;

namespace SudokuCombinatorialEvolutionSolver
{
  public class SudokuSolver
  {
    private Random _rnd;

    public SudokuSolver()
    {
      _rnd = new Random();
    }

    public Sudoku Solve(
      Sudoku problem,
      int numOrganisms = 200,
      int maxEpochs = 5000,
      int maxRestarts = 40)
    {
      var err = int.MaxValue;
      var seed = 0;
      Sudoku best = null;
      var attempt = 0;
      while (err != 0 && attempt < maxRestarts)
      {
        Console.WriteLine("\n Seed = " + seed);
        _rnd = new Random(seed);
        best = SolveEvo(problem, numOrganisms, maxEpochs); // things, maxEpochs
        err = best.Error;
        ++seed;
        ++attempt;
      }

      return best;
    }

    private Sudoku SolveEvo(Sudoku problem, int numOrganisms, int maxEpochs)
    {
      // initialize combinatorial Organisms
      var numWorker = (int) (numOrganisms * 0.90);
      var numExplorer = numOrganisms - numWorker;
      var hive = new Organism[numOrganisms];

      var bestError = int.MaxValue;
      Sudoku bestSudoku = null;

      for (var i = 0; i < numOrganisms; ++i)
      {
        var organismType = i < numWorker
          ? OrganismType.Worker
          : OrganismType.Explorer;

        var randomSudoku = Sudoku.New(MatrixHelper.RandomMatrix(_rnd, problem.CellValues));
        var err = randomSudoku.Error;

        hive[i] = new Organism(organismType, randomSudoku.CellValues, err, 0);

        if (err >= bestError) continue;
        bestError = err;
        bestSudoku = Sudoku.New(MatrixHelper.DuplicateMatrix(randomSudoku.CellValues)); // by value
      }

      // main loop
      var epoch = 0;
      while (epoch < maxEpochs)
      {
        if (epoch % 1000 == 0)
        {
          Console.Write("epoch = " + epoch);
          Console.WriteLine(" best error = " + bestError);
        }

        if (bestError == 0) // solution found
          break;

        // process each organism
        for (var i = 0; i < numOrganisms; ++i)
        {
          if (hive[i].Type == OrganismType.Worker)
          {
            var neighbor = MatrixHelper.NeighborMatrix(_rnd, problem.CellValues, hive[i].Matrix);
            int err = Error(neighbor);

            double p = rnd.NextDouble();
            if (err < hive[i].error || p < 0.001) // better, or a mistake
            {
              hive[i].matrix = DuplicateMatrix(neighbor); // by value
              hive[i].error = err;
              if (err < hive[i].error) hive[i].age = 0;

              if (err < bestError)
              {
                bestError = err;
                bestSudoku = DuplicateMatrix(neighbor);
              }
            }
            else // neighbor is not better
            {
              hive[i].age++;
              if (hive[i].age > 1000) // die
              {
                int[][] m = RandomMatrix(problem);
                hive[i] = new Organism(0, m, Error(m), 0);
              }
            }
          } // worker
          else if (hive[i].type == 1) // explorer
          {
            int[][] rndMatrix = RandomMatrix(problem);
            hive[i].matrix = DuplicateMatrix(rndMatrix);
            hive[i].error = Error(rndMatrix);

            if (hive[i].error < bestError)
            {
              bestError = hive[i].error;
              bestSudoku = DuplicateMatrix(rndMatrix);
            }
          }
        } // each organism

        // merge best worker with best explorer into worst worker
        int bestwi = 0; // index of best worker
        int smallestWorkerError = hive[0].error;
        for (int i = 0; i < numWorker; ++i)
        {
          if (hive[i].error < smallestWorkerError)
          {
            smallestWorkerError = hive[i].error;
            bestwi = i;
          }
        }

        int bestei = numWorker; // index of best explorer
        int smallestExplorerError = hive[numWorker].error;
        for (int i = numWorker; i < numOrganisms; ++i)
        {
          if (hive[i].error < smallestExplorerError)
          {
            smallestExplorerError = hive[i].error;
            bestei = i;
          }
        }

        int worstwi = 0; // index of worst worker
        int largestWorkerError = hive[0].error;
        for (int i = 0; i < numWorker; ++i)
        {
          if (hive[i].error > largestWorkerError)
          {
            largestWorkerError = hive[i].error;
            worstwi = i;
          }
        }

        int[][] merged = MergeMatrices(hive[bestwi].matrix, hive[bestei].matrix);

        hive[worstwi] = new Organism(0, merged, Error(merged), 0);
        if (hive[worstwi].error < bestError)
        {
          bestError = hive[worstwi].error;
          bestSudoku = DuplicateMatrix(merged);
        }

        ++epoch;
      } // while

      return bestSudoku;
    }
  }
}