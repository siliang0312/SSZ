namespace SSZ.Core.Aggregate.ProductionLine;

public class LineLevel:SmartEnum<LineLevel>
{
  public static readonly LineLevel Factory = new(nameof(Factory), 1);
  public static readonly LineLevel Department = new(nameof(Department), 2);
  public static readonly LineLevel WorkShop = new(nameof(WorkShop), 3);
  public static readonly LineLevel ProdutionLine = new(nameof(ProdutionLine), 4);

  public LineLevel(string name, int value) : base(name, value)
  {
  }
}
