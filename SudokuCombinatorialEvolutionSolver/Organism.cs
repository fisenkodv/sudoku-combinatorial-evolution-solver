namespace SudokuCombinatorialEvolutionSolver
{
  public class Organism
  {
    public OrganismType Type { get; }
    public int[,] Matrix { get; set; }
    public int Error { get; set; }
    public int Age { get; set; }

    public Organism(OrganismType type, int[,] m, int error, int age)
    {
      Type = type;
      Error = error;
      Age = age;
      Matrix = MatrixHelper.DuplicateMatrix(m);
    }
  }
}