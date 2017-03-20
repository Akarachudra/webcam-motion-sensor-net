using System;
using System.Windows.Forms;
using SimpleInjector;
using WebcamMotion.Classes;
using WebcamMotion.Helpers;
using WebcamMotion.Resources;

namespace WebcamMotion
{
    internal static class Program
    {
        private static readonly Container Container;

        static Program()
        {
            Container = new Container();

            Container.Register<ISettingsController, SettingsController>(Lifestyle.Singleton);
            Container.Register<IFormLogger, FormLogger>(Lifestyle.Singleton);
            Container.Register<IMotionController, MotionController>(Lifestyle.Singleton);
            Container.Register<IGoogleDriveClient, GoogleDriveClient>(Lifestyle.Singleton);
            Container.Register<IStringResources, StringResources>(Lifestyle.Singleton);
            Container.Register<ITelegramClientWrapper, TelegramClientWrapper>(Lifestyle.Singleton);

            Container.Verify();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(Container.GetInstance<IStringResources>(),
                Container.GetInstance<IGoogleDriveClient>(),
                Container.GetInstance<ISettingsController>(),
                Container.GetInstance<IMotionController>(),
                Container.GetInstance<IFormLogger>(),
                Container.GetInstance<ITelegramClientWrapper>()));
        }
    }
}