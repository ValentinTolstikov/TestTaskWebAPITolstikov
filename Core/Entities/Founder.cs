using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Founder : BaseEntity
    {
        public Founder() { }

        public Founder(int id, string inn, string surname, string name, string patronumic, DateTime dateAdd, DateTime dateEdit, int clientId)
        {
            Id = id;
            INN = inn;
            Surname = surname;
            Name = name;
            Patronumic = patronumic;
            DateAdd = dateAdd;
            DateEdit = dateEdit;
            ClientId = clientId;
        }

        [Column(TypeName = "nvarchar(12)")]
        [MinLength(12)]
        public string INN { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Patronumic { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdd { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateEdit { get; set; }

        public int ClientId { get; set; }

        [JsonIgnore]
        public virtual Client Client { get; set; }
    }
}
