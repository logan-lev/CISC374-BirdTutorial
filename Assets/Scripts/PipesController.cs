using UnityEngine;

public class PipesController : MonoBehaviour
{

    public int deadSpace = -45;

    // Shifts the pipes to the left while destroying them once they leave the screen
    void Update()
    {
        gameObject.transform.position = transform.position + 10 * Time.deltaTime * Vector3.left;
        
        if (gameObject.transform.position.x < deadSpace) {
            Destroy(gameObject);
        }
    }
}
