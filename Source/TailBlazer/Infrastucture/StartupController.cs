using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.Infrastucture.AppState;
using TailBlazer.LogViewer.Views.Tail;
using TailBlazer.Views.Formatting;
using TailBlazer.Views.WindowManagement;

namespace TailBlazer.Infrastucture
{
    public class StartupController
    {
        public StartupController(IObjectProvider objectProvider, ILogger logger,
            IApplicationStatePublisher applicationStatePublisher)
        {
            applicationStatePublisher.Publish(ApplicationState.Startup);

            logger.Info($"Starting Tail Blazer version v{Assembly.GetEntryAssembly().GetName().Version}");
            logger.Info($"at {DateTime.UtcNow}");

            //run start up jobs
            objectProvider.Get<FileHeaderNamingJob>();
            objectProvider.Get<UhandledExceptionHandler>();

            //TODO: Need type scanner then this code is not required
            var viewFactoryRegister = objectProvider.Get<IViewFactoryRegister>();
            viewFactoryRegister.Register<TailViewModelFactory>();

            objectProvider.Get<SystemSetterJob>();

            logger.Info("Starting complete");
        }
    }
}
