using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightmapSaver : MonoBehaviour
{
    [System.Serializable]
    public class LightmapRendererData
    {
        public Renderer renderer;
        public int lightmapIndex;
        public Vector4 lightmapScaleOffset;
    }

    public LightmapRendererData[] RendererData;
    public Texture2D lightmapDir;
    public Texture2D lightmapColor;


    public static void SetLightmap()
    {
        LightmapSaver[] dataHolders = FindObjectsOfType<LightmapSaver>();
        LightmapData[] lightmapDataArr = new LightmapData[dataHolders.Length];
        for(int i = 0; i < dataHolders.Length; i++)
        {
            var holder = dataHolders[i];
            LightmapData lightData = new LightmapData();
            lightData.lightmapColor = holder.lightmapColor;
            lightData.lightmapDir = holder.lightmapDir;
            lightmapDataArr[i] = lightData;
        }
        LightmapSettings.lightmaps = lightmapDataArr;

        for (int i = 0; i < dataHolders.Length; i++)
        {
            LightmapSaver holder = dataHolders[i];
            for(int j = 0; j < holder.RendererData.Length; j++)
            {
                var data = holder.RendererData[j];
                data.renderer.lightmapIndex = i;
                data.renderer.lightmapScaleOffset = data.lightmapScaleOffset;
            }
        }
    }
}
