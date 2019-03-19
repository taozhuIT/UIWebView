using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI显示网页
/// </summary>
public class UIWebViewPanel : MonoBehaviour
{
    // ui背景
    private Image uiBack;
    // UIWebView组件
    private UniWebView webView;
    // 关闭按钮
    private Button closeBtn;
    // 日志输出
    private Text rizhi;

    /// <summary>
    /// 初始
    /// </summary>
    private void Awake()
    {
        webView = this.transform.Find("UniWebView").gameObject.AddComponent<UniWebView>();
        uiBack = this.transform.Find("Back").GetComponent<Image>();
        closeBtn = this.transform.Find("CloseBtn").GetComponent<Button>();
        rizhi = this.transform.parent.Find("Text").GetComponent<Text>();

        closeBtn.onClick.AddListener(OnHidePanel);
    }

    /// <summary>
    /// 起始
    /// </summary>
    private void Start ()
    {
    }

    /// <summary>
    /// 更新
    /// </summary>
    private void Update ()
    {
	}

    /// <summary>
    /// 激活
    /// </summary>
    private void OnEnable()
    {
        webView.SetShowToolbar(true);
        webView.Frame = new Rect(0, 0, 0, 0);
        webView.ReferenceRectTransform = uiBack.rectTransform;

        webView.Load("http://www.baidu.com");
        webView.Show();

        webView.OnPageFinished += OnPageFinished;
        webView.OnMessageReceived += OnMessageReceived;
        webView.OnPageErrorReceived += OnPageErrorReceived;
    }

    /// <summary>
    /// 加载成功
    /// </summary>
    private void OnPageFinished(UniWebView webView, int statusCode, string url)
    {
        rizhi.text += "加载页面成功/n";
        rizhi.text += "http状态："+statusCode.ToString()+"/n";
        rizhi.text += "url：" + url + "/n";
    }

    /// <summary>
    /// “uniwebview://”模式在列表中是默认的，因此单击链接以“uniwebview://”开始。
    /// </summary>
    private void OnMessageReceived(UniWebView webView, UniWebViewMessage message)
    {

    }

    /// <summary>
    /// 加载错误
    /// </summary>
    private void OnPageErrorReceived(UniWebView webView, int errorCode, string errorMessage)
    {
        rizhi.text = "加载页面错误";
        // 重新加载当前页面
        webView.Reload();
    }

    /// <summary>
    /// 隐藏界面
    /// </summary>
    private void OnHidePanel()
    {
        this.gameObject.SetActive(false);
    }
}
