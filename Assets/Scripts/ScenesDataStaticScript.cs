using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScenesDataStaticScript
{

    public static float speed { get; set; }
    public static float timeFromStart { get; set; }
    public static int counter { get; private set; }

    public static void increaseCounter()
    {
        counter++;
    }
}
