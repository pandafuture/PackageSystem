# PackageSystem
熊猫未来的U3D背包系统学习笔记



# UGUI 界面设计和拼接


## 一、 准备工作

- 准备背包系统的图标

- 创建 Unity 项目



## 二、UGUI 拼接

### 1、设置画布

1. 首先将屏幕设为 **1920 x 1080**

2. 新建一个UI画布 **Canvas**

3. *Canvas Scaler* 的 **UI 缩放模式** 改为 **屏幕大小缩放** ，**参考分辨率** 改为 **1920 x 1080** 。确保界面在任意分辨率下都处于正确的表现方式


### 2、设置背包界面
1. 新建一个空物体 **PackagePanel** 作为背包界面的根物体

2. 锚点设置
    - 按 ALT 点击最右下角的 **跟随父物体伸展宽高的方式**

3. 把浏览视图设为 **2D 视角**


### 3、设置位置锚点
1. 背包界面下创建空物体 **LeftTop** 并把锚点设为 **左上角** ，**位置改为 0**

2. 背包界面下创建空物体 **RightTop** 并把锚点设为** 右上角** ，**位置改为 0**

3. 背包界面下创建空物体 **TopCenter** 并把锚点设为 **顶部中心** ，**位置改为 0**

4. 背包界面下创建空物体 **Center** 并把锚点设为 **中心** ，**位置改为 0**

5. 背包界面下创建空物体 **Buttom** 并把锚点设为 **底部中心** ，**位置改为 0**


### 4、插入背包背景图片
1. 新建一个 **图片**，锚点选择 **跟随父物体伸展宽高的方式** ，**所有位置改为 0**

2. 改个 **颜色和透明度** 71/95/123/219


### 5、设置顶部菜单栏
1. 在 **TopCenter 下** 新建一个图片作为 **顶部菜单栏背景** ，修改 **宽** 为 1920 ，**位置 Y** 为 -50 ，**颜色和透明度** 比主体背景略暗即可 42/55/75/186

2. 在 **TopCenter 下** 新建一个空物体 **Menu** 用来容纳菜单主体部分，同时添加上一个水平排序和自适应宽度的组件 **Horizontal Layout Group** ，并将其 **子级对齐** 设为 **Middle Center**（居中对齐以及自适应宽度）

3. 给 **Menu** 添加 **Content Size Fitter 组件** ，并把 **水平组件** 设为 **Preferred Size**

4. 在 **Menu 下** 新建两个 **图片UI** 作为武器按钮和食物按钮

5. 在 **Menu** 的 **Horizontal Layout Group 组件** 中，把 **间距** 设为 5

6. **Weapon** 和 **Food** 都要加上 **Button 组件** 用来响应点击事件，同时把他们的 **透明度设置为 0**

7. 这两个按钮都有两种状态，普通状态和选中状态。
    - 在 **其子节点中** 添加选中状态和正常状态两张图片 **Icon1** 、**Icon2** ，还有一个选中时的高亮效果 **空白图片 Select** ，添加完图片后选择 **设置原生大小**
    - 把 **Select** 的 **高设为 5** ，**移动** 其位置到武器按钮的底部，用来标识说这个菜单项被选中了，并调整其 **颜色和透明度** 209/186/141/256
    - **调整 Menu 的位置** ，处于顶部菜单栏的合适位置



## 三、滚动容器


### 1、设置滚动容器
1. 在 **Center** 下创建 **scoll view** ，并将其 **宽度** 设为 1200 ，**高度** 设为 600 ，**X 轴** 为 -200 ，再把 **水平滚动条** 和 **垂直滚动条** 的 **可见性** 设置为 **永久** ，**滚动方式** 只需要保留垂直滚动即可，**关闭水平滚动**

2. 设置滚动视图的 **Content** 用来容纳所有的滚动容器中的物品
    1. 添加 **Grid Layout Group 组件** 和 **Content Size Fitter 组件**
    2. **Grid Layout Group 组件** 的 **填充** 设置为 40/0/20/0 ，**大小** 设置为 120/150 ，**间距** 设置为 20/25 ，**启动角落** 设置为 **Upper Left** ，**启动轴** 设置为 **水平** ，**子级对齐** 设置为 **UPper Left** ， **约束** 设置为 **Flexible**
    3. **Content Size Fitter** 的 **水平匹配** 设置为 **Unconstrained** ，**垂直适应** 设置为 **Preferred Size**

3. 在 **Content** 下新建一个图片UI **PackageUIItem**

4. 新建一个预制体文件夹 **Prefab** ，在里面再新建一个文件夹 **Panel** ，在里面再新建一个文件夹 **Package**

5. 把 **PackageUIItem** 拖进 **Package 文件夹** 设为预制体

6. 多复制创建几个 **PackageUIItem** ，排序组件 **Content Size Fitter** 会自动排好序

7. 点击 **PackageUIItem** 右边的箭头进入预制件编辑模式
    - 把父节点的图片的 **透明度** 设置为 0
    - 新建一个图片作为选中效果 **Select** ，把 Select 图片复制上去，并调整宽高 127/158
    - 创建一个空物体 **DeleteSelect** 用来容纳删除时选中的状态，包含了两张 **图片**，把 **宽高** 设置为 1220/5 ，**位置 Y** 设置为 77 ，颜色设为绿色
    - **PackageUIItem** 下新建 **Top** 和 **Bottom** 两个空物体，把 **Top** 的锚点设置为 **顶部横向拉伸** ，**位置 Y** 设置为 -60，**左/右** 设置为 0，**高度** 设置为 120 。把 **Buttom** 的锚点设置为 **底部横向拉伸** ，**位置 Y** 设置为 15， **高度** 设置为 30，其他为 0
    - 给 **Top** 和 **Bottom** 添加 **背景图片** ，并把图片设置为 **跟随父物体伸展宽高的方式**，设置 **Top 图片颜色** 为 146/119/178/255 ，**Bottom 图片颜色** 为 223/229/220
    - 在 **Top 容器** 中新建一个图片 **Icon** ，把一个 **武器的图片** 赋上去，**设置为原始大小** ，锚点设置为 **左下角** ，调整缩放 **X0.4/Y0.4** ，调整位置 **X50/Y58** ，调整旋转 **Z-30**
    - 在 **Top** 下再创建一个图片 **New** ，标识这个物品是不是新获得的物品。把图片“新”赋给它，**设置原始大小** ，锚点设为 **右上角**，修改其 **位置** 为 **X-12.8/Y-15.5**
    - 在 **Top** 下创建一个图片 **Head** ，标识这个武器被哪个英雄装备了。设置锚点为 **右上角** ，设置位置为 **X-17.1/Y-16.1**
    - 在 **Bottom** 下创建一个文本（旧版） **LevelText** ，用来显示当前的物品的等级，设置宽高 **80/20** ，设置对齐 **两个都为居中对齐** ，输入文本 **Lv.1**
    - 在 **Bottom** 下新建一个空物体 **Stars** 作为星级界面，添加 **Horizontal Layout Group 组件** 和 **Content Size Fitter 组件** ，并把 **Horizontal Layout Group 组件** 的 **子级对齐** 设置为 **Middle Center** ，把 **Content Size Fitter 组件** 的 **水平匹配** 设置为 **Preferred Size**
    - 把 **星星图片** 赋给 **Stars** ，并 **设置原生大小** 。然后复制到共五个星星，注意命名规范
    - 对 **Stars** 设置缩放为 **统一0.8** ，设置 **Horizontal Layout Group** 的间隔为 -10 ，然后将其移动到合适的位置 **Y 21.8**
    - 对滚动条 **Scrollbar Vertical** 的颜色和透明度进行修改 **161/161/161/255** ，设置宽高 **10/1**
    - 把滚动容器 **Scroll View** 的背景透明度设置为 0
    - 把可复用的物品设为预制件，把星级界面 **Stars** 做成预制件，把整个背包界面 **PackagePanel** 做成预制件



## 四、详情功能

1. 首先进入背包界面 **PackagePanel** 预制件的编辑模式

2. 在 **Center** 下新建一个空物体 **DetailPanel** ，作为详情界面，设置宽高为 **400/600** ，设置位置为 **X 630/Y -50** ，设置锚点为 **最小 X 0.5 Y 1 最大 X 0.5 Y 1** ，设置轴心为 **X 0.5 Y 0.5**

3. 把详情界面分为上、中、下三个部分
    - 在 **DetailPanel** 新建一个空物体 **Center** ，并设置宽高为 **400/200** ，设置位置为 **X 0 / Y 120**

    - 在 **DetailPanel** 新建一个空物体 **Top** ，设置宽高为 **400/80** ，设置位置为 **X 0 / Y 260**

    - 在 **DetailPanel** 新建一个空物体 **Bottom** ，设置宽高为 **400/320** ，设置位置为 **X 0 / Y -140**

4. 设置中间部分 **Center** 的内容
    1. 在 **Center** 下创建一个背景图片 **Bg** ，并设置锚点为 **全部伸展模式** ，设置颜色 **146/119/178/255**

    2. 在 **Center** 下创建一个分界线图片 **Line** ，作为中间部分和下部分之间的分界线，并设置颜色为 **101/77/130**

    3. 在 **Center** 下实例一个星级预制件 **Stars** ，设置位置 **X -112 / Y -67**

    4. 在 **Center** 下添加一个文本（旧版） **Description** ，设置宽高 **200/40** ，设置位置 **X -86 / Y 66** ，设置文本内容 **武器的简短描述** ，设置字体大小 **30** ，设置字体颜色 **白色** ，设置垂直溢出为 **Overflow** 这样当超过文本框宽度时自动转到下一行

    5. 在 **Center** 下创建一个武器图片 **Icon** ，设置宽高 **186/100** ，把武器图片赋上去，**设置原生大小** ，调整缩放 **统一0.7** ，调整位置 **X 95 / Y -29**

5. 设置上部 **Top** 的内容
    1. 在 **Top** 下创建一个背景图片 **Bg** ，设置颜色 **175/155/197** ，设置锚点 **全部伸展模式**

    2. 在 **Top** 下创建一个文本（旧版） **Title** , 设置文本内容 **武器** ，设置宽高 **400/70** ，设置位置 **X 0 / Y 0** ，设置字体大小 **55** ，设置字体样式 **加粗** ，设置对齐 **行间居中对齐** ，设置字体颜色为 **白色**

6. 设置底部 **Bottom** 的内容
    1. 在 **Bottom** 下创建一个背景图片 **Bg** ，设置颜色为 **淡黄色** ，设置锚点为 **全部伸展模式**

    2. 在 **Bottom** 下创建一个文本（旧版） **Description** ，设置文本内容为 **关于武器的详细描述** ，设置锚点为 **居中左对齐**

    3. 在 **Bottom** 下创建一个空物体 **LevelPnl** 作为等级界面，设置宽高为 **120/25** ，设置位置为 **X -113 / Y 132**

    4. 在 **LevelPnl** 下创建一个背景图片 **Bg** ，设置锚点为 **全部伸展模式** ，颜色设置为 **57/68/79/255**

    5. 在 **LevelPnl** 下创建一个文本（旧版 ） **LevelText** ，设置宽高为 **160/30** ，设置位置为 **X 27 / Y 0** ，设置文本内容为 **Lv.40/40** ，设置字体样式为 **加粗** ，设置字体大小为 **25** ，设置字体颜色为 **211/213/216/255**



## 五、删除功能
1. 在 **Bottom** 下创建一个空物体 **BottomMenus** 用来容纳下方的菜单按钮。设置位置为 **X 0 / Y 60**

2. 在 **BottomMenus** 下创建一个图片 **DeleteBtn** 作为删除按钮。添加 **Button 组件** ，把 **删除图标** 赋给它 ，**设置原生大小** ，设置位置为 **X -853 / Y 60**

3. 复制一个 **DeleteBtn** ，把名字改为 **DetailBtn** , 把图片 **详情** 赋给他，**设置原始大小** ，设置位置为 **X 700 / Y 60**

4. 在 **Buttom** 下创建一个空物体 **DeletePanel** 用来容纳所有跟删除界面相关的内容。设置位置 Y 为 **60**

5. 在 **DeletePanel** 下创建一个背景图片 **Bg** ，设置宽高为 **1920/140** ，设置颜色为 **102/34/46/255**

6. 在 **Bg** 下创建一个装饰图片 **Image** ,锚点设置为 **左右伸展模式** ，设置高为 **60** ，设置位置 Y 为 **80** ，设置颜色为 **102/34/46/255**

7. 在 **DeletePanel** 下新建一个图片 **Back** 作为退出删除状态的返回按钮。添加 **Button 组件** ，把 **返回** 图片赋给它， **设置原生大小** ，设置位置 X 为 **-880**

8. 在 **DeletePanel** 下新建一个图片 **InfoIcon** 。把 **删除栏图标**赋给它， **设置原生大小** ，设置位置 X 为 **310**

9. 在 **DeletePanel** 下新建一个文本（旧版） **InfoText** 。设置宽高为 **200/40** ，设置位置 X 为 **460** ，设置字体样式为 **加粗** ，设置字体大小为 **30** ，设置字体颜色为 **纯白色** ，文本内容为 **已选 0/100**

10. 在 **DeletePanel** 下新建一个图片 **ConfirmBtn** 。添加 **Button 组件** ，把 **销毁** 图片赋给他， **设置原生大小** ，设置位置为 **X 692 / Y 3**



## 六、完善界面
1. 在 **LeftTop** 下新建一个图片，把 **背包** 图片赋给它， **设置原生大小** ，设置位置 **X 98 / Y -49**

2. 把 **LeftTop** 的图层顺序放在 **TopCenter** 之下，以便背包等图标的显示

3. 在 **LeftTop** 下新建一个文本（旧版） **TabName** ，文本内容为 **武器** ，字体样式为 **加粗** ，字体大小为 **20** ，设置颜色为 **211/188/142** ，对齐设置为 **居中 / 居中** ，设置位置为 **X 172 / Y -45**

4. 把 **RightTop** 的图层顺序放在 **LeftTop** 之下

5. 在 **RightTop** 下新建一个文本（旧版） **NumText** 用来表示物品数量和总数，设置字体样式为 **加粗** ，字体大小为 **20** ，对齐为 **居中 / 居中** ，字体颜色为 **209/186/141** ，设置位置为 **X -316 / Y -43** ，文本内容为 **武器 213/1000**

6. 在 **RightTop** 下新建一个图片 **Close** ，添加 **Button 组件** ，把 **退出** 图片赋给他，**设置原生大小** ，设置位置为 **X -106 / Y -45**

7. 在 **PackagePanel** 下新建一个空物体 **Left** ，点击之后会切换当前的页签，锚点设置为 **左居中** ，设置位置为 **X 0**

8. 在 **PackagePanel** 下新建一个空物体 **Right** ，点击之后会切换当前的页签，锚点设置为 **右居中** ，设置位置为 **X 0**

9. 在 **Left** 下新建一个按钮（旧版） **Button** ，把 **Button 组件** 下的文本物体删除，把图片 **左** 赋给他， **设置原生大小** ，设置位置 X 为 **97**

10. 在 **Right** 下新建一个按钮（旧版） **Button** ，把 **Button 组件** 下的文本物体删除，把图片 **右** 赋给他， **设置原生大小** ，设置位置 X 为 **-45**





# 存储框架设计

## 一、静态数据的配置
1. 创建脚本文件夹 **Script** ，在文件夹中创建一个背包表格脚本 **Package Table**

2. 使用 **CreateAssetMenu 特性**
    ```
    // CreateAssetMenu特性：点击右键时，可以在 Unity 中创建一个配置文件。传入两个参数，一个是菜单的名称，另一个是创建后文件的名称
    [CreateAssetMenu(menuName = "Pandafuture/PackageData", fileName = "PackageTable")]
    ```

3. 修改 **PackageTable 的父类**
    ```
    // 修改 PackageTable 的父类为 ScriptableObject ，这个配置文件中的每一项，都是背包中的一个物体
    public class PackageTable : ScriptableObject
    ```

4. 设置背包表格中的 **物品属性**
    ```
    // 背包表格中物品包含的参数
    public class PackageTableItem
    {
        public int id;  // 物品的唯一标识ID
        public int type;  // 物品的类型（武器/食物等等）
        public int star;  // 物品的星级名称
        public string name;  // 物品的名称
        public string description;  // 物品的简单描述
        public string skillDescription;  // 物品的详细描述
        public string imagePath;  // 物品图片的路径
        public int num;  // 物品的数量
    }
    ```

5.  创建 **List 容器** 容纳所有物品
    ```
    public class PackageTable : ScriptableObject
    {
        //使用一个 List 容纳所有物品
        public List<PackageTableItem> DataList = new List<PackageTableItem>();
    }
    ```

6. 给 **PackageTableItem** 添加 **Serializable 特性** 以便可以在 Unity 中编辑
    ```
    using System;  // 添加 System 名称空间


    // 添加 Serializable Unity特性，以便可以在 Unity 中编辑，需要添加 System 名称空间
    [System.Serializable]
    // 背包表格中物品包含的参数
    public class PackageTableItem
    {

    }
    ```

7. 创建一个文件夹 **TableData** 用来存储静态数据，点击鼠标右键 -> Pandafuture -> PackageData ，在文件夹内创建一个静态数据项 **Package Table**

8. 锁定静态数据项 **PackageTable** 的 **检查器** ，在旁边新建一个 **检查器**

9. 把每个武器的基本参数都输入 **PackageTble** 中，注意 **ID** 只能是唯一的

10. 在 **Assets** 下创建一个 **Editor 文件夹** ，只有在编辑器运行模式下才会执行，打包出来之后就运行不了了。并在里面创建一个脚本 **GMCmd**

11. 再在 **Assets** 下创建一个 **Resources 文件夹** ，把 **UI 文件夹** 和 **Prefab 文件夹** 和 **Table Data 文件夹** 都放进去，以便后面的 GMCmd 能够成功读取表项，Resources 文件夹属于特殊文件夹，GMCmd 放在其他地方就读不到表项了

12. 在 **GMCmd** 里书写一个静态方法用来查看 **PackageTable** 里的物品是否配置成功，并且这个方法带有 Unity 特性 MenuItem ，保证 Unity 编辑器顶部菜单栏中生成一个按钮，以便我们点击执行相应的逻辑
    ```
    using UnityEditor;  // 添加 UnityEditor 名称空间


    // 书写一个静态方法，并且这个方法带有 Unity 特性 MenuItem ，保证 Unity 编辑器顶部菜单栏中生成一个按钮，以便我们点击执行相应的逻辑，需要添加 UnityEditor 名称空间
    [MenuItem("CMCmd/读取表格")]
    public static void ReadTable()  // 静态方法命名为 读取表格
    {
        // 把配置的表项读出来，并且进行简单的打印，打印出来了就代表打印成功
        PackageTable packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        foreach(PackageTableItem packageItem in packageTable.DataList)
        {
            Debug.Log(string.Format("【id】:{0}，【nama】:{1}", packageItem.id, packageItem.name));
        }
    }
    ```



## 三、动态数据的配置（采用本地数据存取）
1. 首先在 **Script 文件夹** 下创建一个脚本 **PackageLocalData** 。把背包数据以 Json 的格式存储在本地，并且在使用时将其从本地的文本文件中读取到内存中。

2. 修改名称空间
    ```
    using UnityEngine;
    using System.Collections.Generic;
    ```

3. 将其设置为单例模式，以便使用
    ```
    public class PackageLocalData
    {
        // 为了使用方便，将其设置为单例模式
        private static PackageLocalData _instance;

        public static PackageLocalData Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new PackageLocalData();
                }
                return _instance;
            }
        }
    }
    ```

4. 设置背包表格中的物品的动态存储的参数，并使用 Serializable 特性。最后重写这子类的 ToString() 方法，以便后续打印和调试
    ```
    [System.Serializable]
    // 背包表格中物品的动态存储的参数
    public class PackageLocalItem
    {
        public string uid;  // 唯一的标识符 uid
        public int id;  // 表示它是哪个物品
        public int num;  // 表示物品的数量
        public int level;  // 物品的等级
        public bool isNew;  // 是否为新获得的物品

        // 重写这个子类的 ToString() ，方便后续打印和调试
        public override string ToString()
        {
            return string.Format("[id]:{0} [num]:{1}", id, num);
        }
    }
    ```

5. 在 PackageLocalData 类中使用 List 容器来缓存当前所有物品的动态信息
    ```
    public List<PackageLocalItem> items;
    ```

6. 在 PackageLocalData 类中设置数据保存方法
    ```
    public void savePackage()
    {
        // 使用 Unity 提供的 JsonUtility 工具，把表格信息序列化为字符串
        string inventoryJson = JsonUtility.ToJson(this);
        // 使用 PlayerPrefs 把文本数据存储到本地的文件中，键名为 PackageLocalData
        PlayerPrefs.SetString("PackageLocalData", inventoryJson);
        PlayerPrefs.Save();
    }
    ```

7. 在 PackageLocalData 类中设置数据读取方法
    ```
    public List<PackageLocalItem> LoadPackage()
    {
        // 首先判断要缓存的数据是否已存在，若已存在，则说明之前已读取过文本信息，就直接返回 items
        if(items != null)
        {
            return items;
        }
        if (PlayerPrefs.HasKey("PackageLocaData"))  // 检查 PlayerPrefs 中是否有键名为 PackageLocalData 的文本数据，如果没有就从本地的文件中取读取
        {
            // 使用 PlayerPrefs 把本地的文件读取到内存中，使之成为字符串
            string inventoryJson = PlayerPrefs.GetString("PackageLocalData");
            // 在使用 JsonUtility 来反序列化为 packageLocalData 再填充 items 列表
            PackageLocalData packageLocalData = JsonUtility.FromJson<PackageLocalData>(inventoryJson);
            items = packageLocalData.items;
            return items;
        }
        else // 如果 PlayerPrefs 中不存在 PackageLocalData 的文本数据，就创建新的空列表
        {
            items = new List<PackageLocalItem>();
            return items;
        }
    }
    ```

8. 在 **GMCmd** 里书写两个静态方法用来测试 **PackageLocalData** 的本地数据存储，并且这两个方法带有 Unity 特性 MenuItem ，保证 Unity 编辑器顶部菜单栏中生成一个按钮，以便我们点击执行相应的逻辑
    ```
    [MenuItem("CMCmd/创建背包测试数据")]
    public static void CreateLocalPackageData()
    {
        // 创建背包数据并保存到本机
        // 获取背包单例实例，并将其物品列表初始化为空列表
        PackageLocalData.Instance.items = new List<PackageLocalItem>();
        // 创建测试物品
        for(int i = 1; i < 9; i++)
        {
            // 创建新物品
            PackageLocalItem packageLocalItem = new()
            {
                uid = Guid.NewGuid().ToString(),  // Guid 需要添加 System 名称空间来生成一个唯一的字符串
                id = i,
                num = i,
                level = i,
                isNew = i % 2 == 1
            };
            // 添加到背包
            PackageLocalData.Instance.items.Add(packageLocalItem);
        }
        PackageLocalData.Instance.savePackage();  // 保存数据
    }
    ```
    ```
    [MenuItem("CMCmd/读取背包测试数据")]
    public static void ReadLocalPackageData()
    {
        // 读取数据
        List<PackageLocalItem> readItems = PackageLocalData.Instance.LoadPackage();  // 调用读取方法
        foreach (PackageLocalItem item in readItems)
        {
            Debug.Log(item);
        }
    }
    ```



# 界面逻辑


## 一、UI 框架
**UGUI** 分为三大部分， **UIManager** 跨场景的全局 UI 管理器；**BasePanel** 所有界面的父类，封装一些通用方法；**界面关系配置表** 界面预制件的配置路径，通常放在 UIManager 脚本中
1. 在 **Script** 中创建两个脚本 **UIManager** 和 **BasePanel**

2. 将 **UIManager** 设置为 **单例模式**
    ```
    // 跨场景的全局 UI 管理器
    public class UIManager
    {
        // 首先将 UIManager 设置为单例模式
        private static UIManager _instance;
        public static UIManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }
    }
    ```

3. **BasePanel** 继承 **Monobehaviour** ，包含 **打开界面方法** 和 **关闭界面方法** ，然后设置两个属性 **isRemove 界面关闭标志位** 和 **name 界面名称**
    ```
    // 所有界面的父类，继承 MonoBehaviour ，需要挂接在物体身上，封装一些通用的方法
    public class BasePanel : MonoBehaviour
    {
        protected bool isRemove = false;  // 标识当前界面是否已关闭的标志位
        protected new string name;  // 界面的名称


        // 打开界面的方法
        public virtual void OpenPanel(string name)
        {
            this.name = name;  // 给当前界面的名称进行赋值
            gameObject.SetActive(true);  // 显示界面
        }


        // 关闭界面的方法
        public virtual void ClosePanel(string name)
        {
            isRemove = true;  // 标记当前界面已关闭
            gameObject.SetActive(false);  // 关闭界面
            Destroy(gameObject);  // 销毁物体
        }
    }
    ```

4. 在 **UIManager 脚本** 中设置存储界面名称的常量表 **UIConst**
    ```
    // 存储界面名称的常量表
    public class UIConst
    {
        // public const string Panel_1 = "Panel_1Name";
    }
    ```

5. 在 **UIManager** 中用 **字典** 搭建 **界面关系配置表** ，并创建一个私有的 **UIManager** 其中调用 **初始化字典** 的方法。再设置 **初始化字典的方法**
    ```
    // 搭建界面关系配置表，用字典来存储
    private Dictionary<string, string> pathDict;
    ```
    ```
    private UIManager()
    {
        InitDicts();  // 调用字典初始化方法
    }


    // 初始化字典
    private void InitDicts()
    {
        // 把界面路径配置到这映射关系的字典中
        pathDict = new Dictionary<string, string>()
        {
            // UIConst.Panel_1,"Menu/AllPanel"
        };
    }
    ```

6. 在**UIManager** 中设置 UI 界面 **根节点 UIRoot**
    ```
    // 任何界面都需要一个可以挂载的地方，把挂载的根节点称为 uiRoot ，即 UI 最顶层的父节点
    private Transform _uiRoot;


    // 设置 UI 根节点 uiRoot
    public Transform UIRoot
    {
        get
        {
            if(_uiRoot == null)
            {
                _uiRoot = GameObject.Find("Canvas").transform;  // 把画布 Canvas 作为根节点
            }
            return _uiRoot;
        }
    }
    ```

7. 在 **UIManager** 中设置 **打开界面方法** 和 **关闭界面方法**
    ```
    // 用于打开界面
    public BasePanel OpenPanel(string name)
    {

    }

    // 用于关闭界面
    public bool ClosePanel()
    {

    }
    ```

8. 在 **UIManager** 添加两个字典，**prefabDict 预制件缓存字典** 和 **panelDict 界面缓存字典**
    ```
    // 预制件缓存字典
    private Dictionary<string, GameObject> prefabDict;

    // 界面缓存字典，存储当前已打开的界面
    public Dictionary<string, BasePanel> panelDict;
    ```

9. 在 **InitDicts()** 中对 **prefabDict 预制件字典** 和 **panelDict 界面缓存字典** 进行初始化
    ```
    // 初始化预制件字典
    prefabDict = new Dictionary<string, GameObject>();
    // 初始化界面缓存字典
    panelDict = new Dictionary<string, BasePanel>();
    ```

10. 设置 **UIManager** 中的 **OpenPanel 打开界面** 的方法。
    - 首先检查这界面是否已经打开了。
    - 再检查路径是否有配置。
    - 然后加载使用缓存预制件，先在预制件缓存字典中查看，是否之前已被加载过，如果被加载过了就直接拿来用，如果没有被加载过，就把他加载出来并且放在缓存字典中。
    - 最后实现打开界面。把预制件加载出来，并挂载在 UIRoot 下，使其成为 UIRoot 的一个子节点，把它添加到 panelDict 中，表示这个界面已经打开了
    ```
    // 用于打开界面
    public BasePanel OpenPanel(string name)
    {
        BasePanel panel = null;
        // 首先检查这个界面是否打开了
        if(panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("界面已打开：" + name);
            return null;
        }

        // 检查路径是否有配置
        string path = "";
        if(!pathDict.TryGetValue(name, out path))
        {
            Debug.LogError("界面名称错误，或者未配置路径：" + name);
            return null;
        }

        // 加载使用缓存的界面预制件
        GameObject panelPrefab = null;
        // 先在预制件缓存字典中查看，是否之前已被加载过，如果被加载过了就直接拿来用
        if(!prefabDict.TryGetValue(name, out panelPrefab))
        {
            // 如果没有被加载过，就把他加载出来并且放在缓存字典中
            string realPath = "Prefab/Panel/" + path;
            panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
            prefabDict.Add(name, panelPrefab);
        }

        // 打开界面
        // 把预制件加载出来，并挂载在 UIRoot 下，使其成为 UIRoot 的一个子节点
        GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
        panel = panelObject.GetComponent<BasePanel>();
        // 把它添加到 panelDict 中，表示这个界面已经打开了
        panelDict.Add(name, panel);
        return panel;
    }
    ```

11. 设置 **UIManager** 中的 **ClosePanel 关闭界面** 的方法。
    - 先检查这个界面是否在 panelDict 中
    - 如果界面已经打开，则执行这个界面的 ClosePanel()
    - 修改 **BasePanel** 中的 **ClosePanel 关闭界面方法** 。加上检查当前这个界面是否存在，如果存在的话，就移除缓存，表示界面没打开
    ```
    // 用于关闭界面
    public bool ClosePanel(string name)
    {
        BasePanel panel = null;

        // 检查这个界面是否在 panelDict 中
        if (!panelDict.TryGetValue(name, out panel))
        {
            Debug.LogError("界面未打开：" + name);
            return false;
        }

        // 如果界面已经打开，则执行这个界面的 ClosePanel()
        panel.ClosePanel();
        return true;
    }
    ```
    ```
    // 关闭界面的方法
    public virtual void ClosePanel()
    {
        isRemove = true;  // 标记当前界面已关闭
        gameObject.SetActive(false);  // 关闭界面
        Destroy(gameObject);  // 销毁物体

        // 检查当前这个界面是否存在，如果存在的话，就移除缓存，表示界面没打开
        if (UIManager.Instance.panelDict.ContainsKey(name))
        {
            UIManager.Instance.panelDict.Remove(name);
        }
    }
    ```


***通用 UI 框架***  
- **UIManager**
    ```
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    // 跨场景的全局 UI 管理器
    public class UIManager
    {
        // 首先将 UIManager 设置为单例模式
        private static UIManager _instance;

        // 任何界面都需要一个可以挂载的地方，把挂载的根节点称为 uiRoot ，即 UI 最顶层的父节点
        private Transform _uiRoot;

        // 搭建界面关系配置表，用字典来存储
        private Dictionary<string, string> pathDict;

        // 预制件缓存字典
        private Dictionary<string, GameObject> prefabDict;

        // 界面缓存字典，存储当前已打开的界面
        public Dictionary<string, BasePanel> panelDict;

        public static UIManager Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new UIManager();
                }
                return _instance;
            }
        }


        // 设置 UI 根节点 uiRoot
        public Transform UIRoot
        {
            get
            {
                if(_uiRoot == null)
                {
                    if (GameObject.Find("Canvas"))
                    {
                        _uiRoot = GameObject.Find("Canvas").transform;  // 把画布 Canvas 作为根节点
                    }
                    else
                    {
                        _uiRoot = new GameObject("Canvas").transform;
                    }
                }
                return _uiRoot;
            }
        }


        private UIManager()
        {
            InitDicts();  // 调用字典初始化方法
        }


        // 初始化字典
        private void InitDicts()
        {
            // 初始化预制件字典
            prefabDict = new Dictionary<string, GameObject>();
            // 初始化界面缓存字典
            panelDict = new Dictionary<string, BasePanel>();
            // 把界面路径配置到这映射关系的字典中
            pathDict = new Dictionary<string, string>()
            {
                // UIConst.Panel_1,"Menu/AllPanel"
            };
        }


        public BasePanel GetPanel(string name)
        {
            BasePanel panel = null;
            // 检查是否已打开
            if(panelDict.TryGetValue(name, out panel))
            {
                return panel;
            }
            return null;
        }


        // 用于打开界面
        public BasePanel OpenPanel(string name)
        {
            BasePanel panel = null;
            // 首先检查这个界面是否打开了
            if(panelDict.TryGetValue(name, out panel))
            {
                Debug.LogError("界面已打开：" + name);
                return null;
            }

            // 检查路径是否有配置
            string path = "";
            if(!pathDict.TryGetValue(name, out path))
            {
                Debug.Log("界面名称错误，或者未配置路径：" + name);
                return null;
            }

            // 加载使用缓存的界面预制件
            GameObject panelPrefab = null;
            // 先在预制件缓存字典中查看，是否之前已被加载过，如果被加载过了就直接拿来用
            if(!prefabDict.TryGetValue(name, out panelPrefab))
            {
                // 如果没有被加载过，就把他加载出来并且放在缓存字典中
                string realPath = "Prefab/Panel/" + path;
                panelPrefab = Resources.Load<GameObject>(realPath) as GameObject;
                prefabDict.Add(name, panelPrefab);
            }

            // 打开界面
            // 把预制件加载出来，并挂载在 UIRoot 下，使其成为 UIRoot 的一个子节点
            GameObject panelObject = GameObject.Instantiate(panelPrefab, UIRoot, false);
            panel = panelObject.GetComponent<BasePanel>();
            // 把它添加到 panelDict 中，表示这个界面已经打开了
            panelDict.Add(name, panel);
            panel.OpenPanel(name);
            return panel;
        }

        // 用于关闭界面
        public bool ClosePanel(string name)
        {
            BasePanel panel = null;

            // 检查这个界面是否在 panelDict 中
            if (!panelDict.TryGetValue(name, out panel))
            {
                Debug.Log("界面未打开：" + name);
                return false;
            }

            // 如果界面已经打开，则执行这个界面的 ClosePanel()
            panel.ClosePanel();
            return true;
        }
    }


    // 存储界面名称的常量表
    public class UIConst
    {
        // public const string Panel_1 = "Panel_1Name";
    }
    ```

- **BasePanel**
    ```
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    // 所有界面的父类，继承 MonoBehaviour ，需要挂接在物体身上，封装一些通用的方法
    public class BasePanel : MonoBehaviour
    {
        protected bool isRemove = false;  // 标识当前界面是否已关闭的标志位
        protected new string name;  // 界面的名称

        protected virtual void Awake()
        {

        }

        public virtual void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        // 打开界面的方法
        public virtual void OpenPanel(string name)
        {
            this.name = name;  // 给当前界面的名称进行赋值
            gameObject.SetActive(true);  // 显示界面
        }


        // 关闭界面的方法
        public virtual void ClosePanel()
        {
            isRemove = true;  // 标记当前界面已关闭
            SetActive(false);  // 关闭界面
            Destroy(gameObject);  // 销毁物体

            // 检查当前这个界面是否存在，如果存在的话，就移除缓存，表示界面没打开
            if (UIManager.Instance.panelDict.ContainsKey(name))
            {
                UIManager.Instance.panelDict.Remove(name);
            }
        }
    }
    ```

12. 在 **UIConst** 中添加 **PackagePanel** 常量
    ```
    // 存储界面名称的常量表
    public class UIConst
    {
        // 新增 PackagePanel 常量
        public const string PackagePanel = "PackagePanel";
    }
    ```

13. 在 **InitDict** 中配置 **PackagePanel** 常量
    ```
    // 把界面路径配置到这映射关系的字典中
    pathDict = new Dictionary<string, string>()
    {
        // 配置 PackagePanel 对应的路径
        {UIConst.PackagePanel, "Package/PackagePanel" },
    };
    ```

14. 在 **Script** 中新建一个脚本 **PackagePanel** ，用来处理背包界面相关的逻辑代码

15. **PackagePanel** 继承自 **BasePanel**
    ```
    public class PackagePanel : BasePanel
    {
        
    }
    ```

16. 把 **PackagePanel 脚本** 挂载到 **PackagePanel 预制件** 上

17. 测试背包界面是否正常运行，在 **GMCmd 脚本** 中添加 **打开背包界面的指令** 。然后回到场景中，先把场景中的背包界面删除，然后运行游戏，点击打开背包界面的按钮进行测试
    ```
    [MenuItem("CMCmd/打开背包主界面")]
    public static void OpenPackagePanel()
    {
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);  // 打开背包界面的指令
    }
    ```


## 二、界面初始化
1. 通过 **PackagePanel 脚本** 拿到界面里的 UI 组件。
    - 先对各个 UI 组件的属性进行 **初始化** 
    - 然后用 **transform.Find()** 根据路径去绑定属性
    - 然后对子物体 DeletePanel 和 BottomMenus 的可见性初始化为不可见
        ```
        public class PackagePanel : BasePanel  // PackagePanle 继承自 BasePanel
        {
            // 对各个 UI 组件的属性进行初始化
            private Transform UIMenu;
            private Transform UIMenuWeapon;
            private Transform UIMenuFood;
            private Transform UITabName;
            private Transform UICloseBtn;
            private Transform UICenter;
            private Transform UIScrollView;
            private Transform UIDetaiPanel;
            private Transform UILeftBtn;
            private Transform UIRightBtn;
            private Transform UIDeletePanel;
            private Transform UIDeleteBackBtn;
            private Transform UIDeleteInfoText;
            private Transform UIConfirmBtn;
            private Transform UIBottomMenus;
            private Transform UIDeleteBtn;
            private Transform UIDetailBtn;
        }
        ```
        ```
        override protected void Awake()
        {
            base.Awake();
            InitUI();
        }


        private void InitUI()
        {
            InitUIName();
        }


        private void InitUIName()
        {
            // 使用 transform.Find() 根据路径去绑定属性
            UIMenu = transform.Find("TopCenter/Menu");
            UIMenuWeapon = transform.Find("TopCenter/Menu/Weapon");
            UIMenuFood = transform.Find("TopCenter/Menu/Food");

            UITabName = transform.Find("LeftTop/TabName");

            UICloseBtn = transform.Find("RightTop/Close");

            UICenter = transform.Find("center");
            UIScrollView = transform.Find("Centr/Scroll View");
            UIDetailPanel = transform.Find("Center/DetailPanel");

            UILeftBtn = transform.Find("Left/Button");
            UIRightBtn = transform.Find("Right/Button");

            UIDeletePanel = transform.Find("Bottom/DeletePanel");
            UIDeleteBackBtn = transform.Find("Bottom/DeletePanel/Back");
            UIDeleteInfoText = transform.Find("Bottom/DeletePanel/InfoText");
            UIDeleteConfirmBtn = transform.Find("Bottom/DeletePanel/ConfirmBtn");
            UIBottomMenus = transform.Find("Bottom/BottomMenus");
            UIDeleteBtn = transform.Find("BOttom/BottomMenus/DeleteBtn");
            UIDetailBtn = transform.Find("BOttom/BottomMenus/DetailBtn");

            // 对子物体 DeletePanel 和 BottomMenus 的可见性初始化为不可见
            UIDeletePanel.gameObject.SetActive(false);
            UIBottomMenus.gameObject.SetActive(false);
        }

        ```

2. 在 **PackagePanel 脚本** 中把界面中出现的按钮都注册点击事件。注意 **\<Button\>** 要引用 **using UnityEngine.UI** 名称空间
    ```
    // 把界面中出现的按钮都注册点击事件
    private void InitClick()
    {
        UIMenuWeapon.GetComponent<Button>().onClick.AddListener(OnClickWeapon);
        UIMenuFood.GetComponent<Button>().onClick.AddListener(OnClickFood);
        UICloseBtn.GetComponent<Button>().onClick.AddListener(OnClickClose);
        UILeftBtn.GetComponent<Button>().onClick.AddListener(OnClickLeft);
        UIRightBtn.GetComponent<Button>().onClick.AddListener(OnClickRight);

        UIDeleteBackBtn.GetComponent<Button>().onClick.AddListener(OnDeleteBack);
        UIDeleteConfirmBtn.GetComponent<Button>().onClick.AddListener(OnDeleteConfirm);
        UIDeleteBtn.GetComponent<Button>().onClick.AddListener(OnDeleteConfirm);
        UIDetailBtn.GetComponent<Button>().onClick.AddListener(OnDetail);
    }
    ```

3. 在 **PackagePanel 脚本** 中添加每个按钮的 **点击事件**
    ```
    // 添加点击事件
    private void OnClickWeapon()
    {
        print(">>>>> OnClickWeapon");
    }
    private void OnClickFood()
    {
        print(">>>>> OnClickFood");
    }
    private void OnClickClose()
    {
        print(">>>>> OnClickClose");
    }
    private void OnClickLeft()
    {
        print(">>>>> OnClickLeft");
    }
    private void OnClickRight()
    {
        print(">>>>> OnClickRight");
    }
    private void OnDeleteBack()
    {
        print(">>>>> OnDeleteBack");
    }
    private void OnDeleteConfirm()
    {
        print(">>>>> OnDeleteConfirm");
    }
    private void OnDelete()
    {
        print(">>>>> OnDelete");
    }
    private void OnDetail()
    {
        print(">>>>> OnDetail");
    }
    ```

4. 在 **Script** 中新建一个脚本 **PackageCell 脚本** 用来初始化背包中的物体，每个物体都看作一个独立的对象。

5. 打开背包中物品的预制件 **PackageUIItem** ，把 **PackageCell 脚本** 挂载上去

6. 通过 **PackageCell 脚本** 拿到背包中物品的 UI 组件。
    - 先对各个 UI 组件的属性进行 **初始化** 
    - 然后用 **transform.Find()** 根据路径去绑定属性
    ```
    public class PackageCell : MonoBehaviour
    {
        // 添加物品的 UI 属性
        private Transform UIIcon;
        private Transform UIHead;
        private Transform UINew;
        private Transform UISelect;
        private Transform UILevel;
        private Transform UIStars;
        private Transform UIDeleteSelect;


        private void Awake()
        {
            InitUIName();
        }


        private void InitUIName()
        {
            // 使用 transform.Find() 根据路径去绑定属性
            UIIcon = transform.Find("Top/Icon");
            UIHead = transform.Find("Top/Head");
            UINew = transform.Find("Top/New");
            UILevel = transform.Find("Bottom/LevelText");
            UIStars = transform.Find("Bottom/Stars");
            UISelect = transform.Find("Select");
            UIDeleteSelect = transform.Find("DeleteSelect");

            UIDeleteSelect.gameObject.SetActive(false);
        }
    }
    ```

7. 运行游戏，打开界面，测试各个 UI 组件的 **路径** 是否配置正确，若有报错则查看报错的路径进行修改，若运行无报错，则配置成功正确


## 三、控制器逻辑
需要获取动态数据，再配合静态数据对滚动容器初始化，就要先获得数据。  
数据获取功能可以复用，所以用 **GameManager**  作为中间的管理器来统一处理这些数据，界面的逻辑只通过管理器来获得和修改数据

1. 在场景中新建一个空物体 **GameManager** ，然后再 **Script** 中新建一个脚本 **GameManager 脚本** ，并把脚本挂载到 **GameManager 物体** 上

2. 先把 **GameManager 脚本** 设置为单例模式，方便后续使用
    ```
    // 先把 GameManager 设置为单例模式
    private static GameManager _instance;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // 添加 Instance 属性，方便外部调用，设置为公有，方便对数据的处理
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }
    ```

3. 再 **Start()** 中主动打开背包界面
    ```
    void Start()
    {
        // 主动打开背包界面
        UIManager.Instance.OpenPanel(UIConst.PackagePanel);  // 调用 UIManager 实例中打开界面的方法，同时传入 PackagePanel 背包界面常量名，打开背包界面
    }
    ```

4. 在 **GameManager 脚本** 中添加对静态数据处理的方法 **GetPackageTable()**
    ```
    // 静态数据
    private PackageTable packageTable;


    // 对静态数据处理的方法
    public PackageTable GetPackageTable()
    {
        // 使用 Unity 提供的 Resources.Load<> 去加载配置好的表格数据
        if(packageTable == null)  // 若已经加载过，就不用重复加载，直接使用缓存中的数据
        {
            packageTable = Resources.Load<PackageTable>("TableData/PackageTable");
        }
        return packageTable;
    }

    ```

5. 在 **GameManager 脚本** 中添加对动态数据加载的方法
    ```
    // 对动态数据加载的方法
    public List<PackageLocalItem> GetPackageLocalData()
    {
        return PackageLocalData.Instance.LoadPackage();  // 直接调用 PackageLocalData 实例中封装好的加载数据的方法 LoadPackage()
    }
    ```

6. 在 **GameManager 脚本** 中添加根据 id 获取表中指定数据的方法
    ```
    // 根据 id 取到表格中的指定数据的方法
    public PackageTableItem GetPackageItemById(int id)
    {
        List<PackageTableItem> packageDataList = GetPackageTable().DataList;
        foreach(PackageTableItem item in packageDataList)
        {
            if(item.id == id)
            {
                return item;
            }
        }
        return null;
    }
    ```

7. 在 **GameManager 脚本** 中添加根据 uid 找到本地数据中的动态数据的指定项的方法
    ```
    // 根据 uid 找到本地数据中动态数据的指定项的方法
    public PackageLocalItem GetPackageLocalItemByUId(string uid)
    {
        List<PackageLocalItem> packageDataList = GetPackageLocalData();
        foreach(PackageLocalItem item in packageDataList)
        {
            if(item.uid == uid)
            {
                return item;
            }
        }
        return null;
    }
    ```

8. 在 **GameManager 脚本** 中的 **GameManager 类** 中写一个获取背包物品并进行排序的方法，让背包中的物品按预定的规则进行排序，方便确定显示优先级
    ```
    // 对背包物品获取并按照预定规则进行排序，以确定显示优先级
    public List<PackageLocalItem> GetSortPackageLocalData()
    {
        List<PackageLocalItem> localItems = PackageLocalData.Instance.LoadPackage();
        localItems.Sort(new PackageItemComparer());
        return localItems;
    }
    ```

9. 在 **GameManager 脚本** 的 **GameManger 类外面** 写排序规则。先按星级，再按 id ,再按 等级

    ```
    // 定义排序规则
    public class PackageItemComparer : IComparer<PackageLocalItem>
    {
        public int Compare(PackageLocalItem a, PackageLocalItem b)
        {
            PackageTableItem x = GameManager.Instance.GetPackageItemById(a.id);
            PackageTableItem y = GameManager.Instance.GetPackageItemById(b.id);
            // 首先按照 star 从大到小排序
            int starComparison = y.star.CompareTo(x.star);

            // 如果 star 相同，则按 id 从大到小排序
            if (starComparison == 0)
            {
                int idComparison = y.id.CompareTo(x.id);
                // 如果 id 相同，则按 level 从大到小排序
                if (idComparison == 0)
                {
                    return b.level.CompareTo(a.level);
                }
                return idComparison;
            }
            return starComparison;
        }
    }
    ```


## 四、界面逻辑
1. 在 **PackagePanel 脚本** 中添加 **PackageUIItemPrefab 背包中物品** 的预制件属性，就可以在属性面板中对其进行复制生成
    ```
    // 背包子物体预制件属性
    public GameObject PackageUIItemPrefab;
    ```

2. 在 **PackagePanel 编辑器面板** 中把 **PackageUIItem 预制件** 拖到 **PackagePanel 脚本** 中

3. 在 **PackagePanel 脚本** 中的 **Start()** 中执行 **UI 刷新方法 RefreshUI()** 
    ```
    private void Start()
    {
        RefreshUI();  // UI 刷新方法
    }
    ```

4. 在 **PackagePanel 脚本** 中写 UI 刷新方法
    ```
    // UI 刷新方法
    private void RefreshUI()
    {
        RefreshScroll();  // 刷新滚动容器
    }
    ```

5. 在 **PackagePanel 脚本** 中写 **刷新滚动容器的方法。
    - 先清理滚动容器中原本的物品
    - 再使用 GameManager 中封装好的获取本地数据的方法，来拿到当前身上所有的背包数据，并且根据这些数据去初始化滚动容器
    ```
    // 刷新滚动容器方法
    private void RefreshScroll()
    {
        // 先清理滚动容器中原本的物品
        RectTransform scrollContent = UIScrollView.GetComponent<ScrollRect>().content;
        for(int i = 0; i < scrollContent.childCount; i++)
        {
            Destroy(scrollContent.GetChild(i).gameObject);
        }

        // 使用 GameManager 中封装好的获取本地数据的方法，来拿到当前身上所有的背包数据，并且根据这些数据去初始化滚动容器
        foreach(PackageLocalItem localData in GameManager.Instance.GetSortPackageLocalData())
        {
            Transform PackageUIItem = Instantiate(PackageUIItemPrefab.transform, scrollContent) as Transform;
            PackageCell packageCell = PackageUIItem.GetComponent<PackageCell>();
            //packageCell.Refresh(localData, this);
        }
    }
    ```


## 五、物品逻辑
1. 在 **PackageCell 脚本** 中添加 **packageLocalData 当前物品的动态数据** 和 **packageTableItem 当前物品的静态数据** 和 **uiParent 当前物品的父物品(PackagePanel)** 三个属性
    ```
    private PackageLocalItem packageLocalData;  // 当前物品的动态数据
    private PackageTableItem packageTableItem;  // 当前物品的静态数据
    private PackagePanel uiParent;  // 当前物品的父物品(PackagePanel)
    ```

2. 在 **PackageCell 脚本** 中写刷新这个物品状态的方法 **Refresh()** 
    - 需要传入这个物品的 **动态数据** 、**父物体**
    - 对物品基本信息数据进行初始化 **动态数据** 、**静态数据** 、**父物体**
    - 对 UI 组件的信息进行初始化
        - 等级信息
        - 是否新获得
        - 物品的图片
        - 刷新星级
    ```
    using UnityEngine.UI;  // 添加引用 UI 的名称空间



    // 刷新这个物品的状态的方法，要传进当前物品的动态数据、父物体
    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // 数据初始化
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;


        // 对 UI 组件的信息进行初始化
        // 等级信息，使用 <Text> 需要引用 using UnityEngine.UI 名称空间
        UILevel.GetComponent<Text>().text = "Lv." + this.packageLocalData.level.ToString();

        // 是否新获得
        UINew.gameObject.SetActive(this.packageLocalData.isNew);

        // 物品的图片，通过配置的路径去加载这个图片
        Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
        Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        UIIcon.GetComponent<Image>().sprite = temp;
        
        // 刷新星级
        RefreshStars();
    }

    
    // 刷新星级的方法
    public void RefreshStars()
    {
        for(int i = 0; i < UIStars.childCount; i++)
        {
            Transform star = UIStars.GetChild(i);
            if(this.packageTableItem.star > i)
            {
                star.gameObject.SetActive(true);
            }
            else
            {
                star.gameObject.SetActive(false);
            }
        }
    }
    ```

3. 在 **PackagePanel 脚本** 中的 **RefresgScroll 刷新滚动容器方法** 中调用 **PackageCell 脚本** 的 **Refresh** 方法，传入这个物品的 **动态数据** 和 **父物体**
    ```
    // 使用 GameManager 中封装好的获取本地数据的方法，来拿到当前身上所有的背包数据，并且根据这些数据去初始化滚动容器
    foreach (PackageLocalItem localData in GameManager.Instance.GetSortPackageLocalData())
    {
        Transform PackageUIItem = Instantiate(PackageUIItemPrefab.transform, scrollContent) as Transform;
        PackageCell packageCell = PackageUIItem.GetComponent<PackageCell>();
            
        // 刷新这个物品的状态
        packageCell.Refresh(localData, this);
    }
    ```

4. 编写 **PackagePanel 脚本** 的 **UICloseBtn 按钮** 的点击事件 **OnClickClose()** ，把 **PackagePanel 界面** 关闭。有两种方法都可以，直接调用自身的方法更方便些。点击关闭按钮时就关闭了这个界面，点击 CMCmd 指令时就打开了这个界面
    ```
    // PackagePanel 界面的 关闭 按钮
    private void OnClickClose()
    {
        print(">>>>> OnClickClose");
        ClosePanel();  // 调用自身的关闭方法更方便些
        //UIManager.Instance.ClosePanel(UIConst.PackagePanel);
    }
    ```




# 物品交互和物品详情

## 一、点击响应
背包交互中会用到鼠标 **点击**、 **进入**、 **退出** 三种回调方法

1. 在 **PackageCell 脚本** 中让 **PackageCell 类** 继承三个接口，分别对应鼠标的 **点击** 、**进入** 、**退出** 三种回调方法
    ```
    // 用来管理背包中每一个单独的子物品
    // 让 PackageCell 类继承三个接口，分别对应鼠标的点击、进入、退出三种回调方式
    public class PackageCell : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        ......
    }
    ```

2. 在 **PackageCell 脚本** 中实现三个接口对应的方法，然后运行测试一下
    ```
    // 实现鼠标点击的回调方法
    public void OnPointerClick(PointerEventData eventData)
    {
        // 打印当前执行的方法的方法名以及这一数据
        Debug.Log("OnPointerClick: " + eventData.ToString());
    }


    // 实现鼠标进入的回调方法
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter: " + eventData.ToString());
    }


    // 实现鼠标退出的回调方法
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit: " + eventData.ToString());
    }
    ```


## 二、详情界面
1. 打开 **PackagePanel 预制件** ，在 **Script** 中新建一个脚本 **PackageDetail** 并把他挂载到 **DetailPanel 详情界面** 上

2. 在 **PackageDetail 脚本** 中先给 **PackageDetail 类** 添加属性，即 **所有的 UI 子节点**
    ```
    public class PackageDetail : MonoBehaviour
    {
        // 先给 PackageDetail 类添加属性，即所有的 UI 子节点
        private Transform UIStars;
        private Transform UIDescription;
        private Transform UIIcon;
        private Transform UITitle;
        private Transform UILecelText;
        private Transform UISkillDescription;
    }
    ```

3. 作为背包物品的展示区，要先拿到这个物品的动态信息、静态信息、整个背包的父逻辑（uiParent)
    ```
    // 作为背包物品的展示区，要先拿到这个物品的动态信息、静态信息、整个背包的父逻辑（uiParent)
    private PackageLocalItem packageLocalData;
    private PackageTableItem packageTableItem;
    private PackagePanel uiParent;
    ```

4. 对这些属性进行初始化
    ```
    // 对这些属性进行初始化
    private void Awake()
    {
        InitUIName();
    }

    private void InitUIName()
    {
        // 使用 transform.Find() 找到物品对应的路径
        UIStars = transform.Find("Center/Stars");
        UIDescription = transform.Find("Center/Description");
        UIIcon = transform.Find("Center/Icon");
        UITitle = transform.Find("Top/Title");
        UILevelText = transform.Find("Bottom/LevelPnl/LevelText");
        UISkillDescription = transform.Find("Bottom/Description");
    }
    ```

5. 写一个刷新整个详情界面的主体方法，通过 **传入一个动态数据和 uiParent** 来实现整个详情界面的刷新
    - **初始化** ：动态数据、静态数据、父物体逻辑
    - 对 UI 的组件信息进行初始化
        - 等级
        - 简短描述
        - 详细描述
        - 物品描述
        - 图片加载
        - 刷新星级（使用独立方法）
    ```
    public void Refresh(PackageLocalItem packageLocalData, PackagePanel uiParent)
    {
        // 初始化：动态数据、静态数据、父物体逻辑
        this.packageLocalData = packageLocalData;
        this.packageTableItem = GameManager.Instance.GetPackageItemById(packageLocalData.id);
        this.uiParent = uiParent;


        // 对 UI 组件的信息进行初始化
        // 等级
        UILevelText.GetComponent<Text>().text = string.Format("Lv.{0}/40", this.packageLocalData.level.ToString());

        // 简短描述
        UIDescription.GetComponent<Text>().text = this.packageTableItem.description;

        // 详细描述
        UISkillDescription.GetComponent<Text>().text = this.packageTableItem.skillDescription;

        // 物品名称
        UITitle.GetComponent<Text>().text = this.packageTableItem.name;

        // 图片加载
        Texture2D t = (Texture2D)Resources.Load(this.packageTableItem.imagePath);
        Sprite temp = Sprite.Create(t, new Rect(0, 0, t.width, t.height), new Vector2(0, 0));
        UIIcon.GetComponent<Image>().sprite = temp;

        // 刷新星级
        RefreshStars();

    }


    // 刷新星级的方法
    public void RefreshStars()
    {
        for(int i = 0; i < UIStars.childCount; i++)
        {
            Transform star = UIStars.GetChild(i);
            if (this.packageTableItem.star > i)
            {
                star.gameObject.SetActive(true);
            }
            else
            {
                star.gameObject.SetActive(false);
            }
        }
    }
    ```

6. 测试目前详情界面的主体逻辑。创建一个 **Test()** 方法，在 **Awake()** 中调用。运行游戏后，若能显示第一个物品的详情界面则说明逻辑正确
    ```
    // 对这些属性进行初始化
    private void Awake()
    {
        InitUIName();

        // 用于验证此模块逻辑是否正确
        Test();
    }


    // 测试方法
    private void Test()
    {
        // 传入某一个物品的动态信息来对整个详情界面进行初始化
        Refresh(GameManager.Instance.GetPackageLocalData()[1], null);
    }
    ```

7. 在交互过程中需要记录当前选中的是哪一个物品
    - 在 **PackagePanel 脚本** 中添加 **_chooseUid** 表示当前选中的物品是哪一个 uid
    - 外部使用时，则使用不带下滑线的 **chooseUID** ，用来获取当前选中的物品是哪个并从外部选择这个物品并设置这个物品的 Uid
    - 如果获取到一个新的值，就调用 **RefreshDetail()** 刷新整个详情界面
    ```
    // 记录当前选中的是哪一个物品
    private string _chooseUid;  // 表示当前选中的物品是哪一个 uid


    // 外部使用时，则使用不带下滑线的 chooseUID ，用来获取当前选中的物品是哪个并从外部选择这个物品并设置这个物品的 Uid
    public string chooseUID
    {
        get
        {
            return _chooseUid;
        }
        set
        {
            // 如果获取到一个新的值，就刷新整个详情界面
            _chooseUid = value;
            RefreshDetail(); // 调用刷新详情界面的方法
        }
    }
    ```

8. 编写刷新详情界面的方法 **RefreshDetail()**
    ```
    // 刷新详情界面的方法
    private void RefreshDetail()
    {
        // 找到 uid 对应的动态数据
        PackageLocalItem localItem = GameManager.Instance.GetPackageLocalItemByUId(chooseUID);

        // 刷新详情界面
        UIDetailPanel.GetComponent<PackageDetail>().Refresh(localItem, this);
    }
    ```

9. 在 **PackageCell 脚本** 中的 **鼠标点击的回调方法** 中实现刷新详情界面的鼠标交互事件
    - 判断当前点击选中的物品是否和父物品的 uid 一样，如果一样则代表是重复点击，不执行任何逻辑
    - 如果不一样，则代表点击到了新物品身上，就把 uiParent 的 uid 设置为当前选中物品的 uid ，进而刷新详情界面
    ```
    // 实现鼠标点击的回调方法
    public void OnPointerClick(PointerEventData eventData)
    {
        // 打印当前执行的方法的方法名以及这一数据
        Debug.Log("OnPointerClick: " + eventData.ToString());

        // 判断当前点击选中的物品是否和父物品的 uid 一样，如果一样则代表是重复点击，不执行任何逻辑
        if (this.uiParent.chooseUID == this.packageLocalData.uid)
            return;
        // 如果不一样，则代表点击到了新物品身上，就把 uiParent 的 uid 设置为当前选中物品的 uid ，进而刷新详情界面
        this.uiParent.chooseUID = this.packageLocalData.uid;
    }
    ```


## 三、交互动效
1. 先在 **Resources 文件夹** 下创建一个新文件夹 **Ani** ，再在其下创建一个文件夹 **UI** ，用来容纳所有跟 UI 有关的动画

2. 在 **UI 文件夹** 中创建两个动画控制器 **PackageSelect** 和 **PackageMouseOver** 。分别对应 **选中动画** 和 **鼠标掠过动画**

3. 在 **PackageUIItem 预制件** 中添加两个空子物体 **SelectAni** 和 **MouseOverAni**

4. 在 **SelectAni 空子物体** 上添加两张图片 UI ，把 **选中** 图片赋给他， **设置原生大小** ，再设置 **SelectAni 空子物体** 的宽高为 **128/158** ，然后把 **选中 图片UI** 的锚点设置为 **全部伸展模式** 。
    - 第一张图片 **Image1** 的缩放大小为 **1.1/1.1/1**
    - 第二张图片 **Image2** 的缩放大小为 **1.2/1.2/1**

5. 在 **UI 动效文件夹** 中创建三个动画器 **PackageSelectAni** 和 **PackageMouseOverIn** 和 **PackageMouseOverOut**

6. 把 **PackageSelect 动画控制器** 挂载到 **SelectAni 空子物体** 上，再把 **PackageSelectAni 动画器** 挂载上去

7. 打开 **PackageSelect 动画控制器** 
    - 把默认的事件参数设置 **StateMachine 默认状态** 为新创建的 **空** 的状态
    - 添加一个 **Trigger** 类型的参数 **In**
    - 把 **Any State** 创建过渡到 **PackageSelectAni** ，并设置过渡条件为 **In** 参数，过渡持续时间设置为 **0**

8. 双击打开 **PackageSelectAni 动画器** 
    - 点击 **SelectAni 物体** ，在 **动画** 中点击 **添加属性** ，Image1 -> Image -> Color ,Image2 -> Image -> Color
    - 把 **时间轴** 调至中间，**点击录制** ，把两张图片的 **Color.a 透明度** 设置为 0 ，结束录制
    - 把开始和结尾的透明度都设为 **0** ，中间的设为 **1**
    - 把整体时间缩减到 **30s**

9. 把 **PackageMouseOver 动画控制器** 挂载到 **MouseOverAni 空子物体**上，再把 **PackageMouseOverIn 动画器** 和 **PackageMouseOverOut 动画器** 挂载上去

10. 打开 **PackageMouseOver 动画控制器**
    - 把默认的事件参数设置 **StateMachine 默认状态** 为新创建的 **空** 的状态
    - 添加两个 **Trigger** 类型的参数 **In** 和 **Out** ，分别用来切换到鼠标进入和鼠标退出两个动画
    - 把 **Any State** 创建过渡到 **PackageMouseOverIn** ，并设置过渡条件为 **In** 参数，过渡持续时间设置为 **0**
    - 把 **Any State** 创建过渡到 **PackageMouseOverOut** ,并设置过渡条件为 **Out** 参数，过渡持续时间设置为 **0**

11. 在 **MouseOverAni 空子物体** 上添加一张图片 UI ，把 **选中** 图片赋给他， **设置原生大小** ，再设置 **MouseOverAni 空子物体** 的宽高为 **128/156** ，然后把 **选中 图片UI** 的锚点设置为 **全部伸展模式** 。

12. 隐藏 **SelectAni 空子物体**

13. 点击 **MouseOverAni 空子物体** ，打开 **动画**
    - 首先是 **PackageMouseOverIn** 动画
    - **添加属性** Image -> Image -> Color
    - 把 **时间轴** 调至最开始，**点击录制** ，把图片的 **Color.a 透明度** 设置为 0 ，结束录制
    - 把整体时间缩减到 **30s**
    - 再是 **PackageMouseOverOut** 动画
    - **添加属性** Image -> Image -> Color
    - 把 **时间轴** 调至结尾，**点击录制** ，把图片的 **Color.a 透明度** 设置为 0 ，结束录制
    - 把整体时间缩减到 **30s**

14. 在 **PackageCell 脚本** 中添加动画相关两个 UI 属性，并在 **InitUIName()** 中绑定这两个属性，并初始化设置为关闭状态
    ```
    // 绑定动画相关的属性
    UIMouseOverAni = transform.Find("MouseOverAni");
    UISelectAni = transform.Find("SelectAni");

    // 初始化两个动画相关的属性为关闭状态
    UIMouseOverAni.gameObject.SetActive(false);
    UISelectAni.gameObject.SetActive(false);
    ```

15. 在 **PakcageCell 脚本** 中的鼠标点击的回调方法，对 **UISelectAni** 设置 **In** 这个 Trigger 参数来播放鼠标选择动画
    ```
    // 播放鼠标选择动效
    UISelectAni.gameObject.SetActive(true);
    UISelectAni.GetComponent<Animator>().SetTrigger("In");
    ```

16. 在 **PakcageCell 脚本** 中的鼠标进入的回调方法，对 **UIMouseOverAni** 设置 **In** 这个 Trigger 参数来播放鼠标进入动画
    ```
    // 播放鼠标进入动效
    UIMouseOverAni.gameObject.SetActive(true);
    UIMouseOverAni.GetComponent<Animator>().SetTrigger("In");
    ```

17. 在 **PakcageCell 脚本** 中的鼠标进入的回调方法，对 **UIMouseOverAni** 设置 **Out** 这个 Trigger 参数来播放鼠标退出动画
    ```
    // 播放鼠标退出动效
    UIMouseOverAni.GetComponent<Animator>().SetTrigger("Out");
    ```

18. 在左上角的搜索框中搜索 **Image** 这个组件，把除了 **PackageUIItem** 以外的所有 **Image** 全部选中，然后把它的 **光线投射目标** 选项勾选给去掉，以确保子物品不会影响我们点触事件的判断