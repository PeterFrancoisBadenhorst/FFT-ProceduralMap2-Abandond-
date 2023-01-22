using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.SRC.ProceduralMapGeneration.Assets.SRC.ProceduralMapGeneration.Noise
{
    internal class PerlinNoiseGenerator
    {
        public Texture2D GeneratePerlinNoise2DTexture(int size, float scale)
        {
            Texture2D noiseTexture2D = new Texture2D(size, size);
            for (int X = 0; X < size; X++)
            {
                for (int Y = 0; Y < size; Y++)
                {
                    Color color = GeneratePerlinNoise2D(X, Y, (int)(size * scale));
                    noiseTexture2D.SetPixel(X, Y, color);
                }
            }
            noiseTexture2D.Apply();
            return noiseTexture2D;
        }
        public Texture3D GeneratePerlinNoise3DTexture(int size, float scale)
        {
            Texture3D noiseTexture3D = new Texture3D(size, size, size, TextureFormat.RGBA32, false);
            for (int X = 0; X < size; X++)
            {
                for (int Y = 0; Y < size; Y++)
                {
                    for (int Z = 0; Z < size; Z++)
                    {
                        Color color = GeneratePerlinNoise3D(new Vector3(X, Y, Z),
                                                           (int)(size * scale));
                        noiseTexture3D.SetPixel(X, Y, Z, color);
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
