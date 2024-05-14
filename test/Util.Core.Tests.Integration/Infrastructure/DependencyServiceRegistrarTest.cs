﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Util.Infrastructure;
using Util.Tests.Samples;
using Xunit;

namespace Util.Tests.Infrastructure; 

/// <summary>
/// 依赖服务注册器测试
/// </summary>
public class DependencyServiceRegistrarTest {
    /// <summary>
    /// 测试注册服务
    /// </summary>
    [Fact]
    public void TestRegisterDependency_1() {
        var builder = new HostBuilder();
        var bootstrapper = new Bootstrapper( builder );
        bootstrapper.Start();
        var host = builder.Build();
        Assert.Equal( typeof( TestService4 ), host.Services.GetService<ITestService5>()?.GetType() );
        Assert.NotEqual( typeof( TestService4 ), host.Services.GetService<ITestService3>()?.GetType() );
        Assert.Equal( typeof( TestService4 ), host.Services.GetService<ITestService4>()?.GetType() );
        Assert.Equal( typeof( TestService5<A> ), host.Services.GetService<ITestService6<A>>()?.GetType() );
    }

    /// <summary>
    /// 测试Ioc特性覆盖实现
    /// </summary>
    [Fact]
    public void TestRegisterDependency_2() {
        var builder = new HostBuilder();
        var bootstrapper = new Bootstrapper( builder );
        bootstrapper.Start();
        var host = builder.Build();
        Assert.Equal( typeof( TestService8 ), host.Services.GetService<ITestService7>()?.GetType() );
        Assert.Equal( typeof( TestService70 ), host.Services.GetService<ITestService70>()?.GetType() );
    }

    /// <summary>
    /// 测试间接继承ISingletonDependency接口进行依赖配置
    /// </summary>
    [Fact]
    public void TestRegisterDependency_4() {
        var builder = new HostBuilder();
        var bootstrapper = new Bootstrapper( builder );
        bootstrapper.Start();
        var host = builder.Build();
        Assert.Equal( typeof( TestService12 ), host.Services.GetService<ITestService12>()?.GetType() );
        Assert.Equal( typeof( TestService12 ), host.Services.GetService<ITestService10>()?.GetType() );
    }

    /// <summary>
    /// 测试禁用依赖服务注册器
    /// </summary>
    [Fact]
    public void TestDisableDependencyServiceRegistrar() {
        ServiceRegistrarConfig.Instance.DisableDependencyServiceRegistrar();
        var builder = new HostBuilder();
        var bootstrapper = new Bootstrapper( builder );
        bootstrapper.Start();
        var host = builder.Build();
        Assert.NotEqual( typeof( TestService4 ), host.Services.GetService<ITestService5>()?.GetType() );
        ServiceRegistrarConfig.Instance.EnableDependencyServiceRegistrar();
    }
}