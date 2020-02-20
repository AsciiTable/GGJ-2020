using UnityEngine;

[System.Serializable]public class Sound {
    public string name;
    public AudioClip clip;
    private AudioSource source;
    [Range(0f, 1f)] public float volume = 0.7f;
    [Range(0.5f, 1.5f)] public float pitch = 1.0f;
    public void SetSource(AudioSource _source) {
        source = _source;
        source.clip = clip;
    }
    public void Play() {
        source.volume = volume;
        source.pitch = pitch;
        source.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance; 

    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    private void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioManager");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        for (int i = 0; i < sounds.Length; i++) {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlaySound(string _name) {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name.Equals(_name)) {
                sounds[i].Play();
                return;
            }
        }
        Debug.LogWarning(_name + " sound not found in AudioManager.");
    }
}
