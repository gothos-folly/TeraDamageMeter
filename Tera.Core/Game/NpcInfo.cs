using System;

namespace Tera.Game
{
    public class NpcInfo
    {
        public ushort HuntingZoneId { get;private set; }
        public int TemplateId { get;private set; }
        public string Name { get; private set; }

        public NpcInfo(ushort huntingZoneId, int templateId, string name)
        {
            HuntingZoneId = huntingZoneId;
            TemplateId = templateId;
            Name = name;
        }
    }
}
