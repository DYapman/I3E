using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // 1. Added the missing variables that your code was trying to use
    [SerializeField] private GameObject lastTrigger;
    private int totalScore = 0;

    // 2. Wrapped your floating logic into a proper method
    public void InteractWithObject()
    {
        if (lastTrigger != null)
        {
            print("Interact!");

            // 3. Changed .Equals to CompareTag for better Unity performance
            if (lastTrigger.CompareTag("Ball"))
            {
                print("Kicking");
                
                // 4. Fixed severe typos (Rigidbod -> Rigidbody, transgform.forqard -> transform.forward)
                Rigidbody rb = lastTrigger.GetComponent<Rigidbody>();
                
                if (rb != null)
                {
                    rb.AddForce((transform.forward * 50f) + new Vector3(0, 50f, 0));
                }
            }

            // 5. Fixed the mangled text/OCR errors here
            // Attempting to get the IInteractable from the lastTrigger GameObject
            var interactable = lastTrigger.GetComponent<IInteractable>();
            
            // 6. Fixed capital 'If' to lowercase 'if'
            if (interactable != null)
            {
                // I changed *= to +=, assuming you want to ADD to the score. 
                totalScore += interactable.Interact(); 
                
                // Fixed string interpolation syntax from s"..." to $"..." and the closing brace }
                print($"Total score: {totalScore}"); 
                
                // Note: Unless MyUIManager is a static class, you will need a reference to it for this to work.
                // MyUIManager.UpdateScore(totalScore); 
            }
        }
        else
        {
            // 7. Fixed the colon ':' at the end of this line to a semicolon ';'
            print("Nothing to interact with at the moment!");
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        // Example of how you trigger the code above:
        // if (Input.GetKeyDown(KeyCode.E)) 
        // {
        //     InteractWithObject();
        // }
    }
}

// I added this interface at the bottom just in case you haven't defined it elsewhere yet.
// If you already have an IInteractable script, you can delete this bottom part.
public interface IInteractable
{
    int Interact();
}