﻿using Util.Ui.NgZorro.Enums;

namespace Util.Ui.NgZorro.Components.Base; 

/// <summary>
/// 按钮基类
/// </summary>
public abstract class ButtonTagHelperBase : TooltipTagHelperBase {
    /// <summary>
    /// 扩展属性,全屏切换,设置需要全屏的内容区引用变量,范例 &lt;div #id> , 传入 id
    /// </summary>
    public string Fullscreen { get; set; }
    /// <summary>
    /// 扩展属性,全屏标题
    /// </summary>
    public string FullscreenTitle { get; set; }
    /// <summary>
    /// 扩展属性,进入全屏时,外层容器添加的样式类名, 设置为true,则设置默认样式类 x-fullscreen
    /// </summary>
    public string FullscreenWrapClass { get; set; }
    /// <summary>
    /// 扩展属性,全屏是否创建标题和页脚进行包装,默认值: true, 设置为 false 则完全受控,fullscreen-title 和 fullscreen-wrap-class 将无效
    /// </summary>
    public bool FullscreenPack { get; set; }
    /// <summary>
    /// 扩展属性,内容文本,支持i18n
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// 扩展属性,是否显示ok文本,默认文本为'Ok',i18n文本为'util.ok'
    /// </summary>
    public bool TextOk { get; set; }
    /// <summary>
    /// 扩展属性,是否显示cancel文本,默认文本为'Cancel',i18n文本为'util.cancel'
    /// </summary>
    public bool TextCancel { get; set; }
    /// <summary>
    /// 扩展属性,是否显示create文本,默认文本为'Create',i18n文本为'util.create'
    /// </summary>
    public bool TextCreate { get; set; }
    /// <summary>
    /// 扩展属性,是否显示update文本,默认文本为'Update',i18n文本为'util.update'
    /// </summary>
    public bool TextUpdate { get; set; }
    /// <summary>
    /// 扩展属性,是否显示delete文本,默认文本为'Delete',i18n文本为'util.delete'
    /// </summary>
    public bool TextDelete { get; set; }
    /// <summary>
    /// 扩展属性,是否显示detail文本,默认文本为'Detail',i18n文本为'util.detail'
    /// </summary>
    public bool TextDetail { get; set; }
    /// <summary>
    /// 扩展属性,是否显示query文本,默认文本为'Query',i18n文本为'util.query'
    /// </summary>
    public bool TextQuery { get; set; }
    /// <summary>
    /// 扩展属性,是否显示refresh文本,默认文本为'Refresh',i18n文本为'util.refresh'
    /// </summary>
    public bool TextRefresh { get; set; }
    /// <summary>
    /// 扩展属性,是否显示save文本,默认文本为'Save',i18n文本为'util.save'
    /// </summary>
    public bool TextSave { get; set; }
    /// <summary>
    /// 扩展属性,是否显示enable文本,默认文本为'Enable',i18n文本为'util.enable'
    /// </summary>
    public bool TextEnable { get; set; }
    /// <summary>
    /// 扩展属性,是否显示disable文本,默认文本为'Disable',i18n文本为'util.disable'
    /// </summary>
    public bool TextDisable { get; set; }
    /// <summary>
    /// 扩展属性,是否显示select all文本,默认文本为'Select All',i18n文本为'util.selectAll'
    /// </summary>
    public bool TextSelectAll { get; set; }
    /// <summary>
    /// 扩展属性,是否显示deselect all文本,默认文本为'Deselect All',i18n文本为'util.deselectAll'
    /// </summary>
    public bool TextDeselectAll { get; set; }
    /// <summary>
    /// 扩展属性,是否显示upload文本,默认文本为'Upload',i18n文本为'util.upload'
    /// </summary>
    public bool TextUpload { get; set; }
    /// <summary>
    /// 扩展属性,是否显示download文本,默认文本为'Download',i18n文本为'util.download'
    /// </summary>
    public bool TextDownload { get; set; }
    /// <summary>
    /// 扩展属性,是否显示publish文本,默认文本为'Publish',i18n文本为'util.publish'
    /// </summary>
    public bool TextPublish { get; set; }
    /// <summary>
    /// 扩展属性,是否显示run文本,默认文本为'Run',i18n文本为'util.run'
    /// </summary>
    public bool TextRun { get; set; }
    /// <summary>
    /// 扩展属性,是否显示start文本,默认文本为'Start',i18n文本为'util.start'
    /// </summary>
    public bool TextStart { get; set; }
    /// <summary>
    /// 扩展属性,是否显示stop文本,默认文本为'Stop',i18n文本为'util.stop'
    /// </summary>
    public bool TextStop { get; set; }
    /// <summary>
    /// 扩展属性,是否显示add文本,默认文本为'Add',i18n文本为'util.add'
    /// </summary>
    public bool TextAdd { get; set; }
    /// <summary>
    /// 扩展属性,是否显示remove文本,默认文本为'Remove',i18n文本为'util.remove'
    /// </summary>
    public bool TextRemove { get; set; }
    /// <summary>
    /// 扩展属性,是否显示open文本,默认文本为'Open',i18n文本为'util.open'
    /// </summary>
    public bool TextOpen { get; set; }
    /// <summary>
    /// 扩展属性,是否显示close文本,默认文本为'Close',i18n文本为'util.close'
    /// </summary>
    public bool TextClose { get; set; }
    /// <summary>
    /// 扩展属性,是否显示send文本,默认文本为'Send',i18n文本为'util.send'
    /// </summary>
    public bool TextSend { get; set; }
    /// <summary>
    /// 扩展属性,是否显示clear文本,默认文本为'Clear',i18n文本为'util.clear'
    /// </summary>
    public bool TextClear { get; set; }
    /// <summary>
    /// 扩展属性,是否显示import文本,默认文本为'Import',i18n文本为'util.import'
    /// </summary>
    public bool TextImport { get; set; }
    /// <summary>
    /// 扩展属性,是否显示export文本,默认文本为'Export',i18n文本为'util.export'
    /// </summary>
    public bool TextExport { get; set; }
    /// <summary>
    /// 扩展属性,是否显示reset文本,默认文本为'Reset',i18n文本为'util.reset'
    /// </summary>
    public bool TextReset { get; set; }
    /// <summary>
    /// 扩展属性,是否显示unedit文本,默认文本为'UnEdit',i18n文本为'util.unedit'
    /// </summary>
    public bool TextUnedit { get; set; }
    /// <summary>
    /// routerLink,路由链接,当按钮类型为链接时可用
    /// </summary>
    public string RouterLink { get; set; }
    /// <summary>
    /// [routerLink],路由链接,当按钮类型为链接时可用
    /// </summary>
    public string BindRouterLink { get; set; }
    /// <summary>
    /// routerLinkActive,活动路由链接,设置当前活动路由链接的css类,当按钮类型为链接时可用
    /// </summary>
    public string RouterLinkActive { get; set; }
    /// <summary>
    /// [routerLinkActive],活动路由链接,设置当前活动路由链接的css类,当按钮类型为链接时可用
    /// </summary>
    public string BindRouterLinkActive { get; set; }
    /// <summary>
    /// [nzDropdownMenu],设置下拉菜单
    /// </summary>
    public string DropdownMenu { get; set; }
    /// <summary>
    /// nzPlacement,下拉菜单弹出位置
    /// </summary>
    public DropdownMenuPlacement DropdownMenuPlacement { get; set; }
    /// <summary>
    /// [nzPlacement],下拉菜单弹出位置
    /// </summary>
    public string BindDropdownMenuPlacement { get; set; }
    /// <summary>
    /// nzTrigger,下拉菜单触发方式
    /// </summary>
    public DropdownMenuTrigger DropdownMenuTrigger { get; set; }
    /// <summary>
    /// [nzTrigger],下拉菜单触发方式
    /// </summary>
    public string BindDropdownMenuTrigger { get; set; }
    /// <summary>
    /// [nzClickHide],点击后是否隐藏下拉菜单,默认值:true
    /// </summary>
    public string DropdownMenuClickHide { get; set; }
    /// <summary>
    /// [nzVisible],下拉菜单是否可见
    /// </summary>
    public string DropdownMenuVisible { get; set; }
    /// <summary>
    /// [(nzVisible)],下拉菜单是否可见
    /// </summary>
    public string BindonDropdownMenuVisible { get; set; }
    /// <summary>
    /// nzOverlayClassName,下拉菜单根元素类名
    /// </summary>
    public string DropdownMenuOverlayClassName { get; set; }
    /// <summary>
    /// [nzOverlayClassName],下拉菜单根元素类名
    /// </summary>
    public string BindDropdownMenuOverlayClassName { get; set; }
    /// <summary>
    /// [nzOverlayStyle],下拉菜单根元素样式
    /// </summary>
    public string DropdownMenuOverlayStyle { get; set; }
    /// <summary>
    /// *nzSpaceItem,值为true时设置为间距项,放入 nz-space 组件中使用
    /// </summary>
    public bool SpaceItem { get; set; }
    /// <summary>
    /// nzPopoverTitle,气泡卡片标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string PopoverTitle { get; set; }
    /// <summary>
    /// [nzPopoverTitle],气泡卡片标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopoverTitle { get; set; }
    /// <summary>
    /// nzPopoverContent,气泡卡片内容,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string PopoverContent { get; set; }
    /// <summary>
    /// [nzPopoverContent],气泡卡片内容,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopoverContent { get; set; }
    /// <summary>
    /// nzPopoverTrigger,气泡卡片触发行为,为 null 时不响应光标事件,可选值: 'click' | 'focus' | 'hover' | null,默认值: 'hover'
    /// </summary>
    public PopoverTrigger PopoverTrigger { get; set; }
    /// <summary>
    /// [nzPopoverTrigger],气泡卡片触发行为,为 null 时不响应光标事件,可选值: 'click' | 'focus' | 'hover' | null,默认值: 'hover'
    /// </summary>
    public string BindPopoverTrigger { get; set; }
    /// <summary>
    /// nzPopoverPlacement,气泡卡片位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public PopoverPlacement PopoverPlacement { get; set; }
    /// <summary>
    /// [nzPopoverPlacement],气泡卡片位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public string BindPopoverPlacement { get; set; }
    /// <summary>
    /// nzPopoverOrigin,气泡卡片定位元素,类型: ElementRef
    /// </summary>
    public string PopoverOrigin { get; set; }
    /// <summary>
    /// [nzPopoverOrigin],气泡卡片定位元素,类型: ElementRef
    /// </summary>
    public string BindPopoverOrigin { get; set; }
    /// <summary>
    /// [nzPopoverVisible],气泡卡片是否可见,默认值: false
    /// </summary>
    public string PopoverVisible { get; set; }
    /// <summary>
    /// [(nzPopoverVisible)],气泡卡片是否可见,默认值: false
    /// </summary>
    public string BindonPopoverVisible { get; set; }
    /// <summary>
    /// [nzPopoverMouseEnterDelay],鼠标移入后延时多久才显示气泡卡片，单位：秒,默认值: 0.15
    /// </summary>
    public string PopoverMouseEnterDelay { get; set; }
    /// <summary>
    /// [nzPopoverMouseLeaveDelay],鼠标移出后延时多久才隐藏气泡卡片，单位：秒,默认值: 0.1
    /// </summary>
    public string PopoverMouseLeaveDelay { get; set; }
    /// <summary>
    /// nzPopoverOverlayClassName,气泡卡片样式类名
    /// </summary>
    public string PopoverOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopoverOverlayClassName],气泡卡片样式类名
    /// </summary>
    public string BindPopoverOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopoverOverlayStyle],气泡卡片样式,类型: object
    /// </summary>
    public string PopoverOverlayStyle { get; set; }
    /// <summary>
    /// [nzPopoverBackdrop],气泡卡片浮层是否带背景,默认值: false
    /// </summary>
    public string PopoverBackdrop { get; set; }
    /// <summary>
    /// (click),单击事件
    /// </summary>
    public string OnClick { get; set; }
    /// <summary>
    /// (nzVisibleChange),下拉菜单显示状态变化事件
    /// </summary>
    public string OnVisibleChange { get; set; }
    /// <summary>
    /// (nzPopoverVisibleChange),气泡卡片显示状态变化事件,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnPopoverVisibleChange { get; set; }
    /// <summary>
    /// nzPopconfirmTitle,气泡确认框标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string PopconfirmTitle { get; set; }
    /// <summary>
    /// [nzPopconfirmTitle],气泡确认框标题,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopconfirmTitle { get; set; }
    /// <summary>
    /// nzPopconfirmTrigger,气泡确认框触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
    /// </summary>
    public PopconfirmTrigger PopconfirmTrigger { get; set; }
    /// <summary>
    /// [nzPopconfirmTrigger],气泡确认框触发行为,可选值: 'click' | 'focus' | 'hover' | null,为 null 时不响应光标事件,默认值: 'hover'
    /// </summary>
    public string BindPopconfirmTrigger { get; set; }
    /// <summary>
    /// nzPopconfirmPlacement,气泡确认框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public PopconfirmPlacement PopconfirmPlacement { get; set; }
    /// <summary>
    /// [nzPopconfirmPlacement],气泡确认框位置,类型: 'top' | 'left' | 'right' | 'bottom' | 'topLeft' | 'topRight' | 'bottomLeft' | 'bottomRight' | 'leftTop' | 'leftBottom' | 'rightTop' | 'rightBottom' | Array&lt;string>,默认值: 'top'
    /// </summary>
    public string BindPopconfirmPlacement { get; set; }
    /// <summary>
    /// [nzPopconfirmOrigin],气泡确认框定位元素,类型: ElementRef
    /// </summary>
    public string PopconfirmOrigin { get; set; }
    /// <summary>
    /// [nzPopconfirmVisible],气泡确认框是否可见,默认值: false
    /// </summary>
    public string PopconfirmVisible { get; set; }
    /// <summary>
    /// [nzPopconfirmShowArrow],气泡确认框是否显示箭头,默认值: true
    /// </summary>
    public string PopconfirmShowArrow { get; set; }
    /// <summary>
    /// [nzPopconfirmMouseEnterDelay],鼠标移入后延时多久才显示气泡确认框，单位：秒,默认值: 0.15
    /// </summary>
    public string PopconfirmMouseEnterDelay { get; set; }
    /// <summary>
    /// nzPopconfirmMouseLeaveDelay,鼠标移出后延时多久才隐藏气泡确认框，单位：秒,默认值: 0.1
    /// </summary>
    public double PopconfirmMouseLeaveDelay { get; set; }
    /// <summary>
    /// [nzPopconfirmMouseLeaveDelay],鼠标移出后延时多久才隐藏气泡确认框，单位：秒,默认值: 0.1
    /// </summary>
    public string BindPopconfirmMouseLeaveDelay { get; set; }
    /// <summary>
    /// nzPopconfirmOverlayClassName,气泡确认框样式类名
    /// </summary>
    public string PopconfirmOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopconfirmOverlayClassName],气泡确认框样式类名
    /// </summary>
    public string BindPopconfirmOverlayClassName { get; set; }
    /// <summary>
    /// [nzPopconfirmOverlayStyle],气泡确认框样式,类型: object
    /// </summary>
    public string PopconfirmOverlayStyle { get; set; }
    /// <summary>
    /// [nzPopconfirmBackdrop],气泡确认框浮层是否应带背景,默认值: false
    /// </summary>
    public bool PopconfirmBackdrop { get; set; }
    /// <summary>
    /// [nzPopconfirmBackdrop],气泡确认框浮层是否应带背景,默认值: false
    /// </summary>
    public string BindPopconfirmBackdrop { get; set; }
    /// <summary>
    /// nzCancelText,气泡确认框取消按钮文字,默认值: '取消'
    /// </summary>
    public string PopconfirmCancelText { get; set; }
    /// <summary>
    /// [nzCancelText],气泡确认框取消按钮文字,默认值: '取消'
    /// </summary>
    public string BindPopconfirmCancelText { get; set; }
    /// <summary>
    /// nzOkText,气泡确认框确认按钮文字,默认值: '确定'
    /// </summary>
    public string PopconfirmOkText { get; set; }
    /// <summary>
    /// [nzOkText],气泡确认框确认按钮文字,默认值: '确定'
    /// </summary>
    public string BindPopconfirmOkText { get; set; }
    /// <summary>
    /// nzOkType,气泡确认框确认按钮类型,默认值: 'primary'
    /// </summary>
    public ButtonType PopconfirmOkType { get; set; }
    /// <summary>
    /// [nzOkType],气泡确认框确认按钮类型,默认值: 'primary'
    /// </summary>
    public string BindPopconfirmOkType { get; set; }
    /// <summary>
    /// [nzCondition],气泡确认框条件触发,是否直接触发 nzOnConfirm 事件,而不弹出框,默认值: false
    /// </summary>
    public bool PopconfirmCondition { get; set; }
    /// <summary>
    /// [nzCondition],气泡确认框条件触发,是否直接触发 nzOnConfirm 事件,而不弹出框,默认值: false
    /// </summary>
    public string BindPopconfirmCondition { get; set; }
    /// <summary>
    /// nzIcon,气泡确认框自定义图标,类型: string | TemplateRef&lt;void>
    /// </summary>
    public AntDesignIcon PopconfirmIcon { get; set; }
    /// <summary>
    /// [nzIcon],气泡确认框自定义图标,类型: string | TemplateRef&lt;void>
    /// </summary>
    public string BindPopconfirmIcon { get; set; }
    /// <summary>
    /// (nzPopconfirmVisibleChange),气泡确认框显示状态变化事件,类型: EventEmitter&lt;boolean>
    /// </summary>
    public string OnPopconfirmVisibleChange { get; set; }
    /// <summary>
    /// (nzOnCancel),取消事件,点击取消按钮时触发,类型: EventEmitter&lt;void>
    /// </summary>
    public string OnPopconfirmCancel { get; set; }
    /// <summary>
    /// (nzOnConfirm),确认事件,点击确认按钮时触发,类型: EventEmitter&lt;void>
    /// </summary>
    public string OnPopconfirmConfirm { get; set; }
}