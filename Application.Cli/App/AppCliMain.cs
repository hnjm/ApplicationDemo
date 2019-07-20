﻿namespace Application.Cli
{
    using Database.Demo; // Framework and Application contain same namespace.
    using DatabaseBuiltIn.Demo;
    using Framework.Cli.Command;
    using Framework.Cli.Config;
    using Framework.DataAccessLayer;
    using Microsoft.Extensions.CommandLineUtils;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Command line interface application.
    /// </summary>
    public class AppCliMain : AppCli
    {
        public AppCliMain() : 
            base(
                typeof(CountryDisplayCache).Assembly, // Register Application.Database dll
                typeof(AppMain).Assembly) // Register Application dll
        {

        }

        protected override void RegisterCommand()
        {
            new MyCommand(this);

            base.RegisterCommand();
        }

        /// <summary>
        /// Set default values if file ConfigCli.json does not exist.
        /// </summary>
        protected override void InitConfigCli(ConfigCli configCli)
        {
            configCli.WebsiteList.Add(new ConfigCliWebsite()
            {
                AppTypeName = typeof(AppMain).FullName + ", " + typeof(AppMain).Namespace,
                FolderNameServer = "Default",
                DomainNameList = new List<string>(),
                FolderNameNpmBuild = "WebsiteDefault/",
                FolderNameDist = "WebsiteDefault/dist/",
            });
        }

        protected override void CommandGenerateBuiltIn(List<GenerateBuiltInItem> list)
        {
            // LanguageBuiltIn
            var rowList = Data.Select(Data.Query<LanguageBuiltIn>());
            list.Add(GenerateBuiltInItem.Create(rowList, true));

            // Navigation
            var navigationList = Data.Select(Data.Query<Navigation>());
            list.Add(GenerateBuiltInItem.Create(navigationList));
        }

        protected override void CommandDeployDbBuiltIn(List<DeployDbBuiltInItem> list)
        {
            list.Add(DeployDbBuiltInItem.Create(LanguageBuiltInTableApplication.RowList, nameof(LanguageBuiltIn.LanguageName), null));
            list.Add(DeployDbBuiltInItem.Create(NavigationTableApplicationCli.RowList, nameof(Navigation.PageName), null));
        }
    }

    public class MyCommand : CommandBase
    {
        public MyCommand(AppCli appCli) 
            : base(appCli, "My", "My command")
        {

        }

        public CommandOption My;

        protected override void Register(CommandLineApplication configuration)
        {
            this.My = configuration.Option("-m", "My Option", CommandOptionType.NoValue);
        }

        protected override void Execute()
        {
            Console.WriteLine("My");
            if (My.Value() == "on")
            {
                Console.WriteLine("With option");
            }
        }
    }
}
