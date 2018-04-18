using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI显示网页
/// </summary>
public class UIWebViewPanel : MonoBehaviour
{
    // UIWebView组件
    [SerializeField] private UniWebView webView;
    
    /// <summary>
    /// 起始
    /// </summary>
    private void Start () {
        webView.OnLoadComplete += OnLoadComplete;
        webView.OnReceivedMessage += OnReceivedMessage;
        webView.OnEvalJavaScriptFinished += OnEvalJavaScriptFinished;

        // 得到显示网页面板的宽度和高度
        RectTransform panelRect = this.transform.GetComponent<RectTransform>();
        int offsetLeft = (int)Mathf.Abs(panelRect.offsetMin.x);
        int offsetRight = (int)Mathf.Abs(panelRect.offsetMax.x);
        int offsetTop = (int)Mathf.Abs(panelRect.offsetMin.y);
        int offsetBotton = (int)Mathf.Abs(panelRect.offsetMax.y);

        webView.insets = new UniWebViewEdgeInsets(offsetTop, offsetLeft, offsetBotton, offsetRight);    // 距离全屏差5个像素  
        webView.url = "http://www.baidu.com";
        webView.Load();
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update () {
		
	}

    /// <summary>
    /// 加载成功
    /// </summary>
    private void OnLoadComplete(UniWebView webView, bool success, string errorMessage)
    {
        if (success)
        {
            //  显示 加载完成的界面  
            webView.Show();
        }
        else
        {
            //   输出 错误码  
            Debug.LogError("Something wrong in webview loading: " + errorMessage);
        }
    }

    /// <summary>
    /// 加载成功
    /// </summary>
    private void OnReceivedMessage(UniWebView webView, UniWebViewMessage message)
    {

    }

    /// <summary>
    /// 加载成功
    /// </summary>
    private void OnEvalJavaScriptFinished(UniWebView webView, string result)
    {

    }
}
