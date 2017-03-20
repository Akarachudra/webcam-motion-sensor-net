using WebcamMotion.FormsBase;

namespace WebcamMotion.Helpers
{
    public interface IFormLogger
    {
        void InitForm(ILoggableForm form);
        void Log(string message);
        void StopFormLogging();
    }
}