using UnityEngine;
using System.Collections;

public class ShieldCollision : MonoBehaviour
{
    private Object _explosion;

    void Start()
    {
        _explosion = Resources.Load("Prefabs/Explosion");
    }

    void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Equals("ShieldA") && !collider.gameObject.tag.Equals("Asteroid") && !collider.gameObject.tag.Equals("AsteroidEx"))
            return;

        if (collider.gameObject.tag.Equals("Asteroid"))
        {

            var asteroidPosition = collider.gameObject.transform.position;

            var rotation = Quaternion.identity;

            Instantiate(_explosion, asteroidPosition, rotation);

            Destroy(collider.gameObject);

            gameObject.GetComponent<MeshRenderer>().enabled = false;

            gameObject.GetComponent<SphereCollider>().enabled = false;

            gameObject.GetComponent<AudioSource>().Play();
        }
        else if (collider.gameObject.tag.Equals("ShieldA"))
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;

            gameObject.GetComponent<SphereCollider>().enabled = false;

            gameObject.GetComponent<AudioSource>().Play();

            var shield = collider.gameObject;
            shield.GetComponent<MeshRenderer>().enabled = false;
            shield.GetComponent<SphereCollider>().enabled = false;
            shield.GetComponent<AudioSource>().Play();
        }
        else if (collider.gameObject.tag.Equals("AsteroidEx"))
        {
            

            gameObject.GetComponent<MeshRenderer>().enabled = false;

            gameObject.GetComponent<SphereCollider>().enabled = false;

            gameObject.GetComponent<AudioSource>().Play();

            collider.gameObject.GetComponent<SphereCollider>().enabled = false;


        }
	}
}