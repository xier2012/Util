﻿namespace Util.Applications; 

/// <summary>
/// 应用服务
/// </summary>
public abstract class ServiceBase : IService {
    /// <summary>
    /// 初始化应用服务
    /// </summary>
    /// <param name="serviceProvider">服务提供器</param>
    protected ServiceBase( IServiceProvider serviceProvider ) {
        ServiceProvider = serviceProvider ?? throw new ArgumentNullException( nameof( serviceProvider ) );
        Session = serviceProvider.GetService<ISession>() ?? NullSession.Instance;
        IntegrationEventBus = serviceProvider.GetService<IIntegrationEventBus>() ?? NullIntegrationEventBus.Instance;
        var logFactory = serviceProvider.GetService<ILogFactory>();
        Log = logFactory?.CreateLog( GetType() ) ?? NullLog.Instance;
        L = serviceProvider.GetService<IStringLocalizer>() ?? NullStringLocalizer.Instance;
    }

    /// <summary>
    /// 服务提供器
    /// </summary>
    protected IServiceProvider ServiceProvider { get; }

    /// <summary>
    /// 用户会话
    /// </summary>
    protected ISession Session { get; set; }

    /// <summary>
    /// 集成事件总线
    /// </summary>
    protected IIntegrationEventBus IntegrationEventBus { get; }

    /// <summary>
    /// 日志操作
    /// </summary>
    protected ILog Log { get; }

    /// <summary>
    /// 本地化字符串
    /// </summary>
    protected IStringLocalizer L { get; set; }
}