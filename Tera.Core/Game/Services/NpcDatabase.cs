using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tera.Game
{
    public class NpcDatabase
    {
        private readonly Dictionary<Tuple<ushort, int>, NpcInfo> _dictionary;
        private readonly Func<Tuple<ushort, int>, NpcInfo> _getPlaceholder;

        public NpcDatabase(IEnumerable<NpcInfo> npcInfo)
        {
            _dictionary = npcInfo.ToDictionary(x => Tuple.Create(x.HuntingZoneId, x.TemplateId));
            _getPlaceholder = Helpers.Memoize<Tuple<ushort, int>, NpcInfo>(x => new NpcInfo(x.Item1, x.Item2, string.Format("Npc {0} {1}", x.Item1, x.Item2)));
        }

        private static IEnumerable<NpcInfo> LoadNpcInfos(string filename)
        {
            var lines = File.ReadLines(filename);
            var listOfParts = lines.Select(s => s.Split(new[] { ' ' }, 3));
            return listOfParts.Select(parts => new NpcInfo(ushort.Parse(parts[0]), int.Parse(parts[1]), parts[2]));
        }

        public NpcDatabase(string filename)
            : this(LoadNpcInfos(filename))
        {

        }

        public NpcInfo GetOrNull(ushort huntingZoneId, int templateId)
        {
            NpcInfo result;
            _dictionary.TryGetValue(Tuple.Create(huntingZoneId, templateId), out result);
            return result;
        }

        public NpcInfo GetOrPlaceholder(ushort huntingZoneId, int templateId)
        {
            return GetOrNull(huntingZoneId, templateId) ?? _getPlaceholder(Tuple.Create(huntingZoneId, templateId));
        }
    }
}
