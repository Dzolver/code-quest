using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10f;
    private Rigidbody playerRigidBody;
    private bool stop = false;
    private bool isMoving = false;
    private bool grounded = false;
    private float xInput,yInput;
    private float jumpSpeed = 5f;

    public bool recieveInput = false;
    public Animator animator;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (recieveInput)
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            CharacterController controller = GetComponent<CharacterController>();

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            // Move
            Vector3 tempVect = new Vector3(h, 0, v);
            tempVect = tempVect.normalized * moveSpeed * Time.deltaTime;
            controller.SimpleMove(tempVect);
        } else
        {
            animator.SetFloat("Horizontal", 0);
        }

    }
    private void playerJump()
    {
        //need to redo
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Ground"){
            grounded = true;
        }
    }
}
