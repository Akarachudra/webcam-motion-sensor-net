using System.Threading.Tasks;

namespace WebcamMotion.Classes
{
    public interface IGoogleDriveClient
    {
        void Init();
        Task<bool> UploadJpeg(string path);
    }
}