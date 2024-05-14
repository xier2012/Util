﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using Util.Ui.Angular.TagHelpers;
using Util.Ui.NgZorro.Components.PageHeaders.Renders;
using Util.Ui.Renders;

namespace Util.Ui.NgZorro.Components.PageHeaders; 

/// <summary>
/// 页头标题,生成的标签为&lt;nz-page-header-title&gt;&lt;/nz-page-header-title&gt;
/// </summary>
[HtmlTargetElement( "util-page-header-title" )]
public class PageHeaderTitleTagHelper : AngularTagHelperBase {
    /// <inheritdoc />
    protected override IRender GetRender( TagHelperContext context, TagHelperOutput output, TagHelperContent content ) {
        var config = new Config( context, output, content );
        return new PageHeaderTitleRender( config );
    }
}