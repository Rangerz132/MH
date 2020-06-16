using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePop : MonoBehaviour
{
    [Header("Damage properties")]
    private TextMeshPro damageText;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int RandomDamage( int minDamage, int maxDamage) {

        int randomDamage = Mathf.FloorToInt(Random.Range(minDamage, maxDamage));
        return randomDamage;
    
    }

}
