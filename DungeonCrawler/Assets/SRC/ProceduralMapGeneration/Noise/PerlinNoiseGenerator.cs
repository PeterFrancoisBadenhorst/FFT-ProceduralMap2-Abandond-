using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise
{
    public class PerlinNoiseGenerator
    {
        /// <summary>
        /// This method generates a 2D Perlin noise texture.
        /// </summary>
        /// <param name="size">The size of the texture.</param>
        /// <param name="scale">The scale of the noise.</param>
        /// <returns>A 2D Perlin noise texture.</returns>
        public Texture2D GeneratePerlinNoise2DTexture(int size, float scale)
        {
            Texture2D noiseTexture2D = new Texture2D(size, size);
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    float sample = Mathf.PerlinNoise(x * scale, y * scale);
                    noiseTexture2D.SetPixel(x, y, new Color(sample, sample, sample));
                }
            }

            noiseTexture2D.Apply();
            return noiseTexture2D;
        }
    }
}