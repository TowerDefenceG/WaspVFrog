using UnityEngine;

public class PerlinNoise : MonoBehaviour{
    public int width = 256;
    public int height = 256;
    public float scale = 20f;

    void Start()
    {
        GenerateTexture();
    }

    void GenerateTexture()
    {
        Texture2D perlinTexture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xCoord = (float)x / width * scale;
                float yCoord = (float)y / height * scale;

                float perlinValue = Mathf.PerlinNoise(xCoord, yCoord);
                perlinTexture.SetPixel(x, y, new Color(perlinValue, perlinValue, perlinValue));
            }
        }

        perlinTexture.Apply();

        // Assign the generated texture to a material
        GetComponent<Renderer>().material.mainTexture = perlinTexture;
    }
}
