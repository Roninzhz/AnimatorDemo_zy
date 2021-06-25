using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 关羽的血量状态脚本
/// </summary>
public class HP : MonoBehaviour {
	//代表关羽的血量
	public int hp = 100;
	/// <summary>
	/// 可以让外部去访问调用的方法
	/// </summary>
	public void Damage(int v)
    {
		//如果血量大于外部传过来的扣减值
		if (hp >= v)
		{
			//进行扣减
			hp -= v;
            if (hp <= 0)
            {
			    //Destory销毁的方法 1.代表销毁的对象 2.代表延时时间（不写则立即销毁）
				Destroy(gameObject, 1);
            }
		}
    }
}
