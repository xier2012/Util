using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Helpers;
using Util.Logging.Serilog;
using Xunit.DependencyInjection.Logging;

namespace Util.Generators.Razor.Tests.Integration {
    /// <summary>
    /// ��������
    /// </summary>
    public class Startup {
        /// <summary>
        /// ��������
        /// </summary>
        public void ConfigureHost( IHostBuilder hostBuilder ) {
            Environment.SetDevelopment();
            hostBuilder.ConfigureDefaults( null )
                .AsBuild()
                .AddSerilog()
                .AddUtil();
        }

		/// <summary>
		/// ���÷���
		/// </summary>
		public void ConfigureServices( IServiceCollection services ) {
			services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		}
	}
}
