using System;
using System.Threading.Tasks;
using Grpc.Core;
using Polly;

namespace FirestoreExample.Firestore
{
    public interface IFirestoreRequestProcessor
    {
        Task ExecuteWithRetry(string requestName, string documentPath, Func<Task> action);
    }

    public class FirestoreRequestProcessor : IFirestoreRequestProcessor
    {
        public async Task ExecuteWithRetry(string requestName, string documentPath, Func<Task> action)
        {
            var jitterer = new Random();
            var timer = System.Diagnostics.Stopwatch.StartNew();
            try
            {
                await Policy
                    .Handle<RpcException>()
                    .WaitAndRetryAsync(5, retryAttempt =>
                            TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                            + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)),
                        (exception, span, count, context) =>
                        {
                            //application insights tracking usually here
                        })
                    .ExecuteAsync(action);
            }
            finally
            {
                timer.Stop();
            }
        }
    }
}