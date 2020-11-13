using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public Transform[] positions;
    public float r;
    private Vector2 gizmosPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDrawGizmos()
    {
        for (float t = 0; t <= 1.0; t += 0.05f)
        {
            gizmosPos = positions[0].position * Mathf.Pow(1 - t, 3) +
                3 * positions[1].position * Mathf.Pow(1 - t, 2) * t +
                3 * positions[2].position * (1 - t) * Mathf.Pow(t, 2) +
                positions[3].position * Mathf.Pow(t, 3);
            Gizmos.DrawSphere(gizmosPos, r);
        }

        Gizmos.DrawLine(new Vector2(positions[0].position.x, positions[0].position.y),
            new Vector2(positions[1].position.x, positions[1].position.y));

        Gizmos.DrawLine(new Vector2(positions[2].position.x, positions[2].position.y),
            new Vector2(positions[3].position.x, positions[3].position.y));
    }
}
