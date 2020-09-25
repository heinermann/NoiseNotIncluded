using Crainiate.Diagramming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoiseNotIncluded
{
  public partial class MainWindow : Form
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
      palette.AddStencil(Singleton.Instance.GetStencil(typeof(BasicStencil)));
      palette.Tabs.CurrentTab.Name = "Combiners";

      flowchart.Controller.AllowDelete = true;
      flowchart.Controller.AllowCut = true;
      flowchart.Controller.AllowCopy = true;
      flowchart.Controller.AllowPaste = true;
      flowchart.Controller.AllowUndo = true;
      flowchart.Controller.AllowRedo = true;

    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void flowchart_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Delete)
      {
        MessageBox.Show("A", "wa");
        var selected = flowchart.Model.Elements.Where(elem => (elem as ISelectable)?.Selected ?? false)
          .ToList();

        foreach (var elem in selected)
        {
          flowchart.Model.Elements.Remove(elem);
        }
      }
    }
  }
}
