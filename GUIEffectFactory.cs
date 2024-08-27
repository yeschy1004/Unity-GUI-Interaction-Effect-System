using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using Sirenix.OdinInspector;

namespace GUI.Effect
{
    public static class GUIEffectFactory
    {
        public const float animDelaySec = 0.2f;

        public static IGUIEffect CreateEffect(InteractiveGUI gui)
        {
            switch (gui.effectType)
            {
                case GUIEffectType.ImageColorSwap:
                    return new ImageColorSwapGUIEffect(gui.targetBtn, gui.img, gui.defaultImgColor, gui.hoverImgColor, gui.pressImgColor, gui.disableImgColor, animDelaySec);
                case GUIEffectType.TextColorSwap:
                    return new TextColorSwapGUIEffect(gui.targetBtn, gui.text, gui.defaultTextColor, gui.hoverTextColor, gui.pressTextColor, gui.disableTextColor, animDelaySec);
                case GUIEffectType.SizeSwap:
                    return new SizeSwapGUIEffect(gui.targetBtn, gui.rect, gui.defaultSize, gui.hoverSize, gui.pressSize, gui.disableSize, animDelaySec);
                case GUIEffectType.Custom:
                    return new CustomGUIEffect(gui.targetBtn, gui.defaultCustomAction, gui.hoverCustomAction, gui.pressCustomAction, gui.disableCustomAction);
                default:
                    throw new ArgumentException("Unsupported GUIEffectType");
            }
        }
    }

    #region Base
    public interface IGUIEffect
    {
        void OnPointerEnter();
        void OnPointerExit();
        void OnPointerDown();
        void OnPointerUp();
        void OnDisable(); // 추가된 메서드
    }

    [Serializable]
    public class InteractiveGUI
    {
        [HorizontalGroup("Effect Type", 0.5f)]
        [HideLabel, EnumToggleButtons]
        [ValueDropdown(nameof(GetAllGUIEffectTypes))] // 드롭다운 설정
        public GUIEffectType effectType;
        [field: SerializeField]
        public Button targetBtn; // 추가된 필드

        // effectType이 ImageColorSwap일 때만 보여줌
        [ShowIf(nameof(effectType), GUIEffectType.ImageColorSwap)]
        public Image img;
        [ShowIf(nameof(effectType), GUIEffectType.ImageColorSwap)]
        public Color32 defaultImgColor;
        [ShowIf(nameof(effectType), GUIEffectType.ImageColorSwap)]
        public Color32 hoverImgColor;
        [ShowIf(nameof(effectType), GUIEffectType.ImageColorSwap)]
        public Color32 pressImgColor;
        [ShowIf(nameof(ShouldShowDisableFieldsImageColorSwap))]
        public Color32 disableImgColor;

        // effectType이 TextColorSwap일 때만 보여줌
        [ShowIf(nameof(effectType), GUIEffectType.TextColorSwap)]
        public Text text;
        [ShowIf(nameof(effectType), GUIEffectType.TextColorSwap)]
        public Color32 defaultTextColor;
        [ShowIf(nameof(effectType), GUIEffectType.TextColorSwap)]
        public Color32 hoverTextColor;
        [ShowIf(nameof(effectType), GUIEffectType.TextColorSwap)]
        public Color32 pressTextColor;
        [ShowIf(nameof(ShouldShowDisableFieldsTextColorSwap))]
        public Color32 disableTextColor;

        // effectType이 SizeSwap일 때만 보여줌
        [ShowIf(nameof(effectType), GUIEffectType.SizeSwap)]
        public RectTransform rect;
        [ShowIf(nameof(effectType), GUIEffectType.SizeSwap)]
        public Vector2 defaultSize;
        [ShowIf(nameof(effectType), GUIEffectType.SizeSwap)]
        public Vector2 hoverSize;
        [ShowIf(nameof(effectType), GUIEffectType.SizeSwap)]
        public Vector2 pressSize;
        [ShowIf(nameof(ShouldShowDisableFieldsSizeSwap))]
        public Vector2 disableSize;

        // effectType이 Custom일 때만 보여줌
        [ShowIf(nameof(effectType), GUIEffectType.Custom)]
        public UnityAction defaultCustomAction;
        [ShowIf(nameof(effectType), GUIEffectType.Custom)]
        public UnityAction hoverCustomAction;
        [ShowIf(nameof(effectType), GUIEffectType.Custom)]
        public UnityAction pressCustomAction;
        [ShowIf(nameof(ShouldShowDisableFieldsCustom))]
        public UnityAction disableCustomAction;

        // targetBtn이 null이 아닌 경우에만 disable 필드들이 보이게 하는 조건
        private bool ShouldShowDisableFieldsImageColorSwap()
        {
            return (targetBtn != null) && (effectType == GUIEffectType.ImageColorSwap);
        }

        private bool ShouldShowDisableFieldsTextColorSwap()
        {
            return (targetBtn != null) && (effectType == GUIEffectType.TextColorSwap);
        }

        private bool ShouldShowDisableFieldsSizeSwap()
        {
            return (targetBtn != null) && (effectType == GUIEffectType.SizeSwap);
        }

        private bool ShouldShowDisableFieldsCustom()
        {
            return (targetBtn != null) && (effectType == GUIEffectType.Custom);
        }

        // 드롭다운으로 선택할 수 있는 GUIEffectType 목록을 반환하는 메서드
        private static IEnumerable GetAllGUIEffectTypes()
        {
            return Enum.GetValues(typeof(GUIEffectType));
        }
    }

    public enum GUIEffectType
    {
        ImageColorSwap,
        TextColorSwap,
        SizeSwap,
        Custom,
    }
    #endregion
}