﻿using System;

namespace Persistance.Entities
{
    public partial class Meal
    {
        public Meal() { }

        public Meal(Meal entity)
        {
            Id = entity.Id;
            AccountId = entity.AccountId;
            Datetime = entity.Datetime;
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Datetime { get; set; }
    }
}
