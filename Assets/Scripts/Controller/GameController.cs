using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] private TableModel tableModel;
    public static Action OnCircleTouched;
    private GameObject player;
    private BoxCollider2D boxCollider;
    private bool isEnabled;
    

    private void OnEnable()
    {
        OnCircleTouched += CheckCircles;
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boxCollider = player.GetComponent<BoxCollider2D>();
        StartCoroutine(PlayerMovement());
    }
    private IEnumerator PlayerMovement()
    {
        isEnabled = true;
        while (isEnabled)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButton(0) && boxCollider == Physics2D.OverlapPoint(mousePos))
            {
                mousePos.z = player.transform.position.z;
                player.transform.position = mousePos;
            }
            yield return null;
        }
    }
    
    private void CheckCircles()
    {
        if (!tableModel.HasActiveCircle())
        {
            isEnabled = false;
            GUIController.ButtonCallback?.Invoke(true);
        }
    }

    private void OnDisable()
    {
        OnCircleTouched -= CheckCircles;
    }
}
