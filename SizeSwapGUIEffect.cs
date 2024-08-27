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
    /// 2D GUI RectTransform의 크기(sizeDelta)가 동작에 따라 변화함
    /// </summary>
    public class SizeSwapGUIEffect : IGUIEffect
    {
        private Button _targetBtn;
        private RectTransform _rect;
        private Vector2 _defaultSize;
        private Vector2 _hoverSize;
        private Vector2 _pressSize;
        private Vector2 _disableSize;
        private float _animDelaySec;

        public SizeSwapGUIEffect(Button targetBtn, RectTransform rect, Vector2 defaultSize, Vector2 hoverSize, Vector2 pressSize, Vector2 disableSize, float animDelaySec)
        {
            _targetBtn = targetBtn;
            _rect = rect;
            _defaultSize = defaultSize;
            _hoverSize = hoverSize;
            _pressSize = pressSize;
            _disableSize = disableSize;
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

            if (_rect != null)
            {
                _rect.DOSizeDelta(_hoverSize, _animDelaySec);
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

            if (_rect != null)
            {
                _rect.DOSizeDelta(_defaultSize, _animDelaySec);
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

            if (_rect != null)
            {
                _rect.DOSizeDelta(_pressSize, _animDelaySec * 0.5f);
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

            if (_rect != null)
            {
                _rect.DOSizeDelta(_hoverSize, _animDelaySec);
            }
        }

        public void OnDisable()
        {
            if (_rect != null)
            {
                _rect.DOSizeDelta(_disableSize, _animDelaySec);
            }
        }
    }
}