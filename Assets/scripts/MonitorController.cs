using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonitorController : MonoBehaviour
{
    #pragma warning disable 0649
    [SerializeField] float maxStaticTime, minStaticTime, speed, speedOn, minStaticDelay, maxStaticDelay;
    [SerializeField] bool randomOff;
    #pragma warning restore 0649

    AudioClip noise;
    Material screen;
    int toggle, toggleStatic; // toggle is inverted
    float f;

    void Awake()
    {

    }

    void Start()
    {
        screen = gameObject.GetComponent<MeshRenderer>().material;
        noise = AudioManager.Instance.GetSample("ambientActive_noise");
        toggle = screen.GetInt("_TurnOn");
        if (!randomOff) StartCoroutine(Interference());
    }

    void Update()
    {
            if (toggle == 0 && f > 0f)
            {
                f -= Time.deltaTime * speed;
                if (f < 0f) f = 0f;
                screen.SetFloat("_TurnOnProgress", f);
            }
            else if (toggle != 0 && f < 1f)
            {
                f += Time.deltaTime * speedOn;
                if (f > 1f) f = 1f;
                screen.SetFloat("_TurnOnProgress", f);
            }
    }

    public void TogglePower()
    {
        if (toggleStatic == 0)
            screen.SetInt("_TurnOn", toggle = (toggle == 0 ? 1 : 0));
    }
    
    public void StaticOff()
    {
        AudioManager.Instance.StopSound(AudioManager.Channel.ambientActive);
        screen.SetInt("_Static",  toggleStatic = 0);
    }

    public void StaticOn()
    {
        AudioManager.Instance.StartSound(AudioManager.Channel.ambientActive, noise);
        screen.SetInt("_Static",  toggleStatic = 1);
    }

    IEnumerator Interference()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minStaticDelay, maxStaticDelay));
            StaticOn();
            yield return new WaitForSeconds(Random.Range(minStaticTime, maxStaticTime));
            StaticOff();
            yield return null;
        }
    }
}
