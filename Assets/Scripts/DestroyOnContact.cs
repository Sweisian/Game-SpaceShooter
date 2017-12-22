using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    private GameController gameController;
    public int scoreValue;
    private int hitCount = 0;


    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("cant fine 'GameController' object");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        if(hitCount >= 1)
        {
            gameController.AddScore(scoreValue);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            hitCount++;
            Destroy(other.gameObject);
        }
        
        
    }
}
