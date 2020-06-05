using System;
using System.Reflection;
using TailBlazer.Domain.FileHandling.Recent;
using TailBlazer.Domain.FileHandling.TextAssociations;
using TailBlazer.Domain.Formatting;
using TailBlazer.Domain.Infrastructure;
using TailBlazer.Domain.Settings;
using TailBlazer.Domain.StateHandling;
using TailBlazer.LogViewer.Views.Recent;
using TailBlazer.LogViewer.Views.Searching;

namespace TailBlazer.LogViewer.Infrastucture
{
    public class StartupController
    {
        public StartupController(IObjectProvider objectProvider, ILogger logger)
        {
            logger.Info($"Starting Tail Blazer version v{Assembly.GetEntryAssembly().GetName().Version}");
            logger.Info($"at {DateTime.UtcNow}");

            var settingsRegister = objectProvider.Get<ISettingsRegister>();
            settingsRegister.Register(new GeneralOptionsConverter(), "GeneralOptions");
            settingsRegister.Register(new RecentFilesToStateConverter(), "RecentFiles");
            settingsRegister.Register(new StateBucketConverter(), "BucketOfState");
            settingsRegister.Register(new RecentSearchToStateConverter(), "RecentSearch");
            settingsRegister.Register(new TextAssociationToStateConverter(), "TextAssociation");
            settingsRegister.Register(new SearchMetadataToStateConverter(), "GlobalSearch");

            logger.Info("Starting complete");
        }
    }
}