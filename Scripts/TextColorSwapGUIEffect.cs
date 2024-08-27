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
    /// 2D GUI Text 글자 색이 동작에 따라 변화함.
    /// </summary>
    public class TextColorSwapGUIEffect : IGUIEffect
    {
        private Button _targetBtn;
        private Text _text;
        private Color32 _defaultColor;
        private Color32 _hoverColor;
        private Color32 _pressColor;
        private Color32 _disableColor;
        private float _animDelaySec;

        public TextColorSwapGUIEffect(Button targetBtn, Text text, Color32 defaultColor, Color32 hoverColor, Color32 pressColor, Color32 disableColor, float animDelaySec)
        {
            _targetBtn = targetBtn;
            _text = text;
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

            if (_text != null)
            {
                _text.DOColor(_hoverColor, _animDelaySec);
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

            if (_text != null)
            {
                _text.DOColor(_defaultColor, _animDelaySec);
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

            if (_text != null)
            {
                _text.DOColor(_pressColor, _animDelaySec * 0.5f);
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

            if (_text != null)
            {
                _text.DOColor(_hoverColor, _animDelaySec);
            }
        }

        public void OnDisable()
        {
            if (_text != null)
            {
                _text.DOColor(_disableColor, _animDelaySec);
            }
        }
    }
}