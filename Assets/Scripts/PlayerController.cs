using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] int controllerNumber = 0;
    private WhoopeeCharacter character;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<WhoopeeCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Triggers1");

        character.Rotate(-horizontal);

        if(Input.GetButtonDown("Fire1"))
        {
            //character.Go();
        }
    }

}
