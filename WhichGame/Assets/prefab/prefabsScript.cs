using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabsScript : MonoBehaviour
{
    public float zaman =1f;
    void Update()
    {
        zaman += Time.deltaTime;
        if (zaman > 3)
        {
            Destroy(gameObject);
        }
    }
}
