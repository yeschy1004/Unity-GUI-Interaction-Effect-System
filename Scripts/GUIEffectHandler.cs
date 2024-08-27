using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

namespace GUI.Effect
{
    public class GUIEffectHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private List<IGUIEffect> _effects = new List<IGUIEffect>();
        private Button _targetButton;
        private bool _previousInteractableState = true;

        // 여러 IGUIEffect를 추가할 수 있게 함
        public void Initialize(IGUIEffect effect, Button targetButton)
        {
            if (!_effects.Contains(effect))
            {
                _effects.Add(effect);
            }

            // targetBtn을 받아 저장
            if (_targetButton == null && targetButton != null)
            {
                _targetButton = targetButton;
                _previousInteractableState = _targetButton.interactable;
            }
        }

        private void Update()
        {
            // targetBtn의 상태를 확인하고 변경되면 적절한 메서드 호출
            if (_targetButton != null)
            {
                if (_targetButton.interactable != _previousInteractableState)
                {
                    //DebugX.Log("SetInteractableByBtnState: " + _targetButton.interactable);
                    if (!_targetButton.interactable)
                    {
                        // 버튼이 비활성화되었을 때 OnDisable 호출
                        foreach (var effect in _effects)
                        {
                            effect?.OnDisable();
                        }
                    }
                    else
                    {
                        // 버튼이 다시 활성화되면 기본 상태로 돌아가도록 OnPointerEnter 호출
                        foreach (var effect in _effects)
                        {
                            effect?.OnPointerExit(); // 기본 상태로 돌아가게 처리
                        }
                    }

                    _previousInteractableState = _targetButton.interactable;
                }
            }
        }

        public async void SetInteractableByBtnState(bool active)
        {
            await UniTask.WaitUntil(() => _targetButton != null);

            _targetButton.interactable = active;

            if (!_targetButton.interactable)
            {
                // 버튼이 비활성화되었을 때 OnDisable 호출
                foreach (var effect in _effects)
                {
                    effect?.OnDisable();
                }
            }
            else
            {
                // 버튼이 다시 활성화되면 기본 상태로 돌아가도록 OnPointerEnter 호출
                foreach (var effect in _effects)
                {
                    effect?.OnPointerExit(); // 기본 상태로 돌아가게 처리
                }
            }

            _previousInteractableState = _targetButton.interactable;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_targetButton == null || _targetButton.interactable)
            {
                foreach (var effect in _effects)
                {
                    effect?.OnPointerEnter();
                }
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_targetButton == null || _targetButton.interactable)
            {
                foreach (var effect in _effects)
                {
                    effect?.OnPointerExit();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_targetButton == null || _targetButton.interactable)
            {
                foreach (var effect in _effects)
                {
                    effect?.OnPointerDown();
                }
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (_targetButton == null || _targetButton.interactable)
            {
                foreach (var effect in _effects)
                {
                    effect?.OnPointerUp();
                }
            }
        }
    }
}