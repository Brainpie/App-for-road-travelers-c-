namespace Kursach_PIS
{
    partial class MyReviews
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.личныйКабинетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокГородовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.покупаБилетаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиБилетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.моиОтзывыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.моиОценкиМестToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(210, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(578, 328);
            this.dataGridView1.TabIndex = 25;
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.личныйКабинетToolStripMenuItem,
            this.списокГородовToolStripMenuItem,
            this.покупаБилетаToolStripMenuItem,
            this.моиБилетыToolStripMenuItem,
            this.моиОтзывыToolStripMenuItem,
            this.моиОценкиМестToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(167, 450);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // личныйКабинетToolStripMenuItem
            // 
            this.личныйКабинетToolStripMenuItem.Name = "личныйКабинетToolStripMenuItem";
            this.личныйКабинетToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.личныйКабинетToolStripMenuItem.Text = "Личный кабинет";
            // 
            // списокГородовToolStripMenuItem
            // 
            this.списокГородовToolStripMenuItem.Name = "списокГородовToolStripMenuItem";
            this.списокГородовToolStripMenuItem.Size = new System.Drawing.Size(135, 24);
            this.списокГородовToolStripMenuItem.Text = "Список городов";
            // 
            // покупаБилетаToolStripMenuItem
            // 
            this.покупаБилетаToolStripMenuItem.Name = "покупаБилетаToolStripMenuItem";
            this.покупаБилетаToolStripMenuItem.Size = new System.Drawing.Size(133, 24);
            this.покупаБилетаToolStripMenuItem.Text = "Покупка билета";
            // 
            // моиБилетыToolStripMenuItem
            // 
            this.моиБилетыToolStripMenuItem.Name = "моиБилетыToolStripMenuItem";
            this.моиБилетыToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.моиБилетыToolStripMenuItem.Text = "Мои билеты";
            // 
            // моиОтзывыToolStripMenuItem
            // 
            this.моиОтзывыToolStripMenuItem.Name = "моиОтзывыToolStripMenuItem";
            this.моиОтзывыToolStripMenuItem.Size = new System.Drawing.Size(110, 24);
            this.моиОтзывыToolStripMenuItem.Text = "Мои отзывы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(426, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "Мои отзывы";
            // 
            // моиОценкиМестToolStripMenuItem
            // 
            this.моиОценкиМестToolStripMenuItem.Name = "моиОценкиМестToolStripMenuItem";
            this.моиОценкиМестToolStripMenuItem.Size = new System.Drawing.Size(145, 24);
            this.моиОценкиМестToolStripMenuItem.Text = "Мои оценки мест";
            this.моиОценкиМестToolStripMenuItem.Click += new System.EventHandler(this.моиОценкиМестToolStripMenuItem_Click);
            // 
            // MyReviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Name = "MyReviews";
            this.Text = "MyReviews";
            this.Load += new System.EventHandler(this.MyReviews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem личныйКабинетToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem списокГородовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem покупаБилетаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моиБилетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem моиОтзывыToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem моиОценкиМестToolStripMenuItem;
    }
}