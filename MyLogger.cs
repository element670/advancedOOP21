using System;
using UnityEngine;

public class MyLogger
{
    private static IAnalytics _analytics;
    MyLogger(IAnalytics analytics)
    {
        _analytics = analytics;
    }
    public static void Logd(string message, bool sendAnalyticsLog = false)
    {
        Console.Write(message);
        MonoBehaviour.print(message);
        if(sendAnalyticsLog)
            _analytics.SendAnalytic();
        Debug.Log(message);
    }
    
    public static void Logv(string message)
    {
        Debug.LogWarning(message);
    }
    
    public static void Loge(string message)
    {
        Debug.LogError(message);
    }
    
}

interface IAnalytics
{
    void SendAnalytic();
}

class GoogleAnalytics : IAnalytics
{
    public void SendAnalytic()
    {
        
    }
}

class UnityAnalytics : IAnalytics
{
    public void SendAnalytic()
    {
        
    }
}