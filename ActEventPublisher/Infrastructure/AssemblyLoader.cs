using ActEventPublisher.Application.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace ActEventPublisher.Infrastructure
{
    public class AssemblyLoader : IAssemblyLoader
    {
        private readonly AppDomain _currentDomain = AppDomain.CurrentDomain;
        private readonly string _directory;

        public AssemblyLoader(string directory)
        {
            _directory = directory;
        }

        public void Start()
        {
            _currentDomain.AssemblyResolve -= AssemblyResolveHandler;
            _currentDomain.AssemblyResolve += AssemblyResolveHandler;
        }

        public void Stop()
        {
            _currentDomain.AssemblyResolve -= AssemblyResolveHandler;
        }

        private Assembly AssemblyResolveHandler(object sender, ResolveEventArgs e)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            var referencedAssemblies = executingAssembly.GetReferencedAssemblies();

            var requestedAssemblyName = GetName(e.Name);

            if (referencedAssemblies.Any(a => GetName(a.FullName).Equals(requestedAssemblyName)))
            {
                var pluginFile = $@"{_directory}\{requestedAssemblyName}.dll";

                return Assembly.LoadFrom(pluginFile);
            }

            return null;
        }

        private string GetName(string fullname)
        {
            return fullname.Substring(0, fullname.IndexOf(","));
        }
    }
}
