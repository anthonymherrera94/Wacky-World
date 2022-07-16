using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource SFXPrefab;
    [SerializeField]
    private int maxPoolSize = 10;

    private List<AudioSource> pool = new List<AudioSource>();
    private List<AudioSource> active = new List<AudioSource>();
    public static SoundManager Instance { get; protected set; }
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        transform.parent = null;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
            pool.Add(Instantiate(SFXPrefab, transform));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffect(AudioClip sfx)
    {
        if (pool.Count == 0)
            if (active.Count < maxPoolSize)
                pool.Add(Instantiate(SFXPrefab, transform));
            else
            {
                Debug.Log("SFX Pool size limit");
                return;
            }

        pool[0].clip = sfx;
        pool[0].Play();
        active.Add(pool[0]);
        pool.RemoveAt(0);
    }
}
