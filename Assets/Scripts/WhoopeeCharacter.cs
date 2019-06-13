using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoopeeCharacter : MonoBehaviour
{
    const float baseSpeed = 1.0f;
    const float inflationState = 0.5f;
    const float deflateSlowly = 1.5f;
    const float deflateQuickly = 2.5f;

    const float changeTime = 2.0f;
    const float quickDeflate = 1.0f;
    const int inflationMax = 1000;

    private Rigidbody2D body;
    private float currentSpeed = baseSpeed;
    private float changeTimer = -1.0f;

    private int inflation = 500;
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float rotateSpeed = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = transform.up * baseSpeed * moveSpeed;

        if (changeTimer > 0.0f)
        {
            if (changeTimer <= 0.0f)
            {
                currentSpeed = baseSpeed;
            }
        }
    }

    public void Rotate(float value)
    {
        transform.Rotate(0.0f, 0.0f, value * rotateSpeed);
    }

    public void SetState(bool infate, bool defate)
    {
        Debug.Log("Works");
        body.AddForce(transform.up * 10);
    }
}
