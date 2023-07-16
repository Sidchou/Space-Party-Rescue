using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConvPots : MonoBehaviour
{
    [SerializeField]
    private bool _podState = false;
    [SerializeField]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    private Material _activeMat;
    [SerializeField]
    private Material _inactiveMat;
    [SerializeField]
    private Transform _speakers;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
     {
        _podState = true;
        _meshRenderer.material = _activeMat;
        _speakers.gameObject.SetActive(true);
        PlayerState.Instance.currentPod = transform;
        PlayerState.Instance.currentTalks = new List<Transform>();
        foreach (Transform child in _speakers.transform)
        {
            if (child.name.Contains("Person")) 
            {
                PlayerState.Instance.currentTalks.Add(child); 
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _podState = true;
        _meshRenderer.material = _inactiveMat;
        _speakers.gameObject.SetActive(false);
        PlayerState.Instance.currentPod = null;
        PlayerState.Instance.currentTalks = new List<Transform>() ;

    }
}

