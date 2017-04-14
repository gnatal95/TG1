using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
    private float crono;
    public float timeNow;
    public float ExTime;
	// Use this for initialization

	void Start () {
        crono = Time.fixedTime;
        ExTime = 2;
	}
	
	// Update is called once per frame
	void Update () {
        timeNow = Time.fixedTime;
		if (timeNow > crono + ExTime) {
            Destroy(gameObject);
        }
	}
}
