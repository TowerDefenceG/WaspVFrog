using UnityEngine;

// tutorial: https://www.youtube.com/watch?v=bG0uEXV6aHQ

public class PerlinNoise : MonoBehaviour{
    public int width = 256;
    public int height = 256;
    public float scale = 20;

    public float offsetX = 100f;
    public float offsetY = 100f;

    public Texture2D texture = new Texture2D(width, height);
    

    void Update(){
        // Renderer renderer = GetComponent<Renderer>();
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        renderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture(){
        // generate Perlin noise map 
        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        
        texture.Apply();  //applies the texture
        return texture; 
    }

    Color CalculateColor(int x, int y){
        //convert 1-256 to 0-1 range
        float xCoord = (float)x / width * scale + offsetX; 
        float yCoord = (float)y / height * scale + offsetY;


        float sample = Mathf.PerlinNoise(xCoord, yCoord);
        return new Color(sample, sample, sample);
    }
}
