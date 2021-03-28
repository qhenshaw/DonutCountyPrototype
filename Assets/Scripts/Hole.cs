using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hole : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _scaleSpeed = 5f;
    [SerializeField] private float _maxRange = 30f;

    private Vector3 _position;
    private float _totalScore;
    private Vector3 _targetScale;

    public UnityEvent<float> ScoreUpdated;

    private void Start()
    {
        _targetScale = transform.localScale;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if(groundPlane.Raycast(ray, out float distance))
        {
            _position = ray.GetPoint(distance);
        }

        _position = Vector3.ClampMagnitude(_position, _maxRange);
        float dist = Vector3.Distance(transform.position, _position);
        transform.position = Vector3.MoveTowards(transform.position, _position, _moveSpeed * Time.deltaTime * dist);

        transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, Time.deltaTime * _scaleSpeed);
    }

    public void ObjectConsumed(GameObject consumed)
    {
        if(consumed.TryGetComponent(out GrowthScore growthScore))
        {
            _totalScore += growthScore.Score;
            _targetScale += Vector3.one * growthScore.Score;

            ScoreUpdated.Invoke(_totalScore);

            Destroy(consumed);
        }
    }
}
