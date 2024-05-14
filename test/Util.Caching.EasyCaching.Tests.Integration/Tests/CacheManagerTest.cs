using System;
using System.Threading.Tasks;
using Xunit;

namespace Util.Caching.EasyCaching.Tests; 

/// <summary>
/// EasyCaching����������
/// </summary>
public class CacheManagerTest {

    #region ���Գ�ʼ��

    /// <summary>
    /// �������
    /// </summary>
    private readonly ICache _cache;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    /// <param name="cache">�������</param>
    public CacheManagerTest( ICache cache ) {
        _cache = cache;
    }

    #endregion

    #region Get

    /// <summary>
    /// ���Ի�ȡ����
    /// </summary>
    [Fact]
    public void TestGet_1() {
        //��������
        var key = "c:TestGet_1";
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = _cache.Get<int?>( key );
        Assert.Null( result );

        //���û���
        _cache.Set( key, value );

        //��֤
        result = _cache.Get<int?>( key );
        Assert.Equal( value, result );
    }

    /// <summary>
    /// ���Ի�ȡ���� - ���û��������
    /// </summary>
    [Fact]
    public void TestGet_2() {
        //��������
        var key = new CacheKey( "c:TestGet_2" );
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = _cache.Get<int?>( key );
        Assert.Null( result );

        //���û���
        _cache.Set( key, value );

        //��֤
        result = _cache.Get<int?>( key );
        Assert.Equal( value, result );
    }

    /// <summary>
    /// ���Ի�ȡ���� - ��ȡ����
    /// </summary>
    [Fact]
    public void TestGet_3() {
        //��������
        var key = "c:TestGet_31";
        var key2 = "c:TestGet_32";

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //��֤
        var result = _cache.Get<int?>( new[] { key, key2 } );
        Assert.Equal( 1, result[0] );
        Assert.Equal( 2, result[1] );
    }

    /// <summary>
    /// ���Ի�ȡ���� - ��ȡ����,���û��������
    /// </summary>
    [Fact]
    public void TestGet_4() {
        //��������
        var key = new CacheKey( "c:TestGet_41" );
        var key2 = new CacheKey( "c:TestGet_42" );

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //��֤
        var result = _cache.Get<int?>( new[] { key, key2 } );
        Assert.Equal( 1, result[0] );
        Assert.Equal( 2, result[1] );
    }

    /// <summary>
    /// ���Դӻ����л�ȡ���� - Ĭ��8Сʱ����
    /// </summary>
    [Fact]
    public void TestGet_5() {
        var result = 0;
        var data = 0;
        for ( int i = 0; i < 3; i++ ) {
            result = _cache.Get( "TestGet_5", () => {
                data++;
                return data;
            } );
        }
        Assert.Equal( 1, result );
    }

    /// <summary>
    /// ���Դӻ����л�ȡ���� - ����1΢�����
    /// </summary>
    [Fact]
    public void TestGet_6() {
        var result = 0;
        var data = 0;
        for ( int i = 0; i < 3; i++ ) {
            result = _cache.Get( "c:TestGet_6", () => {
                data++;
                return data;
            }, new CacheOptions { Expiration = TimeSpan.FromMicroseconds( 1 ) } );
        }
        Assert.NotEqual( 1, result );
    }

    /// <summary>
    /// ���Դӻ����л�ȡ���� - ���û��������
    /// </summary>
    [Fact]
    public void TestGet_7() {
        var result = 0;
        var data = 0;
        for ( int i = 0; i < 3; i++ ) {
            result = _cache.Get( new CacheKey( "c:TestGet_7" ), () => {
                data++;
                return data;
            } );
        }
        Assert.Equal( 1, result );
    }

    #endregion

    #region GetAsync

    /// <summary>
    /// ���Ի�ȡ����
    /// </summary>
    [Fact]
    public async Task TestGetAsync_1() {
        //��������
        var key = "c:TestGetAsync_1";
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = await _cache.GetAsync<int?>( key );
        Assert.Null( result );

        //���û���
        await _cache.SetAsync( key, value );

        //��֤
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( value, result );
    }

    /// <summary>
    /// ���Ի�ȡ���� - ���û��������
    /// </summary>
    [Fact]
    public async Task TestGetAsync_2() {
        //��������
        var key = new CacheKey( "c:TestGetAsync_2" );
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = await _cache.GetAsync<int?>( key );
        Assert.Null( result );

        //���û���
        await _cache.SetAsync( key, value );

        //��֤
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( value, result );
    }

    /// <summary>
    /// ���Ի�ȡ���� - ��ȡ����
    /// </summary>
    [Fact]
    public async Task TestGetAsync_3() {
        //��������
        var key = "c:TestGetAsync_31";
        var key2 = "c:TestGetAsync_32";

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //��֤
        var result = await _cache.GetAsync<int?>( new[] { key, key2 } );
        Assert.Equal( 1, result[0] );
        Assert.Equal( 2, result[1] );
    }

    /// <summary>
    /// ���Ի�ȡ���� - ��ȡ����,���û��������
    /// </summary>
    [Fact]
    public async Task TestGetAsync_4() {
        //��������
        var key = new CacheKey( "c:TestGetAsync_41" );
        var key2 = new CacheKey( "c:TestGetAsync_42" );

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //��֤
        var result = await _cache.GetAsync<int?>( new[] { key, key2 } );
        Assert.Equal( 1, result[0] );
        Assert.Equal( 2, result[1] );
    }

    /// <summary>
    /// ���Դӻ����л�ȡ���� - Ĭ��8Сʱ����
    /// </summary>
    [Fact]
    public async Task TestGetAsync_5() {
        var result = 0;
        var data = 0;
        for ( int i = 0; i < 3; i++ ) {
            result = await _cache.GetAsync( "c:TestGetAsync_5", async () => {
                data++;
                return await Task.FromResult( data );
            } );
        }
        Assert.Equal( 1, result );
    }

    /// <summary>
    /// ���Դӻ����л�ȡ���� - ����1΢�����
    /// </summary>
    [Fact]
    public async Task TestGetAsync_6() {
        var result = 0;
        var data = 0;
        for ( int i = 0; i < 3; i++ ) {
            result = await _cache.GetAsync( "c:TestGetAsync_6", async () => {
                data++;
                return await Task.FromResult( data );
            }, new CacheOptions { Expiration = TimeSpan.FromMicroseconds( 1 ) } );
        }
        Assert.NotEqual( 1, result );
    }

    /// <summary>
    /// ���Դӻ����л�ȡ���� - ���û��������
    /// </summary>
    [Fact]
    public async Task TestGetAsync_7() {
        var result = 0;
        var data = 0;
        for ( int i = 0; i < 3; i++ ) {
            result = await _cache.GetAsync( new CacheKey( "c:TestGetAsync_7" ), async () => {
                data++;
                return await Task.FromResult( data );
            }, new CacheOptions { Expiration = TimeSpan.FromMicroseconds( 1 ) } );
        }
        Assert.NotEqual( 1, result );
    }

    #endregion
}