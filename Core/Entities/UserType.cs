using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class UserType : BaseEntity
    {
        public UserType() { }

        public UserType(int id, string typename) 
        {
            Id = id;
            TypeName = typename;
        }

        [Column(TypeName = "nvarchar(250)")]
        public string TypeName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Client> Users { get; set; }
    }
}
