using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;

namespace FirestoreExample.Firestore
{
    public interface IFirestoreDatabaseProvider
    {
        Task<FirestoreDb> GetDatabaseAsync();
    }

    public class FirestoreDatabaseProvider : IFirestoreDatabaseProvider
    {
        private readonly IConfigProvider _configProvider;
        private FirestoreClient _client;

        public FirestoreDatabaseProvider(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
            InitializeChannel();
        }

        private void InitializeChannel()
        {
            var credential = GoogleCredential.FromJson(_configProvider.Config.Firestore.Credential);
            var channelCredentials = credential.ToChannelCredentials();
            var builder = new FirestoreClientBuilder()
            {
                ChannelCredentials = channelCredentials
            };

            _client = builder.Build();
        }

        public Task<FirestoreDb> GetDatabaseAsync() =>
            FirestoreDb.CreateAsync(_configProvider.Config.Firestore.Project, _client);
    }
}