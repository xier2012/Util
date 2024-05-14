using Util.ObjectMapping.AutoMapper.Tests.Samples;
using Xunit;

namespace Util.ObjectMapping.AutoMapper.Tests; 

/// <summary>
/// ����ӳ��������
/// </summary>
public class ObjectMapperTest {
    /// <summary>
    /// ����ӳ����
    /// </summary>
    private readonly IObjectMapper _mapper;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    public ObjectMapperTest( IObjectMapper mapper ) {
        _mapper = mapper;
    }

    /// <summary>
    /// ����ӳ�� - Sample -> Sample2 ����������������ӳ���ϵ
    /// </summary>
    [Fact]
    public void TestMap_1() {
        var sample = new Sample { StringValue = "a" };
        var sample2 =_mapper.Map<Sample,Sample2>( sample );
        Assert.Equal( "a", sample2.StringValue );
    }

    /// <summary>
    /// ����ӳ��- Sample -> Sample2 ����������������ӳ���ϵ - ����������
    /// </summary>
    [Fact]
    public void TestMap_2() {
        var sample = new Sample { StringValue = "a" };
        var sample2 = new Sample2();
        _mapper.Map( sample, sample2 );
        Assert.Equal( "a", sample2.StringValue );
    }

    /// <summary>
    /// ����ӳ�� - Sample2 -> Sample δ��������������,���Զ�����ӳ��
    /// </summary>
    [Fact]
    public void TestMap_3() {
        var sample2 = new Sample2 { StringValue = "a" };
        var sample = _mapper.Map<Sample2, Sample>( sample2 );
        Assert.Equal( "a", sample.StringValue );
    }

    /// <summary>
    /// ����ӳ�� - �������ֶ�̬���ú�ӳ��֮ǰ�����ó�������
    /// 1. ִ��Sample -> Sample2ӳ��,����������������ӳ���ϵ
    /// 2. ִ��Sample2 -> Sampleӳ��,δ��������������,���Զ�����ӳ��
    /// 3. �ظ�ִ��Sample -> Sample2ӳ��
    /// </summary>
    [Fact]
    public void TestMap_4() {
        var sample = new Sample { StringValue = "a" };
        var sample2 = _mapper.Map<Sample, Sample2>( sample );
        Assert.Equal( "a", sample2.StringValue );

        var sample3 = _mapper.Map<Sample2, Sample>( sample2 );
        Assert.Equal( "a", sample3.StringValue );

        var sample4 = _mapper.Map<Sample, Sample2>( sample );
        Assert.Equal( "a", sample4.StringValue );
    }
}