using Google.Cloud.Firestore;
using System.Threading.Tasks;

namespace FirestoreExample.Firestore
{
    public interface IFirestoreHelper
    {
        Task<DocumentReference> GetOutgoingActivityDocumentAsync(IFirestoreAccountDetails request, int batchId);

        Task<FirestoreDb> GetDatabaseAsync();
    }

    public class FirestoreHelper : IFirestoreHelper
    {
        private readonly IFirestoreDatabaseProvider _firestoreDatabaseProvider;

        public FirestoreHelper(IFirestoreDatabaseProvider firestoreDatabaseProvider)
        {
            _firestoreDatabaseProvider = firestoreDatabaseProvider;
        }

        public (AccountType AccountType, int AccountId) GetAccountDetails(IFirestoreAccountDetails request) =>
            request.GroupAccountId.HasValue
                ? (AccountType.Group, request.GroupAccountId.Value)
                : (AccountType.User, request.StaffId);

        public string GetOrgPath(IFirestoreAccountDetails request) => GetOrgPath(request.OrganizationId);

        public string GetOrgPath(int orgId) => $"org-{orgId}-contacts";

        public Task<FirestoreDb> GetDatabaseAsync() => _firestoreDatabaseProvider.GetDatabaseAsync();
        
        public async Task<DocumentReference> GetOutgoingActivityDocumentAsync(IFirestoreAccountDetails request, int batchId)
        {
            var db = await _firestoreDatabaseProvider.GetDatabaseAsync();

            return db.Collection(GetOrgPath(request)).Document(GetAccountPath(request))
            .Collection("outgoing").Document($"batch-{batchId}");
        }
        
        private string GetAccountPath(IFirestoreAccountDetails request)
        {
            var accountDetails = GetAccountDetails(request);

            return $"{(accountDetails.AccountType == AccountType.Group ? "account" : "user")}-{accountDetails.AccountId}";
        }
    }
}
