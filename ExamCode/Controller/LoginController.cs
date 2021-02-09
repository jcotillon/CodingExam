using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamCode
{
    public class LoginController
    {
        #region Private Properties
        private ILoginView _view;

        private static readonly string GitHubIdentity = Assembly
            .GetEntryAssembly()
            .GetCustomAttribute<AssemblyProductAttribute>()
            .Product;

        private HttpResponseMessage _response = new HttpResponseMessage();

        #endregion

        #region Public Properties
        public HttpResponseMessage Response {
            get
            {
               return  _response;
            }
            set
            {
                _response = value;
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Set controller value
        /// </summary>
        /// <param name="view"></param>
        public LoginController(ILoginView view)
        {
            _view = view;
            view.SetController(this);
        }

        /// <summary>
        /// Execute this method when Login button is clicked
        /// </summary>
        /// <param name="user"></param>
        public async void LoginUser(LoginModel user)
        {
            // var productInformation = new ProductHeaderValue(GitHubIdentity);
            //GetClient(productInformation, user.Email, user.Password);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            var token = $"{user.Email}:{user.Password}";


            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue(GitHubIdentity, "1.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", token);

            _response = await client.GetAsync("/user");
        }

        // TODO
        /*
        private static GitHubClient GetClient(ProductHeaderValue productInformation,
            string username, string password)
        {
            var credentials = new Credentials(username, password, AuthenticationType.Basic);

            var client = new GitHubClient(productInformation) { Credentials = credentials };

            return client;
        }
        */
        #endregion
    }
}
