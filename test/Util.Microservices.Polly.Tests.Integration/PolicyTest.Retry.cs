using Util.Microservices.Polly.Tests.Samples;

namespace Util.Microservices.Polly.Tests;

/// <summary>
/// ���Դ�����Բ��� - ���Բ���
/// </summary>
public partial class PolicyTest {

    #region HandleException

    /// <summary>
    /// �������� - �쳣�������� - ����1��
    /// </summary>
    [Fact]
    public void TestRetry_1() {
        var i = 0;
        Assert.Throws<Exception>( () => {
            _policy.Retry().HandleException<Exception>().Execute( () => {
                i++;
                throw new Exception();
            } );
        } );
        Assert.Equal( 2, i );
    }

    /// <summary>
    /// �������� - �쳣�������� - ����3��
    /// </summary>
    [Fact]
    public void TestRetry_2() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Assert.Throws<Exception>( () => {
            _policy.Retry( 3 ).HandleException<Exception>().Execute( () => {
                i++;
                throw new Exception();
            } );
        } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( 4, i );
        Assert.True( stopwatch.Elapsed.Milliseconds < 50 );
    }

    /// <summary>
    /// �������� - �쳣�������� - ��������
    /// </summary>
    [Fact]
    public void TestRetry_3() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        _policy.Retry().HandleException<Exception>().Forever().Execute( () => {
            i++;
            if ( i < 100 )
                throw new Exception();
        } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( 100, i );
        Assert.True( stopwatch.Elapsed.Milliseconds < 50 );
    }

    /// <summary>
    /// �������� - �쳣�������� - ����3�� - ��1�εȴ�10���룬��2�εȴ�20���룬��3�εȴ�30����
    /// </summary>
    [Fact]
    public void TestRetry_4() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        Assert.Throws<Exception>( () => {
            _policy.Retry( 3 ).HandleException<Exception>()
                .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
                .Execute( () => {
                    i++;
                    throw new Exception();
                } );
        } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( 4, i );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    /// <summary>
    /// �������� - �쳣�������� - �ص���������
    /// </summary>
    [Fact]
    public void TestRetry_5() {
        var i = 0;
        Assert.Throws<Exception>( () => {
            _policy.Retry( 3 ).HandleException<Exception>()
                .OnRetry( ( e, n ) => {
                    i = n;
                } )
                .Execute( () => throw new Exception() );
        } );
        Assert.Equal( 3, i );
    }

    /// <summary>
    /// �������� - �쳣�������� - �ص��������� - ��������
    /// </summary>
    [Fact]
    public void TestRetry_6() {
        var i = 0;
        _policy.Retry().HandleException<Exception>().Forever()
            .OnRetry( ( e, n ) => {
                i = n;
            } )
            .Execute( () => {
                if ( i < 3 )
                    throw new Exception();
            } );
        Assert.Equal( 3, i );
    }

    /// <summary>
    /// �������� - �쳣�������� - �ص��������� - �ȴ�
    /// </summary>
    [Fact]
    public void TestRetry_7() {
        var i = 0;
        Assert.Throws<Exception>( () => {
            _policy.Retry( 3 ).HandleException<Exception>()
                .Wait( retry => TimeSpan.FromMilliseconds( 1 ) )
                .OnRetry( ( e, n ) => {
                    i = n;
                } )
                .Execute( () => throw new Exception() );
        } );
        Assert.Equal( 3, i );
    }

    /// <summary>
    /// �������� - �쳣�������� - �ص��������� - �ȴ� - ��������
    /// </summary>
    [Fact]
    public void TestRetry_8() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        _policy.Retry().HandleException<Exception>().Forever()
            .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
            .OnRetry( ( e, n ) => {
                i = n;
            } )
            .Execute( () => {
                if ( i < 3 )
                    throw new Exception();
            } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( 3, i );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    #endregion

    #region HandleResult

    /// <summary>
    /// �������� - ����������� - ����1��
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_1() {
        var i = 0;
        var result = _policy.Retry().HandleResult<SampleResult>( t => t.Result != "ok" )
            .Execute( () => {
                i++;
                return new SampleResult { Result = i.ToString() };
            } );
        Assert.Equal( "2", result.Result );
    }

    /// <summary>
    /// �������� - ����������� - ����3��
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_2() {
        var i = 0;
        var result = _policy.Retry( 3 ).HandleResult<SampleResult>( t => t.Result != "ok" )
            .Execute( () => {
                i++;
                return new SampleResult { Result = i.ToString() };
            } );
        Assert.Equal( "4", result.Result );
    }

    /// <summary>
    /// �������� - ����������� - ��������
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_3() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = _policy.Retry()
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .Forever()
            .Execute( () => {
                i++;
                if ( i < 100 )
                    return new SampleResult { Result = i.ToString() };
                return new SampleResult { Result = "ok" };
            } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( "ok", result.Result );
        Assert.True( stopwatch.Elapsed.Milliseconds < 50 );
    }

    /// <summary>
    /// �������� - ����������� - ����3�� - �ȴ�
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_4() {
        var i = 0;
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = _policy.Retry( 3 )
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
            .Execute( () => {
                i++;
                return new SampleResult { Result = i.ToString() };
            } );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( "4", result.Result );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    /// <summary>
    /// �������� - ����������� - �ص���������
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_5() {
        var sample = new SampleResult();
        var result = _policy.Retry( 3 )
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .Execute( () => sample );
        Assert.Equal( "3", result.Result );
    }

    /// <summary>
    /// �������� - ����������� - �ص��������� - ��������
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_6() {
        var sample = new SampleResult();
        var result = _policy.Retry()
            .HandleResult<SampleResult>( t => t.Result != "10" )
            .Forever()
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .Execute( () => sample );
        Assert.Equal( "10", result.Result );
    }

    /// <summary>
    /// �������� - ����������� - �ص��������� - �ȴ�
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_7() {
        var sample = new SampleResult();
        var result = _policy.Retry( 3 )
            .HandleResult<SampleResult>( t => t.Result != "ok" )
            .Wait( retry => TimeSpan.FromMilliseconds( 1 ) )
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .Execute( () => sample );
        Assert.Equal( "3", result.Result );
    }

    /// <summary>
    /// �������� - ����������� - �ص��������� - �ȴ� - ��������
    /// </summary>
    [Fact]
    public void TestRetry_HandleResult_8() {
        var sample = new SampleResult();
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        var result = _policy.Retry()
            .HandleResult<SampleResult>( t => t.Result != "3" )
            .Wait( retry => TimeSpan.FromMilliseconds( retry * 10 ) )
            .Forever()
            .OnRetry( ( result, n ) => {
                result.Result.Result = n.ToString();
            } )
            .Execute( () => sample );
        stopwatch.Stop();
        _output.WriteLine( stopwatch.Elapsed.Milliseconds.ToString() );
        Assert.Equal( "3", result.Result );
        Assert.True( stopwatch.Elapsed.Milliseconds > 60 );
    }

    #endregion
}