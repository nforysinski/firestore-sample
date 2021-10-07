namespace FirestoreExample.Firestore
{
    public interface IFirestoreAccountDetails
    {
        int? GroupAccountId { get; }
        int StaffId { get; }
        int OrganizationId { get; }
    }

    public class FirestoreAccountDetails : IFirestoreAccountDetails
    {
        public int? GroupAccountId { get; set; }
        public int StaffId { get; set; }
        public int OrganizationId { get; set; }

        public FirestoreAccountDetails(int organizationId, int staffId, int? groupAccountId = null)
        {
            OrganizationId = organizationId;
            StaffId = staffId;
            GroupAccountId = groupAccountId;
        }
    }
}
