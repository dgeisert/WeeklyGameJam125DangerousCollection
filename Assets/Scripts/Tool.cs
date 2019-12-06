using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public GameObject animObject;
    public int type = 0;
    void Update()
    {
        if (Controls.Interact && animObject != null)
        {
            animObject.SetActive(false);
            animObject.SetActive(true);
        }
    }
}