using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色移动： 通过鼠标左键点击地面  实现人物移动
/// 1.查找Animator组件  后续需要播放动画
/// 2.通过摄像机中提供的方法  获取一根从摄像机到屏幕鼠标位置的射线
/// 3.如果点击左键  移动至点击的目标点并播放动画
/// </summary>

public class CharacterMove : MonoBehaviour {
	/// <summary>
	/// 声明一个动画组件类型接收
	/// </summary>
	Animator ani;
	/// <summary>
	/// 射线
	/// </summary>
	Ray ray;
	/// <summary>
	/// 射线返回的信息
	/// </summary>
	RaycastHit hit;
	/// <summary>
	/// 是否移动  默认值为false
	/// </summary>
	bool isMove;
	/// <summary>
	/// 移动目标点
	/// </summary>
	Vector3 targetPos;
	void Start () {
		//查找组件并赋值
		ani = GetComponent<Animator>();
	}
	void Update () {
		//从摄像机发射一根射线到屏幕 根据鼠标的位置进行移动
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        //如果点击鼠标左键
        if (Input.GetMouseButtonDown(0))
        {
			//Raycast是判断射线是否打到物体身上的方法
			//参数1.那根射线需要发射2.射线打到物体身上返回的信息3.射线的长度
			//返回值bool类型 为ture则表示打到物体身上  可以进行后续逻辑
			//为fasle 代表射线未打到物体身上
            if (Physics.Raycast(ray,out hit,200))
            {
				//如果点击的是地板
                if (hit.transform.name == "Plane")
                {
					//将当前点击的坐标信息赋值给变量targetPos存储
					targetPos = hit.point;
					//可以移动
					isMove = true;
					//播放跑步动画
					ani.SetBool("Run", true);
                }
			}	
        }
		//如果可以移动
		if (isMove)
		{
            //Distance 判断并返回两点之间的距离 参数1.a点位置 2.b点位置
            //判断当前位置和目标位置之间的距离是否小于1 如果条件成立代表到达目标点
            if (Vector3.Distance(transform.position, targetPos) < 1)
            {
				//播放待机动画
				ani.SetBool("Run", false);
				//关闭移动
				isMove = false;
            }
			//问题：1.跑到了目标点 不能播放待机动画 
			//2.移动过程中需要转向目标点
			//Lerp 方法无限接近目标点  由快到慢
			//MoveTowards  方法可以到达目标点  匀速
			//实现旋转
			//传入目标方向返回该方向的目标角度
			Quaternion q = Quaternion.LookRotation(targetPos);
			//慢慢旋转至目标方向
			transform.rotation = Quaternion.Lerp(transform.rotation, q, 0.5f);
			//看向的另一种实现方式
			//LookAt看向目标点
			transform.LookAt(targetPos);
			//实现移动
			//MoveTowards参数1.当前位置 2.目标位置  3.移动比例  值越小移动 越慢
			transform.position = Vector3.MoveTowards(transform.position, targetPos, 1);
		}
        //练习：点击右键播放攻击动画
        //当点击右键
        if (Input.GetMouseButtonDown(1))
        {
			//播放攻击动画
			ani.SetBool("Atk", true);

        }
		//当抬起右键
        if (Input.GetMouseButtonUp(1))
        {
			//取消播放攻击动画
			ani.SetBool("Atk", false);
        }
	}
	//诞生点
	public Transform point;
	/// <summary>
	/// 攻击事件 诞生技能
	/// </summary>
	public void OnAttack(GameObject skill)
    {
		//诞生的逻辑
		//1.克隆的物体   2.克隆的位置  3.旋转
		Instantiate(skill,point.position,point.rotation);
    }
}
