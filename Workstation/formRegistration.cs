namespace Workstation
{
    using System.Windows.Forms;

    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
            cbRole.DataSource = new[] {"Гость", "Оператор"};
        }

        private void FormRegistrationClosing(object sender, System.EventArgs e) {  }

        private void BtRegistration_Click(object sender, System.EventArgs e)
        {
            var errorMessage = "";
            MessageBox.Show(
                AuthorizationMethods.Registration(tbLogin.Text, tbPassword.Text, cbRole.Text, ref errorMessage)
                    ? "Пользователь успешно зарегистрирован!"
                    : errorMessage);
        }
    }
}
