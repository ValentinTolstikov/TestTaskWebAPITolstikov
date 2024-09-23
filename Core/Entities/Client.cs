using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Client : BaseEntity
    {
        public Client() { }

        public Client(int id,string inn, string name, DateTime dateAdd, DateTime dateEdit, int userTypeId) 
        {
            Id = id;
            INN = inn;
            Name = name;
            DateAdd = dateAdd;
            DateEdit = dateEdit;
            UserTypeId = userTypeId;
        }

        [Column(TypeName = "nvarchar(12)")]
        [MinLength(10)]
        public string INN { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdd { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateEdit { get; set; }

        public int UserTypeId { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }
    }
}
