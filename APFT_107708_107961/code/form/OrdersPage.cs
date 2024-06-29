using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace form
{
    public partial class OrdersPage : Form
    {
        private int NIF;
        private readonly SqlConnection connection;
        private int selectedOrderNumber = 0;
        private SeeOrderPage seeOrderPage;
        private int previousSelectedIndex = -1;

        public OrdersPage(int NIF)
        {
            InitializeComponent();
            this.NIF = NIF;
            connection = new SqlConnection(DatabaseConnection.connectionString);

            PreencherEncomendas();
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

        private void StockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockPage stockPage = new StockPage(NIF);
            stockPage.Show();
        }

        private void BombasDeCombustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GasolinePage gasolinePage = new GasolinePage(NIF);
            gasolinePage.Show();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Número")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Fornecedor NIF")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Número";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Fornecedor NIF";
                textBox3.ForeColor = Color.Silver;
            }
        }

        private void PreencherEncomendas()
        {
            SqlCommand cmd = new SqlCommand("dbo.BuscarEncomendasPorNIF", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NIF", NIF);
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listBox1.Items.Clear();
                    listBox1.ScrollAlwaysVisible = true;
                    listBox1.HorizontalScrollbar = true;
                    while (reader.Read())
                    {
                        string encomenda = $"Número: {reader["Num_Encomenda"]}, Data: {((DateTime)reader["Data_entrega"]).ToString("dd/MM/yyyy")}, NIF Fornecedor: {reader["NIF Fornecedor"]}";
                        listBox1.Items.Add(encomenda);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FAILED TO OPEN CONNECTION TO DATABASE!");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (selectedOrderNumber == 0)
            {
                MessageBox.Show("Nenhuma encomenda selecionado. Por favor, selecione uma encomenda.");
            }
            else
            {
                seeOrderPage = new SeeOrderPage(selectedOrderNumber);
                seeOrderPage.Show();
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (seeOrderPage != null && !seeOrderPage.IsDisposed)
            {
                MessageBox.Show("Não é possível selecionar enquanto a página SeeOrderPage estiver aberta.");
                listBox1.SelectedIndexChanged -= ListBox1_SelectedIndexChanged;
                listBox1.SelectedIndex = previousSelectedIndex;
                listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
                return;
            }

            string selectedOrder = listBox1.SelectedItem.ToString();
            selectedOrderNumber = int.Parse(selectedOrder.Split(':')[1].Split(',')[0].Trim());
            previousSelectedIndex = listBox1.SelectedIndex;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string numEncomendaText = textBox1.Text != "Número" ? textBox1.Text : null;
            string nifFornecedorText = textBox3.Text != "Fornecedor NIF" ? textBox3.Text : null;

            string query = "SELECT * FROM GAS_Encomenda WHERE @NIF=G_NIF";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@NIF", this.NIF);

            if (!string.IsNullOrEmpty(numEncomendaText))
            {
                int numEncomenda = int.Parse(numEncomendaText);
                cmd.CommandText += $" AND Num_Encomenda = {numEncomenda}";
            }

            if (dateTimePicker1.Checked)
            {
                string dataEncomenda = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                cmd.CommandText += $" AND Data_Entrega = '{dataEncomenda}'";
            }

            if (!string.IsNullOrEmpty(nifFornecedorText))
            {
                int nifFornecedor = int.Parse(nifFornecedorText);
                cmd.CommandText += $" AND F_NIF = '{nifFornecedor}'";
            }

            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string orderDetail = $"Número: {reader["Num_Encomenda"]}, Data: {((DateTime)reader["Data_Entrega"]).ToString("dd/MM/yyyy")}, NIF Fornecedor: {reader["F_NIF"]}";
                        listBox1.Items.Add(orderDetail);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FAILED TO OPEN CONNECTION TO DATABASE!");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            OrderCreationPage orderCreationPage = new OrderCreationPage(this.NIF);
            orderCreationPage.Show();
        }
    }
}
