using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GUI.Effect
{
    public class BaseGUIEffect : MonoBehaviour
    {
        [field: SerializeField]
        public InteractiveGUI[] interactiveGUIs;
        private Dictionary<InteractiveGUI, IGUIEffect> _effectMap;

        #region Unity Life Cycle
        private void Start()
        {
            InitializeEffects();
        }

        private void OnValidate()
        {
            // 런타임 중복 호출 방지
            if (Application.isPlaying)
                return;

            InitializeEffects();
        }
        #endregion

        private void InitializeEffects()
        {
            if (interactiveGUIs == null || interactiveGUIs.Length == 0)
                return;

            _effectMap = new Dictionary<InteractiveGUI, IGUIEffect>();
            GUIEffectHandler handler = null;

            foreach (var gui in interactiveGUIs)
            {
                var effect = GUIEffectFactory.CreateEffect(gui);
                _effectMap[gui] = effect;

                // GUIEffectHandler가 처음인 경우 추가하고, 이미 있으면 추가하지 않음
                if (handler == null)
                {
                    handler = this.gameObject.GetComponent<GUIEffectHandler>();
                    if (handler == null)
                    {
                        handler = this.gameObject.AddComponent<GUIEffectHandler>();
                    }
                }

                // 각 GUIEffect를 단일 핸들러에 추가하고 targetBtn을 전달
                handler.Initialize(effect, gui.targetBtn);
            }

#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
#endif
        }
    }
}