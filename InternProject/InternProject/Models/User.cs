using Realms;

namespace InternProject.Models
{
    public class User : RealmObject
    {
        [PrimaryKey]
        public string Username { get; set; }

        public string Password { get; set; }
        public string Phone { get; set; }
    }
}