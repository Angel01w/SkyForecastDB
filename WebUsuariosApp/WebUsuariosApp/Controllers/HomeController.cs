using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using WebUsuariosApp.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebUsuariosApp.Controllers
{
    public class HomeController : Controller
    {

       static List<User> userList = new List<User>();

        public async Task<IActionResult> Index()
        {
            if (userList.Count()==0)
            {
                using (var httpClient = new HttpClient())

                {
                    using (var response = await httpClient.GetAsync("https://fakerestapi.azurewebsites.net/api/v1/Users"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                        }
                    }
                }
            }
            

            return View(userList);
        }



        public IActionResult Create()
        {
            return View();
        }

        // Crear Usuario (POST)
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = userList.Count > 0 ? userList.Max(u => u.Id) + 1 : 1; // Asignar nuevo Id.
            userList.Add(user);
            return RedirectToAction("Index");
        }

        // Mostrar formulario de edición
        public IActionResult Edit(int id)
        {
            var user = userList.FirstOrDefault(u => u.Id == id);
            if (user == null) return NotFound();
            return View(user);
        }

       
        // Eliminar Usuario
        public IActionResult Delete(int id)
        {
            var user = userList.FirstOrDefault(u => u.Id == id);
            if (user != null) userList.Remove(user);
            return RedirectToAction("Index");
        }

        // Editar Usuario (POST)
        [HttpPost]
        public IActionResult Edit(User user)
        {
            var existingUser = userList.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null) return NotFound();

            existingUser.UserName = user.UserName;
            existingUser.Password = user.Password;
            return RedirectToAction("Index");
        }
    }
}
