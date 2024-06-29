using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace form
{
    public partial class StockPage : Form
    {
        private readonly int NIF;
        private readonly SqlConnection connection;

        public StockPage(int NIF)
        {
            InitializeComponent();
            this.NIF = NIF;
            connection = new SqlConnection(DatabaseConnection.connectionString);

            PreencherListBox();
        }

        private void HomeStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AreaServicoPage areaservicoPage = new AreaServicoPage(NIF);
            areaservicoPage.Show();
        }

        private void PerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            PerfilPage perfilPage = new PerfilPage(NIF);
            perfilPage.Show();
        }

        private void FuncionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeePage employeePage = new EmployeePage(NIF);
            employeePage.Show();
        }

        private void EncomendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrdersPage ordersPage = new OrdersPage(NIF);
            ordersPage.Show();
        }

        private void BombasDeCombustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GasolinePage gasolinePage = new GasolinePage(NIF);
            gasolinePage.Show();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Código")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Taxa IVA")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Quantidade")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void TextBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Preço")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void TextBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Stock")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Código";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Taxa IVA";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Quantidade";
                textBox2.ForeColor = Color.Silver;
            }
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Preço";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Stock";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void PreencherListBox()
        {
            listBox1.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT * FROM GAS_Produto", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.ScrollAlwaysVisible = true;
                    listBox1.HorizontalScrollbar = true;

                    int codigo = reader.GetInt32(0);
                    decimal taxaIva = reader.GetDecimal(1);
                    int quantidade = reader.GetInt32(2);
                    decimal preco = reader.GetDecimal(3);
                    int numEstoque = reader.GetInt32(4);

                    string produtoInfo = $"Código: {codigo}, Taxa IVA: {taxaIva}, Quantidade: {quantidade}, Preço: {preco}, Número do Stock: {numEstoque}";
                    listBox1.Items.Add(produtoInfo);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao abrir a conexão com o banco de dados!");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int codigo = int.Parse(textBox1.Text);
            decimal taxaIva = decimal.Parse(textBox4.Text);
            int quantidade = int.Parse(textBox2.Text);
            decimal preco = decimal.Parse(textBox3.Text);
            int numEstoque = int.Parse(textBox5.Text);

            SqlCommand cmd = new SqlCommand("INSERT INTO GAS_Produto (Codigo, TaxaIva, Quantidade, Preco, E_Num_Estoque) VALUES (@Codigo, @TaxaIva, @Quantidade, @Preco, @E_Num_Estoque)", connection);
            cmd.Parameters.AddWithValue("@Codigo", codigo);
            cmd.Parameters.AddWithValue("@TaxaIva", taxaIva);
            cmd.Parameters.AddWithValue("@Quantidade", quantidade);
            cmd.Parameters.AddWithValue("@Preco", preco);
            cmd.Parameters.AddWithValue("@E_Num_Estoque", numEstoque);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao adicionar o produto!");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um produto para remover.");
                return;
            }
            string selectedProduto = listBox1.SelectedItem.ToString();
            int codigo = int.Parse(selectedProduto.Split(':')[1].Split(',')[0].Trim());
            SqlCommand cmd1 = new SqlCommand("DELETE FROM GAS_Item WHERE P_Codigo = @Codigo", connection);
            cmd1.Parameters.AddWithValue("@Codigo", codigo);
            SqlCommand cmd2 = new SqlCommand("DELETE FROM GAS_Produto WHERE Codigo = @Codigo", connection);
            cmd2.Parameters.AddWithValue("@Codigo", codigo);
            try
            {
                connection.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Produto removido com sucesso!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao remover o produto!");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            PreencherListBox();
        }
    }
}
