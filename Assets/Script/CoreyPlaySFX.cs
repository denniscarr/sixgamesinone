using UnityEngine;
using System.Collections;

public class CoreyPlaySFX : MonoBehaviour {
	[SerializeField] AudioClip[] mySFX;
	[SerializeField] bool playOnStart;
	[SerializeField] bool playRandomly;
	[SerializeField] bool playOnce;

	[SerializeField] float playVolume;
	// Use this for initialization
	void Start () {
		if (playOnStart) {
			if (playRandomly)
				PlaySFX (Random.Range (0, mySFX.Length));
			else
				PlaySFX (0);
		}
		if (playOnce) {
			Destroy (this);
		}
	}

	public void PlaySFX (int t_number) {
		if (playVolume == 0) {
			CoreySoundManager.Instance.PlaySFX (mySFX [t_number]);
		} else
			CoreySoundManager.Instance.PlaySFX (mySFX [t_number], playVolume);
	}
}
