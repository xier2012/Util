namespace Util.Microservices.Dapr.WebApiSample.Controllers;

/// <summary>
/// ����1������ - ���ڲ���ʹ��HttpClient��ȡ�ַ������
/// </summary>
[ApiController]
[Route("Test1")]
public class Test1Controller : ControllerBase {
    /// <summary>
    /// HttpGet����,�����ַ���
    /// </summary>
    [HttpGet]
    public string Get_1() {
        return "ok";
    }

    /// <summary>
    /// HttpGet����,�������
    /// </summary>
    [HttpGet( "{id}" )]
    public string Get_2( string id ) {
        return $"id:{id}";
    }
}