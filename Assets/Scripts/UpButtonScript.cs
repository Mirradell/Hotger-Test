using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpButtonScript : MonoBehaviour
{
    public GameObject mainSphere;
    
    private MainSphereScript sphereScript;

    // Start is called before the first frame update
    void Start()
    {
        sphereScript = mainSphere.GetComponent<MainSphereScript>();
    }

    private void OnMouseDrag()
    {
        sphereScript.isMovingUp = true;
    }

    private void OnMouseUp()
    {
        sphereScript.isMovingUp = false;
    }
}
