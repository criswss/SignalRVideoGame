using System.Collections.Generic;
using System.Linq;
using Np2.Models;

namespace Np2.Repositorio{
    public interface IPlayersRepo
    {
        Players newPlayer(string nombre, int x, int y);
        List<Players> GetPlayers();
        void updatePlayer(Players player);
    }
        public class PlayersRepo : IPlayersRepo{
        private static List<Players> players;
        static PlayersRepo(){
            players = new List<Players>();
        }


        public Players newPlayer(string nombre, int x, int y){
            int id;
            if(players.Count > 0){
             id = players.Max(i => i.Id)+1;
            }else{
               id =0; 
            }
            var player = new Players{ Id = id, Nombre = nombre, X = x, Y = y };
            players.Add(player);
            return player;
        }

        public List<Players> GetPlayers(){
            return players.ToList();
        }
        public void updatePlayer(Players playerModific){
            var player = players.FirstOrDefault(i => i.Id == playerModific.Id);
            if(player != null){

                player.X = playerModific.X;
                player.Y = playerModific.Y;
            }

        }     
    }

    public class Players
    {
     public int Id{get; set;}
     public string Nombre{get; set;}
     public int X{get; set;}
     public int Y{get; set;}
    }
}