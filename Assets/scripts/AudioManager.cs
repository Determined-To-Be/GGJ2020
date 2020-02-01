using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    // create matching group in mixer
    public enum Channel { player, friendly, hostile, ambientActive, ambientPassive, background };

    #pragma warning disable 0649
    [SerializeField] float variety;
    [SerializeField] AudioClip[] samples;
    #pragma warning restore 0649
    
    AudioSource[] channels;
    AudioMixer mixer;

    // UnityEvent playTestSample = new UnityEvent();

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
        // start bg music
        channels[(int) Channel.background].loop = true;
        PlaySound(Channel.background, GetSample("background.wav"));

        // PlayAmbientClips();

        // // sample event
        // if (playTestSample == null)
        //     playTestSample = new UnityEvent();
        // playTestSample.AddListener(PlayTestSample);
        
        // playTestSample.Invoke();
    }

    void Awake()
    {
        if (_Instance == null)
            _Instance = GetComponent<AudioManager>();
        else if (_Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        mixer = Resources.Load("Master") as AudioMixer;
        channels = new AudioSource[System.Enum.GetNames(typeof(Channel)).Length];
        string[] names = Channel.GetNames(typeof(Channel));
        for (int chan = 0; chan < channels.Length; chan++)
        {
            channels[chan].outputAudioMixerGroup = mixer.FindMatchingGroups(names[chan])[0];
        }
    }

    void Update()
    {

    }

    public void PlaySoundOnce(Channel chan, AudioClip smpl, float vol = 1f, float pitch = 1f, bool rand = false)
    {
        int chin = (int) chan;
        channels[chin].volume = vol;
        channels[chin].pitch = pitch + (rand ? Random.Range(-variety, variety) : 0f);
        channels[chin].PlayOneShot(smpl);
    }

    public void PlaySound(Channel chan, AudioClip smpl, float vol = 1f, float pitch = 1f, bool rand = false)
    {
        StartCoroutine(PlaySoundThrough(chan, smpl, vol, pitch, rand));
    }

    IEnumerator PlaySoundThrough(Channel chan, AudioClip smpl, float vol, float pitch, bool rand)
    {
        int chin = (int) chan;
        channels[chin].volume = vol;
        channels[chin].pitch = pitch + (rand ? Random.Range(-variety, variety) : 0f);
        channels[chin].clip = smpl;
        channels[chin].Play();
        yield return new WaitWhile(() => channels[chin].isPlaying);
    }

    public bool IsPlaying(Channel chan)
    {
        return channels[(int) chan].isPlaying;
    }

    public void ToggleBackgroundMusic()
    {
        int chin = (int) Channel.background;
        if (channels[chin].isPlaying)
            channels[chin].Pause();
        else
            channels[chin].UnPause();
    }

    public AudioClip GetSample(string name)
    {
        foreach (AudioClip smpl in samples)
        {
            if (name.Equals(smpl.name))
                return smpl;
        }
        return null;
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

    // void PlayTestSample ()
    // {
    //     PlaySoundOnce(Channel.player, 0);
    // }
}
