using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskWebAPI.DTOs
{
    public class ClientDTO : BaseEntity
    {
        public string INN { get; set; }

        public string Name { get; set; }

        public int TypeId { get; set; }
    }
}
