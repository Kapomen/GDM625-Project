﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SelectionSound : MonoBehaviour {

    public AudioClip sound;
    private Button button { get { return GetComponent<Button>(); } }
    private AudioSource source {get { return GetComponent<AudioSource>(); } }

	// Use this for initialization
	void Start () {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
        button.onClick.AddListener(() => playSound());
	}
	
	void playSound () {
        print("sound played: " + sound);
        source.PlayOneShot(sound);
	}
}
