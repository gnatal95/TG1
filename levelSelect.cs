using UnityEngine;
using System.Collections;

public class levelSelect : MonoBehaviour {
    public int Level;
    public int Difficulty;

	// Use this for initialization
	void Start () {
        switch (Level)
        {
            case 0:
                if (Difficulty == 0)
                    Application.LoadLevel("level 0 easy");
                else if (Difficulty == 2)
                    Application.LoadLevel("level 0 hard");
                else
                    Application.LoadLevel("level 0");
                break;
            case 1:
                if (Difficulty == 0)
                    Application.LoadLevel("level 1 easy");
                else if (Difficulty == 2)
                    Application.LoadLevel("level 1 hard");
                else
                    Application.LoadLevel("level 1 normal");
                break;
            case 2:
                if (Difficulty == 0)
                    Application.LoadLevel("level 2 easy");
                else if (Difficulty == 2)
                    Application.LoadLevel("level 2 hard");
                else
                    Application.LoadLevel("level 2 normal");
                break;
            case 3:
                if (Difficulty == 0)
                    Application.LoadLevel("level 3 easy");
                else if (Difficulty == 2)
                    Application.LoadLevel("level 3 hard");
                else
                    Application.LoadLevel("level 3 normal");
                break;
            case 4:
                if (Difficulty == 0)
                    Application.LoadLevel("level 4 easy");
                else if (Difficulty == 2)
                    Application.LoadLevel("level 4 hard");
                else
                    Application.LoadLevel("level 4 normal");
                break;
            case 5:
                if (Difficulty == 0)
                    Application.LoadLevel("level 5 easy");
                else if (Difficulty == 2)
                    Application.LoadLevel("level 5 hard");
                else
                    Application.LoadLevel("level 5 normal");
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
