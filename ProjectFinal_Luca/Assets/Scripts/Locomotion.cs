using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    [Header("Movements")]
    [SerializeField] private float speed = 6f;
    private Vector2 refVelocity = Vector2.zero;
    [SerializeField] private float smoothTime = 0.05f;
    private Rigidbody2D rigid;

    private bool faceLeft = false;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }


    public void Move(float move)
    {
        Movement(move);
        CheckOrientation(move);
    }
    
    public void Movement(float move)
    {
        Vector2 targetVelocity = new Vector2(move * speed, rigid.velocity.y);
        rigid.velocity = Vector2.SmoothDamp(rigid.velocity, targetVelocity, ref refVelocity, smoothTime);

        
    }

    void CheckOrientation(float move)
    {
        if ((move > 0 && faceLeft) || (move < 0 && !faceLeft))
        {
            faceLeft = !faceLeft;
            sprite.flipX = faceLeft;
        }
    }
}
