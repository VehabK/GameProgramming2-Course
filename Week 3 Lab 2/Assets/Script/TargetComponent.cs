using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
public GameObject targetObject;
private int playerScore;

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Projectile"))
    {
        GameManager.Instance.IncrementScore();
        targetObject.SetActive(false);
        Invoke(nameof(ShowTarget), 5f);
    }
}

private void ShowTarget()
{
    targetObject.SetActive(true);
    }
}