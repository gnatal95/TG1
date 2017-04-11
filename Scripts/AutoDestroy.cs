using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
    private float crono;
    public float timenow;
    public float ExTime;
	// Use this for initialization
	void Start () {
        crono = Time.fixedTime;
        ExTime = 2;
	}
	
	// Update is called once per frame
	void Update () {
        timenow = Time.fixedTime;
        if (Time.fixedTime > crono + ExTime) {
            Destroy(gameObject);
        }
	}
}
