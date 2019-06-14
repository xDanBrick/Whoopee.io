using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [SerializeField] public int controllerNumber = 1;
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
        horizontal = Input.GetAxis("Triggers" + controllerNumber.ToString());

        character.Rotate(-horizontal);

        if (Input.GetButton("SpeedUp" + controllerNumber.ToString()))
        {
            character.SetState(State.DEFLATE);
        }
        else if (Input.GetButton("Inflate" + controllerNumber.ToString()))
        {
            character.SetState(State.INFLATE);
        }
        else
        {
            character.SetState(State.NONE);
        }
        
        if(Input.GetButtonDown("Inflate" + controllerNumber.ToString()))
        {
            character.PlayInflateSound();
        }
    }

}
