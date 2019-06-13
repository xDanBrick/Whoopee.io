using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoopeeCharacter : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float rotateSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.up;
    }

    public void Rotate(float value)
    {
        transform.Rotate(0.0f, 0.0f, value * rotateSpeed);
    }
}
