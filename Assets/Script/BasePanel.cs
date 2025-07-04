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
