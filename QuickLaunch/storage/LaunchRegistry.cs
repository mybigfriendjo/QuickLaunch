using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using QuickLaunch.helper;

namespace QuickLaunch.storage {
    public class LaunchRegistry {
        // ReSharper disable once InconsistentNaming
        public static LaunchRegistry INSTANCE = new LaunchRegistry();
        private static readonly ByteComparer byteComparer = new ByteComparer();

        public readonly List<LaunchEntry> Entries = new List<LaunchEntry>();
        private readonly Dictionary<int, byte[]> images = new Dictionary<int, byte[]>();

        private LaunchRegistry() { }

        public IEnumerable<LaunchEntry> Search(string searchTerm) {
            List<LaunchEntry> searchResult = new List<LaunchEntry>();
            foreach (LaunchEntry entry in Entries) {
                if (entry.IsGroup) {
                    SearchChildren(searchResult, entry, searchTerm);
                    continue;
                }
                if (entry.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) {
                    searchResult.Add(entry);
                    continue;
                }
                if (entry.Tags.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))) {
                    searchResult.Add(entry);
                    continue;
                }
                if (entry.Path.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) {
                    searchResult.Add(entry);
                }
            }
            return searchResult;
        }

        private static void SearchChildren(ICollection<LaunchEntry> searchResult, LaunchEntry entry, string searchTerm) {
            foreach (LaunchEntry child in entry.Children) {
                if (child.IsGroup) {
                    SearchChildren(searchResult, entry, searchTerm);
                    continue;
                }
                if (child.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) {
                    searchResult.Add(entry);
                    continue;
                }
                if (child.Tags.Any(tag => tag.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))) {
                    searchResult.Add(entry);
                    continue;
                }
                if (child.Path.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) {
                    searchResult.Add(entry);
                }
            }
        }

        public Image GetIconImage(int posInImageList) {
            using (MemoryStream ms = new MemoryStream(images[posInImageList])) {
                return Image.FromStream(ms);
            }
        }

        public int AddIconImage(Image image) {
            byte[] temp;
            using (MemoryStream ms = new MemoryStream()) {
                image.Save(ms, image.RawFormat);
                temp = ms.ToArray();
            }

            foreach (KeyValuePair<int, byte[]> current in images) {
                if (byteComparer.Equals(temp, current.Value)) {
                    return current.Key;
                }
            }

            for (int i = 0; i < int.MaxValue; i++) {
                if (images.ContainsKey(i)) {
                    continue;
                }
                images.Add(i, temp);
                return i;
            }
            throw new IndexOutOfRangeException("Too many Images in ImageList");
        }

        public static string ToJson() {
            JsonSerializerSettings settings = new JsonSerializerSettings() {
                ContractResolver = new PrivateMemberContractResolver()
            };
            return JsonConvert.SerializeObject(INSTANCE, settings);
        }

        private class ByteComparer : IEqualityComparer<byte[]> {
            public ByteComparer() {
            }

            public bool Equals(byte[] x, byte[] y) {
                if (x == null || y == null) {
                    return x == y;
                }
                return x.SequenceEqual(y);
            }

            public int GetHashCode(byte[] x) {
                return x.Sum(y => y);
            }
        }
    }
}
