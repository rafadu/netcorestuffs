namespace clientsApi
{
    public class Cliente{
        public long id {get; set;}
        public string nome {get; set;}
        public string email {get; set;}

        public Cliente(long id, string nome, string email){
            this.id = id;
            this.nome = nome;
            this.email = email;
        }

        public Cliente(string nome, string email)
            : this(0,nome,email)
        {  }
    }
}