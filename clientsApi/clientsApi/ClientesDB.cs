using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace clientsApi
{
    public static class ClientesDB
    {
        private static List<Cliente> clientes = new List<Cliente>();

        public static void CreateDB(int quantidade){
            clientes.Clear();
            for(var i = 0; i < quantidade; i++){
                Cliente novoCliente = new Cliente(i,$"Cliente {i}",$"customer{i}@gmail.com");
                clientes.Add(novoCliente);
            }
        }

        public static IList<Cliente> GetAll(){
            return clientes;
        }

        public static Cliente GetById(long id) => clientes.Where(c => c.id == id).FirstOrDefault();

        public static IList<Cliente> GetByNome(string nome) => clientes.Where(c => c.nome.Contains(nome)).ToList();

        public static long GetDBAmount() => clientes.Count;

        public static void AddCliente(Cliente novoCliente){
            clientes.Add(novoCliente);
        }

        public static void deleteCliente(long id) => clientes.Remove(clientes.Where(c => c.id == id).FirstOrDefault());
    }
}