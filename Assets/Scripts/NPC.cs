using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public bool isSelected = false;
    [SerializeField]
    Transform highlight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelectedXR()
    {
        if (isSelected)
        {
            PlayerState.Instance.selectedNames.Remove(highlight.gameObject.name);
            isSelected = false;
        }
          else
        {
            if (PlayerState.Instance.selectedNames.Count <= 3)
            {
                isSelected = true;
                PlayerState.Instance.selectedNames.Add(highlight.gameObject.name);
            }
        }
          highlight.gameObject.SetActive(isSelected);
        Debug.Log(PlayerState.Instance.selectedNames.Count);
    }
}
