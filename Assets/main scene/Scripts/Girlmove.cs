using UnityEngine;
using System.Collections;
public class Girlmove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    private Vector3 moveDirection;
    public GameTimer gameTimer;

    private bool isWalking = true; // Track walking state
    private bool hasPlayedVictory = false; // Track if victory animation has been played

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (gameTimer == null)
        {
            Debug.LogError("GameTimer reference is not set.");
        }
    }

    void Update()
    {
        if (transform.position.z < 40f)
        {
            if (gameTimer.GetRemainingTime() <= 80f && isWalking)
            {
                HandleMovement();
                HandleAnimation();
            }

            if (transform.position.z >= -30f && !hasPlayedVictory)
            {
                StartCoroutine(PlayVictoryAndWave());
            }
        }
        else
        {
            isWalking = false;
            HandleAnimation();
        }

    }

    void HandleMovement()
    {
        moveDirection = Vector3.forward;

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void HandleAnimation()
    {
        animator.SetBool("isWalking", isWalking);
    }

    private IEnumerator PlayVictoryAndWave()
    {
        isWalking = false;
        HandleAnimation();

        animator.SetTrigger("MeleeAttack_OneHanded");
        animator.SetTrigger("Wave");

        hasPlayedVictory = true;

        yield return new WaitForSeconds(7f);

        isWalking = true;
        HandleAnimation();
    }
}