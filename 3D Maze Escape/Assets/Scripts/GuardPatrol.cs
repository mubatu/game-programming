using System.Collections;
using UnityEngine;

public class GuardPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;

    private Animator animator;

    void Start()
    {
        // Grab the Animator so the guard does not only slide
        animator = GetComponent<Animator>();
        
        // Trigger the Starter Assets walking animation
        if(animator != null)
        {
            animator.SetFloat("Speed", speed); 
            animator.SetFloat("MotionSpeed", 1f);
        }

        // Start the infinite patrol loop
        StartCoroutine(PatrolRoutine());
    }

    // The Main Loop
    IEnumerator PatrolRoutine()
    {
        while (true)
        {
            // Walk to B, wait until finished, then walk to A
            yield return StartCoroutine(WalkToTarget(pointB));
            yield return StartCoroutine(WalkToTarget(pointA));
        }
    }

    // The Movement Logic
    IEnumerator WalkToTarget(Transform target)
    {
        // 1. Calculate direction and snap rotation to face the target
        // We keep the Y position the same so the guard does not lean
        Vector3 lookPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.LookAt(lookPosition);

        // 2. Move towards the target until we are close (0.1 units)
        while (Vector3.Distance(transform.position, lookPosition) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, lookPosition, speed * Time.deltaTime);
            
            // Pause the coroutine here, render the frame, and continue next frame
            yield return null; 
        }
    }

    // 3. Catch the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("CAUGHT BY GUARD! Game Over.");
            GameManager.instance.GameOver(); // Game over
        }
    }

    // The animation triggers this every time a foot hits the ground
    private void OnFootstep(AnimationEvent animationEvent)
    {
        // We leave this completely empty for now.
        // If we want to add guard footstep sound effects later, this place for it. 
    }

    // Just in case the jump animation ever triggers, we catch this too
    private void OnLand(AnimationEvent animationEvent)
    {
        // Leave empty
    }
}