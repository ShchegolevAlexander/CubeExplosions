using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _minForce = 0.5f;
    [SerializeField] private float _maxForce = 1f;

    public void Explode(Rigidbody[] rigidbodies)
    {
        float upForce = 0.5f;

        if (rigidbodies == null && rigidbodies.Length == 0)
            return;

        foreach (Rigidbody rigidbody in rigidbodies)
        {
            if (rigidbody == null)
                continue;

            Vector3 direction = (rigidbody.transform.position - transform.position).normalized;
            float forceMag = Random.Range(_minForce, _maxForce);
            rigidbody.AddForce(direction * forceMag + Vector3.up * upForce, ForceMode.Impulse);
        }
    }
}