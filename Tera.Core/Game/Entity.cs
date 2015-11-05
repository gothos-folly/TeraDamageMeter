// Copyright (c) Gothos
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Tera.Game
{
    // An object with an Id that can be spawned or deswpawned in the game world
    public class Entity
    {
        public EntityId Id { get; private set; }

        public Entity(EntityId id)
        {
            Id = id;
        }

        public override string ToString()
        {
            var result= string.Format("{0} {1}", GetType().Name, Id);
            if (RootOwner != this)
                result = string.Format("{0} owned by {1}", result, RootOwner);
            return result;
        }
        
        public Entity RootOwner
        {
            get
            {
                var entity = this;
                var ownedEntity = entity as IHasOwner;
                while (ownedEntity != null && ownedEntity.Owner != null)
                {
                    entity = ownedEntity.Owner;
                    ownedEntity = entity as IHasOwner;
                }
                return entity;
            }
        }
    }
}
