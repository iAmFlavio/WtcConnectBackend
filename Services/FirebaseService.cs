using FirebaseAdmin.Messaging;

namespace WtcConnectBackend.Services
{
    public class FirebaseService
    {
        public async Task<bool> SendPushNotificationAsync(string deviceToken, string title, string body)
        {
            try
            {
                var message = new Message()
                {
                    Token = deviceToken,
                    Notification = new Notification()
                    {
                        Title = title,
                        Body = body
                    }
                };

                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                Console.WriteLine($"[FIREBASE] Push enviado com sucesso! ID: {response}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[FIREBASE_ERRO] Falha ao enviar: {ex.Message}");
                return false;
            }
        }
    }
}