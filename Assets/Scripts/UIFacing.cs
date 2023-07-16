using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFacing : MonoBehaviour
{
    Vector3 casheVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        casheVector = transform.position - Camera.main.transform.position;
        casheVector.y = 0;
        transform.forward = casheVector;
    }
    public void NewHover(Transform t) 
    {
        transform.position = t.position + Vector3.up * 3f;
    }
    
}
