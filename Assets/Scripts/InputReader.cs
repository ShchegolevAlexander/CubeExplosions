using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public Action<Vector3> OnMouseClick;

    private const int LeftMouseButton = 0;

    private void Update()
    {
        if (Input.GetMouseButton(LeftMouseButton))
        {
            OnMouseClick?.Invoke(Input.mousePosition);
        }
    }
}