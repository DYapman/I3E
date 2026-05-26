using UnityEngine;

public class coin : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public int score = 5;

    public int Interact()
    {
        // 1. Play the coin collect sound
        audioSource.Play();

        // 2. Hide the coin visual
        var render = GetComponent<MeshRenderer>();
        if (render != null)
        {
            render.enabled = false;
        }

        // 3. Disable the collider so the player can't hit it again
        var collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        // 4. Destroy object after 1 second (allows audio to finish playing)
        // Removed gameObject.SetActive(false) so the audio source stays active!
        Destroy(gameObject, 1f);

        return score;
    }
}