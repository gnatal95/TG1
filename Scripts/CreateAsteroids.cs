using UnityEngine;
using System.Collections;

public class CreateAsteroids : MonoBehaviour {

    public int AsteroidCount = 10;
    public bool Indestructible = false;
    public bool Shielded = false;
    public bool Explosive = false;
    public float mimFieldX = 100f;
    public float maxFieldX = 200f;
    public float minFieldY = -100f;
    public float maxFieldY = 100f;
    public float minSize = 0.75f;
    public float maxSize = 0.75f;
    public float minSpeed = -5f;
    public float maxSpeed = 5f;

	// Use this for initialization
	void Start () 
    {
        //carrega a prefab asteroid com escudo
        var asteroid = Resources.Load("Prefabs/Asteroid");
		//caso seja explosivo carrega a prefab do lava asteroid
        if(Explosive)
            asteroid = Resources.Load("Prefabs/Asteroid2");

		AccelPerSize ();
		SetAccel ();

        for (var i = 0; i < AsteroidCount; i++)
        {
            var x = Random.Range(mimFieldX, maxFieldX);

            var y = Random.Range(minFieldY, maxFieldY);

            var z = 0f;

            var position = new Vector3(x, y, z);

            var rotation = new Quaternion(0f, 0f, 0f, 0f);

			//cria um clone de asteriod
            var gameObject = (GameObject)Instantiate(asteroid, position, rotation);

            var scale = Random.Range(minSize, maxSize);

            gameObject.transform.localScale = new Vector3(scale, scale, scale);

            var movement = gameObject.GetComponentInChildren<AsteroidMovement>();

            if (Indestructible) {
                var ast = gameObject.GetComponentInChildren<AsteroidType>();
                ast.indestructible = true;
            }
            if (Shielded) {
                var shield = gameObject.transform.FindChild("Shield Asteroid");

                shield.GetComponent<MeshRenderer>().enabled = true;

                shield.GetComponent<SphereCollider>().enabled = true;
            }
            if (Explosive) {
                var ast = gameObject.GetComponentInChildren<AsteroidType>();
                ast.explosive = true;

            }

            var mx = Random.Range(minSpeed, maxSpeed);

	        var my = Random.Range(minSpeed, maxSpeed);

	        var mz = 0f;

            var mmx = Random.Range(0, 2);
            var mmy = Random.Range(0, 2);

            if (mmx == 0) {
                mx *= -1;
            }
            if (mmy == 0) {
                my *= -1;
            }

	        var direction = new Vector3(mx, my, mz);

            movement.Direction = direction;
        }
	}

    private void AccelPerSize()
    {
        var controle = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<GameController>();
        int difficulty = controle.getDifficulty();

        var judge = GameObject.FindGameObjectWithTag("DDA").GetComponentInChildren<DDA>();
        int size = judge.GetSize();

        if (size == 1)
        {
            if (difficulty == 0) {
                maxSpeed = -4.0f;
                minSpeed = 4.0f;
            }
            else if (difficulty == 1) {
                maxSpeed = -7.0f;
                minSpeed = 7.0f;
            }
            else {
                minSpeed = 5.0f;
            }
        }
        else if (size == -1)
        {
            if (difficulty == 0) {
                maxSpeed = -1.0f;
                minSpeed = 1.0f;
            }
            else if (difficulty == 1) {
                maxSpeed = -2.0f;
                minSpeed = 2.0f;
            }
            else {
                maxSpeed = 4.0f;
            }
        }
    }


    private void SetAccel(){
        float accelMinus = 0.5f;

        var controle = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<GameController>();
        int deathLimit = controle.GetDeathLimit();
        int difficulty = controle.getDifficulty();

        var judge = GameObject.FindGameObjectWithTag("DDA").GetComponentInChildren<DDA>();
        int numDeath = judge.GetDeath();
        int size = judge.GetSize();
        int mult = (numDeath - deathLimit) / 2;

        if (numDeath >= deathLimit)
        {
            if (difficulty == 0)
            {
                if (size == 0) {
                    if (mult > 1)
                        mult = 1;
                    maxSpeed = maxSpeed - accelMinus - (mult * accelMinus);
                    minSpeed = minSpeed + accelMinus + (mult * accelMinus);
                }
                else if (size == 1)
                {
                    if (mult > 4)
                        mult = 4;
                    maxSpeed = maxSpeed - accelMinus - (mult * accelMinus);
                    minSpeed = minSpeed + accelMinus + (mult * accelMinus);
                }
            }
            else if (difficulty == 1)
            {
                if (size == 0)
                {
                    if (mult > 4)
                        mult = 4;
                    maxSpeed = maxSpeed - accelMinus - (mult * accelMinus);
                    minSpeed = minSpeed + accelMinus + (mult * accelMinus);
                }
                else if (size == 1)
                {
                    if (mult > 6)
                        mult = 6;
                    maxSpeed = maxSpeed - accelMinus - (mult * accelMinus);
                    minSpeed = minSpeed + accelMinus + (mult * accelMinus);
                }
            }
            else
            {
                if (size == 0)
                {
                    if (mult > 6)
                        mult = 6;
                    maxSpeed = maxSpeed - accelMinus - (mult * accelMinus);
                }
                else if (size == 1)
                {
                    if (mult > 4)
                        mult = 4;
                    maxSpeed = maxSpeed - accelMinus - (mult * accelMinus);
                }
            }
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
