using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator animator;
    private Rigidbody2D playerRigidBody;

    private bool playerMoving;
    public Vector2 lastMove;

    private static bool playerExists;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
 	}
	
	// Update is called once per frame
	void Update () {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        //transform.Translate(new Vector3(horizontalAxis * moveSpeed * Time.deltaTime, verticalAxis * moveSpeed * Time.deltaTime, 0));
        playerRigidBody.velocity = new Vector2(horizontalAxis * moveSpeed, verticalAxis * moveSpeed);


        if (horizontalAxis != 0)
            lastMove = new Vector2(horizontalAxis, 0f);

        if (verticalAxis != 0)
            lastMove = new Vector2(0f, verticalAxis);

        if (horizontalAxis != 0 || verticalAxis != 0)
            playerMoving = true;
        else
            playerMoving = false;

        if (playerMoving == false)
            playerRigidBody.velocity = new Vector2();

        animator.SetFloat("MoveX", horizontalAxis);
        animator.SetFloat("MoveY", verticalAxis);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
        animator.SetBool("PlayerMoving", playerMoving);
	}
}
