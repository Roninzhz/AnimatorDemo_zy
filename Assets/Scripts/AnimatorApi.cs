using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 新版动画API使用
/// </summary>
public class AnimatorApi : MonoBehaviour
{
	/// <summary>
	/// 新版动画组件
	/// </summary>
	Animator ani;
	void Start()
	{
		//查找并赋值给ani
		ani = GetComponent<Animator>();
	}
	void Update()
	{
		//当按下键盘的W键播放跑步动画
		if (Input.GetKey(KeyCode.W))
		{
			//播放跑步动画
			//SetFloat   第一个参数要的是  动画参数条件的名字
			//           第二个参数要的是  对应参数的数值
			ani.SetFloat("Run", 1);
		}
		//抬起则切换为上一个动画(待机) 
		if (Input.GetKeyUp(KeyCode.W))
		{
			ani.SetFloat("Run", -1);
		}
        //当点击鼠标左键  播放攻击动画
        /*if (Input.GetMouseButtonDown(0))
		{
			//播放攻击动画
			ani.SetTrigger("Atk");
		}*/
		//当点击鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
			//播放攻击动画
			ani.SetBool("Atk1", true);
        }
		//当抬起鼠标左键
		if (Input.GetMouseButtonUp(0))
        {
			//停止播放攻击动画  切换为返回指向的动画
			ani.SetBool("Atk1", false);
        }
	}
	public void Atk()
    {
		print("看招！");
    }
}
