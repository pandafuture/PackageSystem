using System;  // 添加 System 名称空间
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// CreateAssetMenu特性：点击右键时，可以在 Unity 中创建一个配置文件。传入两个参数，一个是菜单的名称，另一个是创建后文件的名称
[CreateAssetMenu(menuName = "Pandafuture/PackageData", fileName = "PackageTable")]
public class PackageTable : ScriptableObject  // 修改 PackageTable 的父类为 ScriptableObject ，这个配置文件中的每一项，都是背包中的一个物体
{
    //使用一个 List 容纳所有物品
    public List<PackageTableItem> DataList = new List<PackageTableItem>();
}


// 添加 Serializable Unity特性，以便可以在 Unity 中编辑，需要添加 System 名称空间
[System.Serializable]
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