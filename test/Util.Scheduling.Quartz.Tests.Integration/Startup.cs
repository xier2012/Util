using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Data.EntityFrameworkCore;
using Util.Helpers;
using Util.Tests.UnitOfWorks;
using Xunit.DependencyInjection.Logging;

namespace Util.Scheduling.Quartz.Tests {
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
                .AddQuartz()
                .AddSqlServerUnitOfWork<ITestUnitOfWork, SqlServerUnitOfWork>( Config.GetConnectionString( "connection" ) )
                .AddUtil();
        }

        /// <summary>
        /// ���÷���
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
	        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
			InitDatabase( services );
        }

        /// <summary>
        /// ��ʼ�����ݿ�
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            var unitOfWork = services.BuildServiceProvider().GetService<ITestUnitOfWork>();
            unitOfWork.EnsureDeleted();
            unitOfWork.EnsureCreated();
        }
    }
}
