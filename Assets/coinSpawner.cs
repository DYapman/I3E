using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private GameObject explosionEffect; // Declared the missing variable

    private bool touch = false;

    void OnCollisionEnter(Collision collision)
    {
        // Used CompareTag for better performance and removed the space in ". Equals"
        if (collision.gameObject.CompareTag("Player") && !touch)
        {
            var spawnedObject = Instantiate(objectToSpawn,
                transform.position + Vector3.up, // Vector3.up is a cleaner way to write new Vector3(0, 1, 0)
                transform.rotation);

            // Added a null check just in case you forget to assign the effect in the Inspector
            if (explosionEffect != null)
            {
                Instantiate(explosionEffect,
                    transform.position + Vector3.up,
                    transform.rotation, spawnedObject.transform);
            }

            touch = true;

            Destroy(gameObject, 1f); // Added the missing semicolon ';' 
        }
    }
}