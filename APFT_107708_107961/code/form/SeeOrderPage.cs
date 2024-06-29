using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace form
{
    public partial class SeeOrderPage : Form
    {
        private int orderNumber;
        private readonly SqlConnection connection;

        public SeeOrderPage(int orderNumber)
        {
            InitializeComponent();
            this.orderNumber = orderNumber;
            connection = new SqlConnection(DatabaseConnection.connectionString);
        }

        private void SeeOrderPage_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("dbo.BuscarDetalhesDaEncomenda", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Num_Encomenda", orderNumber);
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    listBox1.Items.Clear();
                    while (reader.Read())
                    {
                        string orderDetail = $"Item ID: {reader["ItemID"]}, Quantidade: {reader["Quantidade"]}, Preço: {reader["Preco"]}, Número do Estoque: {reader["Num_Estoque"]}";
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
    }
}
