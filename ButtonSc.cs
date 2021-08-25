using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSc : MonoBehaviour
{
    public GameObject prewievObj, prewievObj2;
    void Start()
    {
        
    }
    public void b1()
    {
        prewievObj.SetActive(true);
        prewievObj2.SetActive(false);

    }
    public void b2()
    {
        prewievObj2.SetActive(true);
        prewievObj.SetActive(false);

    }
}
