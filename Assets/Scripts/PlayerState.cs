using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    static private PlayerState _instance;
    static public PlayerState Instance
    { get {
            if (_instance == null)
                Debug.LogError("instance is null");
            return _instance;
        }
    }
    public Transform currentPod ;
    public TriggerController triggerController;

    public List<Transform> currentTalks = new List<Transform>();
    public List<string> selectedNames = new List<string>();


    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (triggerController == null) { Debug.LogError("controllInteraction is null"); }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
