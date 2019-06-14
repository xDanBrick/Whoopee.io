using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public int health = 2;
    [SerializeField] Sprite brokenSprite;
    [SerializeField] GameObject particleSystem;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        switch(health)
        {
            case 1:
                spriteRenderer.sprite = brokenSprite;
                break;
            case 0:
                Instantiate(particleSystem, transform.position, Quaternion.identity);
                Destroy(gameObject);
                break;
        }
    }
}
