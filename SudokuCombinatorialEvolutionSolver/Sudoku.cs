namespace SudokuCombinatorialEvolutionSolver
{
  public class Sudoku
  {
    private Sudoku(int[,] cellValues)
    {
      CellValues = cellValues;
    }

    public static Sudoku New(int[,] cellValues)
    {
      return new Sudoku(cellValues);
    }

    public int[,] CellValues { get; }

    public int Error
    {
      get
      {
        var err = 0;
        // assumes blocks are OK (one each 1-9)
        // rows error
        for (var i = 0; i < MatrixHelper.SIZE; ++i) // each row
        {
          var counts = new int[MatrixHelper.SIZE]; // [0] = count of 1s, [1] = count of 2s
          for (var j = 0; j < MatrixHelper.SIZE; ++j) // walk down column of curr row
          {
            var v = CellValues[i, j]; // 1 to 9
            ++counts[v - 1];
          }

          for (var k = 0; k < MatrixHelper.SIZE; ++k) // number missing 
          {
            if (counts[k] == 0)
              ++err;
          }
        } // each row

        // columns error
        for (var j = 0; j < MatrixHelper.SIZE; ++j) // each column
        {
          var counts = new int[MatrixHelper.SIZE]; // [0] = count of 1s, [1] = count of 2s
          for (var i = 0; i < MatrixHelper.SIZE; ++i) // walk down 
          {
            var v = CellValues[i, j]; // 1 to 9
            ++counts[v - 1]; // counts[0-8]
          }

          for (var k = 0; k < MatrixHelper.SIZE; ++k) // number missing in the column
          {
            if (counts[k] == 0)
              ++err;
          }
        } // each column

        return err;
      }
    }


    public static Sudoku CreateDifficult()
    {
      var problem = new[,]
      {
        {0, 0, 6, 2, 0, 0, 0, 8, 0},
        {0, 0, 8, 9, 7, 0, 0, 0, 0},
        {0, 0, 4, 8, 1, 0, 5, 0, 0},
        {0, 0, 0, 0, 6, 0, 0, 0, 2},
        {0, 7, 0, 0, 0, 0, 0, 3, 0},
        {6, 0, 0, 0, 5, 0, 0, 0, 0},
        {0, 0, 2, 0, 4, 7, 1, 0, 0},
        {0, 0, 3, 0, 2, 8, 4, 0, 0},
        {0, 5, 0, 0, 0, 1, 2, 0, 0}
      };

      return new Sudoku(problem);
    }
  }
}