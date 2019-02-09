using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Np2.Models;
using Np2.Repositorio;
using Np2.Hubs;

namespace Np2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepo _repo;
        private readonly IPlayersRepo _repoplayers;
        private readonly IHubContext<Listado> _hub;

        public HomeController(IRepo repo, IHubContext<Listado> hub, IPlayersRepo playerrepo){
            _hub = hub;
            _repo = repo;
            _repoplayers = playerrepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Listado()
        {
            var listado = _repo.obtenerPersonas();
            return View(listado);
        }
        public async Task<IActionResult> ChangeAsync(int id){
            var personas= _repo.obtenerPersonas();
            _repo.cambiarEstatus(id,2);
            
            await _hub.Clients.All.SendAsync("ReceiveChange", id, personas);
            return Ok();
        }

        public IActionResult createPlayer(string nombre){
            Random random = new Random();
            var X =  random.Next(0,300);
            var Y = random.Next(0,300);
            var response = _repoplayers.newPlayer(nombre, X, Y);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult getPlayers(){
            var response = _repoplayers.GetPlayers();
            return Ok(response);
        }

        public IActionResult playSauqare(){
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
