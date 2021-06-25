using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 混合树测试
/// </summary>
public class BlendTest : MonoBehaviour {
	//声明组件
	Animator ani;
	void Start () {
		//查找并接收
		ani = GetComponent<Animator>();
	}

	void Update () {
		//根据水平和垂直轴值的数据进行播放相应的动画
		ani.SetFloat("AD", Input.GetAxis("Horizontal"));
		ani.SetFloat("WS", Input.GetAxis("Vertical"));
	}
}
