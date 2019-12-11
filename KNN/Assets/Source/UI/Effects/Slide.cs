using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace Assets.Source.UI.Effects
{
    public class Slide : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private Vector3 _endPosition;
        [SerializeField] private Toggle _toggle;

        private Coroutine _slideCoroutine;
        private RectTransform _rt;

        void Start()
        {
            _rt = GetComponent<RectTransform>();
            _toggle.ObserveEveryValueChanged(toggle => toggle.isOn)
                .Subscribe(isOn =>
                {
                    if (_slideCoroutine != null)
                        StopCoroutine(_slideCoroutine);
                    _slideCoroutine = StartCoroutine(SlideTo(isOn ? _endPosition: _startPosition));
                }).AddTo(this);
        }

        IEnumerator SlideTo(Vector3 endPosition)
        {
            while (Vector3.Distance(_rt.anchoredPosition3D, endPosition) > float.Epsilon)
            {
                _rt.anchoredPosition3D = Vector3.Lerp(_rt.anchoredPosition3D, endPosition, _speed * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }

        }
    }
}
