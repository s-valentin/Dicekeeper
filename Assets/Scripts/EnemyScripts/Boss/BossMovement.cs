using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : StateMachineBehaviour
{

    Transform player;
    Transform boss;
    Rigidbody2D rb;

    public float speed = 4f;
    public float attackRange = 1.7f;
    private float attackDirection;
    private EnemyHealth bossHealth;

    public float teleportCooldown = 5f;
    private float nextTeleport = 0;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Transform>();
        bossHealth = animator.GetComponent<EnemyHealth>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 target = new Vector3(player.position.x, player.position.y, player.position.z);
        Vector3 newPosition = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
        rb.velocity = Vector2.zero;

        // We don't have a movement on left, so we're using this sorry.
        if (boss.position.x > target.x)
            boss.rotation = Quaternion.Euler(0f, -180f, 0f);
        else boss.rotation = Quaternion.Euler(0f, 0, 0f);

        attackDirection = player.position.y - boss.position.y;

        if (Vector3.Distance(player.position, rb.position) <= attackRange)
        {
            if (attackDirection > 0)
                animator.SetTrigger("Attack");
            else
                animator.SetTrigger("AttackDown");
        }

        if(animator.GetBool("IsStageTwo") && Time.time > nextTeleport)
        {
            nextTeleport = Time.time + teleportCooldown;
            animator.SetTrigger("Teleport");
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
        animator.ResetTrigger("AttackDown");
        animator.ResetTrigger("Teleport");
    }

}
