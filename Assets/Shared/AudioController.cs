using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour {
	[SerializeField] AudioClip[] clips;
	[SerializeField] float delayBetweenClips;

	bool canplay;
	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent < AudioSource>();
		canplay = true;
	}
	
	// Update is called once per frame
	public void Play () {

		if (!canplay)
			return;
		GameManager.Instance.Timer.Add (() => {
			canplay = true;
		}, delayBetweenClips);

		canplay = false;

		int clipIndex = Random.Range (0, clips.Length);
		AudioClip clip = clips [clipIndex];
		source.PlayOneShot (clip);
		
	}
}
