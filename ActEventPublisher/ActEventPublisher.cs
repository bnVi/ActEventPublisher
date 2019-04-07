using ActEventPublisher.Application.Interfaces;
using ActEventPublisher.Infrastructure;
using Advanced_Combat_Tracker;
using System.Windows.Forms;

namespace ActEventPublisher
{
    public class ActEventPublisher : IActPluginV1
    {
        private IAssemblyLoader _assemblyLoader;
        private PluginManager _pluginManager;

        public void InitPlugin(TabPage pluginScreenSpace, Label pluginStatusText)
        {
            var pluginDir = this.FindCurrentPluginDirectory();
            _assemblyLoader = new AssemblyLoader(pluginDir);
            _assemblyLoader.Start();

            _pluginManager = new PluginManager(pluginScreenSpace, pluginStatusText);
            _pluginManager.Start();
        }

        public void DeInitPlugin()
        {
            _pluginManager.Stop();
            _assemblyLoader.Stop();
        }
    }
}
