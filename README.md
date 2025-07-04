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

    2. 在 **Top** 下创建一个文本（旧版） **Title** , 设置文本内容 **武器** ，设置宽高 **160/70** ，设置位置 **X -88 / Y 0** ，设置字体大小 **55** ，设置字体样式 **加粗** ，设置对齐 **行间居中对齐** ，设置字体颜色为 **白色**

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