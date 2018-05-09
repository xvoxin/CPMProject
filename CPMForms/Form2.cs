using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPMForms
{
    public partial class Form2 : Form
    {
        private List<Activity> _acts;
        public Form2(List<Activity> acts)
        {
            InitializeComponent();
            _acts = acts;
            DrawGraph();
        }

        private void DrawGraph()
        {
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            var activities = _acts;
            foreach (var acts in _acts)
            {
                foreach (var id in acts.Predecessor)
                {
                    graph.AddEdge(activities[id - 1].Name + ": " + activities[id - 1].Duration, acts.Name + ": " + acts.Duration);
                }
            }

            viewer.Graph = graph;
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            Controls.Add(viewer);
        }
    }
}
