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
    /// 동작에 따라 해당 오브젝트에 원하는 Action을 호출할 수 있음.(초기화를 Awake에서 해야함, **호출 시점 주의)
    /// </summary>
    public class CustomGUIEffect : IGUIEffect
    {
        private Button _targetBtn;
        private UnityAction _defaultAction;
        private UnityAction _hoverAction;
        private UnityAction _pressAction;
        private UnityAction _disableAction;

        /// <summary>
        /// Awake에 할당되어야만 함(초기화가 Start에서 이뤄짐)
        /// </summary>
        /// <param name="targetBtn"></param>
        /// <param name="defaultAction"></param>
        /// <param name="hoverAction"></param>
        /// <param name="pressAction"></param>
        /// <param name="disableAction"></param>
        public CustomGUIEffect(Button targetBtn, UnityAction defaultAction, UnityAction hoverAction, UnityAction pressAction, UnityAction disableAction)
        {
            _targetBtn = targetBtn;
            _defaultAction = defaultAction;
            _hoverAction = hoverAction;
            _pressAction = pressAction;
            _disableAction = disableAction;
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

            _hoverAction?.Invoke();
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

            _defaultAction?.Invoke();
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

            _pressAction?.Invoke();
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

            _hoverAction?.Invoke();
        }

        public void OnDisable()
        {
            _disableAction?.Invoke();
        }
    }
}