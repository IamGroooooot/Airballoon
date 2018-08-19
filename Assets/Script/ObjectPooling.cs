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

	public GameObject Island1;
	public GameObject Island2;
	public GameObject Island3;
	public GameObject Island4;
	public GameObject Island5;
	public GameObject Island6;
	//public GameObject Island7;
	//public GameObject Island8;

	//Pooled Obj 폴더
	public GameObject Skel_Parent;
	public GameObject Player_Bullet;
	public GameObject Hit_Folder;
	public GameObject SmallBullet_Folder;
	public GameObject EnemyBullet_Folder;

	public GameObject Island1_Folder;
	public GameObject Island2_Folder;
	public GameObject Island3_Folder;
	public GameObject Island4_Folder;
	public GameObject Island5_Folder;
	public GameObject Island6_Folder;
	//public GameObject Island7_Folder;
	//public GameObject Island8_Folder;

	// 몇개를 복제할 것인가?
	public int PoolAmount_SkelBomb;
	public int PoolAmount_Bullet;
	public int PoolAmount_Hit;
	public int PoolAmount_SmallBullet;
	public int PoolAmount_EnemyBullet;

	public int PoolAmount_Island1;
	public int PoolAmount_Island2;
	public int PoolAmount_Island3;
	public int PoolAmount_Island4;
	public int PoolAmount_Island5;
	public int PoolAmount_Island6;
	//public int PoolAmount_Island7;
	//public int PoolAmount_Island8;


	//Pooled Obj 리스트
	public List<GameObject> PoolObjs_SkelBomb;
	public List<GameObject> PoolObjs_Bullet;
	public List<GameObject> PoolObjs_Hit;
	public List<GameObject> PoolObjs_SmallBullet;
	public List<GameObject> PoolObjs_EnemyBullet;

	public List<GameObject> PoolObjs_Island1;
	public List<GameObject> PoolObjs_Island2;
	public List<GameObject> PoolObjs_Island3;
	public List<GameObject> PoolObjs_Island4;
	public List<GameObject> PoolObjs_Island5;
	public List<GameObject> PoolObjs_Island6;
	//public List<GameObject> PoolObjs_Island7;
	//public List<GameObject> PoolObjs_Island8;


	void Awake(){
		pool = this;
	}

	void Start () {
		
		PoolObjs_SkelBomb = new List<GameObject> ();
		PoolObjs_Bullet = new List<GameObject> ();
		PoolObjs_Hit = new List<GameObject> ();
		PoolObjs_SmallBullet = new List<GameObject> ();
		PoolObjs_EnemyBullet = new List<GameObject> ();
		PoolObjs_Island1= new List<GameObject> ();
		PoolObjs_Island2= new List<GameObject> ();
		PoolObjs_Island3= new List<GameObject> ();
		PoolObjs_Island4= new List<GameObject> ();
		PoolObjs_Island5= new List<GameObject> ();
		PoolObjs_Island6= new List<GameObject> ();
		//PoolObjs_Island7= new List<GameObject> ();
		//PoolObjs_Island8= new List<GameObject> ();

		//Islands
		for (int i = 0; i < PoolAmount_Island1; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island1);

			Island.transform.parent = Island1_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island1.Add (Island);
		}

		for (int i = 0; i < PoolAmount_Island2; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island2);

			Island.transform.parent = Island2_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island2.Add (Island);
		}

		for (int i = 0; i < PoolAmount_Island3; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island3);

			Island.transform.parent = Island3_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island3.Add (Island);
		}

		for (int i = 0; i < PoolAmount_Island4; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island4);

			Island.transform.parent = Island4_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island4.Add (Island);
		}

		for (int i = 0; i < PoolAmount_Island5; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island5);

			Island.transform.parent = Island5_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island5.Add (Island);
		}

		for (int i = 0; i < PoolAmount_Island6; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island6);

			Island.transform.parent = Island6_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island6.Add (Island);
		}

		/*for (int i = 0; i < PoolAmount_Island7; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island7);

			Island.transform.parent = Island7_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island7.Add (Island);
		}

		for (int i = 0; i < PoolAmount_Island8; i++) {
			// 생성후 차곡차곡 넣기
			GameObject Island = (GameObject)Instantiate (Island8);

			Island.transform.parent = Island8_Folder.transform;


			Island.SetActive (false);
			PoolObjs_Island8.Add (Island);
		}*/
			
		//Extra

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
			PoolObjs_EnemyBullet.Add (Obj_EnemyBullet);
		}
	}

	//Island

	public GameObject GetPoolObject_Island1(){

		if (PoolObjs_Island1.Count == 0) {
			GameObject Obj_Island = Instantiate (Island1);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island1.Count; i++) {


			if (!PoolObjs_Island1[i].activeInHierarchy) {
				return PoolObjs_Island1 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Island2(){

		if (PoolObjs_Island2.Count == 0) {
			GameObject Obj_Island = Instantiate (Island2);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island2.Count; i++) {


			if (!PoolObjs_Island2[i].activeInHierarchy) {
				return PoolObjs_Island2 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Island3(){

		if (PoolObjs_Island3.Count == 0) {
			GameObject Obj_Island = Instantiate (Island3);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island3.Count; i++) {


			if (!PoolObjs_Island3[i].activeInHierarchy) {
				return PoolObjs_Island3 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Island4(){

		if (PoolObjs_Island4.Count == 0) {
			GameObject Obj_Island = Instantiate (Island4);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island4.Count; i++) {


			if (!PoolObjs_Island4[i].activeInHierarchy) {
				return PoolObjs_Island4 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Island5(){

		if (PoolObjs_Island5.Count == 0) {
			GameObject Obj_Island = Instantiate (Island5);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island5.Count; i++) {


			if (!PoolObjs_Island5[i].activeInHierarchy) {
				return PoolObjs_Island5 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Island6(){

		if (PoolObjs_Island6.Count == 0) {
			GameObject Obj_Island = Instantiate (Island6);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island6.Count; i++) {


			if (!PoolObjs_Island6[i].activeInHierarchy) {
				return PoolObjs_Island6 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}

	/*public GameObject GetPoolObject_Island7(){

		if (PoolObjs_Island7.Count == 0) {
			GameObject Obj_Island = Instantiate (Island7);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island7.Count; i++) {


			if (!PoolObjs_Island7[i].activeInHierarchy) {
				return PoolObjs_Island7 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}

	public GameObject GetPoolObject_Island8(){

		if (PoolObjs_Island8.Count == 0) {
			GameObject Obj_Island = Instantiate (Island8);
			return Obj_Island;

			//PoolObjs_SkelBomb.Add(SkelBomb);
		}

		// obj.SetActive false이면 실행할것이다.
		for (int i = 0; i < PoolObjs_Island8.Count; i++) {


			if (!PoolObjs_Island8[i].activeInHierarchy) {
				return PoolObjs_Island8 [i];// SetActive(true)된 섬
			}

		}
		return null;
	}*/



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
