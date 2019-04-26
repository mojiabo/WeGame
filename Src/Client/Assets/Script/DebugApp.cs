using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugApp
{


    public static void Log(object message)
    {
#if DEBUG_MODEL
        Debug.Log(message);
#endif
    }
    public static void LogError(object message)
    {
#if DEBUG_MODEL
        Debug.LogError(message);
#endif
    }


}
