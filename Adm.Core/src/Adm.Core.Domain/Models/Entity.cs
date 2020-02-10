using System;
using System.Collections.Generic;
using System.Text;

namespace RA.School.Proj.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
 