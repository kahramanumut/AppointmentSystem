using System;
using System.ComponentModel.DataAnnotations;

namespace RandevuTakip.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            UserGuidId = Guid.NewGuid().ToString();
        }
        public int Id { get; set; }
        public string UserGuidId { get; set; }
    }
}
