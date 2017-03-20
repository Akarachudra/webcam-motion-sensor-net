using System.IO;
using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core;
using TLSharp.Core.Utils;

namespace WebcamMotion.Classes
{
    public class TelegramClientWrapper : ITelegramClientWrapper
    {
        private const int ApiId = 62457;
        private const string ApiHash = "978bb3769f15bde2730b84bdc94c9768";
        private readonly TelegramClient telegramClient;
        private bool isInited;

        public TelegramClientWrapper()
        {
            telegramClient = new TelegramClient(ApiId, ApiHash);
        }

        public async void Init()
        {
            if (isInited) return;
            await telegramClient.ConnectAsync();
            isInited = true;
        }

        public async void SendMessageToSelf(string message)
        {
            if (!isInited) return;
            await telegramClient.SendMessageAsync(new TLInputPeerSelf(), message);
        }

        public bool IsSessionActive()
        {
            return telegramClient.IsUserAuthorized();
        }

        public Task<string> SendCodeAsync(string phoneNumber)
        {
            return telegramClient.SendCodeRequestAsync(phoneNumber);
        }

        public async Task LoginAsync(string phoneNumber, string hash, string code)
        {
            await telegramClient.MakeAuthAsync(phoneNumber, hash, code);
        }

        public async void SendPhotoToSelf(string filePath, string message)
        {
            if (!isInited) return;
            var fileResult = await telegramClient.UploadFile(Path.GetFileName(filePath), new StreamReader(filePath));
            await telegramClient.SendUploadedPhoto(new TLInputPeerSelf(), fileResult, message);
        }
    }
}
