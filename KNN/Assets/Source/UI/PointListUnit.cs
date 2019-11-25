using Data;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UIElements
{
    public class PointListUnit : MonoBehaviour
    {
        [SerializeField] private Toggle _expandBtn;
        [SerializeField] private float _expandOffset;
        [SerializeField] private RectTransform _moreInfo;

        [Header("Point info holders")]
        [SerializeField] private Text _name;
        [SerializeField] private Text _type;
        [SerializeField] private Text _posX;
        [SerializeField] private Text _posY;
        [SerializeField] private Text _posZ;

        private RectTransform _rt;
        private Vector2 _defaultSizeDelta;
        private Vector2 _expandSizeDelta;

        public void Init(Point point)
        {
            _name.text = point.Name;
            _posX.text = point.Position.x.ToString();
            _posY.text = point.Position.y.ToString();
            _posZ.text = point.Position.z.ToString();
            _type.text = point.Type != -1 ? point.Type.ToString() : string.Empty;
        }

        private void Start()
        {
            _rt = GetComponent<RectTransform>();
            _moreInfo.sizeDelta = new Vector2(_moreInfo.sizeDelta.x, _expandOffset);
            _defaultSizeDelta = _rt.sizeDelta;
            _expandSizeDelta = new Vector2(_defaultSizeDelta.x, _defaultSizeDelta.y + _expandOffset);

            _expandBtn.ObserveEveryValueChanged(toggle => toggle.isOn)
                .Subscribe(isOn =>
                {
                    _rt.sizeDelta = isOn ? _expandSizeDelta : _defaultSizeDelta;
                    _moreInfo.gameObject.SetActive(isOn);
                }).AddTo(this);
        }

        
    }
}