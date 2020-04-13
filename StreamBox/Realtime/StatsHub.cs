using Microsoft.AspNetCore.SignalR;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StreamBox.Realtime
{
    public class StatsHub : Hub
    {
        public async Task Statistics()
        {
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            PerformanceCounter ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            PerformanceCounter uptimeCounter = new PerformanceCounter("System", "System Up Time");
            cpuCounter.NextValue();
            ramCounter.NextValue();
            uptimeCounter.NextValue();
            System.Threading.Thread.Sleep(1000);
            TimeSpan upTimeSpan = TimeSpan.FromSeconds(uptimeCounter.NextValue());
            object dataObject = new
            {
                cpu = decimal.Parse(cpuCounter.NextValue().ToString("0.00")) + "%",
                ram = decimal.Parse((ramCounter.NextValue() / 1024).ToString("0.00")) + "GB Free",
                uptime = string.Format("{0}:{1}:{2}", ((int)upTimeSpan.TotalHours), upTimeSpan.Minutes, upTimeSpan.Seconds)
            };
            await Clients.All.SendAsync("Statistics", dataObject);
        }
    }
}
