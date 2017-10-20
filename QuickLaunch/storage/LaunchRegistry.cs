using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using QuickLaunch.helper;

namespace QuickLaunch.storage {
    public class LaunchRegistry {
        public static LaunchRegistry INSTANCE = new LaunchRegistry();

        private List<LaunchEntry> entries = new List<LaunchEntry>();

        private LaunchRegistry() { }

        public IEnumerable<LaunchEntry> Search(string searchTerm) {
            List<LaunchEntry> temp = new List<LaunchEntry>();
            foreach (LaunchEntry entry in entries) {
                if (entry.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) {
                    temp.Add(entry);
                    continue;
                }
                if (entry.Tags.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))) {
                    temp.Add(entry);
                    continue;
                }
                if (entry.Path.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) {
                    temp.Add(entry);
                }
            }
            return temp;
        }

        public static string ToJson() {
            JsonSerializerSettings settings = new JsonSerializerSettings() {
                ContractResolver = new PrivateMemberContractResolver()
            };
            return JsonConvert.SerializeObject(INSTANCE, settings);
        }
    }
}
