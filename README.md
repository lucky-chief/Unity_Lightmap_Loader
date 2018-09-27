# Lightmap  Loader

## **实现思路**

​	unity烘焙的lightmap信息记录在了每个场景的LightingData的.asset的资源文件里，却没有提供任何操作这个资源的API，这样就想在runtime的时候加载Lightmap就特别恶心了。对此unity官方技术人员提出了一个解决方案：**把烘焙好的信息保存到预制里，在加载预制时再把保存在预制里的光照信息还原到预制里的render里。**

## **使用**

### 1、在场景里打好光

### 2、在需要保存光照贴图的预制上挂载 LightmapSaver 脚本（建议一个场景里就只有一个这个脚本）

### 3、点击 Tools > 烘焙当前场景，稍等，知道弹出一下弹窗。![dialog](https://github.com/lucky-chief/imageCache/blob/master/dialog.png)，此时观察 LightmapSaver 脚本，发现已经把相关信息写入：![prefab](https://github.com/lucky-chief/imageCache/blob/master/prefab.png)

### 4、将挂载 LightmapSaver 脚本的游戏物体保存成预制

### 5、在游戏运行时加载上一步保存的预制，即可还原光照贴图。（运行Example里的TestScene）![1538039638811](https://github.com/lucky-chief/imageCache/blob/master/scene.png)
