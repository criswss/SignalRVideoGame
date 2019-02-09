using Microsoft.AspNetCore.SignalR;
using Np2.Repositorio;
using System.Threading.Tasks;

namespace Np2.Hubs
{
    public class Listado : Hub
    {
        private readonly IRepo _repo;
        public Listado(IRepo repo){
             _repo = repo;
        }

        public async Task SendChange(int id)
        {
            _repo.cambiarEstatus(id,2);
            var personas= _repo.obtenerPersonas();
            await Clients.All.SendAsync("ReceiveChange", id, personas);
        }
    }
}