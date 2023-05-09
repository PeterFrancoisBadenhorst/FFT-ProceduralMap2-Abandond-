using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise
{
    public class PerlinNoiseGenerator
    {
        // Generate a 2D Perlin noise texture
        public Texture2D GeneratePerlinNoise2DTexture(int size, float scale)
        {
            // Create a new texture with the given size
            Texture2D noiseTexture2D = new Texture2D(size, size);

            // Iterate over each pixel in the texture
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    // Generate a Perlin noise value for the current pixel
                    float sample = Mathf.PerlinNoise(x * scale, y * scale);
                    // Set the pixel color to a grayscale value based on the noise value
                    noiseTexture2D.SetPixel(x, y, new Color(sample, sample, sample));
                }
            }

            // Apply the changes to the texture and return it
            noiseTexture2D.Apply();
            return noiseTexture2D;
        }
    }
}