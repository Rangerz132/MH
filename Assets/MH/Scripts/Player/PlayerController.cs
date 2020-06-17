using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movements")]
    public float unarmedMovementSpeed = 5f;
    public float armedMovementSpeed = 3f;
    public float turnAngleTime = 0.1f;
    public float turnSmoothVelocity;
    private CharacterController characterController;
    private Animator animator;
    private PlayerState playerStateScript;
    public Transform cam;
   
    
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        playerStateScript = GetComponent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {

 
      
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= .05f) {


            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnAngleTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            characterController.Move(moveDir.normalized * unarmedMovementSpeed * Time.deltaTime);



            if (playerStateScript.stateValue == PlayerState.playerState.Armed)
            {

                characterController.Move(moveDir.normalized * unarmedMovementSpeed * Time.deltaTime);
            }
            else if (playerStateScript.stateValue == PlayerState.playerState.Unarmed)
            {

                characterController.Move(moveDir.normalized * armedMovementSpeed * Time.deltaTime);
            }


        }

        animator.SetFloat("InputX", horizontal);
        animator.SetFloat("InputY", vertical);


    }


  



}
