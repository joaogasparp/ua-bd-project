using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace form
{
    public partial class OrderCreationPage : Form
    {
        private int NIF;
        private readonly SqlConnection connection;

        public OrderCreationPage(int NIF)
        {
            InitializeComponent();
            this.NIF = NIF;
            connection = new SqlConnection(DatabaseConnection.connectionString);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                int numEncomenda = int.Parse(textBox1.Text);
                DateTime dataEntrega = dateTimePicker1.Value;
                int itemId = int.Parse(textBox2.Text);
                int nifFornecedor = int.Parse(textBox3.Text);
                decimal preco = decimal.Parse(textBox7.Text);
                int quantidade = int.Parse(textBox6.Text);
                int numEstoque = int.Parse(textBox5.Text);
                using (SqlCommand cmd = new SqlCommand("CreateOrderAndItems", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NifGerente", this.NIF);
                    cmd.Parameters.AddWithValue("@NumEncomenda", numEncomenda);
                    cmd.Parameters.AddWithValue("@DataEntrega", dataEntrega);
                    cmd.Parameters.AddWithValue("@NifFornecedor", nifFornecedor);
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                    cmd.Parameters.AddWithValue("@Preco", preco);
                    cmd.Parameters.AddWithValue("@NumEstoque", numEstoque);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Encomenda criada com sucesso!");
                }
                MessageBox.Show("Encomenda criada com sucesso!");
                this.Close();
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

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
