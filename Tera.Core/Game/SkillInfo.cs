// Copyright (c) Gothos
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Tera.Game
{
    public class SkillInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        internal SkillInfo(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class UserSkillInfo : SkillInfo
    {
        public RaceGenderClass RaceGenderClass { get; private set; }

        public UserSkillInfo(int id, RaceGenderClass raceGenderClass, string name)
            : base(id, name)
        {
            RaceGenderClass = raceGenderClass;
        }

        public override bool Equals(object obj)
        {
            var other = obj as UserSkillInfo;
            if (other == null)
                return false;
            return (Id == other.Id) && (RaceGenderClass.Equals(other.RaceGenderClass));
        }

        public override int GetHashCode()
        {
            return Id + RaceGenderClass.GetHashCode();
        }
    }
}