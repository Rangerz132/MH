using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CameraInteractable : MonoBehaviour
{

    public float maxDist = 10f;
    public Color highlighColor;
    public Color defaultColor;
    public Material targetMat;
    RaycastHit hit;


    


    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Physics.BoxCast(transform.position, new Vector3(2f,2f, maxDist), transform.forward, out hit, transform.rotation, maxDist)){

            if (hit.transform.tag == "Interactable") {

                targetMat = hit.transform.gameObject.GetComponent<Renderer>().material;
                targetMat.SetColor("ColorHdr", highlighColor);
            }
        }
        
        
        
            
    }



}
