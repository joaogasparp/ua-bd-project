namespace form
{
    partial class GasolinePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GasolinePage));
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.HomeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PerfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FuncionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EncomendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BombasDeCombustívelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox5.Location = new System.Drawing.Point(469, 237);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(217, 27);
            this.textBox5.TabIndex = 47;
            this.textBox5.Text = "Produto Associado";
            this.textBox5.Enter += new System.EventHandler(this.TextBox5_Enter);
            this.textBox5.Leave += new System.EventHandler(this.TextBox5_Leave);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox4.Location = new System.Drawing.Point(469, 204);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(217, 27);
            this.textBox4.TabIndex = 46;
            this.textBox4.Text = "Preço";
            this.textBox4.Enter += new System.EventHandler(this.TextBox4_Enter);
            this.textBox4.Leave += new System.EventHandler(this.TextBox4_Leave);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(469, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(217, 30);
            this.button3.TabIndex = 44;
            this.button3.Text = "Remover Bomba";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(469, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 30);
            this.button1.TabIndex = 43;
            this.button1.Text = "Adicionar Bomba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox3.Location = new System.Drawing.Point(469, 171);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(217, 27);
            this.textBox3.TabIndex = 42;
            this.textBox3.Text = "Marca";
            this.textBox3.Enter += new System.EventHandler(this.TextBox3_Enter);
            this.textBox3.Leave += new System.EventHandler(this.TextBox3_Leave);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox1.Location = new System.Drawing.Point(469, 138);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(217, 27);
            this.textBox1.TabIndex = 41;
            this.textBox1.Text = "Número";
            this.textBox1.Enter += new System.EventHandler(this.TextBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 25);
            this.label2.TabIndex = 40;
            this.label2.Text = "Bomba de Combustível:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 25);
            this.label1.TabIndex = 38;
            this.label1.Text = "Lista de Bombas de Combustível:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HomeStripMenuItem,
            this.PerfilToolStripMenuItem,
            this.FuncionáriosToolStripMenuItem,
            this.EncomendasToolStripMenuItem,
            this.StockToolStripMenuItem,
            this.BombasDeCombustívelToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 67);
            this.menuStrip1.TabIndex = 48;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HomeStripMenuItem
            // 
            this.HomeStripMenuItem.Name = "HomeStripMenuItem";
            this.HomeStripMenuItem.Size = new System.Drawing.Size(63, 63);
            this.HomeStripMenuItem.Text = "Home";
            this.HomeStripMenuItem.Click += new System.EventHandler(this.HomeStripMenuItem_Click);
            // 
            // PerfilToolStripMenuItem
            // 
            this.PerfilToolStripMenuItem.Name = "PerfilToolStripMenuItem";
            this.PerfilToolStripMenuItem.Size = new System.Drawing.Size(55, 63);
            this.PerfilToolStripMenuItem.Text = "Perfil";
            this.PerfilToolStripMenuItem.Click += new System.EventHandler(this.PerfilToolStripMenuItem_Click);
            // 
            // FuncionáriosToolStripMenuItem
            // 
            this.FuncionáriosToolStripMenuItem.Name = "FuncionáriosToolStripMenuItem";
            this.FuncionáriosToolStripMenuItem.Size = new System.Drawing.Size(108, 63);
            this.FuncionáriosToolStripMenuItem.Text = "Funcionários";
            this.FuncionáriosToolStripMenuItem.Click += new System.EventHandler(this.FuncionáriosToolStripMenuItem_Click);
            // 
            // EncomendasToolStripMenuItem
            // 
            this.EncomendasToolStripMenuItem.Name = "EncomendasToolStripMenuItem";
            this.EncomendasToolStripMenuItem.Size = new System.Drawing.Size(110, 63);
            this.EncomendasToolStripMenuItem.Text = "Encomendas";
            this.EncomendasToolStripMenuItem.Click += new System.EventHandler(this.EncomendasToolStripMenuItem_Click);
            // 
            // StockToolStripMenuItem
            // 
            this.StockToolStripMenuItem.Name = "StockToolStripMenuItem";
            this.StockToolStripMenuItem.Size = new System.Drawing.Size(61, 63);
            this.StockToolStripMenuItem.Text = "Stock";
            this.StockToolStripMenuItem.Click += new System.EventHandler(this.StockToolStripMenuItem_Click);
            // 
            // BombasDeCombustívelToolStripMenuItem
            // 
            this.BombasDeCombustívelToolStripMenuItem.Name = "BombasDeCombustívelToolStripMenuItem";
            this.BombasDeCombustívelToolStripMenuItem.Size = new System.Drawing.Size(184, 63);
            this.BombasDeCombustívelToolStripMenuItem.Text = "Bombas de Combustível";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(46, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(309, 244);
            this.listBox1.TabIndex = 62;
            // 
            // GasolinePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GasolinePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BOMBA DE COMBUSTÍVEL";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HomeStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PerfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FuncionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EncomendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BombasDeCombustívelToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
    }
}