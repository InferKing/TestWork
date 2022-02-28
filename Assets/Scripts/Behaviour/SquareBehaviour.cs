using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Circle")
        {
            collision.gameObject.SetActive(false);
            GUIController.TextCallback?.Invoke(1);
            GameController.OnCircleTouched?.Invoke();
        }
    }
}
