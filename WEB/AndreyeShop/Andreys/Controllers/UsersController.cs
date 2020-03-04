namespace Andreys.Controllers
{
    using Andreys.Services;
    using Andreys.ViewModels.Users;

    using SIS.HTTP;
    using SIS.MvcFramework;
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpGet("/Users/Login")]
        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel loginInputModel)
        {
            var userId = this.usersService.GetUserId(loginInputModel.Username, loginInputModel.Password);

            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();

            return this.Redirect("/");
        }

        [HttpGet("/Users/Register")]
        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel registerInputModel)
        {
            if (registerInputModel.Username.Length < 4 
                || registerInputModel.Username.Length > 10)
            {
                return this.Error("Invalid Username lenght!");
            }

            if (registerInputModel.Password.Length < 6 
                || registerInputModel.Password.Length > 20)
            {
                return this.Error("Invalid Password lenght!");
            }

            if (registerInputModel.Password != registerInputModel.ConfirmPassword)
            {
                return this.Error("Password must be same as ConfirmPassword!");
            }

            if (this.usersService.EmailExists(registerInputModel.Email))
            {
                return this.Error("This Email is already taken!");
            }

            if (this.usersService.UsernameExists(registerInputModel.Username))
            {
                return this.Error("This Username is already taken!");
            }

            this.usersService.Register(registerInputModel.Username,
                registerInputModel.Email, registerInputModel.Password);

            return this.Redirect("/Users/Login");
        }
    }
}