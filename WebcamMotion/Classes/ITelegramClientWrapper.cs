using System.Threading.Tasks;

namespace WebcamMotion.Classes
{
    public interface ITelegramClientWrapper
    {
        void Init();
        void SendMessageToSelf(string message);
        void SendPhotoToSelf(string filePath, string message);
        bool IsSessionActive();
        Task<string> SendCodeAsync(string phoneNumber);
        Task LoginAsync(string phoneNumber, string hash, string code);
    }
}
