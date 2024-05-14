using System.Threading.Tasks;
using Util.Applications;
using Util.Http;
using Util.Microservices;
using Xunit;

namespace Util.AspNetCore.Tests.Authorization; 

/// <summary>
/// ��Ȩ���ʲ���
/// </summary>
public class AclTest {
    /// <summary>
    /// Http�ͻ���
    /// </summary>
    private readonly IHttpClient _client;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    /// <param name="client">Http�ͻ���</param>
    public AclTest( IHttpClient client ) {
        _client = client;
    }

    /// <summary>
    /// ����δ��Ȩ
    /// </summary>
    [Fact]
    public async Task Test() {
        var result = await _client.Get<ServiceResult<object>>( "/api/test5/1" ).GetResultAsync();
        Assert.Equal( StateCode.Unauthorized, result.Code );
    }
}