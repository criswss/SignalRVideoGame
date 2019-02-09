using Microsoft.AspNetCore.SignalR;
using Np2.Repositorio;
using System.Threading.Tasks;

namespace Np2.Hubs
{
    public class Play : Hub
    {
        private readonly IPlayersRepo _repo;
        public Play(IPlayersRepo players){
            _repo = players;
        }


        public async Task mandarCambio(Players player)
        {
            _repo.updatePlayer(player);
            await Clients.All.SendAsync("ReceiveChange",  _repo.GetPlayers());
        }


    }
}