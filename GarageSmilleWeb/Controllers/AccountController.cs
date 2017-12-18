using AutoMapper;
using GarageSmille.Domain.Entities;
using GarageSmille.Domain.Interface.Domain;
using GarageSmille_Ui.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;


namespace GarageSmille_Ui.Controllers
{
    public class AccountController : Controller
    {
        private readonly IServicoDeUsuarioDomain _usuarioDomain;
        public AccountController(IServicoDeUsuarioDomain usuarioDomain)
        {
            _usuarioDomain = usuarioDomain;
        }
        // GET: Account
        public ActionResult Login()
        {
            var logInView = new LogInViewModel
            {
                PerfilUsuario = _usuarioDomain.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem
                { Text = x.NomePerfil, Value = Convert.ToString(x.PerfilUsuarioId) })
            };
            return View(logInView);
        }

        [HttpPost]
        [ActionName("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogInViewModel logViewModel)
        {
            logViewModel.PerfilUsuario = _usuarioDomain.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem
            { Text = x.NomePerfil, Value = Convert.ToString(x.PerfilUsuarioId) });
            if (!ModelState.IsValid)
                return View(logViewModel);

            var usuario = _usuarioDomain.LogaUsuario(logViewModel.Email, logViewModel.Password);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Email ou Senha Invalido");
                return View(logViewModel);
            }

            SessionManager.UsuarioLogado = usuario;

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logoff()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            var register = new RegisterViewModel
            {
                ComboPerfilUsuario = _usuarioDomain.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem
                { Text = x.NomePerfil, Value = Convert.ToString(x.PerfilUsuarioId) })
            };
            return View(register);
        }

        [HttpPost]
        [ActionName("Register")]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel register)
        {

            if (!ModelState.IsValid)
                return View(register);

            register.ComboPerfilUsuario = _usuarioDomain.RecuperaTodosPerfisAtivos().Select(x => new SelectListItem
            { Text = x.NomePerfil, Value = Convert.ToString(x.PerfilUsuarioId) });

            var UsuarioExistente = _usuarioDomain.ResuperaUsuarioPorEmail(register.Email);

            if (UsuarioExistente!=null)
            {
                ModelState.AddModelError("","Email Esta Sendo Utilizado");
                return View(register);
            }
            var LogaUsuario = Mapper.Map<RegisterViewModel, Usuario>(register);
            _usuarioDomain.CadastrarUsuario(LogaUsuario);
            //_usuarioDomain.CadastrarUsuario(
            //    new GarageSmille.Domain.Entities.Usuario
            //    {
            //        Nome = register.Nome,
            //        Email = register.Email,
            //        PerfilUsuarioId = register.PerfilUsuarioId,
            //        Senha = register.Senha,
            //        SenhaKey = CodGerator.GetCodigo()
            //    });
            return View();
        }
    }
}
