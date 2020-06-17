using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    private Animator animator;
    public enum playerState {Unarmed, Armed};
    public playerState stateValue;
    public GameObject weapon;
    public Transform weaponHolderHand;
    public Transform weaponHolderBag;
    public bool isAttacking = false;

    public Transform targetVFX;
    public GameObject SwordVFX;




    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        stateValue = playerState.Unarmed;

    }

    // Update is called once per frame
    void Update()
    {
        DetectState();
        AttackState();


        isAttacking = animator.GetBool("isAttacking");
    }


    private void DetectState() {


        //Switch between states
        if (Input.GetButtonDown("SwitchArmState") || Input.GetKeyDown(KeyCode.Q)) {

            animator.SetTrigger("SwitchArmState");

            switch (stateValue) {

                case playerState.Unarmed:

                    //Now armed

                    stateValue = playerState.Armed;
                    animator.SetInteger("ArmStateID", 1);
                    break;

                case playerState.Armed:

                   //Now disarmed
                   
                    stateValue = playerState.Unarmed;
                    animator.SetInteger("ArmStateID", 0);
                    break;
     
            }
        }   
    }

    public void ChangeWeaponOriginToHand() {
        weapon.transform.SetParent(weaponHolderHand);
    }


    public void ChangeWeaponOriginToBag() {
        weapon.transform.SetParent(weaponHolderBag);
    }

    public void AttackState() {

        if (stateValue == playerState.Armed) {


            if (Input.GetKeyDown(KeyCode.E) && isAttacking == false) {

                isAttacking = true;
                animator.SetTrigger("AttackE");
                
               
            
            }
        }
    
    }


    public void WeaponAttackEnable(int enableCol)
    {
        Rigidbody weaponRb = weaponHolderHand.GetChild(0).GetComponent<Rigidbody>();

        if (enableCol != 0)
        {
            weaponRb.detectCollisions = true;

        }
        else {
            weaponRb.detectCollisions = false;
        }
    }

    public void EnableSwordVFX() { 
           
        Instantiate(SwordVFX, targetVFX.position, targetVFX.rotation);

    }



    public void ResetAttackState() {

        isAttacking = false;
    }



}
