using System.Collections.Generic;
using System.Threading.Tasks;
using Util.AspNetCore.Tests.Samples;
using Xunit;

namespace Util.AspNetCore.Tests.Http;

/// <summary>
/// Http�ͻ��˲��� - Post����
/// </summary>
public partial class HttpClientServiceTest {
    /// <summary>
    /// ����Post���� - �����ַ������
    /// </summary>
    [Fact]
    public async Task TestPost_1() {
        var dto = new CustomerDto { Code = "a" };
        var result = await _client.Post( "/api/test2/create", dto ).GetResultAsync();
        Assert.Equal( "ok:a", result );
    }

    /// <summary>
    /// ����Post���� - ���ط��ͽ��
    /// </summary>
    [Fact]
    public async Task TestPost_2() {
        var dto = new CustomerDto { Code = "a" };
        var result = await _client.Post<CustomerDto>( "/api/test2", dto ).GetResultAsync();
        Assert.Equal( "a", result.Code );
    }

    /// <summary>
    /// ����Post���� - ʹ��Content�������ݲ��� - ��ֵ��
    /// </summary>
    [Fact]
    public async Task TestPost_Content_1() {
        var result = await _client.Post( "/api/test2/create" ).Content( "code", "a" ).GetResultAsync();
        Assert.Equal( "ok:a", result );
    }

    /// <summary>
    /// ����Post���� - ʹ��Content�������ݲ��� - �ֵ�
    /// </summary>
    [Fact]
    public async Task TestPost_Content_2() {
        var dic = new Dictionary<string, string> { { "code", "a" } };
        var result = await _client.Post( "/api/test2/create" ).Content( dic ).GetResultAsync();
        Assert.Equal( "ok:a", result );
    }

    /// <summary>
    /// ����Post���� - ʹ��Content�������ݲ��� - ����
    /// </summary>
    [Fact]
    public async Task TestPost_Content_3() {
        var dto = new CustomerDto { Code = "a" };
        var result = await _client.Post( "/api/test2/create" ).Content( dto ).GetResultAsync();
        Assert.Equal( "ok:a", result );
    }

    /// <summary>
    /// ����Post���� - �ϴ��ļ� - �ļ�·��
    /// </summary>
    [Fact]
    public async Task TestPost_FileContent_1() {
        var path = Util.Helpers.Common.GetPhysicalPath( "Resources/a.png" );
        var result = await _client.Post( "/api/test6" ).FileContent( path, "file1" ).GetResultAsync();
        Assert.Equal( "ok:file1:a.png", result );
    }

    /// <summary>
    /// ����Post���� - �ϴ��ļ� - �ļ���
    /// </summary>
    [Fact]
    public async Task TestPost_FileContent_2() {
        var path = Util.Helpers.Common.GetPhysicalPath( "Resources/a.png" );
        var stream = await Util.Helpers.File.ReadToMemoryStreamAsync( path );
        var result = await _client.Post( "/api/test6" ).FileContent( stream, "abc.png", "file2" ).GetResultAsync();
        Assert.Equal( "ok:file2:abc.png", result );
    }

    /// <summary>
    /// ����Post���� - �ϴ��ļ� - ���ļ��ϴ�
    /// </summary>
    [Fact]
    public async Task TestPost_FileContent_3() {
        var path = Util.Helpers.Common.GetPhysicalPath( "Resources/a.png" );
        var stream = await Util.Helpers.File.ReadToMemoryStreamAsync( path );
        var result = await _client.Post( "/api/test6/multi" )
            .FileContent( path, "file1" )
            .FileContent( stream, "b.png", "file2" )
            .GetResultAsync();
        Assert.Equal( "ok:file1:a.png:file2:b.png", result );
    }

    /// <summary>
    /// ����Post���� - �ϴ��ļ� - ���Ͳ���
    /// </summary>
    [Fact]
    public async Task TestPost_FileContent_4() {
        var path = Util.Helpers.Common.GetPhysicalPath( "Resources/a.png" );
        var result = await _client.Post( "/api/test6" )
            .FileContent( path, "file1" )
            .Content( "util","core" )
            .GetResultAsync();
        Assert.Equal( "ok:file1:a.png:core", result );
    }
}