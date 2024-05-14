using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Logging.Serilog;
using Xunit.DependencyInjection.Logging;
using serilog = Serilog;

namespace Util.Logging.Tests; 

/// <summary>
/// ��������
/// </summary>
public class Startup {
    /// <summary>
    /// ��������
    /// </summary>
    public void ConfigureHost( IHostBuilder hostBuilder ) {
        AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
        hostBuilder.ConfigureDefaults( null )
            .AsBuild()
            .AddSerilog()
            .AddUtil();
    }

    /// <summary>
    /// �����˳�ʱ�ͷ���־ʵ��,���ڽ��Seq�޷�д�������
    /// </summary>
    private void CurrentDomain_ProcessExit( object sender, EventArgs e ) {
        var log = (serilog.Core.Logger)serilog.Log.Logger;
        log.Dispose();
    }

    /// <summary>
    /// ���÷���
    /// </summary>
    public void ConfigureServices( IServiceCollection services ) {
	    services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
		services.AddSingleton<ILogContextAccessor, LogContextAccessor>();
    }
}