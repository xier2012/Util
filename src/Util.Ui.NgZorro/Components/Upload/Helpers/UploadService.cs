﻿using Util.Ui.Configs;
using Util.Ui.NgZorro.Components.Forms.Helpers;

namespace Util.Ui.NgZorro.Components.Upload.Helpers; 

/// <summary>
/// 上传组件服务
/// </summary>
public class UploadService {
    /// <summary>
    /// 配置
    /// </summary>
    private readonly Config _config;

    /// <summary>
    /// 初始化上传组件服务
    /// </summary>
    /// <param name="config">配置</param>
    public UploadService( Config config ) {
        _config = config;
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init() {
        LoadExpression();
        InitValidationService();
        InitFormShareService();
        InitFormItemShareService();
    }

    /// <summary>
    /// 加载表达式
    /// </summary>
    private void LoadExpression() {
        var loader = new UploadExpressionLoader();
        loader.Load( _config );
    }

    /// <summary>
    /// 初始化验证服务
    /// </summary>
    private void InitValidationService() {
        var service = new ValidationService( _config );
        service.Init();
    }

    /// <summary>
    /// 初始化表单共享服务
    /// </summary>
    private void InitFormShareService() {
        var service = new FormShareService( _config );
        service.Init();
    }

    /// <summary>
    /// 初始化表单项共享服务
    /// </summary>
    private void InitFormItemShareService() {
        var service = new FormItemShareService( _config );
        service.Init();
        service.InitId();
    }
}