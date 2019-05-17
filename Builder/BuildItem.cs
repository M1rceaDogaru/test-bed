using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    enum ResourceType
    {
        Iron,
        Silicate,
        Titanium,
        Crystalite
    }

    class BuildItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<ResourceType, int> ResourceCost { get; set; }
        public string Prefab { get; set; }
    }
}
