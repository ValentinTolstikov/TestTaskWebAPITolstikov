using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class UserType : BaseEntity
    {
        [Column(TypeName = "nvarchar(250)")]
        public string TypeName { get; set; }

        public virtual ICollection<Client> Users { get; set; }
    }
}
