using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Xunit.DependencyInjection.Logging;

namespace Util.Validation.Tests; 

/// <summary>
/// ��������
/// </summary>
public class Startup {
    /// <summary>
    /// ��������
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        hostBuilder.AsBuild().AddAop().AddUtil();
    }

    /// <summary>
    /// ���÷���
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
    }
}