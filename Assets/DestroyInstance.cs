using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script care-mi distruge dash-urile facute aiurea
public class DestroyInstance : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
