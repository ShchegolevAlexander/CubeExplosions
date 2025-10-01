using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _halver = 2f;

    public Rigidbody[] Spawn(Vector3 position, Vector3 scale, int minCount, int maxCount, ColorChanger colorChanger, float mass)
    {
        int count = Random.Range(minCount, maxCount + 1);
        Vector3 newScale = scale / _halver;
        Rigidbody[] rigidbodyes = new Rigidbody[count];

        for (int i = 0; i < count; i++)
        {
            Vector3 offset = new Vector3
                (
                Random.Range(-newScale.x / _halver, newScale.x / _halver),
                Random.Range(-newScale.y / _halver, newScale.y / _halver),
                Random.Range(-newScale.z / _halver, newScale.z / _halver)
                );

            Cube newCube = Instantiate(_cubePrefab, position + offset, Quaternion.identity);
            newCube.transform.localScale = newScale;

            Cube cube = newCube.GetComponent<Cube>();

            if (cube != null)
            {
                cube.SetColorChanger(colorChanger);

                float newMass = mass / _halver;
                cube.SetMass(newMass);

                if (cube.ColorChanger != null)
                {
                    cube.ChangeColor();
                }
            }

            rigidbodyes[i] = cube.GetComponent<Rigidbody>();
        }

        return rigidbodyes;
    }
}