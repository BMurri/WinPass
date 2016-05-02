﻿using System;
using System.Windows.Navigation;
using KeePass.I18n;
using KeePass.Utils;

namespace KeePass
{
    public partial class AnalyticsSettings
    {
        public AnalyticsSettings()
        {
            InitializeComponent();
            AppButton(0).Text = Strings.AnalyticsSettings_Allow;
            AppButton(1).Text = Strings.AnalyticsSettings_Disable;
        }

        protected override void OnBackKeyPress(
            System.ComponentModel.CancelEventArgs e)
        {
            var settings = AppSettings.Instance;
            var justInstalled = settings.AllowAnalytics == null;

            if (justInstalled)
                this.ClearBackStack();

            base.OnBackKeyPress(e);
        }

        protected override void OnNavigatedTo(
            bool cancelled, NavigationEventArgs e)
        {
            if (cancelled)
                return;

            var settings = AppSettings.Instance;
            lblDevice.Text = settings.InstanceID;
        }

        private void cmdAllow_Click(object sender, EventArgs e)
        {
            var settings = AppSettings.Instance;
            var justInstalled = settings.AllowAnalytics == null;
            settings.AllowAnalytics = true;

            NavigationService.GoBack();
        }

        private void cmdDisable_Click(object sender, EventArgs e)
        {
            AppSettings.Instance
                .AllowAnalytics = false;
            
            NavigationService.GoBack();
        }
    }
}