﻿using System.Text;
using Xunit;

namespace Util.Ui.NgAlain.Tests.Tinymce;

/// <summary>
/// Tinymce富文本编辑器测试 - 表达式解析测试
/// </summary>
public partial class TinymceTagHelperTest {
    /// <summary>
    /// 测试解析表达式属性for
    /// </summary>
    [Fact]
    public void TestFor_1() {
            _wrapper.SetExpression( t => t.Code );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">code</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_code\">" );
            result.Append( "<tinymce #code=\"\" #v_code=\"xValidationExtend\" #x_code=\"xTinymceExtend\" displayName=\"code\" " );
            result.Append( "name=\"code\" requiredMessage=\"编码不能是空值\" " );
            result.Append( "x-tinymce-extend=\"\" x-validation-extend=\"\" [(ngModel)]=\"model.code\" [config]=\"x_code.config\" " );
            result.Append( "[required]=\"true\"></tinymce>" );
            result.Append( "<ng-template #vt_code=\"\">" );
            result.Append( "{{v_code.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
}