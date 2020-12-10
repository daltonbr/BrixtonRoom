using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerforHole : MonoBehaviour
{
    public GameObject hole;

    private void OnTriggerEnter(Collider other)
    {
        hole.SetActive(false);
    }

}
