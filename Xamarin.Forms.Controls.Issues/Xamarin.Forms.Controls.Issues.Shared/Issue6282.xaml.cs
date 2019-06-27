﻿using System.Threading;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 6282, "Text on button loses center alignment on changing of IsEnabled", PlatformAffected.Android)]
	public partial class Issue6282 : ContentPage
	{
		public Issue6282()
		{
#if APP
			InitializeComponent();
			new Thread(() =>
			{
				Thread.Sleep(1000);
				SwitchIsEnabled();
				Thread.Sleep(1500);
				SwitchIsEnabled();
				Thread.Sleep(1000);
				SwitchIsEnabled();
			}).Start();
#endif
		}

#if APP
		void SwitchIsEnabled() => Device.BeginInvokeOnMainThread(() => button.IsEnabled = buttonMaterial.IsEnabled = !button.IsEnabled);
#endif
	}
}
