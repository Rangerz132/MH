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
    }


    private void DetectState() {

        if (Input.GetButtonDown("SwitchArmState") || Input.GetKeyDown(KeyCode.Q)) {

            animator.SetTrigger("SwitchArmState");

            switch (stateValue) {

                case playerState.Unarmed:

                    Debug.Log("Unarmed");

                    stateValue = playerState.Armed;
                    animator.SetInteger("ArmStateID", 1);
                    break;

                case playerState.Armed:

                    Debug.Log("armed");

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

    public void testtest(Transform testObject) {

        weapon.transform.SetParent(testObject);
    }


}
