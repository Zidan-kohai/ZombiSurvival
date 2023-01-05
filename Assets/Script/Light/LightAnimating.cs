using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LightAnimating : MonoBehaviour
{
    [SerializeField] private AnimationCurve _lightIntensity;
    private float _currentTime, _totalTime;
    private Light _light;
    void Start()
    {
        _light = GetComponent<Light>();
        _totalTime = _lightIntensity.keys[_lightIntensity.length - 1].time;
    }

    // Update is called once per frame
    void Update()
    {
        _light.intensity = _lightIntensity.Evaluate(_currentTime);
        _currentTime += Time.deltaTime;
        if (_currentTime > _totalTime) _currentTime = 0;
    }
}
