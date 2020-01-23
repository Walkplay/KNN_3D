using Assets.Source.UI.WindowHandler;
using Data;
using System;
using System.Collections.Generic;
using UIElements;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Source.UI
{
    public class TopBarView : AbstractView, ITopBarView
    {
        [SerializeField] private Button Play;

        public event Action Run;

        private void Start()
        {
            Play.onClick.AddListener(() => Run?.Invoke());
        }

        public void Close()
        {
            Destroy(transform);
        }
    }
}