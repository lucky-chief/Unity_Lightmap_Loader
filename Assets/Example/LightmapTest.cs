using UnityEngine;
using System.Collections.Generic;

public class LightmapTest : MonoBehaviour {
    public List<LightmapSaver> lightthings;

    void Start()
    {
        foreach (var l in lightthings)
        {
            Instantiate<LightmapSaver>(l);
        }

        LightmapSaver.SetLightmap();
    }
}
