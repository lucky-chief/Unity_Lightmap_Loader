using UnityEngine;
using UnityEditor;
using System.Collections;

public class LightmapSaverEditor {
    [MenuItem("Tools/烘焙当前场景")]
    static void LightmapSaverEditorSimplePasses() {
        LightmapSaver[] dataHolders = GameObject.FindObjectsOfType<LightmapSaver>();
        for(int i = 0; i < dataHolders.Length; i++)
        {
            var holder = dataHolders[i];
            GameObject root = holder.gameObject;
            LightmapSaver pSaver = root.GetComponentInParent<LightmapSaver>();
            if(null != pSaver && pSaver.gameObject != root)
            {
                EditorUtility.DisplayDialog("错误", string.Format("游戏物体{0}的父节点{1}包含有 LightmapSaver 组件，这是不允许的。", root.gameObject.name, pSaver.gameObject.name),"确定");
                return;
            }
            var cSaver = root.GetComponentInChildren<LightmapSaver>();
            if(null != cSaver && cSaver.gameObject != root)
            {
                EditorUtility.DisplayDialog("错误", string.Format("游戏物体{0}的子节点{1}包含有 LightmapSaver 组件，这是不允许的。", root.gameObject.name, cSaver.gameObject.name), "确定");
                return;
            }

            Lightmapping.Clear();
            Lightmapping.Bake();//开始烘焙

            var renderers = root.GetComponentsInChildren<Renderer>(true);

            holder.RendererData = new LightmapSaver.LightmapRendererData[renderers.Length];
            for (int j = 0; j < renderers.Length; j++)
            {
                var renderer = renderers[j];
                holder.RendererData[j] = new LightmapSaver.LightmapRendererData();
                Debug.Log(renderer.gameObject.name);
                if (renderer.lightmapIndex == -1) continue;
                var rendererData = holder.RendererData[j];
                rendererData.renderer = renderer;
                rendererData.lightmapIndex = renderer.lightmapIndex;
                rendererData.lightmapScaleOffset = renderer.lightmapScaleOffset;
            }
            if(LightmapSettings.lightmaps.Length > 0)
            {
                holder.lightmapColor = LightmapSettings.lightmaps[0].lightmapColor;
                holder.lightmapDir = LightmapSettings.lightmaps[0].lightmapDir;
            }
            else
            {
                EditorUtility.DisplayDialog("烘焙失败", "没有成功生成光照贴图。", "确定");
                return;
            }
        }
        EditorUtility.DisplayDialog("烘焙成功", "烘焙已经完成。", "确定");
    }
}
