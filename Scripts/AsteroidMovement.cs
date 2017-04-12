using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

	public int verticalLimit = 500;
	public int horizontalLimit = 100;

    public Vector3 Direction;
    void Update () 
    {
		if (transform.position.x > verticalLimit)
            Direction.x = -Direction.x;
        var x = Direction.x * Time.deltaTime;
		if (transform.position.y > horizontalLimit || transform.position.y < -horizontalLimit)
            Direction.y = -Direction.y;
        
        var y = Direction.y * Time.deltaTime;

        var z = Direction.z;

        var vector = new Vector3(x, y, z);

	    gameObject.transform.Translate(vector);
	}
}
