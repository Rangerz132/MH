using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movements")]
    public float unarmedMovementSpeed = 5f;
    public float armedMovementSpeed = 3f;
    private CharacterController characterController;
    private Animator animator;
    private PlayerState playerStateScript;
   
    
    

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

        //Player movement;
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        animator.SetFloat("InputX", moveX);
        animator.SetFloat("InputY", moveZ);

        Vector3 move = transform.right * moveX + transform.forward * moveZ; //direction and facing


        if (playerStateScript.stateValue == PlayerState.playerState.Armed)
        {

            characterController.Move(move * unarmedMovementSpeed * Time.deltaTime);
        }
        else if (playerStateScript.stateValue == PlayerState.playerState.Unarmed) {

            characterController.Move(move * armedMovementSpeed * Time.deltaTime);
        }

       

    }


  



}
