using UnityEngine;
using System.Collections;

public class CreateBitalino : MonoBehaviour {

	// Use this for initialization
	void Start () {
        var bitalino = Resources.Load("Prefabs/BITalino");
        var line = Resources.Load("Prefabs/Line1");
        var gameObject = (GameObject)Instantiate(bitalino);
                
        var gameObject2 = (GameObject)Instantiate(line);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
