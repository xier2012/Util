﻿using System.Text;
using Util.Ui.NgZorro.Components.Containers;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Containers {
    /// <summary>
    /// router-outlet测试
    /// </summary>
    public class RouterOutletTagHelperTest {
        /// <summary>
        /// 输出工具
        /// </summary>
        private readonly ITestOutputHelper _output;
        /// <summary>
        /// TagHelper包装器
        /// </summary>
        private readonly TagHelperWrapper _wrapper;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public RouterOutletTagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new RouterOutletTagHelper().ToWrapper();
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        private string GetResult() {
            var result = _wrapper.GetResult();
            _output.WriteLine( result );
            return result;
        }

        /// <summary>
        /// 测试默认输出
        /// </summary>
        [Fact]
        public void TestDefault() {
            var result = new StringBuilder();
            result.Append( "<router-outlet></router-outlet>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}