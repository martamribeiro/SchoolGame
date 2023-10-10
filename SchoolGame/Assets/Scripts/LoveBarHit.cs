using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveBarHit : MonoBehaviour
{

    [SerializeField] private float _maxLove = 3;
    private float _currentLove;
    [SerializeField] private LoveBar _lovebar;

    void Start()
    {
        _lovebar.UpdateLoveBar(_maxLove, _currentLove);
    }

    void OnMouseDown()
    {
        _currentLove -= Random.Range(0.5f, 1.5f);

        if (_currentLove <= 0)
        {

        }
        else
        {
            _lovebar.UpdateLoveBar(_maxLove, _currentLove);
        }
    }
}
