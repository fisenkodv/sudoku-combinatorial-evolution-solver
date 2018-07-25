namespace SudokuCombinatorialEvolutionSolver
{
  public enum OrganismType
  {
    Worker,
    Explorer
  }

  public class Organism
  {
    public OrganismType Type { get; }
    public int[,] Matrix { get; }
    public int Error { get; }
    public int Age { get; }

    public Organism(OrganismType type, int[,] m, int error, int age)
    {
      Type = type;
      Error = error;
      Age = age;
      Matrix = MatrixHelper.DuplicateMatrix(m);
    }
  }
}