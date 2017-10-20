namespace QuickLaunch.storage {
    public class LaunchEntry {
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
