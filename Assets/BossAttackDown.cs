using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackDown : MonoBehaviour
{

    public PolygonCollider2D hitCollider;

    public void startDownAttack()
    {
        hitCollider.gameObject.SetActive(true);
        Debug.Log("abbba");
        StartCoroutine(disableCollider());
    }

    IEnumerator disableCollider()
    {
        yield return new WaitForSeconds(0.1f);
        hitCollider.gameObject.SetActive(false);
    }
}
