using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyAudio : MonoBehaviour {


	void Awake () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	
}
