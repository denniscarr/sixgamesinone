//http://www.cnblogs.com/gameprogram/archive/2012/08/15/2640357.html
//http://www.blog.silentkraken.com/2010/04/06/audiomanager/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

/// <summary>
/// This is mostly by Hang Ruan, using it also to assign music clips randomly
/// Currently written as a singleton.
/// </summary>

public class CoreySoundManager : MonoBehaviour {


	private static CoreySoundManager instance = null;

	[SerializeField] GameObject myPrefabSFX;

	bool _SFXOverload;
	[SerializeField] int maxSFX = 30;







	//========================================================================
	//enforce singleton pattern

	public static CoreySoundManager Instance {
		get { 
			return instance;
		}
	}

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
		} else {
			instance = this;
		}

		//DontDestroyOnLoad(this.gameObject);
	}
	//========================================================================
	//SFX INSTANTIATION
	//========================================================================

	//right now have 2 overloads one for just playing an SFX clip, another for pitch ctrl
	//could make more overloads for PLaySFX in the future

	void Start() {
		_SFXOverload = false;
	}

	void Update() {
		GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag ("CoreySFX");
//		Debug.Log (sfxObjects.Length);
		if (sfxObjects.Length >= maxSFX) {
			_SFXOverload = true;
		} else
			_SFXOverload = false;
	}

	public void PlaySFX (AudioClip g_SFX) {
		if (!_SFXOverload) {
			GameObject t_SFX = Instantiate (myPrefabSFX) as GameObject;
			t_SFX.name = "SFX_" + g_SFX.name;
			t_SFX.GetComponent<AudioSource> ().clip = g_SFX;
			//t_SFX.GetComponent<AudioSource> ().outputAudioMixerGroup = SFXGroup;
			t_SFX.GetComponent<AudioSource> ().Play ();
			DestroyObject (t_SFX, g_SFX.length);
		}	
	}

	public void PlaySFX (AudioClip g_SFX, float g_Pitch) {
		if (!_SFXOverload) {
			GameObject t_SFX = Instantiate (myPrefabSFX) as GameObject;
			t_SFX.name = "SFX_" + g_SFX.name;
			t_SFX.GetComponent<AudioSource> ().clip = g_SFX;
			t_SFX.GetComponent<AudioSource> ().pitch = g_Pitch;
			//t_SFX.GetComponent<AudioSource> ().outputAudioMixerGroup = SFXGroup;
			t_SFX.GetComponent<AudioSource> ().Play ();
			DestroyObject (t_SFX, g_SFX.length);
		}
	}




	//================================================================================
	// Background Music Functions
	//================================================================================
	//This stuff will probably be useless to the Dada game


	/*
	public void PlayBGM (AudioClip g_BGM) {
		if (myAudioSource.isPlaying == false) {
			myAudioSource.clip = g_BGM;
			myAudioSource.Play ();
			return;
		}

		if (g_BGM == myAudioSource.clip)
			return;

		myAudioSource.Stop ();
		myAudioSource.clip = g_BGM;
		myAudioSource.Play ();
	}

	public void PlayBGM (AudioClip g_BGM, float g_Volume) {
		if (myAudioSource.isPlaying == false) {
			myAudioSource.clip = g_BGM;
			myAudioSource.volume = g_Volume;
			myAudioSource.Play ();
			return;
		} else if (g_BGM == myAudioSource.clip) {
			myAudioSource.volume = g_Volume;
			return;
		}

		myAudioSource.Stop ();
		myAudioSource.clip = g_BGM;
		myAudioSource.volume = g_Volume;
		myAudioSource.Play ();
	}

	public void StopBGM () {
		myAudioSource.Stop ();
	}
	*/


}
