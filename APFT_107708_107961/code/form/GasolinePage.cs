using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace form
{
    public partial class GasolinePage : Form
    {
        private readonly int NIF;
        private readonly SqlConnection connection;

        public GasolinePage(int NIF)
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

        private void StockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockPage stockPage = new StockPage(NIF);
            stockPage.Show();
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
            if (textBox3.Text == "Marca")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
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
            if (textBox5.Text == "Produto Associado")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
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
                textBox3.Text = "Marca";
                textBox3.ForeColor = Color.Silver;
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
                textBox5.Text = "Produto Associado";
                textBox5.ForeColor = Color.Silver;
            }
        }

        private void PreencherListBox()
        {
            listBox1.Items.Clear();

            SqlCommand cmd = new SqlCommand("SELECT * FROM GAS_BombaCombustivel", connection);

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listBox1.ScrollAlwaysVisible = true;
                    listBox1.HorizontalScrollbar = true;

                    int numBomba = reader.GetInt32(0);
                    string marca = reader.GetString(1);
                    decimal preco = reader.GetDecimal(2);
                    int pCodigo = reader.GetInt32(3);
                    int numArea = reader.GetInt32(4);

                    string bombaInfo = $"Número da Bomba: {numBomba}, Marca: {marca}, Preço: {preco}, Código do Produto: {pCodigo}";
                    listBox1.Items.Add(bombaInfo);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                
                int AS_Num_Area = 0;
                using (SqlCommand cmd = new SqlCommand("SELECT Num_Area FROM dbo.GAS_Area_Servico JOIN dbo.GAS_Pessoa ON Num_Area = AS_Num_Area WHERE NIF = @NIF", connection))
                {
                    cmd.Parameters.AddWithValue("@NIF", NIF); 
                    AS_Num_Area = (int)cmd.ExecuteScalar();
                }

                using (SqlCommand cmd = new SqlCommand("INSERT INTO GAS_BombaCombustivel (Num_Bomba, Marca, Preco, P_Codigo, AS_Num_Area) VALUES (@Num_Bomba, @Marca, @Preco, @P_Codigo, @AS_Num_Area)", connection))
                {
                    cmd.Parameters.AddWithValue("@Num_Bomba", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@Marca", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Preco", decimal.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@P_Codigo", int.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@AS_Num_Area", AS_Num_Area);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Bomba de gasolina adicionada com sucesso!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao adicionar a bomba de gasolina!");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            PreencherListBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma bomba de gasolina para remover.");
                return;
            }
            string selectedBomba = listBox1.SelectedItem.ToString();
            int numBomba = int.Parse(selectedBomba.Split(':')[1].Split(',')[0].Trim());
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM GAS_BombaCombustivel WHERE Num_Bomba = @Num_Bomba", connection))
                {
                    cmd.Parameters.AddWithValue("@Num_Bomba", numBomba);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Bomba de gasolina removida com sucesso!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao remover a bomba de gasolina!");
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
