namespace FirestoreExample
{
    public class ConfigurationDocument
    {
        public FirestoreSection Firestore { get; set; }
        
        public ConfigurationDocument()
        {
            Firestore = new FirestoreSection
            {
                Project = "mongoose-test-01", //todo: configure me
                Credential = "{\n  \"type\": \"service_account\",\n  \"project_id\": \"mongoose-test-01\",\n  \"private_key_id\": \"6f11eeab37bbd8dd66ec570c631db6ac4b672959\",\n  \"private_key\": \"-----BEGIN PRIVATE KEY-----\\nMIIEvQIBADANBgkqhkiG9w0BAQEFAASCBKcwggSjAgEAAoIBAQC8yf5fSDcqQW50\\nBodOWtHwDS/BKF2qJVOzV4OFtme6C1YFdD3i8NWVd0j2h5h8ZbrmoH4jxOE3kGZP\\nLEOmO2tRmqZ1wS1sIOyapUrYlPEPl2P3cDe++LFjKRWTQpaGWG9JeOm0y2e/tL4K\\nnLwfQF4tdBfGISLldsJVx3yFvMjgmuuEckZtWmBIc4Q26Y2JRWtIzaSeQReIq/zT\\ndTDR4j3vSERlM0GPKYbuxvuC4P8v7kiguq5dx15q81gxyoNVIeUlV68+9KiE4y/b\\ndnEEj5Qu6lPPXAezSsIntAM4jvnJKj3L6UdaKvRNyVbnxEh2xili6mJln+NxJM20\\nHh4y+CEzAgMBAAECggEAMlea4UWckEQKdB4ZjqdhPCYICfX9pBV4EGbRx6IwXsgP\\nFD0/E3ktO0InzrWxz9pA0KcTe+5QMETtQ0eGcpl9sLEQmm388syEy2gwYTi2X3X7\\nTkw6UU533v1hp3cmNIT4iBsaFv/2loRX+PR6pcrAUlaW0Fqdt5rHj6A2cGM7Hck8\\nFuw7j9U+JMomwWrwqIa0ITPi24wpQc1xXrW0jfesWR8WoRQ81ZPWarvY1Ay2mOkD\\nW3CT6q/T0gKO6JR94UTM+9TG7XcJUcIs0x6cJKY4izfXfFsLFNN75NwUyAxaXyDY\\nkllnNoTyqQV9F9LM45xKayajWnb5xlQGA+CQ3bE/gQKBgQDy+xyoKktfcej6A7BA\\neRpDLInvm1lSZHCVfGpLluj6bbbNnJg512oImVLm6ICzGiMFLf086LEquad1AFic\\nDqqsbPlFwBZeidmtw2Wkm6ymHH//dfELZR3qVLthrTQXy0H76O7fjKpBK7NZdPdY\\nGIbIrJZYdVULGFdJoZd0yipj8QKBgQDG54zHKPjiVszvKjvoScbGQjvLwR4xVkp5\\ngIqGfNSqrf3AJEOjM4x1J8ZpkRh64OOEikvHbS4hYlWoyXK/DbTyg7magabvUrO/\\nEnLljsM2eU1JGKI/oe2M4GPGzwPkk9zG94QUe3fGrMb5Nd0Zwl5YOWOWm7TH3NlJ\\n1Ku9xGorYwKBgGgeaKo67W9pzW6M9BK8kh9kz3qoM/9VYNT9qkLX2N+u8d1rk+N9\\nRkeHA/pEeRnGQmluyow2Hezz/yjozA+bTVFzpOFZrXw3T9rg1wZRWwsXPVYHgRHj\\n84y9YEo7wQ3NIGpE509N5IrmogTcVT0fzWniYs5nANkvRgAcSV1XYBDRAoGAJuWB\\nEjFg+mIfEWYg8Pv8cyjgqKfLT7qgNcJ9VG905yu/Q6PT1kZuYTq2Ak7tipoP5Atn\\nZkhjjQO93JQIbHQxvnskAKL6EjMKE4N4FIwmgLCX/INktyzjV3lKCcbR7BE+S2p7\\n2cWLVr7S6kkuQ6tO59HRN9KbN7pog5ejPij62iECgYEAqqc1S/ZYnd+dUyma8IQa\\nulp1h7gGRLZi/lArsHKVxtrE5UFiziKcLcT7zTmL7YsmqUHHQFwaHE/QQsI0QfP9\\nQnUX3QSb4WlxSmfE7hZ11yq42UpNnPB1n9E1paeRyYcv7yzvz+g2Dw03OaiekaoC\\nt2D9fZk/isu3lTyXHtkQHzc=\\n-----END PRIVATE KEY-----\\n\",\n  \"client_email\": \"firebase-adminsdk-ec4u8@mongoose-test-01.iam.gserviceaccount.com\",\n  \"client_id\": \"105449221861059972444\",\n  \"auth_uri\": \"https://accounts.google.com/o/oauth2/auth\",\n  \"token_uri\": \"https://oauth2.googleapis.com/token\",\n  \"auth_provider_x509_cert_url\": \"https://www.googleapis.com/oauth2/v1/certs\",\n  \"client_x509_cert_url\": \"https://www.googleapis.com/robot/v1/metadata/x509/firebase-adminsdk-ec4u8%40mongoose-test-01.iam.gserviceaccount.com\"\n}" //todo: configure me
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
