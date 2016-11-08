using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RoachController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D roachRigidBody;

    private bool isMoving;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    public float timeToReload;
    private bool isReloading;

    private GameObject playerObject;

    // Use this for initialization
    void Start () {
        roachRigidBody = GetComponent<Rigidbody2D>();
        
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
    }
	
	// Update is called once per frame
	void Update () {
	    if (isMoving)
        {
            timeToMoveCounter -= Time.deltaTime;
            roachRigidBody.velocity = moveDirection;

            if (timeToMoveCounter <= 0)
            {
                isMoving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            roachRigidBody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter <= 0f)
            {
                isMoving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range (-1f, 1f) * moveSpeed, 0f);
            }
        }

        if (isReloading)
        {
            timeToReload -= Time.deltaTime;
            if (timeToReload <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                playerObject.SetActive(true);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            other.gameObject.SetActive(false);
            isReloading = true;
            playerObject = other.gameObject;
        }
    }
}
