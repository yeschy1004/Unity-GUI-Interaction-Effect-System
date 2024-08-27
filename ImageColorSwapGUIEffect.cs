using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace GUI.Effect
{
    /// <summary>
    /// 2D GUI Image 색이 동작에 따라 변화함.
    /// </summary>
    public class ImageColorSwapGUIEffect : IGUIEffect
    {
        private Button _targetBtn;
        private Image _img;
        private Color32 _defaultColor;
        private Color32 _hoverColor;
        private Color32 _pressColor;
        private Color32 _disableColor;
        private float _animDelaySec;

        public ImageColorSwapGUIEffect(Button targetBtn, Image img, Color32 defaultColor, Color32 hoverColor, Color32 pressColor, Color32 disableColor, float animDelaySec)
        {
            _targetBtn = targetBtn;
            _img = img;
            _defaultColor = defaultColor;
            _hoverColor = hoverColor;
            _pressColor = pressColor;
            _disableColor = disableColor;
            _animDelaySec = animDelaySec;
        }

        public void OnPointerEnter()
        {
            if (_targetBtn != null)
            {
                if (!_targetBtn.interactable)
                {
                    return;
                }
            }

            if (_img != null)
            {
                _img.DOColor(_hoverColor, _animDelaySec);
            }
        }

        public void OnPointerExit()
        {
            if (_targetBtn != null)
            {
                if (!_targetBtn.interactable)
                {
                    return;
                }
            }

            if (_img != null)
            {
                _img.DOColor(_defaultColor, _animDelaySec);
            }
        }

        public void OnPointerDown()
        {
            if (_targetBtn != null)
            {
                if (!_targetBtn.interactable)
                {
                    return;
                }
            }

            if (_img != null)
            {
                _img.DOColor(_pressColor, _animDelaySec * 0.5f);
            }
        }

        public void OnPointerUp()
        {
            if (_targetBtn != null)
            {
                if (!_targetBtn.interactable)
                {
                    return;
                }
            }

            if (_img != null)
            {
                _img.DOColor(_hoverColor, _animDelaySec);
            }
        }

        public void OnDisable()
        {
            if (_img != null)
            {
                _img.DOColor(_disableColor, _animDelaySec);
            }
        }
    }

}