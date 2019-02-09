using System.Collections.Generic;
using System.Linq;
using Np2.Models;

namespace Np2.Repositorio{
    public interface IRepo
    {
        List<Persona> obtenerPersonas();
        List<Persona> obtenerPersonasByEstatus(int estatus);
        void cambiarEstatus(int id, int estatus);
    }
        public class Repo : IRepo{
        private static List<Persona> personas;
        static Repo(){
            personas = new List<Persona>();
            personas.Add(new Persona{ Id = 1, Nombre = "Cristobal", Edad = 23,Estatus = 1});
            personas.Add(new Persona{ Id = 2, Nombre = "Juan", Edad = 29, Estatus = 1});
            personas.Add(new Persona{ Id = 3, Nombre = "Humberto", Edad = 40, Estatus = 1});
            personas.Add(new Persona{ Id = 4, Nombre = "Manuel", Edad = 17, Estatus = 1});
            personas.Add(new Persona{ Id = 5, Nombre = "Pedro", Edad = 25,Estatus = 1});
        }
        
        public List<Persona> obtenerPersonas(){
            return personas.ToList();           
        }

        public List<Persona> obtenerPersonasByEstatus(int estatus){
            return personas.FindAll(item => item.Estatus == estatus).ToList();
        }

        public void cambiarEstatus(int id, int estatus){
            personas.FirstOrDefault(item => item.Id == id).Estatus = estatus;
        }

    }
}