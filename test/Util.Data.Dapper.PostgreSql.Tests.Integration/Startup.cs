using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Aop;
using Util.Data.Dapper.Metadata;
using Util.Data.Dapper.Sql;
using Util.Data.Dapper.Tests.Infrastructure;
using Util.Data.EntityFrameworkCore;
using Util.Data.Metadata;
using Util.Dates;
using Util.Helpers;
using Util.Sessions;
using Util.Tests.Infrastructure;
using Util.Tests.UnitOfWorks;
using Xunit.DependencyInjection.Logging;

namespace Util.Data.Dapper.Tests {
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
                .ConfigureServices( ( context, services ) => {
                    services.AddTransient<IMetadataService, PostgreSqlMetadataService>();
                } )
                .AsBuild()
                .AddAop()
                .AddUtc()
                .AddPgSqlQuery( Config.GetConnectionString( "connection" ) )
                .AddPgSqlExecutor( Config.GetConnectionString( "connection" ) )
                .AddPgSqlUnitOfWork<ITestUnitOfWork, PgSqlUnitOfWork>( Config.GetConnectionString( "connection" ) )
                .AddUtil();
        }

        /// <summary>
        /// ���÷���
        /// </summary>
        public void ConfigureServices( IServiceCollection services ) {
	        services.AddLogging( logBuilder => logBuilder.AddXunitOutput() );
			services.AddSingleton<ISession, TestSession>();
            InitDatabase( services );
        }

        /// <summary>
        /// ��ʼ�����ݿ�
        /// </summary>
        private void InitDatabase( IServiceCollection services ) {
            using var scope = services.BuildServiceProvider().CreateScope();
            var unitOfWork = (PgSqlUnitOfWork)scope.ServiceProvider.GetService<ITestUnitOfWork>();
            unitOfWork.EnsureDeleted();
            unitOfWork.EnsureCreated();
            DatabaseScript.InitProcedures( unitOfWork?.Database );
        }
    }
}
