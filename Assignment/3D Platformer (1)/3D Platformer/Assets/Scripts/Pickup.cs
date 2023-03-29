using UnityEngine;
using StarterAssets;

public enum PickupType
{
    Yellow,
    Blue,
    Red
}

// Pickup uses the same script for yellow, blue, and red interactable objects (including obstacles)
// with behavior OnTriggerEnter determined by the PickupType type. 

public class Pickup : MonoBehaviour
{
    public ParticleSystem particles;
    public PickupType type;
    public float rotationSpeed = 10f;

    // Slowly rotate on its y-axis
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            particles.Play();

            switch(type)
            {
                case PickupType.Yellow:
                    Yellow();
                    break;
                case PickupType.Blue:
                    Blue();
                    break;
                case PickupType.Red:
                    Red();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }

    private void Yellow()
    {
        GameManager.Instance.AddScore(50);
    }

    private void Blue()
    {
        ThirdPersonController player = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
        player.bluePowerUp = true;
        player.hasDoubleJumped = false;
    }

    private void Red()
    {
        GameManager.Instance.OnDeath();
    }
}
