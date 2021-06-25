using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 技能移动
/// </summary>
public class SkillMove : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		//朝着正前方移动
		transform.Translate(0, 0, 10*Time.deltaTime);
	}
	void OnTriggerEnter(Collider other)
    {
		//print(other.transform.name);
		other.GetComponent<HP>().Damage(20);
    }
}
