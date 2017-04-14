using UnityEngine;
using System.Collections;

public class ShipFireWeapon : MonoBehaviour
{
    private Object _torpedo;
    private GameController _gameController;

    void Start () 
    {
        _gameController = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();
        _torpedo = Resources.Load("Prefabs/Photon Torpedo");
	}
	
	public void FirePrimaryWeapon()
	{
	    var position = gameObject.transform.position;

	    var rotation = gameObject.transform.rotation;

	    Instantiate(_torpedo, position, rotation);

        _gameController.AddToScore(-10);
    }
}
