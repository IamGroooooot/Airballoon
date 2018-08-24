using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour {

    //public GameObject Player;

	private GameObject Player;
    private Vector3 offset;

	public GameObject MainCam;

    public float shakes = 0f;

    public float shakeAmount = 0.7f;

    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    bool CameraShaking;

    // Use this for initialization
    void Start () {
		Player = PlayerManager.instance.player;

        originalPos = gameObject.transform.position;

        CameraShaking = false;

        offset = transform.position - Player.transform.position;

    }

    private void Update()
    {
        if (HP_Bar.IsDamaged)
        {
            Camera.main.GetComponent<CamCtrl>().ShakeCamera(1.0f);
        }
    }

    private void FixedUpdate()
    {
        if (CameraShaking)
        {

            if (shakes > 0)

            {
                gameObject.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
                gameObject.transform.position += new Vector3(0f, 0f, -50f);
                shakes -= Time.deltaTime * decreaseFactor;

            }

            else

            {
                shakes = 0f;
                gameObject.transform.localPosition = originalPos;
                CameraShaking = false;
            }
        }
}
    // Update is called once per frame
    void LateUpdate () {

        transform.position = Player.transform.position + offset;

    }

    public void ShakeCamera(float shaking)

    {
        shakes = shaking;
        originalPos = gameObject.transform.position;
        CameraShaking = true;

    }
}
