using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boundary : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(collision.collider.gameObject);
            //collision.collider.GetComponent<WhoopeeCharacter>().UpdateOpponentScore();
            //foreach(GameObject g in GameObject.FindGameObjectsWithTag("Player"))
            //{
            //    g.GetComponent<WhoopeeCharacter>().ResetPosition();
            //}
        }
    }
}
