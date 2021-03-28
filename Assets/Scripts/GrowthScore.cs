using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthScore : MonoBehaviour
{
    [SerializeField] private float _score = 0.1f;
    public float Score => _score;

    [ContextMenu("Auto Score")]
    public void AutoScore()
    {
        if(TryGetComponent(out Renderer renderer))
        {
            Vector3 size = renderer.bounds.size;
            _score = size.x * size.y * size.z;
        }
    }
}
