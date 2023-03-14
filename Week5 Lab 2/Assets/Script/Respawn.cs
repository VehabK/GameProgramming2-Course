using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Respawn : MonoBehaviour
{
    void OnTriggerEnter(Collider otherCollider)
{
if (otherCollider.CompareTag("Player"))
{
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
    }
}