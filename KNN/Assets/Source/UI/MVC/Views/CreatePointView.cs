using Assets.Source.UI.WindowHandler;
using Data;
using System;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.UI
{
    public class CreatePointView : AbstractView, ICreatePointView
    {
        [SerializeField] private InputField _nameIF;
        [SerializeField] private InputField _typeIF;
        [SerializeField] private InputField _xPosIF;
        [SerializeField] private InputField _yPosIF;
        [SerializeField] private InputField _zPosIF;
        [SerializeField] private Button _addBtn;
        [SerializeField] private Button _closeBtn;

        public event Action<Point> AddNewPoint;
        private int counter = 0;

        public CreatePointView(IWindowHandler windowHandler)
        {
        }

        private void OnEnable()
        {
            Clear();
        }

        private void Start()
        {
            _addBtn.onClick.AddListener(() => {
                string name = _nameIF.text;
                if (name == string.Empty && _typeIF.text != string.Empty) name = $"c{_typeIF.text}";
                if (name == string.Empty) name = $"p{counter}";
                AddNewPoint?.Invoke(new Point(name,
                                           _xPosIF.text == string.Empty ? 0 : float.Parse(_xPosIF.text),
                                            _yPosIF.text == string.Empty ? 0 : float.Parse(_yPosIF.text),
                                            _zPosIF.text == string.Empty ? 0 : float.Parse(_zPosIF.text),
                                            _typeIF.text == string.Empty ? -1 : int.Parse(_typeIF.text)));
                                        });
            _addBtn.onClick.AddListener(Hide);
            _addBtn.onClick.AddListener(() => counter++);

            _closeBtn.OnClickAsObservable()
                .Subscribe(next => Hide())
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