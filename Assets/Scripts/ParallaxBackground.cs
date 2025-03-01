using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float speed = 2f;

    public Material mat;

    private Vector2 offset = Vector2.zero;

    // Gets the material component
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Updates the texture offset constantly to create a parallax effect
    void Update()
    {
       offset.x += speed * Time.deltaTime;
       mat.mainTextureOffset = offset;
    }
}
