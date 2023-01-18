using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserControl : MonoBehaviour
{
    private float h = 0;
    private Locomotion character;
    private Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Locomotion>();
        anim = GetComponent<Animator>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 move = context.ReadValue<Vector2>();
        h = move.x;
    }


    private void FixedUpdate()
    {
        character.Move(h);
    }

    private void Update()
    {
        anim.SetFloat("h", Mathf.Abs(h));
    }
}
