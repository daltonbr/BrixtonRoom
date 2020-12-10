using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class TriggerMechanic : MonoBehaviour
{
    public GameObject hole;
    [SerializeField] private UnityEvent _enterEvent;
    [SerializeField] private UnityEvent _exitEvent;
    [SerializeField] private float _secondsToWait = 1f;

    private Coroutine _enterCoroutine;
    private Coroutine _exitCoroutine;

    private void Start()
    {
        Assert.IsNotNull(_enterEvent);
        Assert.IsNotNull(_exitEvent);
        
        if (_enterEvent == null)
            _enterEvent = new UnityEvent();

        //_enterEvent.AddListener(HandleEvent);
        
        if (_exitEvent == null)
            _exitEvent = new UnityEvent();

        //_exitEvent.AddListener(HandleEvent);
    }

    private void HandleEvent()
    {
        //StartCoroutine(EventCoroutine(_secondsToWait));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("[TriggerMechanic] OnTriggerEnter");
        //    _enterCoroutine = StartCoroutine(TriggerEnterCoroutine());
        _enterEvent?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("[TriggerMechanic] OnTriggerExit");
        if (_exitCoroutine != null)
        {
            StopCoroutine(_exitCoroutine);
        }
        _exitCoroutine = StartCoroutine(TriggerExitCoroutine(_secondsToWait));        
    }

    // private IEnumerator TriggerEnterCoroutine()
    // {
    //     _enterEvent.Invoke();
    //     _enterCoroutine = null;
    //     yield break;
    // }

    private IEnumerator TriggerExitCoroutine(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        //hole.SetActive(false);
        _exitEvent?.Invoke();
        Debug.Log("Exit after delay");
    }

}
