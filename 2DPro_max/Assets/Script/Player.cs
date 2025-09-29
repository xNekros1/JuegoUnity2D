using System;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float velocidad;
    [SerializeField] private float fuerzaSalto;
    Vector2 ejeControl;
    private Rigidbody2D fisicas;
    private Animator animator;
    private SpriteRenderer sprite;
    void Start()
    {
        fisicas = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        ejeControl = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            fisicas.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 movimiento = new Vector2(ejeControl.x,0);
        transform.Translate(movimiento * velocidad *Time.deltaTime);

        animator.SetBool("corriendo",ejeControl.x !=0);
        if (ejeControl.x < 0)
        {
            sprite.flipX = true;
        }else if(ejeControl.x > 0)
        {
            sprite.flipX=false;
        }
    }
    
}
