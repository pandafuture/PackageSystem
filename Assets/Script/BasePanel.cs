using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���н���ĸ��࣬�̳� MonoBehaviour ����Ҫ�ҽ����������ϣ���װһЩͨ�õķ���
public class BasePanel : MonoBehaviour
{
    protected bool isRemove = false;  // ��ʶ��ǰ�����Ƿ��ѹرյı�־λ
    protected new string name;  // ���������

    protected virtual void Awake()
    {

    }

    public virtual void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    // �򿪽���ķ���
    public virtual void OpenPanel(string name)
    {
        this.name = name;  // ����ǰ��������ƽ��и�ֵ
        gameObject.SetActive(true);  // ��ʾ����
    }


    // �رս���ķ���
    public virtual void ClosePanel()
    {
        isRemove = true;  // ��ǵ�ǰ�����ѹر�
        SetActive(false);  // �رս���
        Destroy(gameObject);  // ��������

        // ��鵱ǰ��������Ƿ���ڣ�������ڵĻ������Ƴ����棬��ʾ����û��
        if (UIManager.Instance.panelDict.ContainsKey(name))
        {
            UIManager.Instance.panelDict.Remove(name);
        }
    }
}
