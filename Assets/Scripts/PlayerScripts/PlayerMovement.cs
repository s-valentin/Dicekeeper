using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Animation variables")]
    public Animator animator;

    [Header("Movement variables")]
    private Rigidbody2D rb;

    private Vector3 moveDirection;

    [SerializeField] private float moveSpeed;


    [Header("Dash variables")]
    public bool isDashButtonDown;
    private float dashSpeed = 4f;

    [SerializeField] private LayerMask dashLayerMask;

    public GameObject dashEffect;

    private float dashCooldown = 2f;
    private float nextDash = 0f;

    private float blinkTime = .05f;

    [SerializeField] Slider dashSlider;

    private Vector3 playerVelocity = Vector3.zero;

    public GameObject DashRune;
    
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

        animator.SetFloat("Horizontal", movementX);
        animator.SetFloat("Vertical", movementY);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);


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
            var dashRune = Instantiate(DashRune, transform.position, Quaternion.identity);

            // Verific daca ma lovesc de pereti/obiecte/whatever vrei tu
            Vector3 dashPosition = transform.position + moveDirection * dashSpeed;

            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, moveDirection, dashSpeed, dashLayerMask);

            if (raycastHit2d.collider != null)
                dashPosition = raycastHit2d.point;

            // Aici ii modific pozitia direct, pentru ca e blink 
            StartCoroutine(blink(dashPosition));

            // Imi sterg instanta de gameObject facuta, dupa o secunda;
            StartCoroutine(SelfDestruct(clone, dashRune));

            isDashButtonDown = false;
            
        }
            
    }

    IEnumerator blink(Vector2 dashPosition)
    {

        float scaleDuration = .1f;                                //animation duration in seconds
        Vector3 actualScale = transform.localScale;             // scale of the object at the begining of the animation
        Vector3 targetScale = new Vector3(0.10f, 0.10f, 0.5f);     // scale of the object at the end of the animation

        for (float t = 0; t < 1; t += Time.deltaTime / scaleDuration)
        {
            transform.localScale = Vector3.Lerp(actualScale, targetScale, t);
            yield return null;
        }


        // Aici se intampla blink-ul si camera shake-ul 
        yield return new WaitForSeconds(blinkTime);
        CameraShake.instance.ShakeCamera(1f, .2f);
        rb.position = dashPosition;

        yield return new WaitForSeconds(blinkTime);

        targetScale = new Vector3(1f, 1f, 1f);
        actualScale = transform.localScale;
        for (float t = 0; t < 1; t += Time.deltaTime / scaleDuration)
        {
            transform.localScale = Vector3.Lerp(actualScale, targetScale, t);
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);

    }

    IEnumerator SelfDestruct(GameObject clone, GameObject dashRune)
    {
        yield return new WaitForSeconds(1f);
        Destroy(clone);
        Destroy(dashRune);
    }
}
