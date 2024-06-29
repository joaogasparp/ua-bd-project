using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace form
{

    public partial class EmployeePage : Form
    {
        private readonly int NIF;
        private readonly SqlConnection connection;
        public class Funcionario
        {
            private int F_NIF;
            private String F_Nome;
            private int F_Contacto;
            private int F_AS_Num_Area;
            private String F_Cargo;
            private int F_GerenteNIF;
        }

        public EmployeePage(int NIF)
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

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            if (Fnome.Text == "Nome")
            {
                Fnome.Text = "";
                Fnome.ForeColor = Color.Black;
            }
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            if (Fnif.Text == "NIF")
            {
                Fnif.Text = "";
                Fnif.ForeColor = Color.Black;
            }
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {
            if (Fcargo.Text == "Cargo")
            {
                Fcargo.Text = "";
                Fcargo.ForeColor = Color.Black;
            }
        }

        private void TextBox4_Enter(object sender, EventArgs e)
        {
            if (Fcontacto.Text == "Contacto")
            {
                Fcontacto.Text = "";
                Fcontacto.ForeColor = Color.Black;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            if (Fnome.Text == "")
            {
                Fnome.Text = "Nome";
                Fnome.ForeColor = Color.Gray;
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            if (Fnif.Text == "")
            {
                Fnif.Text = "NIF";
                Fnif.ForeColor = Color.Gray;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            if (Fcargo.Text == "")
            {
                Fcargo.Text = "Cargo";
                Fcargo.ForeColor = Color.Gray;
            }
        }

        private void TextBox4_Leave(object sender, EventArgs e)
        {
            if (Fcontacto.Text == "")
            {
                Fcontacto.Text = "Contacto";
                Fcontacto.ForeColor = Color.Gray;
            }
        }

        private void PreencherListBox()
        {
            listBox1.Items.Clear();
            listBox1.ScrollAlwaysVisible = true;
            listBox1.HorizontalScrollbar = true;
            SqlCommand cmd = new SqlCommand("SELECT GAS_Pessoa.Nome, GAS_Pessoa.Contacto, GAS_Funcionario.Cargo FROM GAS_Pessoa INNER JOIN GAS_Funcionario ON GAS_Pessoa.NIF = GAS_Funcionario.NIF", connection);
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add($"Nome: {reader["Nome"].ToString()}, Contacto: {reader["Contacto"].ToString()}, Cargo: {reader["Cargo"].ToString()}");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao preencher a lista de funcionários!");
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
            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.AddFuncionario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@F_NIF", int.Parse(Fnif.Text));
                    cmd.Parameters.AddWithValue("@F_Nome", Fnome.Text);
                    cmd.Parameters.AddWithValue("@F_Contacto", int.Parse(Fcontacto.Text));
                    cmd.Parameters.AddWithValue("@F_Cargo", Fcargo.Text);
                    cmd.Parameters.AddWithValue("@F_GerenteNIF", NIF);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionário adicionado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                Debug.WriteLine("FAILED TO OPEN CONNECTION TO DATABASE! " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string fnome = Fnome.Text != "Nome" ? Fnome.Text : null;
            string fnifText = Fnif.Text != "NIF" ? Fnif.Text : null;
            string fcargo = Fcargo.Text != "Cargo" ? Fcargo.Text : null;
            string fcontactoText = Fcontacto.Text != "Contacto" ? Fcontacto.Text : null;

            string query = "SELECT GAS_Pessoa.Nome, GAS_Pessoa.Contacto, GAS_Funcionario.Cargo FROM GAS_Pessoa INNER JOIN GAS_Funcionario ON GAS_Pessoa.NIF = GAS_Funcionario.NIF WHERE 1=1";

            SqlCommand cmd = new SqlCommand(query, connection);

            if (!string.IsNullOrEmpty(fnome))
            {
                cmd.CommandText += $" AND GAS_Pessoa.Nome LIKE '%{fnome}%'";
            }

            if (!string.IsNullOrEmpty(fnifText))
            {
                int fnif = int.Parse(fnifText);
                cmd.CommandText += $" AND GAS_Pessoa.NIF = {fnif}";
            }

            if (!string.IsNullOrEmpty(fcargo))
            {
                cmd.CommandText += $" AND GAS_Funcionario.Cargo LIKE '%{fcargo}%'";
            }

            if (!string.IsNullOrEmpty(fcontactoText))
            {
                int fcontacto = int.Parse(fcontactoText);
                cmd.CommandText += $" AND GAS_Pessoa.Contacto = {fcontacto}";
            }

            try
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string funcionario = $"Nome: {reader["Nome"].ToString()}, Contacto: {reader["Contacto"].ToString()}, Cargo: {reader["Cargo"].ToString()}";
                        listBox1.Items.Add(funcionario);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao pesquisar o funcionário!");
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um funcionário para remover.");
                return;
            }
            string selectedFuncionario = listBox1.SelectedItem.ToString();
            int contacto = int.Parse(selectedFuncionario.Split(':')[2].Split(',')[0].Trim());
            SqlCommand cmd1 = new SqlCommand("DELETE FROM GAS_Funcionario WHERE NIF = (SELECT NIF FROM GAS_Pessoa WHERE Contacto = @Contacto)", connection);
            cmd1.Parameters.AddWithValue("@Contacto", contacto);
            SqlCommand cmd2 = new SqlCommand("DELETE FROM GAS_Pessoa WHERE Contacto = @Contacto", connection);
            cmd2.Parameters.AddWithValue("@Contacto", contacto);
            try
            {
                connection.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Funcionário removido com sucesso!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Falha ao remover o funcionário!");
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
