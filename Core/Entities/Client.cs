﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class Client : BaseEntity
    {
        [Column(TypeName = "nvarchar(12)")]
        public string INN { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Name { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateAdd { get; set; }

        [Column(TypeName = "Date")]
        public DateTime DateEdit { get; set; }

        public int TypeId { get; set; }

        [JsonIgnore]
        public virtual UserType UserType { get; set; }
    }
}
