namespace Workstation
{
    using System.Windows.Forms;

    /// <inheritdoc />
    /// <summary>TODO The form autorization.</summary>
    public partial class FormAutorization : Form
    {
        public FormAutorization()
        {
            InitializeComponent();
        }

        private void BtRegistrationClick(object sender, System.EventArgs e) => 
            new FormRegistration().ShowDialog();

        private void BtAutorizationClick(object sender, System.EventArgs e)
        {
            var errorMessage = string.Empty;
            var user = AuthorizationMethods.Authorization(tbLogin.Text, tbPassword.Text, ref errorMessage);
            if (user != null)
            {
                new FormMain(user).Show();
                Visible = false;
            }
            else
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void BtGuestAutorizationClick(object sender, System.EventArgs e)
        {
            new FormMain(new Users { login = "Аноним", role = "Гость" }).Show();
            Visible = false;
        }
    }
}
