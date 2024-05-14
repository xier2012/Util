using System.Threading.Tasks;
using Util.Helpers;
using Util.Templates.Razor.Tests.Integration.Samples.Models;
using Xunit;

namespace Util.Templates.Razor.Tests.Integration; 

/// <summary>
/// Razorģ��������� - ��Ⱦģ���ļ�
/// </summary>
public partial class RazorTemplateEngineTest {
    /// <summary>
    /// ����ͨ��·����Ⱦģ��
    /// </summary>
    [Fact]
    public void TestRenderByPath() {
        var model = new TestModel { Name = "util" };
        var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
        var result = _templateEngine.RenderByPath( path, model );
        Assert.Equal( "hello,util", result );
    }

    /// <summary>
    /// ����ͨ��·����Ⱦģ��
    /// </summary>
    [Fact]
    public void TestRenderByPath_2() {
        var model = new TestModel { Name = "a", Model2 = new TestModel2 { Name = "b", Model3 = new TestModel3 { Name = "c" } } };
        var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate2.cshtml" );
        var result = _templateEngine.RenderByPath( path, model );
        Assert.Equal( "a,b,c", result );
    }

    /// <summary>
    /// ����ͨ��·����Ⱦģ��
    /// </summary>
    [Fact]
    public async Task TestRenderByPathAsync() {
        var model = new TestModel { Name = "util" };
        var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
        var result = await _templateEngine.RenderByPathAsync( path, model );
        Assert.Equal( "hello,util", result );
    }

    /// <summary>
    /// ����ͨ��·����Ⱦģ��
    /// </summary>
    [Fact]
    public async Task TestRenderByPathAsync_2() {
        var model = new TestModel { Name = "a", Model2 = new TestModel2 { Name = "b", Model3 = new TestModel3 { Name = "c" } } };
        var path = Common.GetPhysicalPath( "Samples/Templates/TestTemplate2.cshtml" );
        var result = await _templateEngine.RenderByPathAsync( path, model );
        Assert.Equal( "a,b,c", result );
    }

    /// <summary>
    /// ����ͨ��·����Ⱦģ�岢���浽�ļ�
    /// </summary>
    [Fact]
    public void TestSaveByPath() {
        var filePath = Common.GetPhysicalPath( "result/SaveByPath.txt" );
        Util.Helpers.File.Delete( filePath );
        var model = new TestModel { Name = "util" };
        var templatePath = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
        _templateEngine.SaveByPath( templatePath, model, filePath );
        var result = Util.Helpers.File.ReadToString( filePath );
        Assert.Equal( "hello,util", result );
    }

    /// <summary>
    /// ����ͨ��·����Ⱦģ�岢���浽�ļ�
    /// </summary>
    [Fact]
    public async Task TestSaveByPathAsync() {
        var filePath = Common.GetPhysicalPath( "result/SaveByPathAsync.txt" );
        Util.Helpers.File.Delete( filePath );
        var model = new TestModel { Name = "util" };
        var templatePath = Common.GetPhysicalPath( "Samples/Templates/TestTemplate.cshtml" );
        await _templateEngine.SaveByPathAsync( templatePath, model, filePath );
        var result = await Util.Helpers.File.ReadToStringAsync( filePath );
        Assert.Equal( "hello,util", result );
    }
}