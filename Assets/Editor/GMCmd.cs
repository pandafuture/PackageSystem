using System;  // 添加 System 名称空间
using System.Collections;
using System.Collections.Generic;
using UnityEditor;  // 添加 UnityEditor 名称空间
using UnityEngine;

public class GMCmd : MonoBehaviour
{
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
}
