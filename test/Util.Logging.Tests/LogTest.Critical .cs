using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;
using Util.Logging.Tests.Samples;
using Xunit;

namespace Util.Logging.Tests; 

/// <summary>
/// ��־�������� - ������������
/// </summary>
public partial class LogTest {
    /// <summary>
    /// ����д������־ - ͬʱ�����Զ�����չ����,״̬����,��־��Ϣ
    /// </summary>
    [Fact]
    public void TestLogCritical_Message() {
        var product = new Product { Code = "a", Name = "b", Price = 123 };
        _log.Message( "a{b}{c}", 1, 2 )
            .Property( "d", "3" )
            .Property( "e", "4" )
            .State( product )
            .LogCritical();
        _mockLogger.Verify( t => t.LogCritical( 0, null, "[d:{d},e:{e},Code:{Code},Name:{Name},Price:{Price}]a{b}{c}", "3", "4", "a", "b", 123, 1, 2 ) );
    }

    /// <summary>
    /// ����д������־ - �����Զ�����չ���Ժ�״̬����
    /// </summary>
    [Fact]
    public void TestLogCritical_Property() {
        var product = new Product { Code = "a", Name = "b", Price = 123 };
        _log.Property( "Age", "18" ).State( product ).LogCritical();
        _mockLogger.Verify( t => t.Log( LogLevel.Critical, 0,
            It.Is<IDictionary<string, object>>( dic => dic.Count == 4 && dic["Age"].ToString() == "18" && dic["Name"].ToString() == "b" ),
            null,
            It.IsAny<Func<IDictionary<string, object>, Exception, string>>() ) );
    }
}