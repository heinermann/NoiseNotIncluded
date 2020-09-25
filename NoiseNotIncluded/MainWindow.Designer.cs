namespace NoiseNotIncluded
{
  partial class MainWindow
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      Crainiate.Diagramming.Forms.Paging paging2 = new Crainiate.Diagramming.Forms.Paging();
      Crainiate.Diagramming.Forms.Margin margin2 = new Crainiate.Diagramming.Forms.Margin();
      Crainiate.Diagramming.Forms.Paging paging1 = new Crainiate.Diagramming.Forms.Paging();
      Crainiate.Diagramming.Forms.Margin margin1 = new Crainiate.Diagramming.Forms.Margin();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.preview = new System.Windows.Forms.PictureBox();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.mainPanel = new System.Windows.Forms.Panel();
      this.propertyGrid = new System.Windows.Forms.PropertyGrid();
      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.flowchart = new Crainiate.Diagramming.Flowcharting.Flowchart();
      this.palette = new Crainiate.Diagramming.Forms.Palette();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      this.mainPanel.SuspendLayout();
      this.menuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 24);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
      this.splitContainer1.Size = new System.Drawing.Size(907, 590);
      this.splitContainer1.SplitterDistance = 181;
      this.splitContainer1.TabIndex = 0;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.palette);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.preview);
      this.splitContainer2.Size = new System.Drawing.Size(181, 590);
      this.splitContainer2.SplitterDistance = 368;
      this.splitContainer2.TabIndex = 0;
      // 
      // preview
      // 
      this.preview.Dock = System.Windows.Forms.DockStyle.Fill;
      this.preview.Location = new System.Drawing.Point(0, 0);
      this.preview.Name = "preview";
      this.preview.Size = new System.Drawing.Size(181, 218);
      this.preview.TabIndex = 0;
      this.preview.TabStop = false;
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Name = "splitContainer3";
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.mainPanel);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.propertyGrid);
      this.splitContainer3.Size = new System.Drawing.Size(722, 590);
      this.splitContainer3.SplitterDistance = 522;
      this.splitContainer3.TabIndex = 0;
      // 
      // mainPanel
      // 
      this.mainPanel.Controls.Add(this.flowchart);
      this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanel.Location = new System.Drawing.Point(0, 0);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(522, 590);
      this.mainPanel.TabIndex = 0;
      // 
      // propertyGrid
      // 
      this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.propertyGrid.Location = new System.Drawing.Point(0, 0);
      this.propertyGrid.Name = "propertyGrid";
      this.propertyGrid.Size = new System.Drawing.Size(196, 590);
      this.propertyGrid.TabIndex = 0;
      // 
      // menuStrip
      // 
      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(907, 24);
      this.menuStrip.TabIndex = 1;
      this.menuStrip.Text = "menuStrip";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Image = global::NoiseNotIncluded.Properties.Resources.document_new;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
      this.newToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.newToolStripMenuItem.Text = "&New";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Image = global::NoiseNotIncluded.Properties.Resources.document_open;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.openToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.openToolStripMenuItem.Text = "&Open";
      // 
      // recentFilesToolStripMenuItem
      // 
      this.recentFilesToolStripMenuItem.Image = global::NoiseNotIncluded.Properties.Resources.document_open_recent;
      this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
      this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.recentFilesToolStripMenuItem.Text = "&Recent Files";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Image = global::NoiseNotIncluded.Properties.Resources.document_save;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Image = global::NoiseNotIncluded.Properties.Resources.document_save_as;
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As";
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size(183, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Image = global::NoiseNotIncluded.Properties.Resources.application_exit;
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // flowchart
      // 
      this.flowchart.AllowDrop = true;
      this.flowchart.AutoScroll = true;
      this.flowchart.AutoScrollMinSize = new System.Drawing.Size(834, 1163);
      this.flowchart.Dock = System.Windows.Forms.DockStyle.Fill;
      this.flowchart.DragElement = null;
      this.flowchart.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.flowchart.GridSize = new System.Drawing.Size(20, 20);
      this.flowchart.LineMode = Crainiate.Diagramming.Flowcharting.LineCreateMode.Curve;
      this.flowchart.Location = new System.Drawing.Point(0, 0);
      this.flowchart.Name = "flowchart";
      this.flowchart.Orientation = Crainiate.Diagramming.Flowcharting.FlowchartOrientation.Horizontal;
      paging2.Enabled = true;
      margin2.Bottom = 0F;
      margin2.Left = 0F;
      margin2.Right = 0F;
      margin2.Top = 0F;
      paging2.Margin = margin2;
      paging2.Padding = new System.Drawing.SizeF(40F, 40F);
      paging2.Page = 1;
      paging2.PageSize = new System.Drawing.SizeF(793.7008F, 1122.52F);
      paging2.WorkspaceColor = System.Drawing.SystemColors.AppWorkspace;
      this.flowchart.Paging = paging2;
      this.flowchart.PortMode = Crainiate.Diagramming.Flowcharting.PortCreateMode.LeftRight;
      this.flowchart.Size = new System.Drawing.Size(522, 590);
      this.flowchart.Spacing = new System.Drawing.SizeF(40F, 40F);
      this.flowchart.TabIndex = 0;
      this.flowchart.Zoom = 100F;
      this.flowchart.KeyDown += new System.Windows.Forms.KeyEventHandler(this.flowchart_KeyDown);
      // 
      // palette
      // 
      this.palette.AllowDrop = true;
      this.palette.AutoScrollMinSize = new System.Drawing.Size(0, 0);
      this.palette.BackColor = System.Drawing.SystemColors.Window;
      this.palette.BorderColor = System.Drawing.Color.Black;
      this.palette.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.palette.Dock = System.Windows.Forms.DockStyle.Fill;
      this.palette.DragElement = null;
      this.palette.DragSelect = false;
      this.palette.DrawGrid = false;
      this.palette.DrawSelections = false;
      this.palette.FillColor = System.Drawing.Color.White;
      this.palette.ForeColor = System.Drawing.Color.Black;
      this.palette.GradientColor = System.Drawing.SystemColors.Control;
      this.palette.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.palette.GridSize = new System.Drawing.Size(20, 20);
      this.palette.ItemSize = new System.Drawing.Size(18, 18);
      this.palette.Location = new System.Drawing.Point(0, 0);
      this.palette.Name = "palette";
      paging1.Enabled = true;
      margin1.Bottom = 0F;
      margin1.Left = 0F;
      margin1.Right = 0F;
      margin1.Top = 0F;
      paging1.Margin = margin1;
      paging1.Padding = new System.Drawing.SizeF(40F, 40F);
      paging1.Page = 1;
      paging1.PageSize = new System.Drawing.SizeF(793.7008F, 1122.52F);
      paging1.WorkspaceColor = System.Drawing.SystemColors.AppWorkspace;
      this.palette.Paging = paging1;
      this.palette.Size = new System.Drawing.Size(181, 368);
      this.palette.Spacing = new System.Drawing.Size(20, 22);
      this.palette.TabIndex = 1;
      this.palette.Zoom = 100F;
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(907, 614);
      this.Controls.Add(this.splitContainer1);
      this.Controls.Add(this.menuStrip);
      this.MainMenuStrip = this.menuStrip;
      this.Name = "MainWindow";
      this.Text = "Noise Not Included";
      this.Load += new System.EventHandler(this.MainWindow_Load);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
      this.splitContainer3.ResumeLayout(false);
      this.mainPanel.ResumeLayout(false);
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.PictureBox preview;
    private System.Windows.Forms.SplitContainer splitContainer3;
    private System.Windows.Forms.PropertyGrid propertyGrid;
    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem recentFilesToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.Panel mainPanel;
    internal Crainiate.Diagramming.Forms.Palette palette;
    internal Crainiate.Diagramming.Flowcharting.Flowchart flowchart;
  }
}

