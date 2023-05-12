using UnityEngine;

namespace PathFinding
{
    public class PerlinNoiseGenerator
    {
        public Texture2D GeneratePerlinNoise2DTexture(int size, float scale)
        {
            Texture2D noiseTexture2D = new Texture2D(size, size);
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Color color = GeneratePerlinNoise2D(x, y, size * scale);
                    noiseTexture2D.SetPixel(x, y, color);
                }
            }
            noiseTexture2D.Apply();
            return noiseTexture2D;
        }
        public Texture3D GeneratePerlinNoise3DTexture(int size, float scale)
        {
            Texture3D noiseTexture3D = new Texture3D(size, size, size, TextureFormat.RGBA32, false);
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        Color color = GeneratePerlinNoise3D(new Vector3(x, y, z), size * scale);
                        noiseTexture3D.SetPixel(x, y, z, color);
                    }
                }
            }
            noiseTexture3D.Apply();
            return noiseTexture3D;
        }
        private Color GeneratePerlinNoise2D(int x, int y, int size)
        {
            float xpc = (float)x / size;
            float ypc = (float)y / size;
            float sample = Mathf.PerlinNoise(xpc, ypc);
            return new Color(sample, sample, sample);
        }
        private Color GeneratePerlinNoise3D(Vector3 position, float scale)
        {
            position = position / scale;

            float ab = Mathf.PerlinNoise(position.x, position.y);
            float bc = Mathf.PerlinNoise(position.y, position.z);
            float ac = Mathf.PerlinNoise(position.x, position.z);

            float ba = Mathf.PerlinNoise(position.y, position.x);
            float cb = Mathf.PerlinNoise(position.z, position.y);
            float ca = Mathf.PerlinNoise(position.z, position.x);

            float abc = (ab + bc + ac + ba + cb + ca) / 6;
            return new Color(abc, abc, abc);

        }
    }
}
