namespace FirestoreExample
{
    public class ConfigurationDocument
    {
        public FirestoreSection Firestore { get; set; }
        
        public ConfigurationDocument()
        {
            Firestore = new FirestoreSection
            {
                Project = "", //todo: configure me
                Credential = "" //todo: configure me
            };
        }

        public class FirestoreSection
        {
            public string Project { get; set; }
            public string Credential { get; set; }
        }
    }

    public interface IConfigProvider
    {
        ConfigurationDocument Config { get; }
    }

    public class ConfigProvider : IConfigProvider
    {
        public ConfigurationDocument Config { get; }

        public ConfigProvider()
        {
            Config = new ConfigurationDocument();
        }
    }
}
