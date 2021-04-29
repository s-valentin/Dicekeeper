using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement variables")]
    private Rigidbody2D rb;

    private Vector3 moveDirection;

    [SerializeField] private float moveSpeed;


    [Header("Dash variables")]
    public bool isDashButtonDown;
    private float dashSpeed = 4f;

    [SerializeField] private LayerMask dashLayerMask;

    public GameObject dashEffect;

    private float dashCooldown = 3f;
    private float nextDash = 0f;

    private float blinkTime = .1f;

    [SerializeField] Slider dashSlider;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        dashSlider.maxValue = dashCooldown;
        dashSlider.value = dashCooldown;
    }

    private void Update()
    {
        // Movement part
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
       
        moveDirection = new Vector2(movementX, movementY).normalized;

        // Dash cooldown and key input
        dashSlider.value = nextDash - Time.time;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextDash)
        {
            isDashButtonDown = true;
            nextDash = Time.time + dashCooldown;
        }
    
    }

    private void FixedUpdate()
    {
        // Movement part
        rb.velocity = moveDirection * moveSpeed;
       
        // Dash part
        if (isDashButtonDown)
        {
            // Creates the particles
            var clone = Instantiate(dashEffect, transform.position, Quaternion.identity);
    
            // Verific daca ma lovesc de pereti/obiecte/whatever vrei tu
            Vector3 dashPosition = transform.position + moveDirection * dashSpeed;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDirection, dashSpeed, dashLayerMask);

            if (raycastHit2d.collider != null)
                dashPosition = raycastHit2d.point;

            // Aici ii modific pozitia direct, pentru ca e blink 
            StartCoroutine(blinkTimer(dashPosition));

            // Imi sterg instanta de gameObject facuta, dupa o secunda;
            StartCoroutine(SelfDestruct(clone));

            isDashButtonDown = false;
            
        }
            
    }

    IEnumerator blinkTimer(Vector2 dashPosition)
    {
        // Scad putin cate putin marimea player-ului, la intervale mici de timp
        transform.localScale = new Vector3(.65f, .65f, .65f);
        yield return new WaitForSeconds(0.03f);
        transform.localScale = new Vector3(.55f, .5f, .5f);
        yield return new WaitForSeconds(0.03f);
        transform.localScale = new Vector3(.35f, .35f, .35f);
        yield return new WaitForSeconds(0.03f);
        transform.localScale = new Vector3(.25f, .25f, .25f);

        // Aici se intampla blink-ul si camera shake-ul
        yield return new WaitForSeconds(blinkTime);
        CameraShake.instance.ShakeCamera(1f, .2f);
        rb.position = dashPosition;

        // Cresc marimea player-ului, la intervale mici de timp, pana la marimea initiala
        yield return new WaitForSeconds(0.04f);
        transform.localScale = new Vector3(.35f, .35f, .35f);
        yield return new WaitForSeconds(0.04f);
        transform.localScale = new Vector3(.55f, .5f, .5f);
        yield return new WaitForSeconds(0.04f);
        transform.localScale = new Vector3(.65f, .65f, .65f);
        yield return new WaitForSeconds(0.02f);
        transform.localScale = new Vector3(.75f, .75f, .75f);

        

    }

    IEnumerator SelfDestruct(GameObject clone)
    {
        yield return new WaitForSeconds(1f);
        Destroy(clone);
    }
}
