using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace form
{
    public partial class RegisterPage : Form
    {
        private readonly SqlConnection connection;

        public RegisterPage()
        {
            InitializeComponent();
            connection = new SqlConnection(DatabaseConnection.connectionString);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
                try
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("RegisterUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Num_Area", int.Parse(numAS.Text));
                        cmd.Parameters.AddWithValue("@Localizacao", locAS.Text);
                        cmd.Parameters.AddWithValue("@NomeArea", nameAS.Text);
                        cmd.Parameters.AddWithValue("@NIF", NIF.Text);
                        cmd.Parameters.AddWithValue("@NomePessoa", utilizador.Text);
                        cmd.Parameters.AddWithValue("@Contacto", contacto.Text);
                        cmd.Parameters.AddWithValue("@Gabinete", gabinete.Text);
                        cmd.Parameters.AddWithValue("@Senha", pass.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Utilizador Adicionado com sucesso!");

                    LoginPage loginPage = new LoginPage();
                    this.Hide();
                    loginPage.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    Debug.WriteLine("FAILED TO OPEN CONNECTION TO DATABASE! " + ex.Message);
                }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
        }
    }
}
