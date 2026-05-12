using UnityEngine;

public class Effect : MonoBehaviour
{ 

    int score = 0;

    
    void OnCollisionEnter(Collision collision)
    {
        print("Collision detected with " );
        if (collision.gameObject.name == "coin")
        {
            score++;
            print($"Current score: {score}");
            Destroy(collision.gameObject);

            if (score == 4)
            {
                print("You win!");
            }
        }
    }

} 