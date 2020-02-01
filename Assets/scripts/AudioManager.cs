using System.Collections;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    #pragma warning disable 0649
    [SerializeField] float variety;
    [SerializeField] AudioClip[] samples;
    #pragma warning restore 0649
    
    public enum Channel { player, friendly, hostile, ambientActive, ambientPassive, background };
    AudioSource[] channels;

    UnityEvent playTestSample = new UnityEvent();

    static AudioManager _Instance;
    public static AudioManager Instance
    {
        get
        {
            if (_Instance != null)
            {
                return _Instance;
            }

            GameObject obj = new GameObject();
            _Instance = obj.AddComponent<AudioManager>();
            return _Instance;
        }
    }

    void Start()
    {
        // PlayBackgroundTrack();
        // PlayAmbientClips();

        if (playTestSample == null)
            playTestSample = new UnityEvent();
        playTestSample.AddListener(PlayTestSample);
        
        playTestSample.Invoke();
    }

    void Awake()
    {
        if (_Instance == null)
            _Instance = GetComponent<AudioManager>();
        else if (_Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        channels = new AudioSource[System.Enum.GetNames(typeof(Channel)).Length];
    }

    void Update ()
    {

    }

    public void PlaySoundOnce(Channel chan, int smpl, float pitch = 1f, bool rand = false)
    {
        int chin = (int) chan;
        channels[chin].pitch = pitch + (rand ? Random.Range(-variety, variety) : 0f);
        channels[chin].PlayOneShot(samples[smpl]);
    }

    public void PlaySound(Channel chan, int smpl, float pitch = 1f, bool rand = false)
    {
        StartCoroutine(PlaySoundThrough(chan, smpl, pitch, rand));
    }

    IEnumerator PlaySoundThrough(Channel chan, int smpl, float pitch, bool rand)
    {
        int chin = (int) chan;
        channels[chin].pitch = pitch + (rand ? Random.Range(-variety, variety) : 0f);
        channels[chin].clip = samples[smpl];
        channels[chin].Play();
        yield return new WaitWhile(() => channels[chin].isPlaying);
    }

    // IEnumerator DoAmbientClips()
    // {
    //     while (true)
    //     {
    //         yield return new WaitForSeconds(Random.Range(10f, 30f));
    //         player[2].clip = ambientClips[Mathf.FloorToInt(Random.Range(0f, (ambientClips.Length - Mathf.Epsilon)))];
    //         player[2].Play();
    //         yield return new WaitWhile(() => player[2].isPlaying);
    //     }
    // }

    // void PlayAmbientClips()
    // {
    //     StartCoroutine(DoAmbientClips());
    // }

    void PlayTestSample ()
    {
        PlaySoundOnce(Channel.player, 0);
    }
}
