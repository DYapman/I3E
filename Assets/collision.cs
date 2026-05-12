using UnityEngine;

public class collision : MonoBehaviour
{
    int score = 0;

    private void OnCollisionEnter(Collision collision)
    { 
        Debug.Log("yo");
        if (collision.gameObject.name.StartsWith("coin")) {
            score += 1;
            Destroy(collision.gameObject);
            Debug.Log($"Coin collected! Score: {score}");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.StartsWith("Goal") && (score == 3)) {
            Debug.Log($"Congratulations, you've got {score} coins. you win!");
        }
        else
        {
            Debug.Log($"Hey, you need 3 coins! You only have {score} coin(s).");
        }
    }
}