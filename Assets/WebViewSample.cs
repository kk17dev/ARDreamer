﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewSample : MonoBehaviour
{
        WebViewObject webViewObject;

    void Start()
    {
    }

    void OnGUI()
    {
        GUI.enabled = webViewObject.CanGoBack();
        if (GUI.Button(new Rect(10, 10, 80, 80), "<"))
        {
            // ブラウザ：前のページへ
            webViewObject.GoBack();
        }
        GUI.enabled = true;

        GUI.enabled = webViewObject.CanGoForward();
        if (GUI.Button(new Rect(100, 10, 80, 80), ">"))
        {
            // ブラウザ：次のページへ
            webViewObject.GoForward();
        }
        GUI.enabled = true;
    }

    public void createWebView() {
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init(
            ld: (msg) => Debug.Log(string.Format("CallOnLoaded[{0}]", msg)),
            enableWKWebView: true);

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        webViewObject.bitmapRefreshCycle = 1;
#endif
        // お好きなMarginにしてください
        webViewObject.SetMargins(200, 200, 200, 200);
        webViewObject.SetVisibility(true);
        // お好きなURLにしてください
        webViewObject.LoadURL("https://www.youtube.com/watch?v=b2OsMyWP684");
    }
}
