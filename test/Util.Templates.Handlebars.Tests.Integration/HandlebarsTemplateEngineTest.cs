using System.Threading.Tasks;
using Xunit;

namespace Util.Templates.Handlebars.Tests.Integration; 

/// <summary>
/// Razorģ��������� - ��Ⱦģ���ַ���
/// </summary>
public class HandlebarsTemplateEngineTest {
    /// <summary>
    /// Razorģ������
    /// </summary>
    private readonly ITemplateEngine _templateEngine;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    public HandlebarsTemplateEngineTest( ITemplateEngine templateEngine ) {
        _templateEngine = templateEngine;
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦû�����ݵ�ģ��
    /// </summary>
    [Fact]
    public void TestRender_1() {
        var result = _templateEngine.Render( "a" );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦ������ģ��,ʹ���������󴫵�����
    /// </summary>
    [Fact]
    public void TestRender_2() {
        var result = _templateEngine.Render( "hello {{Name}}", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// �����첽��Ⱦģ�� 
    /// </summary>
    [Fact]
    public async Task TestRenderAsync() {
        var result = await _templateEngine.RenderAsync( "a" );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦ������ģ��,ʹ���������󴫵�����
    /// </summary>
    [Fact]
    public async Task TestRenderAsync_2() {
        var result = await _templateEngine.RenderAsync( "hello {{Name}}", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }
}