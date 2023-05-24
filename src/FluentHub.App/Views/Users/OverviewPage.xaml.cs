// Copyright (c) FluentHub
// Licensed under the MIT License. See the LICENSE.

using FluentHub.App.Services;
using FluentHub.App.ViewModels.Users;
using FluentHub.Core.Data.Enums;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;

namespace FluentHub.App.Views.Users
{
    public sealed partial class OverviewPage : LocatablePage
    {
        public OverviewPage()
            : base(NavigationBarPageKind.User, NavigationBarItemKey.Overview)
        {
            InitializeComponent();

            var provider = App.Current.Services;
            ViewModel = provider.GetRequiredService<OverviewViewModel>();
        }

        public OverviewViewModel ViewModel { get; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var param = e.Parameter as Models.FrameNavigationArgs;
            _ = param ?? throw new ArgumentNullException("param");

            ViewModel.Login = param.Login;

            ViewModel.ContextViewModel = new ViewModels.Repositories.RepoContextViewModel()
            {
                Repository = new()
                {
                    Name = ViewModel.Login,

                    Owner = new RepositoryOwner()
                    {
                        Login = ViewModel.Login,
                    },
                }
            };

            var command = ViewModel.LoadUserOverviewCommand;
            if (command.CanExecute(null))
                command.Execute(null);
        }
    }
}
