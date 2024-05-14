using EasyCaching.Core.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Util.Helpers;
using Xunit.DependencyInjection.Logging;

namespace Util.Caching.EasyCaching; 

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
            .AddAop()
            .AddRedisCache( t => {
                t.MaxRdSecond = 0;
                t.DBConfig.AllowAdmin = true;
                t.DBConfig.KeyPrefix = "test:";
                t.DBConfig.Endpoints.Add( new ServerEndPoint( Config.GetConnectionString( "Redis" ), 6379 ) );
            } )
            .AddMemoryCache( t => {
                t.MaxRdSecond = 0;
                t.CacheNulls = true;
            } )
            .AddUtil();
    }

    /// <summary>
    /// ���÷���
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
    }
}