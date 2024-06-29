using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace form
{
    public partial class PerfilPage : Form
    {
        private readonly int NIF;
        private readonly SqlConnection connection;

        public PerfilPage(int NIF)
        {
            InitializeComponent();
            this.NIF = NIF;
            connection = new SqlConnection(DatabaseConnection.connectionString);

            PreencherCampos();
        }

        private void HomeStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AreaServicoPage areaservicoPage = new AreaServicoPage(NIF);
            areaservicoPage.Show();
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

        private void PreencherCampos()
        {
            SqlCommand cmd = new SqlCommand("SELECT GAS_Pessoa.Nome, GAS_Pessoa.Contacto, GAS_Gerente.Gabinete FROM GAS_Pessoa INNER JOIN GAS_Gerente ON GAS_Pessoa.NIF = GAS_Gerente.NIF WHERE GAS_Pessoa.NIF = @NIF", connection);
            cmd.Parameters.AddWithValue("@NIF", NIF);
            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        utilizador.Text = reader["Nome"].ToString();
                        contacto.Text = reader["Contacto"].ToString();
                        textBox1.Text = reader["Gabinete"].ToString();
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
            SqlCommand cmd = new SqlCommand("dbo.AtualizarGerente", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NIF", NIF);
            try
            {
                connection.Open();
                if (!string.IsNullOrEmpty(utilizador.Text))
                {
                    cmd.Parameters.AddWithValue("@Nome", utilizador.Text);
                }
                if (!string.IsNullOrEmpty(contacto.Text))
                {
                    cmd.Parameters.AddWithValue("@Contacto", int.Parse(contacto.Text));
                }
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    cmd.Parameters.AddWithValue("@Gabinete", int.Parse(textBox1.Text));
                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Definições atualizadas com sucesso!");
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

