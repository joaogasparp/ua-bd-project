namespace form
{
    partial class EmployeePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeePage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Fnome = new System.Windows.Forms.TextBox();
            this.pnif = new System.Windows.Forms.TextBox();
            this.Fcargo = new System.Windows.Forms.TextBox();
            this.Fcontacto = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.HomeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perfilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encomendasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bombasDeCombustívelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Fnif = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Lista de Funcionários:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(464, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Funcionários:";
            // 
            // Fnome
            // 
            this.Fnome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fnome.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Fnome.Location = new System.Drawing.Point(469, 138);
            this.Fnome.Name = "Fnome";
            this.Fnome.Size = new System.Drawing.Size(217, 27);
            this.Fnome.TabIndex = 7;
            this.Fnome.Text = "Nome";
            this.Fnome.Enter += new System.EventHandler(this.TextBox1_Enter);
            this.Fnome.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // pnif
            // 
            this.pnif.Location = new System.Drawing.Point(0, 0);
            this.pnif.Name = "pnif";
            this.pnif.Size = new System.Drawing.Size(100, 22);
            this.pnif.TabIndex = 51;
            // 
            // Fcargo
            // 
            this.Fcargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fcargo.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Fcargo.Location = new System.Drawing.Point(469, 204);
            this.Fcargo.Name = "Fcargo";
            this.Fcargo.Size = new System.Drawing.Size(217, 27);
            this.Fcargo.TabIndex = 9;
            this.Fcargo.Text = "Cargo";
            this.Fcargo.Enter += new System.EventHandler(this.TextBox3_Enter);
            this.Fcargo.Leave += new System.EventHandler(this.TextBox3_Leave);
            // 
            // Fcontacto
            // 
            this.Fcontacto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fcontacto.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Fcontacto.Location = new System.Drawing.Point(469, 237);
            this.Fcontacto.Name = "Fcontacto";
            this.Fcontacto.Size = new System.Drawing.Size(217, 27);
            this.Fcontacto.TabIndex = 10;
            this.Fcontacto.Text = "Contacto";
            this.Fcontacto.Enter += new System.EventHandler(this.TextBox4_Enter);
            this.Fcontacto.Leave += new System.EventHandler(this.TextBox4_Leave);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(469, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 30);
            this.button1.TabIndex = 11;
            this.button1.Text = "Pesquisar Funcionário";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(469, 380);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(217, 30);
            this.button2.TabIndex = 12;
            this.button2.Text = "Remover Funionário";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(469, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(217, 30);
            this.button3.TabIndex = 13;
            this.button3.Text = "Adicionar Funcionário";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HomeStripMenuItem,
            this.perfilToolStripMenuItem,
            this.funcionáriosToolStripMenuItem,
            this.encomendasToolStripMenuItem,
            this.stockToolStripMenuItem,
            this.bombasDeCombustívelToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 67);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // HomeStripMenuItem
            // 
            this.HomeStripMenuItem.Name = "HomeStripMenuItem";
            this.HomeStripMenuItem.Size = new System.Drawing.Size(63, 63);
            this.HomeStripMenuItem.Text = "Home";
            this.HomeStripMenuItem.Click += new System.EventHandler(this.HomeStripMenuItem_Click);
            // 
            // perfilToolStripMenuItem
            // 
            this.perfilToolStripMenuItem.Name = "perfilToolStripMenuItem";
            this.perfilToolStripMenuItem.Size = new System.Drawing.Size(55, 63);
            this.perfilToolStripMenuItem.Text = "Perfil";
            this.perfilToolStripMenuItem.Click += new System.EventHandler(this.PerfilToolStripMenuItem_Click);
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(108, 63);
            this.funcionáriosToolStripMenuItem.Text = "Funcionários";
            // 
            // encomendasToolStripMenuItem
            // 
            this.encomendasToolStripMenuItem.Name = "encomendasToolStripMenuItem";
            this.encomendasToolStripMenuItem.Size = new System.Drawing.Size(110, 63);
            this.encomendasToolStripMenuItem.Text = "Encomendas";
            this.encomendasToolStripMenuItem.Click += new System.EventHandler(this.EncomendasToolStripMenuItem_Click);
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(61, 63);
            this.stockToolStripMenuItem.Text = "Stock";
            this.stockToolStripMenuItem.Click += new System.EventHandler(this.StockToolStripMenuItem_Click);
            // 
            // bombasDeCombustívelToolStripMenuItem
            // 
            this.bombasDeCombustívelToolStripMenuItem.Name = "bombasDeCombustívelToolStripMenuItem";
            this.bombasDeCombustívelToolStripMenuItem.Size = new System.Drawing.Size(184, 63);
            this.bombasDeCombustívelToolStripMenuItem.Text = "Bombas de Combustível";
            this.bombasDeCombustívelToolStripMenuItem.Click += new System.EventHandler(this.BombasDeCombustívelToolStripMenuItem_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(46, 138);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(309, 244);
            this.listBox1.TabIndex = 50;
            // 
            // Fnif
            // 
            this.Fnif.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fnif.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.Fnif.Location = new System.Drawing.Point(469, 171);
            this.Fnif.Name = "Fnif";
            this.Fnif.Size = new System.Drawing.Size(217, 27);
            this.Fnif.TabIndex = 52;
            this.Fnif.Text = "NIF";
            this.Fnif.Enter += new System.EventHandler(this.TextBox2_Enter);
            this.Fnif.Leave += new System.EventHandler(this.TextBox2_Leave);
            // 
            // EmployeePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Fnif);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Fcontacto);
            this.Controls.Add(this.Fcargo);
            this.Controls.Add(this.pnif);
            this.Controls.Add(this.Fnome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EmployeePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FUNCIONÁRIOS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Fnome;
        private System.Windows.Forms.TextBox pnif;
        private System.Windows.Forms.TextBox Fcargo;
        private System.Windows.Forms.TextBox Fcontacto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HomeStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encomendasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bombasDeCombustívelToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox Fnif;
    }
}