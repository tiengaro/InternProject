using Realms;

namespace InternProject.Models
{
    public class TypeTransaction : RealmObject
    {
        [PrimaryKey]
        public int IdType { get; set; }

        public string TypeName { get; set; }
    }
}