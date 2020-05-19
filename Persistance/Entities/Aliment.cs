using System;

namespace Persistance.Entities
{
    public partial class Aliment
    {
        public Aliment() { }

        public Aliment(Aliment entity)
        {
            Id = entity.Id;
            AccountId = entity.AccountId;
            Name = entity.Name;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
    }
}
