using System;
using System.Collections;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    [SerializeField] private int _minNewCubes = 2;
    [SerializeField] private int _maxNewCubes = 6;

    private float _splitChance = 1f;
    private int _halver = 2;

    private void OnEnable()
    {
        _raycaster.OnCubeHit += HandleHit;
    }

    private void OnDisable()
    {
        _raycaster.OnCubeHit -= HandleHit;
    }

    private void HandleHit(Cube cube)
    {
        StartCoroutine(HitCoroutine(cube));
    }

    private IEnumerator HitCoroutine(Cube cube)
    {
        float random = UnityEngine.Random.value;
        float delay = 0.2f;

        if (random <= _splitChance)
        {
            _splitChance /= _halver;

            Rigidbody cubeRigidbody = cube.Rigidbody;

            if (_spawner != null && cube.ColorChanger != null)
            {
                Rigidbody[] newRigidbodies = _spawner.Spawn(cube.transform.position, cube.transform.localScale, _minNewCubes, _maxNewCubes, cube.ColorChanger, cubeRigidbody.mass);

                yield return new WaitForSeconds(delay);

                if (_exploder != null)
                {
                    _exploder.Explode(newRigidbodies);
                }
            }
        }

        if (cube != null)
        {
            Destroy(cube.gameObject);
        }
    }
}