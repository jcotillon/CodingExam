using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExamCode
{
    public partial class LoginForm : Form, ILoginView
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        LoginController _controller;

        public void SetController(LoginController controller)
        {
            _controller = controller;
        }

        public void ClearValue()
        {
            this.txtValue.Clear();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginModel user = new LoginModel() { Email = txtEmail.Text, Password = txtPassword.Text };
            _controller?.LoginUser(user);
            this.txtValue.Text = _controller?.Response.Headers?.Date?.ToString();
        }

    }
}
