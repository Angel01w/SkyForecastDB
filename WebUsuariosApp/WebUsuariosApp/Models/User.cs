namespace WebUsuariosApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // Constructor por defecto
        public User() { }

        // Constructor con parámetros
        public User(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        // Método para mostrar los datos del usuario
        public override string ToString()
        {
            return $"Id: {Id}, UserName: {UserName}, Password: {Password}";
        }
    }
}
