using log4net;
using WebcamMotion.FormsBase;

namespace WebcamMotion.Helpers
{
    public class FormLogger : IFormLogger
    {
        private ILoggableForm loggableForm;
        private bool formLogging = true;
        private readonly ILog log4NetLogger = LogManager.GetLogger(typeof(Program));

        public void Log(string message)
        {
            if (formLogging)
            {
                loggableForm?.LogToForm(message);
            }
            log4NetLogger.Info(message);
        }

        public void StopFormLogging()
        {
            formLogging = false;
        }

        public void InitForm(ILoggableForm form)
        {
            loggableForm = form;
        }
    }
}
