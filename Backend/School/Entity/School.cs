﻿using System.Collections.Generic;
using Core;
using Core.Entities;
using NodaTime;

namespace School.Entity
{
    public class School : ICreated, IUpdated
    {
        public int SchoolId { get; set; }

        public string Name { get; set; }
        public Address Address { get; set; }

        
        public ICollection<Teacher> Teachers { get; set; }


        public Instant Created { get; set; }
        public Instant Updated { get; set; }
    }
}