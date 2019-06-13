using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private WhoopeeCharacter character;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<WhoopeeCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
