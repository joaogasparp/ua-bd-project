using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace form
{
    public partial class AreaServicoPage : Form
    {
        private readonly int NIF;
        private readonly SqlConnection connection;

        public AreaServicoPage(int NIF)
        {
            InitializeComponent();
            this.NIF = NIF;
            connection = new SqlConnection(DatabaseConnection.connectionString);

            PreencherLabel6();
            label7.Text = NIF.ToString();
            PreencherLabel8();
            PreencherLabel9();
            PreencherLabel11();
            PreencherListBox();
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

        private void BombasDeCombustívelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            GasolinePage gasolinePage = new GasolinePage(NIF);
            gasolinePage.Show();
        }

        private void PreencherLabel6()
        {
            SqlCommand cmd = new SqlCommand("SELECT Nome FROM GAS_Pessoa WHERE NIF = @NIF", connection);
            cmd.Parameters.AddWithValue("@NIF", NIF);
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label6.Text = reader["Nome"].ToString();
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

        private void PreencherLabel8()
        {
            SqlCommand cmd = new SqlCommand("SELECT Gabinete FROM GAS_Gerente WHERE NIF = @NIF", connection);
            cmd.Parameters.AddWithValue("@NIF", NIF);
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label8.Text = reader["Gabinete"].ToString();
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

        private void PreencherLabel9()
        {
            SqlCommand cmd = new SqlCommand("SELECT AS_Num_Area FROM GAS_Pessoa WHERE NIF = @NIF", connection);
            cmd.Parameters.AddWithValue("@NIF", NIF);
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label9.Text = reader["AS_Num_Area"].ToString();
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

        private void PreencherLabel11()
        {
            SqlCommand cmd = new SqlCommand("SELECT GAS_Area_Servico.Localizacao FROM GAS_Area_Servico INNER JOIN GAS_Pessoa ON GAS_Area_Servico.Num_Area = GAS_Pessoa.AS_Num_Area WHERE GAS_Pessoa.NIF = @NIF", connection);
            cmd.Parameters.AddWithValue("@NIF", NIF);
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        label11.Text = reader["Localizacao"].ToString();
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

        private void PreencherListBox()
        {
            int AS_Num_Area = int.Parse(label9.Text);

            SqlCommand cmd1 = new SqlCommand("SELECT dbo.GetNumeroBombasGasolina(@AS_Num_Area)", connection);
            cmd1.Parameters.AddWithValue("@AS_Num_Area", AS_Num_Area);
            SqlCommand cmd2 = new SqlCommand("SELECT dbo.GetCapacidadeTotalEstacionamento(@AS_Num_Area)", connection);
            cmd2.Parameters.AddWithValue("@AS_Num_Area", AS_Num_Area);
            SqlCommand cmd3 = new SqlCommand("SELECT dbo.GetTotalFuncionariosPorGerente(@G_NIF)", connection);
            cmd3.Parameters.AddWithValue("@G_NIF", NIF);
            SqlCommand cmd4 = new SqlCommand("SELECT dbo.GetLojasPorGerente(@G_NIF)", connection);
            cmd4.Parameters.AddWithValue("@G_NIF", NIF);

            try
            {
                connection.Open();
                int numeroBombas = (int)cmd1.ExecuteScalar();
                int capacidadeTotal = (int)cmd2.ExecuteScalar();
                int totalFuncionarios = (int)cmd3.ExecuteScalar();

                listBox1.Items.Add("Bombas de Combustível: " + numeroBombas);
                listBox1.Items.Add("Nº de Estacionamentos: " + capacidadeTotal);
                listBox1.Items.Add("Total de Funcionários: " + totalFuncionarios);

                string nomesLojas = (string)cmd4.ExecuteScalar();
                string[] lojas = nomesLojas.Split(',');
                foreach (string loja in lojas)
                {
                    listBox1.Items.Add("Loja: " + loja.Trim());
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

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }
    }
}
