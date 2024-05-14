﻿using System.Text;
using Xunit;

namespace Util.Ui.NgZorro.Tests.DatePickers {
    /// <summary>
    /// 日期选择测试 - 表达式解析测试
    /// </summary>
    public partial class DatePickerTagHelperTest {
        /// <summary>
        /// 测试解析表达式属性for
        /// </summary>
        [Fact]
        public void TestFor_1() {
            _wrapper.SetExpression( t => t.Birthday );
            var result = new StringBuilder();
            result.Append( "<nz-form-item>" );
            result.Append( "<nz-form-label [nzRequired]=\"true\">出生日期</nz-form-label>" );
            result.Append( "<nz-form-control [nzErrorTip]=\"vt_birthday\">" );
            result.Append( "<nz-date-picker #birthday=\"\" #v_birthday=\"xValidationExtend\" displayName=\"出生日期\" name=\"birthday\" " );
            result.Append( "x-validation-extend=\"\" [(ngModel)]=\"model.birthday\" [required]=\"true\">" );
            result.Append( "</nz-date-picker>" );
            result.Append( "<ng-template #vt_birthday=\"\">" );
            result.Append( "{{v_birthday.getErrorMessage()}}" );
            result.Append( "</ng-template>" );
            result.Append( "</nz-form-control>" );
            result.Append( "</nz-form-item>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}