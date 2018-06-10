using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dogs.Models;
using System.Windows.Input;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace Dogs.Controllers
{
    public class HomeController : Controller
    {
        Random Rnd = new Random();

        public ViewResult Index()
        {
            HelpDogs.DogsHelp dogsHelp1 = new HelpDogs.DogsHelp();

            ViewBag.hhh = dogsHelp1.DogHName()[0];


            HelpDogs.DogsHelp dogsHelp = new HelpDogs.DogsHelp();

            List<SignIn> lst = new List<SignIn>();

            lst = dogsHelp.DogHMail();
            
            return View(lst);
        }

        #region Contact

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Contact(GuestMassage guest)
        {
            Email.SendEmailMassage send = new Email.SendEmailMassage();
            if (ModelState.IsValid)
            {
                send.sendEmail(guest.Email, guest.Email, guest.Massage,guest.Subject,guest.Phone);
                return View();
            }
            else
            {
                return View();
            }
        }

        #endregion

        #region Account
        [HttpGet]
        public ViewResult Account(GuestResponse guest)
        {
            ViewBag.UserName = guest.UserName;
            ViewBag.DogName = guest.DogName;
            ViewBag.Id = guest.ID;
            return View();
        }

        [HttpPost]
        public ViewResult Account(SignIn sign)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevak\Desktop\Dogs\DogsSql.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlCommand cmd = new SqlCommand();
                    sqlConnection1.Open();

                    cmd.CommandText = "INSERT INTO [HelpDogs] VALUES (@Mail,@Name,@Phone,@Text,@Photo)";
                    cmd.Parameters.AddWithValue("@Mail", sign.Email);
                    cmd.Parameters.AddWithValue("@Name", sign.Name);
                    cmd.Parameters.AddWithValue("@Phone", sign.Phone);
                    cmd.Parameters.AddWithValue("@Text", sign.Text);
                    cmd.Parameters.AddWithValue("@Photo", sign.PhotoData);
                    //cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;
                    cmd.ExecuteReader();
                    // Data is accessible through the DataReader object here.
                    sqlConnection1.Close();

                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex;
                }

                return View();
            }
            else
            {
                ViewBag.WrongText = "Դուք սխալեք արել ";
                return View();
            }

        }

        [HttpPost]
        public ViewResult AccountPhoto()
        {
            return View();
        }

        #endregion

        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }
        int EmailCod = 0;
        
        [HttpPost]
        public ViewResult SignIn(GuestResponse guest)
        {
            Email.SendEmailCod SendCod = new Email.SendEmailCod();

            if (ModelState.IsValid)
            {
                guest.EmailCod = Rnd.Next(1000, 10000); 
                SendCod.sendEmail(guest.Email, guest.EmailCod);
                EmailCod = guest.EmailCod;
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ViewResult Thanks()
        {
            return View();
        }
        
        [HttpPost]
        public ViewResult Thanks(GuestResponse guest)
        {
            if (EmailCod == guest.EmailCod2)
            {
                try
                {
                    SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevak\Desktop\Dogs\DogsSql.mdf;Integrated Security=True;Connect Timeout=30");
                    SqlCommand cmd = new SqlCommand();
                    sqlConnection1.Open();

                    cmd.CommandText = "INSERT INTO [ResponseSql] VALUES (@Id,@EMail,@UserName,@DogName,@Password)";
                    cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@EMail", guest.Email);
                    cmd.Parameters.AddWithValue("@UserName", guest.UserName);
                    cmd.Parameters.AddWithValue("@DogName", guest.DogName);
                    cmd.Parameters.AddWithValue("@Password", guest.Password);
                    //cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection1;
                    cmd.ExecuteReader();
                    // Data is accessible through the DataReader object here.
                    sqlConnection1.Close();
                }
                catch (Exception ex)
                {
                    ViewBag.Exception = ex;
                }

               // AddResponse.AddGuest(guest);
                return View("Account");
            }
            else
            {
                ViewBag.FalseLogin = "Մուտքագրված կոդը սխալ է: Փորձեք նորից:";
                ViewBag.True = "True";
                return View();
            }
        }

        #region Sign

        [HttpGet]
        public ViewResult Sign()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Sign(GuestResponse sign)
        {
            SqlConnection sqlConnection1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Sevak\Desktop\Dogs\DogsSql.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from [ResponseSql] Where EMail= '" + sign.Email + "'and Password= '" + sign.Password + "'";
            SqlDataAdapter sql = new SqlDataAdapter(query,sqlConnection1);
            DataTable dtbl = new DataTable();
            sql.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
               return View("Account");
            }
            else
            {
                return View();
            }
        }

        #endregion

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
