using UnityEngine;
using System.Collections;

public class CreateAsteroids : MonoBehaviour {

    public int AsteroidCount = 10;
    public bool Indestructible = false;
    public bool Shielded = false;
    public bool Explosive = false;
    public float MinFieldX = 100f;
    public float MaxFieldX = 200f;
    public float MinFieldY = -100f;
    public float MaxFieldY = 100f;
    public float MinSize = 0.75f;
    public float MaxSize = 0.75f;
    public float MinSpeed = -5f;
    public float MaxSpeed = 5f;

	// Use this for initialization
	void Start () 
    {
        //carrega a prefab asteroid com escudo
        var asteroid = Resources.Load("Prefabs/Asteroid");
		//caso seja explosivo carrega a prefab do lava asteroid
        if(Explosive)
            asteroid = Resources.Load("Prefabs/Asteroid2");

        accelPerSize();
        setAccel();

        for (var i = 0; i < AsteroidCount; i++)
        {
            var x = Random.Range(MinFieldX, MaxFieldX);

            var y = Random.Range(MinFieldY, MaxFieldY);

            var z = 0f;

            var position = new Vector3(x, y, z);

            var rotation = new Quaternion(0f, 0f, 0f, 0f);

			//cria um clone de asteriod
            var gameObject = (GameObject)Instantiate(asteroid, position, rotation);

            var scale = Random.Range(MinSize, MaxSize);

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

            var mx = Random.Range(MinSpeed, MaxSpeed);

	        var my = Random.Range(MinSpeed, MaxSpeed);

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

    private void accelPerSize()
    {
        var controle = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<GameController>();
        int difficulty = controle.getDifficulty();

        var judge = GameObject.FindGameObjectWithTag("DDA").GetComponentInChildren<DDA>();
        int size = judge.getSize();

        if (size == 1)
        {
            if (difficulty == 0) {
                MaxSpeed = -4.0f;
                MinSpeed = 4.0f;
            }
            else if (difficulty == 1) {
                MaxSpeed = -7.0f;
                MinSpeed = 7.0f;
            }
            else {
                MinSpeed = 5.0f;
            }
        }
        else if (size == -1)
        {
            if (difficulty == 0) {
                MaxSpeed = -1.0f;
                MinSpeed = 1.0f;
            }
            else if (difficulty == 1) {
                MaxSpeed = -2.0f;
                MinSpeed = 2.0f;
            }
            else {
                MaxSpeed = 4.0f;
            }
        }
    }


    private void setAccel(){
        float accelMinus = 0.5f;

        var controle = GameObject.FindGameObjectWithTag("GameController").GetComponentInChildren<GameController>();
        int deathLimit = controle.getDeathLimit();
        int difficulty = controle.getDifficulty();

        var judge = GameObject.FindGameObjectWithTag("DDA").GetComponentInChildren<DDA>();
        int numDeath = judge.getDeath();
        int size = judge.getSize();
        int mult = (numDeath - deathLimit) / 2;

        if (numDeath >= deathLimit)
        {
            if (difficulty == 0)
            {
                if (size == 0) {
                    if (mult > 1)
                        mult = 1;
                    MaxSpeed = MaxSpeed - accelMinus - (mult * accelMinus);
                    MinSpeed = MinSpeed + accelMinus + (mult * accelMinus);
                }
                else if (size == 1)
                {
                    if (mult > 4)
                        mult = 4;
                    MaxSpeed = MaxSpeed - accelMinus - (mult * accelMinus);
                    MinSpeed = MinSpeed + accelMinus + (mult * accelMinus);
                }
            }
            else if (difficulty == 1)
            {
                if (size == 0)
                {
                    if (mult > 4)
                        mult = 4;
                    MaxSpeed = MaxSpeed - accelMinus - (mult * accelMinus);
                    MinSpeed = MinSpeed + accelMinus + (mult * accelMinus);
                }
                else if (size == 1)
                {
                    if (mult > 6)
                        mult = 6;
                    MaxSpeed = MaxSpeed - accelMinus - (mult * accelMinus);
                    MinSpeed = MinSpeed + accelMinus + (mult * accelMinus);
                }
            }
            else
            {
                if (size == 0)
                {
                    if (mult > 6)
                        mult = 6;
                    MaxSpeed = MaxSpeed - accelMinus - (mult * accelMinus);
                }
                else if (size == 1)
                {
                    if (mult > 4)
                        mult = 4;
                    MaxSpeed = MaxSpeed - accelMinus - (mult * accelMinus);
                }
            }
        }

    }

	// Update is called once per frame
	void Update () {
	
	}
}
