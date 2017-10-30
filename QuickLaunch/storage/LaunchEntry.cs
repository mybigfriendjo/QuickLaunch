using System.Collections.Generic;

namespace QuickLaunch.storage {
    public class LaunchEntry {
        public List<LaunchEntry> Children {
            get;
            set;
        }

        public LaunchEntry Parent {
            get;
            set;
        }

        public bool IsGroup {
            get;
            set;
        }

        public string Name {
            get;
            set;
        }

        public string Path {
            get;
            set;
        }

        public string[] Tags {
            get;
            set;
        }

        public int ImageListIndex {
            get;
            set;
        }
    }
}
