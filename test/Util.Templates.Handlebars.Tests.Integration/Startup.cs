using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xunit.DependencyInjection.Logging;

namespace Util.Templates.Handlebars.Tests.Integration; 

/// <summary>
/// ��������
/// </summary>
public class Startup {
    /// <summary>
    /// ��������
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        hostBuilder.AddUtil();
    }

	/// <summary>
	/// ���÷���
	/// </summary>
	public void ConfigureServices( IServiceCollection services ) {
		services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
	}
}