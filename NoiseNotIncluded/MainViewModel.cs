
using DynamicData;
using NodeNetwork;
using NodeNetwork.Toolkit;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using NoiseNotIncluded.Nodes.Combiners;
using NoiseNotIncluded.Nodes.Filters;
using NoiseNotIncluded.Nodes.Modifiers;
using NoiseNotIncluded.Nodes.Other;
using NoiseNotIncluded.Nodes.Primitives;
using NoiseNotIncluded.Nodes.Selectors;
using NoiseNotIncluded.Nodes.Transformers;
using ReactiveUI;
using System.Linq;

namespace NoiseNotIncluded
{
  public class MainViewModel : ReactiveObject
  {
    static MainViewModel()
    {
      Splat.Locator.CurrentMutable.Register(() => new MainWindow(), typeof(IViewFor<MainViewModel>));
    }

    public NodeListViewModel ListViewModel { get; } = new NodeListViewModel();
    public NetworkViewModel NetworkViewModel { get; } = new NetworkViewModel();


    public MainViewModel()
    {
      NetworkViewModel.Validator = network =>
      {
        bool containsLoops = GraphAlgorithms.FindLoops(network).Any();
        if (containsLoops)
        {
          return new NetworkValidationResult(false, false, new ErrorMessageViewModel("Network contains loops!"));
        }

        return new NetworkValidationResult(true, true, null);
      };

      ListViewModel.AddNodeType(() => new AddNode());
      ListViewModel.AddNodeType(() => new MaxNode());
      ListViewModel.AddNodeType(() => new MinNode());
      ListViewModel.AddNodeType(() => new MultiplyNode());
      ListViewModel.AddNodeType(() => new PowerNode());
      
      ListViewModel.AddNodeType(() => new BillowNode());
      ListViewModel.AddNodeType(() => new HeterogeneousMultiFractalNode());
      ListViewModel.AddNodeType(() => new HybridMultiFractalNode());
      ListViewModel.AddNodeType(() => new MultiFractalNode());
      ListViewModel.AddNodeType(() => new PipeNode());
      ListViewModel.AddNodeType(() => new RidgedMultiFractalNode());
      ListViewModel.AddNodeType(() => new SinFractalNode());
      ListViewModel.AddNodeType(() => new SumFractalNode());
      ListViewModel.AddNodeType(() => new VoronoiNode());
      
      ListViewModel.AddNodeType(() => new AbsNode());
      ListViewModel.AddNodeType(() => new ClampNode());
      ListViewModel.AddNodeType(() => new CurveNode());
      ListViewModel.AddNodeType(() => new ExponentNode());
      ListViewModel.AddNodeType(() => new InvertNode());
      ListViewModel.AddNodeType(() => new Scale2DNode());
      ListViewModel.AddNodeType(() => new ScaleBiasNode());
      ListViewModel.AddNodeType(() => new TerraceNode());

      ListViewModel.AddNodeType(() => new BevinsGradientNode());
      ListViewModel.AddNodeType(() => new BevinsValueNode());
      ListViewModel.AddNodeType(() => new ConstantNode());
      ListViewModel.AddNodeType(() => new CylindersNode());
      ListViewModel.AddNodeType(() => new ImprovedPerlinNode());
      ListViewModel.AddNodeType(() => new SimplexPerlinNode());
      ListViewModel.AddNodeType(() => new SpheresNode());
      
      ListViewModel.AddNodeType(() => new BlendNode());
      ListViewModel.AddNodeType(() => new SelectNode());
      
      ListViewModel.AddNodeType(() => new DisplaceNode());
      ListViewModel.AddNodeType(() => new RotatePointNode());
      ListViewModel.AddNodeType(() => new TurbulenceNode());
      
      ListViewModel.AddNodeType(() => new ControlPointNode());
      ListViewModel.AddNodeType(() => new FloatNode());

      //ListViewModel.AddNodeType(() => new TerminatorNode());

      var terminatorNode = new TerminatorNode();
      terminatorNode.CanBeRemovedByUser = false;
      NetworkViewModel.Nodes.Add(terminatorNode);

    }
  }
}
