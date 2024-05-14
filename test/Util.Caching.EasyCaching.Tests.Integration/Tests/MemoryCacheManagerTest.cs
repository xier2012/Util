using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Util.Caching.EasyCaching.Tests; 

/// <summary>
/// EasyCaching�ڴ滺��������
/// </summary>
public class MemoryCacheManagerTest {

    #region ���Գ�ʼ��

    /// <summary>
    /// �������
    /// </summary>
    private readonly ILocalCache _cache;

    /// <summary>
    /// ���Գ�ʼ��
    /// </summary>
    /// <param name="cache">�������</param>
    public MemoryCacheManagerTest( ILocalCache cache ) {
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
        var key = "TestGet_1";
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
        var key = new CacheKey( "TestGet_2" );
        var value = 1;

        //��ȡ����,���Ϊ��
        _cache.Remove( key );
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
        var key = "TestGet_31";
        var key2 = "TestGet_32";

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //��֤
        var result = _cache.Get<int?>( new []{ key , key2 } );
        Assert.Equal( 1,result[0] );
        Assert.Equal( 2, result[1] );
    }

    /// <summary>
    /// ���Ի�ȡ���� - ��ȡ����,���û��������
    /// </summary>
    [Fact]
    public void TestGet_4() {
        //��������
        var key = new CacheKey( "TestGet_41" );
        var key2 = new CacheKey( "TestGet_42" );

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
            result = _cache.Get( "TestGet_6", () => {
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
            result = _cache.Get( new CacheKey( "TestGet_7" ), () => {
                data++;
                return data;
            } );
        }
        Assert.Equal( 1, result );
    }

    /// <summary>
    /// ���Դӻ����л�ȡ���� - ���� null ֵ - nullӦ������
    /// </summary>
    [Fact]
    public void TestGet_8() {
        var index = 0;
        for( int i = 0; i < 3; i++ ) {
            _cache.Get<string>( "TestGet_8", () => {
                index++;
                return null;
            } );
        }
        Assert.Equal( 1, index );
    }

    #endregion

    #region GetAsync

    /// <summary>
    /// ���Ի�ȡ����
    /// </summary>
    [Fact]
    public async Task TestGetAsync_1() {
        //��������
        var key = "TestGetAsync_1";
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
        var key = new CacheKey( "TestGetAsync_2" );
        var value = 1;

        //��ȡ����,���Ϊ��
        await _cache.RemoveAsync( key );
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
        var key = "TestGetAsync_31";
        var key2 = "TestGetAsync_32";

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
        var key = new CacheKey( "TestGetAsync_41" );
        var key2 = new CacheKey( "TestGetAsync_42" );

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
            result = await _cache.GetAsync( "TestGetAsync_5", async () => {
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
            result = await _cache.GetAsync( "TestGetAsync_6", async () => {
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
            result = await _cache.GetAsync( new CacheKey( "TestGetAsync_7" ), async () => {
                data++;
                return await Task.FromResult( data );
            }, new CacheOptions { Expiration = TimeSpan.FromMicroseconds( 1 ) } );
        }
        Assert.NotEqual( 1, result );
    }

    #endregion

    #region GetByPrefix

    /// <summary>
    /// ����ͨ�������ǰ׺��ȡ����
    /// </summary>
    [Fact]
    public void TestGetByPrefix_1() {
        //��������
        var key = "TestGetByPrefix_11";
        var key2 = "TestGetByPrefix_12";

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //��֤
        var result = _cache.GetByPrefix<int?>( "TestGetByPrefix_1" ).OrderBy( t => t ).ToList();
        Assert.Equal( 1, result[0] );
        Assert.Equal( 2, result[1] );
    }

    #endregion

    #region GetByPrefixAsync

    /// <summary>
    /// ����ͨ�������ǰ׺��ȡ����
    /// </summary>
    [Fact]
    public async Task TestGetByPrefixAsync_1() {
        //��������
        var key = "abc:TestGetByPrefixAsync_11";
        var key2 = "abc:TestGetByPrefixAsync_12";

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //��֤
        var result = (await _cache.GetByPrefixAsync<int?>( "abc:" )).OrderBy( t => t ).ToList();
        Assert.Equal( 1, result[0] );
        Assert.Equal( 2, result[1] );
    }

    #endregion

    #region TrySet

    /// <summary>
    /// �������û���
    /// </summary>
    [Fact]
    public void TestTrySet_1() {
        //��������
        var key = "TestTrySet_1";
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = _cache.Get<int?>( key );
        Assert.Null( result );

        //���û���1
        _cache.TrySet( key, value );
        result = _cache.Get<int?>( key );
        Assert.Equal( value, result );

        //���û���2,��Ч
        _cache.TrySet( key, 2 );
        result = _cache.Get<int?>( key );
        Assert.Equal( value, result );
    }

    /// <summary>
    /// �������û��� - ���û��������
    /// </summary>
    [Fact]
    public void TestTrySet_2() {
        //��������
        var key = new CacheKey( "TestTrySet_2" );
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = _cache.Get<int?>( key );
        Assert.Null( result );

        //���û���1
        _cache.TrySet( key, value );
        result = _cache.Get<int?>( key );
        Assert.Equal( value, result );

        //���û���2,��Ч
        _cache.TrySet( key, 2 );
        result = _cache.Get<int?>( key );
        Assert.Equal( value, result );
    }

    #endregion

    #region TrySetAsync

    /// <summary>
    /// �������û���
    /// </summary>
    [Fact]
    public async Task TestTrySetAsync_1() {
        //��������
        var key = "TestTrySetAsync_1";
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = await _cache.GetAsync<int?>( key );
        Assert.Null( result );

        //���û���1
        await _cache.TrySetAsync( key, value );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( value, result );

        //���û���2,��Ч
        await _cache.TrySetAsync( key, 2 );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( value, result );
    }

    /// <summary>
    /// �������û��� - ���û��������
    /// </summary>
    [Fact]
    public async Task TestTrySetAsync_2() {
        //��������
        var key = new CacheKey( "TestTrySetAsync_2" );
        var value = 1;

        //��ȡ����,���Ϊ��
        var result = await _cache.GetAsync<int?>( key );
        Assert.Null( result );

        //���û���1
        await _cache.TrySetAsync( key, value );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( value, result );

        //���û���2,��Ч
        await _cache.TrySetAsync( key, 2 );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( value, result );
    }

    #endregion

    #region Set

    /// <summary>
    /// �������û���
    /// </summary>
    [Fact]
    public void TestSet_1() {
        //��������
        var key = "TestSet_1";

        //��ȡ����,���Ϊ��
        var result = _cache.Get<int?>( key );
        Assert.Null( result );

        //���û���1
        _cache.Set( key, 1 );
        result = _cache.Get<int?>( key );
        Assert.Equal( 1, result );

        //���û���2,����
        _cache.Set( key, 2 );
        result = _cache.Get<int?>( key );
        Assert.Equal( 2, result );
    }

    /// <summary>
    /// �������û���- ���û��������
    /// </summary>
    [Fact]
    public void TestSet_2() {
        //��������
        var key = new CacheKey( "TestSet_2" );

        //��ȡ����,���Ϊ��
        var result = _cache.Get<int?>( key );
        Assert.Null( result );

        //���û���1
        _cache.Set( key, 1 );
        result = _cache.Get<int?>( key );
        Assert.Equal( 1, result );

        //���û���2,����
        _cache.Set( key, 2 );
        result = _cache.Get<int?>( key );
        Assert.Equal( 2, result );
    }

    /// <summary>
    /// �������û��� - ���ü���
    /// </summary>
    [Fact]
    public void TestSet_3() {
        //��������
        var key = "TestSet_31";
        var key2 = "TestSet_32";

        //���û���
        _cache.Set( new Dictionary<string,int>{{key,1}, { key2, 2 } } );

        //��֤
        Assert.Equal( 1, _cache.Get<int>( key ) );
        Assert.Equal( 2, _cache.Get<int>( key2 ) );
    }

    /// <summary>
    /// �������û��� - ���ü���,���û��������
    /// </summary>
    [Fact]
    public void TestSet_4() {
        //��������
        var key = new CacheKey( "TestSet_41" );
        var key2 = new CacheKey( "TestSet_42" );

        //���û���
        _cache.Set( new Dictionary<CacheKey, int> { { key, 1 }, { key2, 2 } } );

        //��֤
        Assert.Equal( 1, _cache.Get<int>( key ) );
        Assert.Equal( 2, _cache.Get<int>( key2 ) );
    }

    #endregion

    #region SetAsync

    /// <summary>
    /// �������û���
    /// </summary>
    [Fact]
    public async Task TestSetAsync_1() {
        //��������
        var key = "TestSetAsync_1";

        //��ȡ����,���Ϊ��
        var result = await _cache.GetAsync<int?>( key );
        Assert.Null( result );

        //���û���1
        await _cache.SetAsync( key, 1 );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( 1, result );

        //���û���2,����
        await _cache.SetAsync( key, 2 );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( 2, result );
    }

    /// <summary>
    /// �������û��� - ���û��������
    /// </summary>
    [Fact]
    public async Task TestSetAsync_2() {
        //��������
        var key = new CacheKey( "TestSetAsync_2" );

        //��ȡ����,���Ϊ��
        var result = await _cache.GetAsync<int?>( key );
        Assert.Null( result );

        //���û���1
        await _cache.SetAsync( key, 1 );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( 1, result );

        //���û���2,����
        await _cache.SetAsync( key, 2 );
        result = await _cache.GetAsync<int?>( key );
        Assert.Equal( 2, result );
    }

    /// <summary>
    /// �������û��� - ���ü���
    /// </summary>
    [Fact]
    public async Task TestSetAsync_3() {
        //��������
        var key = "TestSetAsync_31";
        var key2 = "TestSetAsync_32";

        //���û���
        await _cache.SetAsync( new Dictionary<string, int> { { key, 1 }, { key2, 2 } } );

        //��֤
        Assert.Equal( 1, await _cache.GetAsync<int>( key ) );
        Assert.Equal( 2, await _cache.GetAsync<int>( key2 ) );
    }

    /// <summary>
    /// �������û��� - ���ü���,���û��������
    /// </summary>
    [Fact]
    public async Task TestSetAsync_4() {
        //��������
        var key = new CacheKey( "TestSetAsync_41" );
        var key2 = new CacheKey( "TestSetAsync_42" );

        //���û���
        await _cache.SetAsync( new Dictionary<CacheKey, int> { { key, 1 }, { key2, 2 } } );

        //��֤
        Assert.Equal( 1, await _cache.GetAsync<int>( key ) );
        Assert.Equal( 2, await _cache.GetAsync<int>( key2 ) );
    }

    #endregion

    #region Exists

    /// <summary>
    /// ���Ի����Ƿ��Ѵ���
    /// </summary>
    [Fact]
    public void TestExists_1() {
        //��������
        var key = "TestExists_1";

        //���治����
        Assert.False( _cache.Exists( key ) );

        //���û���
        _cache.Set( key, 1 );

        //��֤
        Assert.True( _cache.Exists( key ) );
    }

    /// <summary>
    /// ���Ի����Ƿ��Ѵ���- ���û��������
    /// </summary>
    [Fact]
    public void TestExists_2() {
        //��������
        var key = new CacheKey( "TestExists_2" );

        //���治����
        Assert.False( _cache.Exists( key ) );

        //���û���
        _cache.Set( key, 1 );

        //��֤
        Assert.True( _cache.Exists( key ) );
    }

    #endregion

    #region ExistsAsync

    /// <summary>
    /// ���Ի����Ƿ��Ѵ���
    /// </summary>
    [Fact]
    public async Task TestExistsAsync_1() {
        //��������
        var key = "TestExistsAsync_1";

        //���治����
        Assert.False( await _cache.ExistsAsync( key ) );

        //���û���
        await _cache.SetAsync( key, 1 );

        //��֤
        Assert.True( await _cache.ExistsAsync( key ) );
    }

    /// <summary>
    /// ���Ի����Ƿ��Ѵ��� - ���û��������
    /// </summary>
    [Fact]
    public async Task TestExistsAsync_2() {
        //��������
        var key = new CacheKey( "TestExistsAsync_2" );

        //���治����
        Assert.False( await _cache.ExistsAsync( key ) );

        //���û���
        await _cache.SetAsync( key, 1 );

        //��֤
        Assert.True( await _cache.ExistsAsync( key ) );
    }

    #endregion

    #region Remove

    /// <summary>
    /// �����Ƴ�����
    /// </summary>
    [Fact]
    public void TestRemove_1() {
        //��������
        var key = "TestRemove_1";

        //���û���
        _cache.Set( key, 1 );
        Assert.True( _cache.Exists( key ) );

        //�Ƴ�����
        _cache.Remove( key );

        //��֤
        Assert.False( _cache.Exists( key ) );
    }

    /// <summary>
    /// �����Ƴ����� - ���û��������
    /// </summary>
    [Fact]
    public void TestRemove_2() {
        //��������
        var key = new CacheKey( "TestRemove_2" );

        //���û���
        _cache.Set( key, 1 );
        Assert.True( _cache.Exists( key ) );

        //�Ƴ�����
        _cache.Remove( key );

        //��֤
        Assert.False( _cache.Exists( key ) );
    }

    /// <summary>
    /// �����Ƴ����漯��
    /// </summary>
    [Fact]
    public void TestRemove_3() {
        //��������
        var key = "TestRemove_31";
        var key2 = "TestRemove_32";

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //�Ƴ�����
        _cache.Remove( new[] { key, key2 } );

        //��֤
        Assert.False( _cache.Exists( key ) );
        Assert.False( _cache.Exists( key2 ) );
    }

    /// <summary>
    /// �����Ƴ����漯�� - ���û��������
    /// </summary>
    [Fact]
    public void TestRemove_4() {
        //��������
        var key = new CacheKey( "TestRemove_41" );
        var key2 = new CacheKey( "TestRemove_42" );

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //�Ƴ�����
        _cache.Remove( new[] { key, key2 } );

        //��֤
        Assert.False( _cache.Exists( key ) );
        Assert.False( _cache.Exists( key2 ) );
    }

    #endregion

    #region RemoveAsync

    /// <summary>
    /// �����Ƴ�����
    /// </summary>
    [Fact]
    public async Task TestRemoveAsync_1() {
        //��������
        var key = "TestRemoveAsync_1";

        //���û���
        await _cache.SetAsync( key, 1 );
        Assert.True( await _cache.ExistsAsync( key ) );

        //�Ƴ�����
        await _cache.RemoveAsync( key );

        //��֤
        Assert.False( await _cache.ExistsAsync( key ) );
    }

    /// <summary>
    /// �����Ƴ����� - ���û��������
    /// </summary>
    [Fact]
    public async Task TestRemoveAsync_2() {
        //��������
        var key = new CacheKey( "TestRemoveAsync_2" );

        //���û���
        await _cache.SetAsync( key, 1 );
        Assert.True( await _cache.ExistsAsync( key ) );

        //�Ƴ�����
        await _cache.RemoveAsync( key );

        //��֤
        Assert.False( await _cache.ExistsAsync( key ) );
    }

    /// <summary>
    /// �����Ƴ����漯��
    /// </summary>
    [Fact]
    public async Task TestRemoveAsync_3() {
        //��������
        var key = "TestRemoveAsync_31";
        var key2 = "TestRemoveAsync_32";

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //�Ƴ�����
        await _cache.RemoveAsync( new[] { key, key2 } );

        //��֤
        Assert.False( await _cache.ExistsAsync( key ) );
        Assert.False( await _cache.ExistsAsync( key2 ) );
    }

    /// <summary>
    /// �����Ƴ����漯�� - ���û��������
    /// </summary>
    [Fact]
    public async Task TestRemoveAsync_4() {
        //��������
        var key = new CacheKey( "TestRemoveAsync_41" );
        var key2 = new CacheKey( "TestRemoveAsync_42" );

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //�Ƴ�����
        await _cache.RemoveAsync( new[] { key, key2 } );

        //��֤
        Assert.False( await _cache.ExistsAsync( key ) );
        Assert.False( await _cache.ExistsAsync( key2 ) );
    }

    #endregion

    #region RemoveByPrefix

    /// <summary>
    /// ����ͨ�������ǰ׺�Ƴ�����
    /// </summary>
    [Fact]
    public void RemoveByPrefix_1() {
        //��������
        var key = "RemoveByPrefix_11";
        var key2 = "RemoveByPrefix_12";

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //��֤
        Assert.True( _cache.Exists( key ) );
        Assert.True( _cache.Exists( key2 ) );

        //�Ƴ�����
        _cache.RemoveByPrefix( "RemoveByPrefix" );

        //��֤
        Assert.False( _cache.Exists( key ) );
        Assert.False( _cache.Exists( key2 ) );
    }

    #endregion

    #region RemoveByPrefixAsync

    /// <summary>
    /// ����ͨ�������ǰ׺�Ƴ�����
    /// </summary>
    [Fact]
    public async Task RemoveByPrefixAsync_1() {
        //��������
        var key = "RemoveByPrefixAsync_11";
        var key2 = "RemoveByPrefixAsync_12";

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //�Ƴ�����
        await _cache.RemoveByPrefixAsync( "RemoveByPrefix" );

        //��֤
        Assert.False( await _cache.ExistsAsync( key ) );
        Assert.False( await _cache.ExistsAsync( key2 ) );
    }

    #endregion

    #region RemoveByPattern

    /// <summary>
    /// ����ͨ�������ģʽ�Ƴ�����
    /// </summary>
    [Fact]
    public void RemoveByPattern() {
        //��������
        var key = "RemoveByPattern_1";
        var key2 = "RemoveByPattern_2";

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //�Ƴ�����
        _cache.RemoveByPattern( "*2" );

        //��֤
        Assert.True( _cache.Exists( key ) );
        Assert.False( _cache.Exists( key2 ) );
    }

    #endregion

    #region RemoveByPatternAsync

    /// <summary>
    /// ����ͨ�������ģʽ�Ƴ�����
    /// </summary>
    [Fact]
    public async Task RemoveByPatternAsync() {
        //��������
        var key = "RemoveByPatternAsync_1";
        var key2 = "RemoveByPatternAsync_2";

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //�Ƴ�����
        await _cache.RemoveByPatternAsync( "*2" );

        //��֤
        Assert.True( await _cache.ExistsAsync( key ) );
        Assert.False( await _cache.ExistsAsync( key2 ) );
    }

    #endregion

    #region Clear

    /// <summary>
    /// ������ջ���
    /// </summary>
    [Fact]
    public void TestClear() {
        //��������
        var key = "TestClear_1";
        var key2 = "TestClear_2";

        //���û���
        _cache.Set( key, 1 );
        _cache.Set( key2, 2 );

        //��ջ���
        _cache.Clear();

        //��֤
        Assert.False( _cache.Exists( key ) );
        Assert.False( _cache.Exists( key2 ) );
    }

    #endregion

    #region ClearAsync

    /// <summary>
    /// ������ջ���
    /// </summary>
    [Fact]
    public async Task TestClearAsync() {
        //��������
        var key = "TestClear_1";
        var key2 = "TestClear_2";

        //���û���
        await _cache.SetAsync( key, 1 );
        await _cache.SetAsync( key2, 2 );

        //��ջ���
        await _cache.ClearAsync();

        //��֤
        Assert.False( await _cache.ExistsAsync( key ) );
        Assert.False( await _cache.ExistsAsync( key2 ) );
    }

    #endregion
}