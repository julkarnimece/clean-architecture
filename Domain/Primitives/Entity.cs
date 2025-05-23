﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class Entity : IEquatable<Entity>
    {

        protected Entity(Guid id)
        {
            Id = id;
        }

        protected Entity()
        {
           
        }
        public Guid Id { get; private set; }


        public static bool operator == (Entity left, Entity right)
        {
            
            return left is not null && right is not null && left.Equals(right);
        }

        public static bool operator != (Entity left, Entity right)
        {
            return !(left == right);
        }

        public override bool Equals(object? obj)
        {
            if(obj is null)
            {
                return false;
            }

            if(obj.GetType() != GetType())
            {
                return false;   
            }

            if(obj is not Entity entity)
            {
                return false;
            }


            return entity.Id == Id;
        }


        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.GetType() != GetType())
            {
                return false;
            }


            return other.Id == Id;
        }
    }
}
