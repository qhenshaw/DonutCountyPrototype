using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 5f;

    private Vector3 _position;
    private float _totalScore;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if(groundPlane.Raycast(ray, out float distance))
        {
            _position = ray.GetPoint(distance);
        }

        float dist = Vector3.Distance(transform.position, _position);
        transform.position = Vector3.MoveTowards(transform.position, _position, _lerpSpeed * Time.deltaTime * dist);
    }

    public void ObjectConsumed(GameObject consumed)
    {
        if(consumed.TryGetComponent(out GrowthScore growthScore))
        {
            _totalScore += growthScore.Score;
            transform.localScale += Vector3.one * growthScore.Score;
        }
        
        Destroy(consumed);
    }
}
