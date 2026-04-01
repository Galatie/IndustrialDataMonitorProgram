namespace IndustrialDataMonitorProgram
{
    partial class FormDBQ
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
            label1 = new Label();
            textBox1 = new TextBox();
            btnQueryOne = new Button();
            dataGridView1 = new DataGridView();
            labCount = new Label();
            textBox2 = new TextBox();
            btnQueryMany = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "产品号：";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(76, 10);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(202, 27);
            textBox1.TabIndex = 1;
            // 
            // btnQueryOne
            // 
            btnQueryOne.Location = new Point(395, 6);
            btnQueryOne.Name = "btnQueryOne";
            btnQueryOne.Size = new Size(96, 35);
            btnQueryOne.TabIndex = 2;
            btnQueryOne.Text = "单个查询";
            btnQueryOne.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 100);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(694, 341);
            dataGridView1.TabIndex = 3;
            // 
            // labCount
            // 
            labCount.AutoSize = true;
            labCount.Location = new Point(27, 58);
            labCount.Name = "labCount";
            labCount.Size = new Size(54, 20);
            labCount.TabIndex = 4;
            labCount.Text = "数量：";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(76, 55);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(128, 27);
            textBox2.TabIndex = 5;
            // 
            // btnQueryMany
            // 
            btnQueryMany.Location = new Point(395, 51);
            btnQueryMany.Name = "btnQueryMany";
            btnQueryMany.Size = new Size(96, 35);
            btnQueryMany.TabIndex = 6;
            btnQueryMany.Text = "多个查询";
            btnQueryMany.UseVisualStyleBackColor = true;
            // 
            // FormDBQ
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 453);
            Controls.Add(btnQueryMany);
            Controls.Add(textBox2);
            Controls.Add(labCount);
            Controls.Add(dataGridView1);
            Controls.Add(btnQueryOne);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "FormDBQ";
            Text = "数据查询";
            Load += this.FormDBQ_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button btnQueryOne;
        private DataGridView dataGridView1;
        private Label labCount;
        private TextBox textBox2;
        private Button btnQueryMany;
    }
}