using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Data;

namespace Assets.Source.UI
{
    public class CreatePointView : MonoBehaviour
    {
        [SerializeField] private InputField _nameIF;
        [SerializeField] private InputField _typeIF;
        [SerializeField] private InputField _xPosIF;
        [SerializeField] private InputField _yPosIF;
        [SerializeField] private InputField _zPosIF;
        [SerializeField] private Button _addBtn;
        [SerializeField] private Button _closeBtn;

        public Subject<Point> NewPointCreated = new Subject<Point>();

        private void OnEnable()
        {
            Clear();
        }

        private void Start()
        {
            _addBtn.OnClickAsObservable()
                .Select(unit => new Point(_nameIF.text,
                                        float.Parse(_xPosIF.text),
                                        float.Parse(_yPosIF.text),
                                        float.Parse(_zPosIF.text),
                                        _typeIF.text == string.Empty ? -1 : int.Parse(_typeIF.text)))
                .Subscribe(point => 
                {
                    NewPointCreated.OnNext(point);
                    gameObject.SetActive(false);
                })
                .AddTo(this);

            _closeBtn.OnClickAsObservable()
                .Subscribe(next => gameObject.SetActive(false))
                .AddTo(this);
        }

        private void Clear()
        {
            _nameIF.text = string.Empty;
            _typeIF.text = string.Empty;
            _xPosIF.text = string.Empty;
            _yPosIF.text = string.Empty;
            _zPosIF.text = string.Empty;
        }
    }
}
