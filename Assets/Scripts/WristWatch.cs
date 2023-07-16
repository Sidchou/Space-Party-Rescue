using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class WristWatch : MonoBehaviour
{
    private bool _powerAvail = true;
    [SerializeField]
    private float _powerCD = 60;
    private float _powerTime = 0;
    [SerializeField]
    private float _powerLimit = 10;

    [SerializeField]
    private Transform _particles;
    [SerializeField]
    private XRSimpleInteractable _interactable;
    private InteractionLayerMask _onMask;
    [SerializeField]
    private InteractionLayerMask _offMask;
    [SerializeField]
    private Image _powerUI;
    private float _distant = Mathf.Infinity;

    private float _susLvl = 0;
    [SerializeField]
    private Image _susUI;
    [SerializeField]
    private float _susMinDist = 2;
    [SerializeField]
    private float _susRateBase = 1;
    [SerializeField]
    private float _susRechargeRate = 1f;
    private Vector3 _camPosCashe;
    [SerializeField]
    private UnityEngine.Color _barColor;
    [SerializeField]
    private UnityEngine.Color _susColor;


    // Start is called before the first frame update
    void Start()
    {
        _onMask = _interactable.interactionLayers;
        _particles.parent = null;

    }

    // Update is called once per frame
    void Update()
    {
        if (!_powerAvail)
        {
            _powerTime += Time.deltaTime;
            if (_powerTime < _powerLimit)
            {
                _particles.transform.position = transform.position;
                _particles.up = transform.forward;
                //_particles.transform.rotation = transform.rotation;
            }
            else
            {
                if (PlayerState.Instance.triggerController.isTriggerPressed == true)
                {
                    PlayerState.Instance.triggerController.isTriggerPressed = false;
                }
            }
            _powerUI.fillAmount = 1 - _powerTime / _powerCD;
            if (_powerTime > _powerCD)
            {
                //_interactable.enabled = true;
                _powerUI.fillAmount = 1;
                _interactable.interactionLayers = _onMask;
                _powerAvail = true;
            }
        }
        if (PlayerState.Instance.currentPod != null)
        {
            GetDistance();
        }
    }
    public void PowerUp()
    {
        //_interactable.enabled = false;
        _interactable.interactionLayers = _offMask;
        _powerTime = 0;
        _powerAvail = false;
        PlayerState.Instance.triggerController.isTriggerPressed = true;
    }
    public void GetDistance()
    {
        /*
        _camPosCashe = Camera.main.transform.position;
        _camPosCashe.y = PlayerState.Instance.currentPod.transform.position.y;
        _distant = (_camPosCashe - PlayerState.Instance.currentPod.transform.position).magnitude;
        Debug.Log(_distant);

        if (_distant > 5)
        {
            _susLvl += 0.1f * Time.deltaTime;
        }
        _susUI.fillAmount = 1 - _susLvl;
    */
        _camPosCashe = Camera.main.transform.position;
        _distant = Mathf.Infinity;
        foreach (var person in PlayerState.Instance.currentTalks)
        {
            //_camPosCashe.y = person.transform.position.y;
            _distant = Mathf.Min(_distant,(_camPosCashe - person.transform.position).magnitude);
        }
        if (_distant < _susMinDist)
        {
            if (_susLvl < 0)
            {

            }
            else
            {
                _susLvl += 0.1f * (_susRateBase + _susMinDist - _distant) * Time.deltaTime;
                //_susUI.color = UnityEngine.Color.Lerp(_susColor,_barColor, _distant / _susMinDist);
            }
        }
        else if(_susLvl < 1)
        {
            _susLvl -=  0.1f * _susRechargeRate * Time.deltaTime;

        }

        _susUI.fillAmount = 1 - _susLvl;
    
    }

}
