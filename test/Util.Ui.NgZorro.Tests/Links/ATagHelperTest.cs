﻿using System.Text;
using Util.Helpers;
using Util.Ui.Angular.Configs;
using Util.Ui.Configs;
using Util.Ui.Enums;
using Util.Ui.NgZorro.Components.Forms.Configs;
using Util.Ui.NgZorro.Components.Links;
using Util.Ui.NgZorro.Configs;
using Util.Ui.NgZorro.Enums;
using Util.Ui.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Util.Ui.NgZorro.Tests.Links {
    /// <summary>
    /// 链接测试
    /// </summary>
    public class ATagHelperTest {
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
        public ATagHelperTest( ITestOutputHelper output ) {
            _output = output;
            _wrapper = new ATagHelper().ToWrapper();
            Id.SetId("id");
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
            result.Append( "<a></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接地址
        /// </summary>
        [Fact]
        public void TestHref() {
            _wrapper.SetContextAttribute( UiConst.Href, "a" );
            var result = new StringBuilder();
            result.Append( "<a href=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接地址
        /// </summary>
        [Fact]
        public void TestBindHref() {
            _wrapper.SetContextAttribute( AngularConst.BindHref, "a" );
            var result = new StringBuilder();
            result.Append( "<a [href]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接打开目标
        /// </summary>
        [Fact]
        public void TestTarget() {
            _wrapper.SetContextAttribute( UiConst.Target, ATarget.Parent );
            var result = new StringBuilder();
            result.Append( "<a target=\"_parent\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接打开目标
        /// </summary>
        [Fact]
        public void TestBindTarget() {
            _wrapper.SetContextAttribute( AngularConst.BindTarget, "a" );
            var result = new StringBuilder();
            result.Append( "<a [target]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接关系
        /// </summary>
        [Fact]
        public void TestRel() {
            _wrapper.SetContextAttribute( UiConst.Rel, "a" );
            var result = new StringBuilder();
            result.Append( "<a rel=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试链接关系
        /// </summary>
        [Fact]
        public void TestBindRel() {
            _wrapper.SetContextAttribute( AngularConst.BindRel, "a" );
            var result = new StringBuilder();
            result.Append( "<a [rel]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试危险状态
        /// </summary>
        [Fact]
        public void TestDanger() {
            _wrapper.SetContextAttribute( UiConst.Danger, true );
            var result = new StringBuilder();
            result.Append( "<a class=\"ant-btn-dangerous\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestRouterLink() {
            _wrapper.SetContextAttribute( AngularConst.RouterLink, "a" );
            var result = new StringBuilder();
            result.Append( "<a routerLink=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试路由链接
        /// </summary>
        [Fact]
        public void TestBindRouterLink() {
            _wrapper.SetContextAttribute( AngularConst.BindRouterLink, "a" );
            var result = new StringBuilder();
            result.Append( "<a [routerLink]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试活动路由链接
        /// </summary>
        [Fact]
        public void TestRouterLinkActive() {
            _wrapper.SetContextAttribute( AngularConst.RouterLinkActive, "a" );
            var result = new StringBuilder();
            result.Append( "<a routerLinkActive=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试活动路由链接
        /// </summary>
        [Fact]
        public void TestBindRouterLinkActive() {
            _wrapper.SetContextAttribute( AngularConst.BindRouterLinkActive, "a" );
            var result = new StringBuilder();
            result.Append( "<a [routerLinkActive]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单
        /// </summary>
        [Fact]
        public void TestDropdownMenu() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenu, "a" );
            var result = new StringBuilder();
            result.Append( "<a nz-dropdown=\"\" [nzDropdownMenu]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单弹出位置
        /// </summary>
        [Fact]
        public void TestDropdownMenuPlacement() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuPlacement, DropdownMenuPlacement.BottomLeft );
            var result = new StringBuilder();
            result.Append( "<a nzPlacement=\"bottomLeft\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单弹出位置
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuPlacement() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuPlacement, "a" );
            var result = new StringBuilder();
            result.Append( "<a [nzPlacement]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单触发方式
        /// </summary>
        [Fact]
        public void TestDropdownMenuTrigger() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuTrigger, DropdownMenuTrigger.Click );
            var result = new StringBuilder();
            result.Append( "<a nzTrigger=\"click\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单触发方式
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuTrigger() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuTrigger, "a" );
            var result = new StringBuilder();
            result.Append( "<a [nzTrigger]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试点击隐藏下拉菜单
        /// </summary>
        [Fact]
        public void TestDropdownMenuClickHide() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuClickHide, "false" );
            var result = new StringBuilder();
            result.Append( "<a [nzClickHide]=\"false\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单可见性
        /// </summary>
        [Fact]
        public void TestDropdownMenuVisible() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuVisible, "false" );
            var result = new StringBuilder();
            result.Append( "<a [nzVisible]=\"false\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单可见性
        /// </summary>
        [Fact]
        public void TestBindonDropdownMenuVisible() {
            _wrapper.SetContextAttribute( AngularConst.BindonDropdownMenuVisible, "a" );
            var result = new StringBuilder();
            result.Append( "<a [(nzVisible)]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单根元素类名
        /// </summary>
        [Fact]
        public void TestDropdownMenuOverlayClassName() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<a nzOverlayClassName=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单根元素类名
        /// </summary>
        [Fact]
        public void TestBindDropdownMenuOverlayClassName() {
            _wrapper.SetContextAttribute( AngularConst.BindDropdownMenuOverlayClassName, "a" );
            var result = new StringBuilder();
            result.Append( "<a [nzOverlayClassName]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单根元素样式
        /// </summary>
        [Fact]
        public void TestDropdownMenuOverlayStyle() {
            _wrapper.SetContextAttribute( UiConst.DropdownMenuOverlayStyle, "a" );
            var result = new StringBuilder();
            result.Append( "<a [nzOverlayStyle]=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试间距项
        /// </summary>
        [Fact]
        public void TestSpaceItem() {
            _wrapper.SetContextAttribute( UiConst.SpaceItem, true );
            var result = new StringBuilder();
            result.Append( "<a *nzSpaceItem=\"\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询表单链接 - 查询条件数量超过初始显示数量则显示
        /// </summary>
        [Fact]
        public void TestIsSearch_1() {
            _wrapper.SetContextAttribute( UiConst.IsSearch, true );
            var formShareConfig = new FormShareConfig { SearchFormShowNumber = 1 };
            formShareConfig.AddColumnId( "a" );
            formShareConfig.AddColumnId( "b" );
            formShareConfig.AddColumnId( "action" );
            _wrapper.SetItem( formShareConfig );

            var result = new StringBuilder();
            result.Append( "<a (click)=\"expand=!expand\">" );
            result.Append( "{{expand?'收起':'展开'}}" );
            result.Append( "<i nz-icon=\"\" [nzType]=\"expand?'up':'down'\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询表单链接 - 查询条件数量超过初始显示数量则显示 - 多语言
        /// </summary>
        [Fact]
        public void TestIsSearch_2() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.IsSearch, true );
            var formShareConfig = new FormShareConfig { SearchFormShowNumber = 1 };
            formShareConfig.AddColumnId( "a" );
            formShareConfig.AddColumnId( "b" );
            formShareConfig.AddColumnId( "action" );
            _wrapper.SetItem( formShareConfig );

            var result = new StringBuilder();
            result.Append( "<a (click)=\"expand=!expand\">" );
            result.Append( "{{expand?('util.collapse'|i18n):('util.expand'|i18n)}}" );
            result.Append( "<i nz-icon=\"\" [nzType]=\"expand?'up':'down'\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试查询表单链接 - 查询条件数量少于等于初始显示数量则不显示
        /// </summary>
        [Fact]
        public void TestIsSearch_3() {
            _wrapper.SetContextAttribute( UiConst.IsSearch, true );
            var formShareConfig = new FormShareConfig { SearchFormShowNumber = 2 };
            formShareConfig.AddColumnId( "a" );
            formShareConfig.AddColumnId( "b" );
            formShareConfig.AddColumnId( "action" );
            _wrapper.SetItem( formShareConfig );
            Assert.Empty( GetResult() );
        }

        /// <summary>
        /// 测试显示表格设置
        /// </summary>
        [Fact]
        public void TestShowTableSettings() {
            _wrapper.SetContextAttribute( UiConst.ShowTableSettings, "a" );
            var result = new StringBuilder();
            result.Append( "<a (click)=\"ts_a.show()\" class=\"card-tool-icon-btn\" nz-tooltip=\"\" nzTooltipTitle=\"表格设置\">" );
            result.Append( "<i nz-icon=\"\" nzType=\"setting\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试显示表格设置 - 多语言
        /// </summary>
        [Fact]
        public void TestShowTableSettings_i18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.ShowTableSettings, "a" );
            var result = new StringBuilder();
            result.Append( "<a (click)=\"ts_a.show()\" class=\"card-tool-icon-btn\" nz-tooltip=\"\" [nzTooltipTitle]=\"'util.tableSettings'|i18n\">" );
            result.Append( "<i nz-icon=\"\" nzType=\"setting\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试全屏
        /// </summary>
        [Fact]
        public void TestFullscreen() {
            _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
            var result = new StringBuilder();
            result.Append( "<a #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a)\" class=\"card-tool-icon-btn\" " );
            result.Append( "nz-tooltip=\"\" x-button-extend=\"\" [nzTooltipTitle]=\"x_id.isFullscreen?'退出全屏':'全屏'\">" );
            result.Append( "<i *ngIf=\"!x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen\"></i>" );
            result.Append( "<i *ngIf=\"x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen-exit\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试全屏 - 多语言
        /// </summary>
        [Fact]
        public void TestFullscreen_I18n() {
            NgZorroOptionsService.SetOptions( new NgZorroOptions { EnableI18n = true } );
            _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
            var result = new StringBuilder();
            result.Append( "<a #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a)\" class=\"card-tool-icon-btn\" " );
            result.Append( "nz-tooltip=\"\" x-button-extend=\"\" [nzTooltipTitle]=\"(x_id.isFullscreen?'util.fullscreenExit':'util.fullscreen')|i18n\">" );
            result.Append( "<i *ngIf=\"!x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen\"></i>" );
            result.Append( "<i *ngIf=\"x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen-exit\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试全屏外层容器样式类名
        /// </summary>
        [Fact]
        public void TestFullscreenWrapClass() {
            _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
            _wrapper.SetContextAttribute( UiConst.FullscreenWrapClass, "b" );
            var result = new StringBuilder();
            result.Append( "<a #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,'b')\" class=\"card-tool-icon-btn\" " );
            result.Append( "nz-tooltip=\"\" x-button-extend=\"\" [nzTooltipTitle]=\"x_id.isFullscreen?'退出全屏':'全屏'\">" );
            result.Append( "<i *ngIf=\"!x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen\"></i>" );
            result.Append( "<i *ngIf=\"x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen-exit\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试全屏包装
        /// </summary>
        [Fact]
        public void TestFullscreenPack() {
            _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
            _wrapper.SetContextAttribute( UiConst.FullscreenPack, false );
            var result = new StringBuilder();
            result.Append( "<a #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,null,false)\" class=\"card-tool-icon-btn\" " );
            result.Append( "nz-tooltip=\"\" x-button-extend=\"\" [nzTooltipTitle]=\"x_id.isFullscreen?'退出全屏':'全屏'\">" );
            result.Append( "<i *ngIf=\"!x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen\"></i>" );
            result.Append( "<i *ngIf=\"x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen-exit\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试测试全屏标题
        /// </summary>
        [Fact]
        public void TestFullscreenTitle() {
            _wrapper.SetContextAttribute( UiConst.Fullscreen, "a" );
            _wrapper.SetContextAttribute( UiConst.FullscreenTitle, "b" );
            var result = new StringBuilder();
            result.Append( "<a #x_id=\"xButtonExtend\" (click)=\"x_id.fullscreen(a,null,true,'b')\" class=\"card-tool-icon-btn\" " );
            result.Append( "nz-tooltip=\"\" x-button-extend=\"\" [nzTooltipTitle]=\"x_id.isFullscreen?'退出全屏':'全屏'\">" );
            result.Append( "<i *ngIf=\"!x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen\"></i>" );
            result.Append( "<i *ngIf=\"x_id.isFullscreen\" nz-icon=\"\" nzTheme=\"outline\" nzType=\"fullscreen-exit\"></i>" );
            result.Append( "</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试内容
        /// </summary>
        [Fact]
        public void TestContent() {
            _wrapper.AppendContent( "a" );
            var result = new StringBuilder();
            result.Append( "<a>a</a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试单击事件
        /// </summary>
        [Fact]
        public void TestOnClick() {
            _wrapper.SetContextAttribute( UiConst.OnClick, "a" );
            var result = new StringBuilder();
            result.Append( "<a (click)=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }

        /// <summary>
        /// 测试下拉菜单显示状态变化事件
        /// </summary>
        [Fact]
        public void TestOnVisibleChange() {
            _wrapper.SetContextAttribute( UiConst.OnVisibleChange, "a" );
            var result = new StringBuilder();
            result.Append( "<a (nzVisibleChange)=\"a\"></a>" );
            Assert.Equal( result.ToString(), GetResult() );
        }
    }
}