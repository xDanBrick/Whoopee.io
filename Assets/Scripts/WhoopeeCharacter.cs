using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { NONE, INFLATE, DEFLATE }

public class WhoopeeCharacter : MonoBehaviour
{

    
    State state;

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
    [SerializeField] private float maxSpeed = 8.0f;
    [SerializeField] private float rotateSpeed = 2.5f;
    [SerializeField] private float maxRotateSpeed = 100.0f;
    [SerializeField] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    private GameObject mouth;
    private GameObject face;

    private CircleCollider2D circleCollider;

    Vector2 velocityModifier;
    private int inflationModifier = -1;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        mouth = transform.GetChild(0).gameObject;
        face = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocityModifier = transform.up * 1.0f;

        inflation += inflationModifier;
        inflation = Mathf.Clamp(inflation, 0, 999);//inflation > 0 ? inflation + inflationModifier : 0;

        
        UpdateSprite();

        body.velocity = body.velocity + velocityModifier;
        body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, -maxSpeed, maxSpeed), Mathf.Clamp(body.velocity.y, -maxSpeed, maxSpeed));
        if (changeTimer > 0.0f)
        {
            if (changeTimer <= 0.0f)
            {
                currentSpeed = baseSpeed;
            }
        }

        switch (state)
        {
            case State.NONE:
                maxSpeed = 8.0f;
                inflationModifier = -1;
                mouth.GetComponent<Animator>().speed = 1.0f;
                break;
            case State.INFLATE:
                maxSpeed = 4.0f;
                inflationModifier = 12;
                mouth.GetComponent<Animator>().speed = 1.0f;
                break;
            case State.DEFLATE:
                maxSpeed = inflation > 0 ? 16.0f : 8.0f;
                inflationModifier = -2;
                mouth.GetComponent<Animator>().speed = 2.0f;
                break;

        }
    }

    public void Rotate(float value)
    {
        if (value == 0.0f)
        {
            body.angularVelocity = 0.0f;
        }
        else
        {
            body.AddTorque(value * rotateSpeed);
            if (Mathf.Abs(body.angularVelocity) > maxRotateSpeed)
            {
                body.angularVelocity = Mathf.Sign(body.angularVelocity) * maxRotateSpeed;
            }
        }
    }

    public void SetState(bool infate, bool defate)
    {
        //Debug.Log("Works");
        body.AddForce(transform.up * 10);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
        }
    }

    private void UpdateSprite()
    {
        spriteRenderer.sprite = sprites[(int)(inflation / 100)];
        circleCollider.radius = Mathf.Max(spriteRenderer.sprite.rect.width , spriteRenderer.sprite.rect.height) / 200;
        mouth.transform.localPosition = new Vector2(0.0f, -circleCollider.radius - 0.55f);
        
    }

    public void SetState(State newState)
    {
        state = newState;
    }
}
