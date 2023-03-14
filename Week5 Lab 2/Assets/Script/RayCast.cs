using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
   private AudioSource SoundSource;


public GameObject SoundClip;
public float ClipDuration = 1f;

public GameObject ImpactEffectPrefab;

void Start()
{
    Cursor.lockState = CursorLockMode.Confined;
    SoundSource = GetComponent<AudioSource>();
}

void Update()
{
    if (Input.GetButtonDown("Fire1"))
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        SoundSource.Play();

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Target")
            {
                GameObject hitObject = hit.collider.gameObject;
                GameManager.Instance.IncrementScore();
                Destroy(hitObject);
            }
        }
        Instantiate(ImpactEffectPrefab, hit.point, Quaternion.identity);
    }
}

IEnumerator PlaySound()
{
    SoundClip.SetActive(true);
    yield return new WaitForSeconds(ClipDuration);
    SoundClip.SetActive(false);
  }
}
