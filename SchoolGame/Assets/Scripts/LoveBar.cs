using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveBar : MonoBehaviour
{

    [SerializeField] private Image _lovebarSprite;

    private Camera _cam;

    void Start()
    {
        _cam = Camera.main;
    }

    public void UpdateLoveBar(float maxLove, float currentLove)
    {
        _lovebarSprite.fillAmount = currentLove / maxLove;
    }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
    }

}
