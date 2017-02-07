using UnityEngine;
using System.Collections;

public class DestroyAfterXSeconds : MonoBehaviour {
    public float countdown;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, countdown);
	}

}
