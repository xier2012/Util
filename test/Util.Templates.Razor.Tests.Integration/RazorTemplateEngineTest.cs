using System.Text;
using System.Threading.Tasks;
using Util.Helpers;
using Util.Templates.Razor.Tests.Integration.Samples.Models;
using Xunit;

namespace Util.Templates.Razor.Tests.Integration; 

/// <summary>
/// Razorģ��������� - ��Ⱦģ���ַ���
/// </summary>
public partial class RazorTemplateEngineTest {
    /// <summary>
    /// Razorģ������
    /// </summary>
    private readonly ITemplateEngine _templateEngine;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    public RazorTemplateEngineTest( ITemplateEngine templateEngine ) {
        _templateEngine = templateEngine;
        _templateEngine.ClearTemplateCache();
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
        var result = _templateEngine.Render( "hello @Model.Name", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦ������ģ��,����TestModel����
    /// </summary>
    [Fact]
    public void TestRender_3() {
        var model = new TestModel { Name = "util" };
        var result = _templateEngine.Render( "hello @Model.Name", model );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��ӳ�������
    /// </summary>
    [Fact]
    public void TestRender_4() {
        RazorTemplateEngine.DisableAutoLoadAssemblies();
        var template = new StringBuilder();
        template.Append( "@using Util.Templates.Razor.Tests.Integration.Samples.Models\n" );
        template.Append( "@inherits RazorEngineCore.RazorEngineTemplateBase<TestModel>\n" );
        template.Append( "hello,@Model.Name" );
        var model = new TestModel { Name = "util" };
        var result = _templateEngine.Render( template.ToString(), model, builder => builder.AddAssemblyReference( GetType() ) );
        Assert.Equal( "hello,util", result );
    }

    /// <summary>
    /// ������Ⱦģ�� 
    /// </summary>
    [Fact]
    public async Task TestRenderAsync_1() {
        var result = await _templateEngine.RenderAsync( "a" );
        Assert.Equal( "a", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦ������ģ��,ʹ���������󴫵�����
    /// </summary>
    [Fact]
    public async Task TestRenderAsync_2() {
        var result = await _templateEngine.RenderAsync( "hello @Model.Name", new { Name = "util" } );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��Ⱦ������ģ��,����TestModel����
    /// </summary>
    [Fact]
    public async Task TestRenderAsync_3() {
        var model = new TestModel { Name = "util" };
        var result = await _templateEngine.RenderAsync( "hello @Model.Name", model );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// ������Ⱦģ�� - ��ӳ�������
    /// </summary>
    [Fact]
    public async Task TestRenderAsync_4() {
        RazorTemplateEngine.DisableAutoLoadAssemblies();
        var template = new StringBuilder();
        template.Append( "@using Util.Templates.Razor.Tests.Integration.Samples.Models\n" );
        template.Append( "@inherits RazorEngineCore.RazorEngineTemplateBase<TestModel>\n" );
        template.Append( "hello,@Model.Name" );
        var model = new TestModel { Name = "util" };
        var result = await _templateEngine.RenderAsync( template.ToString(), model, builder => builder.AddAssemblyReference( GetType() ) );
        Assert.Equal( "hello,util", result );
    }

    /// <summary>
    /// ������Ⱦģ�岢���浽�ļ�
    /// </summary>
    [Fact]
    public void TestSave() {
        var filePath = Common.GetPhysicalPath( "result/save.txt" );
        Util.Helpers.File.Delete( filePath );
        var model = new TestModel { Name = "util" };
        _templateEngine.Save( "hello @Model.Name", model, filePath );
        var result = Util.Helpers.File.ReadToString( filePath );
        Assert.Equal( "hello util", result );
    }

    /// <summary>
    /// ������Ⱦģ�岢���浽�ļ�
    /// </summary>
    [Fact]
    public async Task TestSaveAsync() {
        var filePath = Common.GetPhysicalPath( "result/saveasync.txt" );
        Util.Helpers.File.Delete( filePath );
        var model = new TestModel { Name = "util" };
        await _templateEngine.SaveAsync( "hello @Model.Name", model, filePath );
        var result = await Util.Helpers.File.ReadToStringAsync( filePath );
        Assert.Equal( "hello util", result );
    }
}