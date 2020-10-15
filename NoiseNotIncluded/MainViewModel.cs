using DynamicData;
using NodeNetwork;
using NodeNetwork.Toolkit;
using NodeNetwork.Toolkit.NodeList;
using NodeNetwork.ViewModels;
using NodeNetworkExtensions.ViewModels;
using NoiseNotIncluded.Nodes;
using NoiseNotIncluded.Nodes.Combiners;
using NoiseNotIncluded.Nodes.Filters;
using NoiseNotIncluded.Nodes.Modifiers;
using NoiseNotIncluded.Nodes.Other;
using NoiseNotIncluded.Nodes.Primitives;
using NoiseNotIncluded.Nodes.Selectors;
using NoiseNotIncluded.Nodes.Transformers;
using NoiseNotIncluded.Util;
using NoiseNotIncluded.Yaml;
using NoiseNotIncluded.Yaml.Noise.Nodes;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using YamlDotNet.Serialization;

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
    public NoiseFile FileData { get; set; } = new NoiseFile();

    public string CurrentFileName { get; set; }
    public bool HasChangesSinceLastSaved { get; set; }

    private static readonly List<Func<NodeViewModel>> Factories = new List<Func<NodeViewModel>> {
        () => new AddNode(),
        () => new MaxNode(),
        () => new MinNode(),
        () => new MultiplyNode(),
        () => new PowerNode(),

        () => new BillowNode(),
        () => new HeterogeneousMultiFractalNode(),
        () => new HybridMultiFractalNode(),
        () => new MultiFractalNode(),
        () => new PipeNode(),
        () => new RidgedMultiFractalNode(),
        () => new SinFractalNode(),
        () => new SumFractalNode(),
        () => new VoronoiNode(),

        () => new AbsNode(),
        () => new ClampNode(),
        //() => new CurveNode(), // TODO
        () => new ExponentNode(),
        () => new InvertNode(),
        () => new Scale2DNode(),
        () => new ScaleBiasNode(),
        //() => new TerraceNode(), // TODO

        () => new BevinsGradientNode(),
        () => new BevinsValueNode(),
        () => new ConstantNode(),
        () => new CylindersNode(),
        () => new ImprovedPerlinNode(),
        () => new SimplexPerlinNode(),
        () => new SpheresNode(),

        // TODO
        //() => new BlendNode(),
        //() => new SelectNode(),

        () => new DisplaceNode(),
        () => new RotatePointNode(),
        // Turbulence crashes in ONI
        // https://forums.kleientertainment.com/klei-bug-tracker/oni/using-turbulence-in-biome-noise-file-crashes-r25837/
        // () => new TurbulenceNode(),

        // TODO
        //() => new ControlPointNode(),
        //() => new FloatNode(),
      };

    public MainViewModel()
    {
      NetworkViewModel.Validator = network =>
      {
        bool containsLoops = GraphAlgorithms.FindLoops(network).Any();
        if (containsLoops)
        {
          return new NetworkValidationResult(false, false, new ErrorMessageViewModel("Network contains loops!"));
        }

        if (!IsAllNodeNamesUnique())
        {
          return new NetworkValidationResult(false, false, new ErrorMessageViewModel("Nodes contain duplicate names!"));
        }

        return new NetworkValidationResult(true, true, null);
      };

      Factories.ForEach(ListViewModel.AddNodeType);
    }

    bool IsAllNodeNamesUnique()
    {
      HashSet<string> names = new HashSet<string>();
      foreach (var node in NetworkViewModel.Nodes.Items)
      {
        if (!names.Add(node.Name)) return false;
      }
      return true;
    }

    public void AddConnection(NodeInputViewModel input, NodeOutputViewModel output)
    {
      NetworkViewModel.Connections.Add(new ConnectionViewModel(NetworkViewModel, input, output));
    }

    public void New()
    {
      NetworkViewModel.Nodes.Clear();
      NetworkViewModel.Nodes.Add(new TerminatorNode() { Position = new Point(256, 128) });

      CurrentFileName = null;

      FileData = new NoiseFile();
      Init();
    }

    void Init()
    {
      HasChangesSinceLastSaved = false;
      SyncZoom();
    }

    public void SyncZoom()
    {
      foreach (NodeViewModel node in Enumerable.Concat(ListViewModel.Nodes.Items, NetworkViewModel.Nodes.Items))
      {
        var outputPreview = node.Outputs.Items.First().Editor as OutputPreviewModel;
        if (outputPreview != null) outputPreview.Zoom = FileData.settings.zoom;
      }
    }

    public void LoadFile(string filename)
    {
      // Load the file
      var yaml = new DeserializerBuilder().Build();
      string rawYaml = File.ReadAllText(filename);
      NoiseFile noise = FileData = yaml.Deserialize<NoiseFile>(rawYaml);

      // Convert nodes in file to editor nodes
      Dictionary<string, NodeViewModel> primitives = noise.primitives.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> combiners = noise.combiners.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> filters = noise.filters.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> modifiers = noise.modifiers.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      //Dictionary<string, NodeViewModel> selectors = noise.selectors.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      Dictionary<string, NodeViewModel> transformers = noise.transformers.ToDictionary(x => x.Key, x => x.Value.CreateModel());

      //Dictionary<string, NodeViewModel> controlPoints = noise.controlpoints.ToDictionary(x => x.Key, x => x.Value.CreateModel());
      //Dictionary<string, NodeViewModel> floats = noise.floats.ToDictionary(x => x.Key, x => x.Value.CreateModel());

      Dictionary<Link.Type, Dictionary<string, NodeViewModel>> typeMap = new Dictionary<Link.Type, Dictionary<string, NodeViewModel>>{
        { Link.Type.Primitive, primitives },
        { Link.Type.Combiner, combiners },
        { Link.Type.Filter, filters },
        { Link.Type.Modifier, modifiers },
        //{ Link.Type.Selector, selectors },
        { Link.Type.Transformer, transformers },
        //{ Link.Type.ControlPoints, controlPoints },
        //{ Link.Type.FloatPoints, floats }
      };

      // Add the nodes to the graph
      NetworkViewModel.Nodes.Clear();

      NetworkViewModel.Nodes.AddRange(primitives.Values);
      NetworkViewModel.Nodes.AddRange(combiners.Values);
      NetworkViewModel.Nodes.AddRange(filters.Values);
      NetworkViewModel.Nodes.AddRange(modifiers.Values);
      //NetworkViewModel.Nodes.AddRange(selectors.Values);
      NetworkViewModel.Nodes.AddRange(transformers.Values);
      //NetworkViewModel.Nodes.AddRange(controlPoints.Values);
      //NetworkViewModel.Nodes.AddRange(floats.Values);

      TerminatorNode terminatorNode = new TerminatorNode();
      NetworkViewModel.Nodes.Add(terminatorNode);

      // Connect the graph using links
      foreach (NodeLink link in noise.links)
      {
        NodeOutputViewModel source0 = link.source0 != null ? typeMap[link.source0.type][link.source0.name].Outputs.Items.First() : null;
        NodeOutputViewModel source1 = link.source1 != null ? typeMap[link.source1.type][link.source1.name].Outputs.Items.First() : null;
        NodeOutputViewModel source2 = link.source2 != null ? typeMap[link.source2.type][link.source2.name].Outputs.Items.First() : null;
        NodeOutputViewModel source3 = link.source3 != null ? typeMap[link.source3.type][link.source3.name].Outputs.Items.First() : null;

        switch (link.target.type)
        {
          case Link.Type.Filter:
            var filter = filters[link.target.name] as FilterNode;
            AddConnection(filter.NodeInput, source0);
            break;
          case Link.Type.Transformer:
            var transformer = transformers[link.target.name] as TransformerNode;
            AddConnection(transformer.SelectNode, source0);
            AddConnection(transformer.XNode, source1);
            AddConnection(transformer.YNode, source2);
            AddConnection(transformer.ZNode, source3);
            break;
          case Link.Type.Selector:
            // TODO
            break;
          case Link.Type.Modifier:
            var modifier = modifiers[link.target.name] as ModifierNode;
            AddConnection(modifier.NodeInput, source0);
            break;
          case Link.Type.Combiner:
            var combiner = combiners[link.target.name] as CombinerNode;
            AddConnection(combiner.LeftInput, source0);
            AddConnection(combiner.RightInput, source1);
            break;
          case Link.Type.Terminator:
            AddConnection(terminatorNode.NodeInput, source0);

            NodeViewModel previousNode = typeMap[link.source0.type][link.source0.name];
            terminatorNode.Position = new Point(previousNode.Position.X + 256, previousNode.Position.Y);
            break;
        }
      }

      CurrentFileName = filename;
      Init();
    }

    void SerializeNodes()
    {
      foreach (NodeViewModel node in NetworkViewModel.Nodes.Items)
      {
        NoiseBase yamlNode = (node as NodeWithPreview)?.GetYamlNode();
        if (yamlNode == null) continue;

        switch (yamlNode)
        {
          case Combiner combiner:
            FileData.combiners.Add(combiner.name, combiner);
            break;
          case ControlPointList cpl:
            FileData.controlpoints.Add(cpl.name, cpl);
            break;
          case Filter filter:
            FileData.filters.Add(filter.name, filter);
            break;
          case FloatList floats:
            FileData.floats.Add(floats.name, floats);
            break;
          case Modifier modifier:
            FileData.modifiers.Add(modifier.name, modifier);
            break;
          case Primitive primitive:
            FileData.primitives.Add(primitive.name, primitive);
            break;
          case Selector selector:
            FileData.selectors.Add(selector.name, selector);
            break;
          case Transformer transformer:
            FileData.transformers.Add(transformer.name, transformer);
            break;
        }
      }
    }

    void SerializeConnections()
    {
      Dictionary<Link.Type, Dictionary<string, NodeLink>> targetConnections = new Dictionary<Link.Type, Dictionary<string, NodeLink>>();
      foreach (ConnectionViewModel conn in NetworkViewModel.Connections.Items)
      {
        var srcNode = conn.Output.Parent as NodeWithPreview;

        var targetNode = conn.Input.Parent as NodeWithPreview;
        NodeLink nodeLink = targetConnections.GetOrCreate(targetNode.NodeType).GetOrCreate(targetNode.Name);
        nodeLink.target = nodeLink.target ?? new Link { name = targetNode.Name, type = targetNode.NodeType };

        Link srcLink = new Link { name = srcNode.Name, type = srcNode.NodeType };

        switch (targetNode)
        {
          case CombinerNode combiner:
            if (conn.Input == combiner.LeftInput) nodeLink.source0 = srcLink;
            if (conn.Input == combiner.RightInput) nodeLink.source1 = srcLink;
            break;
          case FilterNode filter:
            if (conn.Input == filter.NodeInput) nodeLink.source0 = srcLink;
            break;
          case ModifierNode modifier:
            if (conn.Input == modifier.NodeInput) nodeLink.source0 = srcLink;
            break;
          case TransformerNode transformer:
            if (conn.Input == transformer.SelectNode) nodeLink.source0 = srcLink;
            if (conn.Input == transformer.XNode) nodeLink.source1 = srcLink;
            if (conn.Input == transformer.YNode) nodeLink.source2 = srcLink;
            if (conn.Input == transformer.ZNode) nodeLink.source3 = srcLink;
            break;
          // TODO: Select
          //case SelectNode select:
          //break;
          case TerminatorNode term:
            if (conn.Input == term.NodeInput) nodeLink.source0 = srcLink;
            break;
        }
      }

      var nodeLinks = targetConnections.Values.SelectMany(x => x.Values);
      FileData.links = nodeLinks.ToList();
    }

    public void Save()
    {
      SaveFile(CurrentFileName);
    }

    public void CreateBackup()
    {
      var date = DateTime.Now;

      try
      {
        File.Copy(CurrentFileName, $"{CurrentFileName}_{date:yyyy_MM_dd_HH_mm_ss}");
      }
      catch { }
    }

    public void SaveFile(string filename)
    {
      if (filename == CurrentFileName) CreateBackup();

      FileData.ClearLists();

      SerializeNodes();
      SerializeConnections();

      // Serialize to YAML
      var yaml = new SerializerBuilder()
        .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
        .DisableAliases()
        .Build();
      string rawYaml = yaml.Serialize(FileData);
      File.WriteAllText(filename, rawYaml);

      HasChangesSinceLastSaved = false;
      CurrentFileName = filename;
    }
  }
}
