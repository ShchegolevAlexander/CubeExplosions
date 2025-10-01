using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _raycaster.CastRay(Input.mousePosition);
        }
    }
}
