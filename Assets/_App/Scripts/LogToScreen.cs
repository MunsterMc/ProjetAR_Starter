using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogToScreen : MonoBehaviour
{
    uint qsize = 15;
    Queue logQueue = new Queue();


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start logging...");
    }

    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;

    }

    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        logQueue.Enqueue("" + type + ": " + logString);

        if (type == LogType.Exception)
        {
            logQueue.Enqueue(stackTrace);
            while (logQueue.Count > qsize)
            {
                logQueue.Dequeue();
            }
        }

    }

    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(Screen.width - 400, 0, 400, Screen.height));
        GUILayout.Label("\n" + string.Join("\n", logQueue.ToArray()));
        GUILayout.EndArea();
    }
}