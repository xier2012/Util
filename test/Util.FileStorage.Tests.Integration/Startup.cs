using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.DependencyInjection.Logging;

namespace Util.FileStorage;

/// <summary>
/// ��������
/// </summary>
public class Startup {
    /// <summary>
    /// ��������
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        Util.Helpers.Environment.SetDevelopment();
        hostBuilder.ConfigureDefaults( null )
            .AsBuild()
            .AddLocalFileStore()
            .AddUtil();
    }

    /// <summary>
    /// ���÷���
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
    }
}