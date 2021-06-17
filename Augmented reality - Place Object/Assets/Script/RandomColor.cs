using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        Color color = Random.ColorHSV(0.0f, 1.0f, 0.5f, 0.5f);

        meshRenderer.material.color = color;
    }
}
