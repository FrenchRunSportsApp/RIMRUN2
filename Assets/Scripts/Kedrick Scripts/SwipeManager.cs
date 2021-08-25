using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwipeManager : MonoBehaviour
{
    private static SwipeManager instance;
    public static SwipeManager Instance
    { get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SwipeManager>();
                if (instance == null)
                {
                    instance = new GameObject("Spawned swipeInput", typeof(SwipeManager)).GetComponent<SwipeManager>();
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    [Header("Tweaks")]
    [SerializeField] private float deadzone = 100.0f;
    [SerializeField] private float doubleTapDelta = 0.5f;

    [Header("Logic")]
    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, doubleTap;
    private float lastTap;
    private bool isDraging = true;
    private Vector2 startTouch, swipeDelta;
    private float sqrDeadzone;


    public bool Tap { get { return tap; } }
    public bool DoubleTap { get { return doubleTap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return SwipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }



    private void Start()
    {
        sqrDeadzone = deadzone * deadzone;
    }

    private void Update()
    {
        tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;

#if UNITY_EDITOR
        UpdateStandalone();
#else
    UpdateMobile();
#endif
    }

    private void UpdateStandalone()
    {

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            doubleTap = Time.time - lastTap < doubleTapDelta;
            lastTap = Time.time;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }

        //Calculate the distance
        swipeDelta = Vector2.zero;
        {
            if (startTouch != Vector2.zero && Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
        }
        #endregion

        //Did we cross the distance?
        if (swipeDelta.sqrMagnitude > sqrDeadzone)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }


    private void UpdateMobile()
    {

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                doubleTap = Time.time - lastTap < doubleTapDelta;
                lastTap = Time.time;
                startTouch = Input.mousePosition;

            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }
        #endregion

        //Calculate the distance
        swipeDelta = Vector2.zero;

        {
            if (startTouch != Vector2.zero && Input.touches.Length != 0)
                swipeDelta = Input.touches[0].position - startTouch;
        }

        //Did we cross the distance?
        if (swipeDelta.sqrMagnitude > sqrDeadzone)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else
            {
                //Up or Down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }

            startTouch = swipeDelta = Vector2.zero;
        }

    } }
