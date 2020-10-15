using NodeNetwork.ViewModels;
using NoiseNotIncluded.Nodes.Combiners;

namespace NoiseNotIncluded.Yaml.Noise.Nodes
{
  public class Combiner : NoiseBase
  {
	public enum CombinerType
	{
	  _UNSET_,
	  Add,
	  Max,
	  Min,
	  Multiply,
	  Power
	}

	public CombinerType combineType { get; set; }


    public override NodeViewModel CreateModel()
    {
      CombinerNode result = null;
      switch (combineType)
      {
        case CombinerType.Add:
          result = new AddNode();
          break;
        case CombinerType.Max:
          result = new MaxNode();
          break;
        case CombinerType.Min:
          result = new MinNode();
          break;
        case CombinerType.Multiply:
          result = new MultiplyNode();
          break;
        case CombinerType.Power:
          result = new PowerNode();
          break;
      }

      result.Name = name;
      result.Position = pos;

      return result;
    }
  }
}
