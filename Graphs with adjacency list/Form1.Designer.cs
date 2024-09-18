namespace Graphs_with_adjacency_list
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnAddNode = new Button();
            txtNode = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtFrom = new TextBox();
            label4 = new Label();
            txtTo = new TextBox();
            button1 = new Button();
            btnRemoveEdge = new Button();
            btnShowGraph = new Button();
            txtGraphRepresentation = new TextBox();
            label5 = new Label();
            txtWeight = new TextBox();
            chkDirected = new CheckBox();
            btnShowDFS = new Button();
            txtStartNode = new TextBox();
            btnRemoveNode = new Button();
            btnShowBFS = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold);
            label1.Location = new Point(196, 21);
            label1.Name = "label1";
            label1.Size = new Size(406, 25);
            label1.TabIndex = 0;
            label1.Text = "Bankai Sakashima Yokoshima Happo Fusagari ";
            // 
            // btnAddNode
            // 
            btnAddNode.Location = new Point(330, 73);
            btnAddNode.Name = "btnAddNode";
            btnAddNode.Size = new Size(75, 23);
            btnAddNode.TabIndex = 1;
            btnAddNode.Text = "Add Node";
            btnAddNode.UseVisualStyleBackColor = true;
            btnAddNode.Click += btnAddNode_Click;
            // 
            // txtNode
            // 
            txtNode.Location = new Point(126, 70);
            txtNode.Name = "txtNode";
            txtNode.Size = new Size(180, 23);
            txtNode.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(46, 73);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 3;
            label2.Text = "Node Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 147);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 5;
            label3.Text = "Node From:";
            // 
            // txtFrom
            // 
            txtFrom.Location = new Point(124, 144);
            txtFrom.Name = "txtFrom";
            txtFrom.Size = new Size(104, 23);
            txtFrom.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 185);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 7;
            label4.Text = "Node to:";
            // 
            // txtTo
            // 
            txtTo.Location = new Point(124, 182);
            txtTo.Name = "txtTo";
            txtTo.Size = new Size(104, 23);
            txtTo.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(261, 144);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 8;
            button1.Text = "Add Edge";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnRemoveEdge
            // 
            btnRemoveEdge.Location = new Point(261, 182);
            btnRemoveEdge.Name = "btnRemoveEdge";
            btnRemoveEdge.Size = new Size(75, 39);
            btnRemoveEdge.TabIndex = 9;
            btnRemoveEdge.Text = "Remove Edge";
            btnRemoveEdge.UseVisualStyleBackColor = true;
            btnRemoveEdge.Click += btnRemoveEdge_Click;
            // 
            // btnShowGraph
            // 
            btnShowGraph.Location = new Point(261, 245);
            btnShowGraph.Name = "btnShowGraph";
            btnShowGraph.Size = new Size(75, 39);
            btnShowGraph.TabIndex = 11;
            btnShowGraph.Text = "Show Graph";
            btnShowGraph.UseVisualStyleBackColor = true;
            btnShowGraph.Click += btnShowGraph_Click;
            // 
            // txtGraphRepresentation
            // 
            txtGraphRepresentation.Location = new Point(389, 200);
            txtGraphRepresentation.Multiline = true;
            txtGraphRepresentation.Name = "txtGraphRepresentation";
            txtGraphRepresentation.Size = new Size(362, 202);
            txtGraphRepresentation.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 219);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 14;
            label5.Text = "Weight:";
            // 
            // txtWeight
            // 
            txtWeight.Location = new Point(124, 216);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(104, 23);
            txtWeight.TabIndex = 13;
            // 
            // chkDirected
            // 
            chkDirected.AutoSize = true;
            chkDirected.Location = new Point(124, 245);
            chkDirected.Name = "chkDirected";
            chkDirected.Size = new Size(70, 19);
            chkDirected.TabIndex = 15;
            chkDirected.Text = "Directed";
            chkDirected.UseVisualStyleBackColor = true;
            // 
            // btnShowDFS
            // 
            btnShowDFS.Location = new Point(119, 363);
            btnShowDFS.Name = "btnShowDFS";
            btnShowDFS.Size = new Size(75, 39);
            btnShowDFS.TabIndex = 16;
            btnShowDFS.Text = "Show DFS Algorithm";
            btnShowDFS.UseVisualStyleBackColor = true;
            btnShowDFS.Click += btnShowDFS_Click;
            // 
            // txtStartNode
            // 
            txtStartNode.Location = new Point(66, 334);
            txtStartNode.Name = "txtStartNode";
            txtStartNode.Size = new Size(104, 23);
            txtStartNode.TabIndex = 17;
            // 
            // btnRemoveNode
            // 
            btnRemoveNode.Location = new Point(330, 102);
            btnRemoveNode.Name = "btnRemoveNode";
            btnRemoveNode.Size = new Size(75, 23);
            btnRemoveNode.TabIndex = 20;
            btnRemoveNode.Text = "Remove";
            btnRemoveNode.UseVisualStyleBackColor = true;
            btnRemoveNode.Click += btnRemoveNode_Click;
            // 
            // btnShowBFS
            // 
            btnShowBFS.Location = new Point(38, 363);
            btnShowBFS.Name = "btnShowBFS";
            btnShowBFS.Size = new Size(75, 39);
            btnShowBFS.TabIndex = 21;
            btnShowBFS.Text = "Show BFS Algorithm";
            btnShowBFS.UseVisualStyleBackColor = true;
            btnShowBFS.Click += btnShowBFS_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(66, 316);
            label6.Name = "label6";
            label6.Size = new Size(66, 15);
            label6.TabIndex = 22;
            label6.Text = "Node Start:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(btnShowBFS);
            Controls.Add(btnRemoveNode);
            Controls.Add(txtStartNode);
            Controls.Add(btnShowDFS);
            Controls.Add(chkDirected);
            Controls.Add(label5);
            Controls.Add(txtWeight);
            Controls.Add(txtGraphRepresentation);
            Controls.Add(btnShowGraph);
            Controls.Add(btnRemoveEdge);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(txtTo);
            Controls.Add(label3);
            Controls.Add(txtFrom);
            Controls.Add(label2);
            Controls.Add(txtNode);
            Controls.Add(btnAddNode);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnAddNode;
        private TextBox txtNode;
        private Label label2;
        private Label label3;
        private TextBox txtFrom;
        private Label label4;
        private TextBox txtTo;
        private Button button1;
        private Button btnRemoveEdge;
        private Button btnShowGraph;
        private TextBox txtGraphRepresentation;
        private Label label5;
        private TextBox txtWeight;
        private CheckBox chkDirected;
        private Button btnShowDFS;
        private TextBox txtStartNode;
        private Button btnRemoveNode;
        private Button btnShowBFS;
        private Label label6;
    }
}
