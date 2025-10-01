using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private EventHandler _eventHandler;

    public void CastRay(Vector3 mousePosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            Cube cube;

            if (hitObject.TryGetComponent<Cube>(out cube))
            {
                _eventHandler.Hit(cube);
            }
        }
    }
}