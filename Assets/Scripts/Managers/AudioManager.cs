using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{



	public AudioSource MusicSource;

	public static AudioManager Instance = null;

	[SerializeField] private List<AudioClip> musicSources = new List<AudioClip>();

	private void Awake()
	{
		// Setting up singleton
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	// Start is called before the first frame update
	void Start()
    {
		SelectMusicTrack(0);
		MusicSource.loop = true;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void SelectMusicTrack(int clipIndex = 0)
    {
		MusicSource.clip = musicSources[clipIndex];
		MusicSource.Play();
    }

}
