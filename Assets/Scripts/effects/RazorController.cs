using UnityEngine;
using System.Collections;

public class RazorController : MonoBehaviour {
	public GameObject Line;
	public GameObject FXef;//激光击中物体的粒子效果

	public int damage = 10;//10 per sec
	// Use this for initialization
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit;
		Vector3 Sc;// 变换大小
		Sc.x=0.5f;
		Sc.z=0.5f;
		//发射射线，通过获取射线碰撞后返回的距离来变换激光模型的y轴上的值
		if (hit = Physics2D.Raycast(transform.position, this.transform.forward,500.0f,(1 << LayerMask.NameToLayer("Platforms")|1 << LayerMask.NameToLayer("Player")))){//|1 << LayerMask.NameToLayer("Player")
			//hit = Physics2D.Raycast (transform.position, this.transform.forward, 1 << LayerMask.NameToLayer ("Platforms") | 1 << LayerMask.NameToLayer ("Player"));
			Sc.y=hit.distance;
			FXef.transform.position=hit.point;//让激光击中物体的粒子效果的空间位置与射线碰撞的点的空间位置保持一致；
			FXef.SetActive(true);
			if (hit.collider.gameObject.tag == "Player") {
				hit.collider.gameObject.GetComponent<PlayerController> ().takeDamage (20,Vector3.zero);
			}
		}
		//当激光没有碰撞到物体时，让射线的长度保持为500m，并设置击中效果为不显示
		else{
			Sc.y=500;
			FXef.SetActive(false);
		}

		Line.transform.localScale=Sc;

	}
}
