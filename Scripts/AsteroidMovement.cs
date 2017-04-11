using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour {

    public Vector3 Direction;
    void Update () 
    {
		//evita que o asteroide saia dos limites do jogo
        if (transform.position.x > 500)
            Direction.x = -Direction.x;
        var x = Direction.x * Time.deltaTime;
		// ??d
        if (transform.position.y > 100 || transform.position.y < -100)
            Direction.y = -Direction.y;
        

        var y = Direction.y * Time.deltaTime;

        var z = Direction.z;

        var vector = new Vector3(x, y, z);

	    gameObject.transform.Translate(vector);
	}
}
