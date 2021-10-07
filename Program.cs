using Autofac;
using FirestoreExample.Firestore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirestoreExample
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            await using var scope = AutofacContainer.BuildContainer().BeginLifetimeScope();

            var firestoreHelper = scope.Resolve<IFirestoreHelper>();
            var firestoreRequestProcessor = scope.Resolve<IFirestoreRequestProcessor>();

            var batchId = new Random().Next(1000000); //randomizing this to create different batches each time its run

            await InitBatch(firestoreHelper, batchId, firestoreRequestProcessor);
        }

        private static async Task InitBatch(IFirestoreHelper firestoreHelper, int batchId, IFirestoreRequestProcessor firestoreRequestProcessor)
        {
            var document =
                await firestoreHelper.GetOutgoingActivityDocumentAsync(new FirestoreAccountDetails(1, 7, 140), batchId);
            var trackingDocument = (await firestoreHelper.GetDatabaseAsync()).Collection("outgoing-activity").Document();

            var data = new
            {
                campaign = "some string",
                campaignId = 1, //just an internal id
                composeDate = DateTime.UtcNow.ToString("s"),
                completeDate = DateTime.UtcNow.ToString("s"),
                message = "a sometimes very long string up to maybe 300ish characters",
                segments = new List<string> { "1", "2", "3" },
                sendAsStaff = false,
                sentBy = "john doe",
                status = "sent",
                totalRecipients = 32,
                totalSent = 2, //this get incremented by an outside process later
                deliveryFailures = 1, //this get incremented by an outside process later
                batchId = batchId, //just an internal id
                isComplete = false,
                target = string.Empty,
                filter = string.Empty,
                student = "Thomas Smith",
                staffId = 7, //just an internal id
                accountId = 140, //just an internal id
                totalReplies = 0,
                media = new List<string>(),
                departmentId = 1, //just an internal id
                departmentName = "Event Organizing",
                smartMessageId = 1, //just an internal id
                smartMessageName = "Sign up reminder",
                messageName = "Weekly signup reminder"
            };

            var createBatchTask = document.CreateAsync(data);

            var trackingDoc = new
            {
                documentPath = document,
                batchId = 31,
                retentionDate = DateTime.UtcNow.AddDays(121).ToString("s")
            };

            var createTrackingTask = trackingDocument.CreateAsync(trackingDoc);

            await firestoreRequestProcessor.ExecuteWithRetry("Create Batch Doc", document.Path,
                (Func<Task>)(() => createBatchTask));
            await firestoreRequestProcessor.ExecuteWithRetry("Create Batch Tracking Doc", trackingDocument.Path,
                (Func<Task>)(() => createTrackingTask));
        }
    }
}
