using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using HidLibrary;
using LedMessageBoard.DisplayAdapters;

namespace LedMessageBoard
{
    /// <summary>
    /// The "system tray" version of the application
    /// </summary>
    internal class TrayApplication : ApplicationContext
    {
        private const int VendorID = 0x1D34;
        private const int ProductID = 0x0013;

        private HidDevice device;

        private readonly NotifyIcon trayIcon;

        private readonly ConfigurationForm configurationForm;

        private IDisplayAdapter[] adapters;

        private int adapterIndex = 0;

        private System.Timers.Timer timer;

        public TrayApplication()
        {
            this.configurationForm = new ConfigurationForm();
            this.configurationForm.Visible = false;

            this.configurationForm.OnConfigurationUpdated += this.ConfigurationUpdated;

            var connectMenu = new MenuItem(LedMessageBoard.Properties.Resources.ConnectMenuItem, this.OnConnect);

            var configureMenu = new MenuItem(LedMessageBoard.Properties.Resources.ConfigureMenuItem, this.OnConfigure);

            var exitMenu = new MenuItem(LedMessageBoard.Properties.Resources.ExitMenuItem, this.OnExit);

            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(connectMenu);
            contextMenu.MenuItems.Add("-");
            contextMenu.MenuItems.Add(configureMenu);
            contextMenu.MenuItems.Add(exitMenu);

            this.trayIcon = new NotifyIcon
                                {
                                    Icon = LedMessageBoard.Properties.Resources.LMB,
                                    Text = LedMessageBoard.Properties.Resources.TrayText,
                                    ContextMenu = contextMenu,
                                    Visible = true
                                };

            this.ConfigurationUpdated(null, null);
        }

        private void ConfigurationUpdated(object sender, EventArgs e)
        {
            if (this.timer != null)
            {
                this.timer.Enabled = false;
            }

            this.adapterIndex = 0;

            this.adapters = this.configurationForm.ActiveDisplayAdapters;

            this.timer = new System.Timers.Timer(LedMessageBoard.Properties.Settings.Default.Global_RefreshRate);
            this.timer.Elapsed += this.OnTimerElapsed;
            this.timer.Enabled = true;
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (device == null)
            {
                return;
            }

            if (this.adapters.Length == 0)
            {
                return;
            }

            if (this.adapters[this.adapterIndex].DisplayComplete)
            {
                this.adapterIndex++;
                if (this.adapterIndex >= this.adapters.Length)
                {
                    this.adapterIndex = 0;
                }

                this.adapters[this.adapterIndex].Reset();
            }

            this.adapters[this.adapterIndex].Draw(this.device, LedMessageBoard.Properties.Settings.Default.Global_Brightness);
        }

        private void OnConnect(object sender, EventArgs e)
        {
            if (this.device == null)
            {
                this.device = HidDevices.Enumerate(VendorID, ProductID).FirstOrDefault();

                if (this.device == null)
                {
                    return;
                }

                this.device.OpenDevice();
                this.device.Removed += this.DeviceRemovedHandler;
                this.device.MonitorDeviceEvents = true;

                this.trayIcon.ContextMenu.MenuItems[0].Checked = true;
            }
            else
            {
                this.device.CloseDevice();
                this.device = null;

                this.trayIcon.ContextMenu.MenuItems[0].Checked = false;
            }
        }

        private void OnExit(object sender, EventArgs e)
        {
            if (this.device != null)
            {
                device.CloseDevice();
            }

            this.configurationForm.Close();

            this.trayIcon.Visible = false;

            Application.Exit();
        }

        private void OnConfigure(object sender, EventArgs e)
        {
            this.configurationForm.Visible = true;
        }

        private void DeviceRemovedHandler()
        {
            this.trayIcon.ContextMenu.MenuItems[0].Checked = false;
            this.device = null;
        }
    }
}
