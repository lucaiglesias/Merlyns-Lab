using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{

    public GameObject Bubbles;
    public GameObject Sparkles;
    private GameManager gameManager;
    public StopWatch timer;


    // Start is called before the first frame update
    void Start()
    {

        gameManager = GameManager.instance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Trap"))
        {

            Sparkles.transform.position = gameObject.transform.position;
            Sparkles.GetComponent<AudioSource>().Play();
            Sparkles.GetComponent<ParticleSystem>().Play();
            gameManager.GameOver(gameObject);
            
            

        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            
            Bubbles.transform.position = this.gameObject.transform.position;
            Bubbles.GetComponent<AudioSource>().Play();
            Bubbles.GetComponent<ParticleSystem>().Play();
            gameManager.Next_Level(gameObject);

        }
    }

}
