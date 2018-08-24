using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class BtnLongPressed : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public static bool LongPressed = false;
    public float requiredHoldTime = 2f;
    private StoreToolTip Tooltip;
    [SerializeField]
    private UnityEvent onLongClick;

    void Start()
    {
        Tooltip = GameObject.Find("Store").GetComponent<StoreToolTip>();
        LongPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        //Debug.Log("OnPointerDown");


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        
        Debug.Log("OnPointerUp");

        Tooltip.Deactivate();

    }

    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if(onLongClick != null)
                {
                    onLongClick.Invoke();
                    LongPressed = true;
                    //Debug.Log("까꿍");
                }

                Reset();
            }
        }
    }
    private void Reset()
    {
        if(pointerDownTimer < requiredHoldTime)    StartCoroutine(NoLongerPressed());
        pointerDown = false;
        pointerDownTimer = 0;
        
    }
    IEnumerator NoLongerPressed()
    {
        yield return new WaitForEndOfFrame();
        LongPressed = false;
    }
}
