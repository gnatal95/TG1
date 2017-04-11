﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading;

public class ShipCollision : MonoBehaviour
{
    private GameController _controller;
    private Object _explosion;
    private Object _bigExplosion;
    private AudioClip _explosionClip;

    void Start()
    {
        _controller = GameObject.FindGameObjectWithTag("GameController")
            .GetComponent<GameController>();

        _explosion = Resources.Load("Prefabs/Explosion");

        _bigExplosion = Resources.Load("Prefabs/Big Explosion");
        
        _explosionClip = Resources.Load<AudioClip>("Sounds/explosion");
    }

	void OnTriggerEnter(Collider collider)
    {
        if (!collider.gameObject.tag.Equals("ShieldA")&&!collider.gameObject.tag.Equals("Asteroid")&&!collider.gameObject.tag.Equals("AsteroidEx")) 
            return;

        var shipPosition = gameObject.transform.position;

        var asteroidPosition = collider.gameObject.transform.position;

        var rotation = Quaternion.identity;

        if (!collider.gameObject.tag.Equals("AsteroidEx"))
            Instantiate(_explosion, asteroidPosition, rotation);

        Instantiate(_bigExplosion, shipPosition, rotation);

        var mainAudio = GameObject.FindGameObjectWithTag("MainAudio");

        if (!collider.gameObject.tag.Equals("AsteroidEx"))
            Destroy(collider.gameObject);

        Destroy(gameObject);

        var random = new System.Random();

        for (int i = 0; i < 5; i++)
        {
            var explosionAudioSource = mainAudio.AddComponent<AudioSource>();

            explosionAudioSource.clip = _explosionClip;

            var delay = (float) random.Next(0, 1);

            explosionAudioSource.PlayDelayed(delay);
        }

        _controller.SetGameOver();   
    }
}
