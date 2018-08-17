using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour {

	public static ObjectPooling pool;

	//복제할 오브젝트
	public GameObject SkelBomb;
	public GameObject Bullet;
	public GameObject Hit;
	public GameObject SmallBullet;
	public GameObject EnemyBullet;

	//Pooled Obj 폴더
	public GameObject Skel_Parent;
	public GameObject Player_Bullet;
	public GameObject Hit_Folder;
	public GameObject SmallBullet_Folder;
	public GameObject EnemyBullet_Folder;

	// 몇개를 복제할 것인가?
	public int PoolAmount_SkelBomb;
	public int PoolAmount_Bullet;
	public int PoolAmount_Hit;
	public int PoolAmount_SmallBullet;
	public int PoolAmount_EnemyBullet;

	//Pooled Obj 리스트
	public List<GameObject> PoolObjs_SkelBomb;
	public List<GameObject> PoolObjs_Bullet;
	public List<GameObject> PoolObjs_Hit;
	public List<GameObject> PoolObjs_SmallBullet;
	public List<GameObject> PoolObjs_EnemyBullet;

	void Awake(){
		pool = this;
	}

	void Start () {
		
		PoolObjs_SkelBomb = new List<GameObject> ();
		PoolObjs_Bullet = new List<GameObject> ();
		PoolObjs_Hit = new List<GameObject> ();
		PoolObjs_SmallBullet = new List<GameObject> ();
		PoolObjs_EnemyBullet = new List<GameObject> ();

		for (int i = 0; i < PoolAmount_SkelBomb; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Obj_SkelBomb = (GameObject)Instantiate (SkelBomb);

			Obj_SkelBomb.transform.parent = Skel_Parent.transform;


			Obj_SkelBomb.SetActive (false);
			PoolObjs_SkelBomb.Add (Obj_SkelBomb);
		}

		for (int i = 0; i < PoolAmount_Bullet; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Obj_Bullet = (GameObject)Instantiate (Bullet);

			Obj_Bullet.transform.parent = Player_Bullet.transform;

			Obj_Bullet.SetActive (false);
			PoolObjs_Bullet.Add (Obj_Bullet);
		}

		for (int i = 0; i < PoolAmount_Hit; i++) {
			// 생성후 Pool에 차곡차곡 넣기
			GameObject Obj_Hit = (GameObject)Instantiate (Hit);

			Obj_Hit.transform.parent = Hit_Folder.transform;

			Obj_Hit.SetActive (false);
			PoolObjs_Hit.Add (Obj_Hit);
		}

		for (int i = 0; i < PoolAmount_SmallBullet; i++) {
			// 생성후 Pool에 차곡차곡 넣기
			GameObject Obj_SmallBullet = (GameObject)Instantiate (SmallBullet);

			Obj_SmallBullet.transform.parent = SmallBullet_Folder.transform;

			Obj_SmallBullet.SetActive (false);
			PoolObjs_SmallBullet.Add (Obj_SmallBullet);
		}

		for (int i = 0; i < PoolAmount_EnemyBullet; i++) {
			// 생성후 Pool에 차곡차곡 넣기
			GameObject Obj_EnemyBullet = (GameObject)Instantiate (EnemyBullet);

			Obj_EnemyBullet.transform.parent = EnemyBullet_Folder.transform;

			Obj_EnemyBullet.SetActive (false);
			PoolObjs_SmallBullet.Add (Obj_EnemyBullet);
		}
	}

	public GameObject GetPoolObject_SkelBomb(){
		
		if (PoolObjs_SkelBomb.Count == 0) {
			GameObject Obj_SkelBomb = Instantiate (SkelBomb);
			return Obj_SkelBomb;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_SkelBomb.Count; i++) {

		
			if (!PoolObjs_SkelBomb[i].activeInHierarchy) {
				return PoolObjs_SkelBomb [i];// SetActive(true)된 폭탄 호출
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Bullet(){

		if (PoolObjs_Bullet.Count == 0) {
			GameObject Obj_Bullet = Instantiate (Bullet);
			return Obj_Bullet;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Bullet.Count; i++) {


			if (!PoolObjs_Bullet[i].activeInHierarchy) {
				return PoolObjs_Bullet [i];// SetActive(true)된 폭탄 호출
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Hit(){

		if (PoolObjs_Hit.Count == 0) {
			GameObject Obj_Hit = Instantiate (Hit);
			return Obj_Hit;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Hit.Count; i++) {


			if (!PoolObjs_Hit[i].activeInHierarchy) {
				return PoolObjs_Hit [i];// SetActive(true)된 Pooled Obj 호출
			}

		}
		return null;
	}

	public GameObject GetPoolObject_SmallBullet(){

		if (PoolObjs_SmallBullet.Count == 0) {
			GameObject Obj_SmallBullet = Instantiate (SmallBullet);
			return Obj_SmallBullet;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_SmallBullet.Count; i++) {


			if (!PoolObjs_SmallBullet[i].activeInHierarchy) {
				return PoolObjs_SmallBullet [i];// SetActive(true)된 Pooled Obj 호출
			}

		}
		return null;
	}

	public GameObject GetPoolObject_EnemyBullet(){

		if (PoolObjs_EnemyBullet.Count == 0) {
			GameObject Obj_EnemyBullet = Instantiate (EnemyBullet);
			return Obj_EnemyBullet;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_EnemyBullet.Count; i++) {


			if (!PoolObjs_EnemyBullet[i].activeInHierarchy) {
				return PoolObjs_EnemyBullet [i];// SetActive(true)된 Pooled Obj 호출
			}

		}
		return null;
	}
}
