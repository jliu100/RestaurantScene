using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLookWalk : MonoBehaviour
{

    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;


    [SerializeField] public Rigidbody rb;
    private CharacterController cc;

    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpForce = 400f;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        
        if (rb.position.x > 4.0f && vrCamera.eulerAngles.y < 100.0f && vrCamera.eulerAngles.y > 0.0f)
        {
            Debug.Log("out");
            moveForward = false;
        }else if (rb.position.x < -4.0f  && vrCamera.eulerAngles.y < 360.0f && vrCamera.eulerAngles.y > 300.0f)
        {
            Debug.Log("out");
            moveForward = false;
        }
        //else if (vrCamera.eulerAngles.y >= -10.0f && vrCamera.eulerAngles.y < 10.0f)
        //{
          //  moveForward = true;
        //}
        else
        {
            moveForward = true;
        }

        
        if(vrCamera.eulerAngles.x <340 && vrCamera.eulerAngles.x>330)
            Debug.Log("x: " + vrCamera.eulerAngles.x);

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }
        else
        {
          
            Vector3 point = new Vector3(0,0,1);
            cc.SimpleMove(point * 5); 
        }
    }

    void Jump()
    {
        // Check whether we are currently grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        //If we are jump
        rb.AddForce(Vector3.up * jumpForce);


    }
}