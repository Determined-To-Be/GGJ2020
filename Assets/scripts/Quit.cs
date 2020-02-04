using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    Coroutine noWaitDont;

    public void EndTheSimulation()
    {
        noWaitDont = StartCoroutine(Stop());
    }

    public void Cancel()
    {
        StopCoroutine(noWaitDont);
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(5f);
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_WEBPLAYER
        Application.OpenURL("https://sbarrack.itch.io/drone-seamulator");
        #else
        Application.Quit();
        #endif
        yield return null;
    }
}
