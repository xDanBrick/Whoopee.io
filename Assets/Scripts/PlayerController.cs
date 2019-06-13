using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

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

        character.Rotate(horizontal);

        Debug.Log(horizontal);
    }

}
