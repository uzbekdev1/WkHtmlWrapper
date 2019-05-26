using System.Diagnostics;
using System.Threading.Tasks;
using WkHtmlWrapper.Core.Services.Interfaces;

namespace WkHtmlWrapper.Core.Services
{
    internal class ProcessService : IProcessService
    {
        public async Task StartAsync(string filename, string arguments)
        {
            await Task.Run(() =>
            {
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo(filename, arguments)
                    {
                        CreateNoWindow = true,
                        WindowStyle = ProcessWindowStyle.Hidden
                    }
                };

                process.Start();
                process.WaitForExit();
            });
        }
    }
}