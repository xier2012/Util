namespace Util.Microservices.Polly.Tests;

/// <summary>
/// ���Դ�����Բ���
/// </summary>
public partial class PolicyTest {
    /// <summary>
    /// ���Դ������
    /// </summary>
    private readonly IPolicy _policy;
    /// <summary>
    /// ���
    /// </summary>
    private readonly ITestOutputHelper _output;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    public PolicyTest( IPolicy policy, ITestOutputHelper output ) {
        _policy = policy;
        _output = output;
    }
}