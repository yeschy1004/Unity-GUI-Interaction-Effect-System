# Unity-GUI-Interaction-Effect-System
This repository contains a modular and extendable system for adding dynamic interaction effects to Unity's GUI elements such as buttons, texts, and images. The system is designed to handle various types of effects like color swaps, size transitions, and custom actions upon user interaction with the GUI elements.

Unity GUI Interaction Effect System
This repository contains a modular and extendable system for adding dynamic interaction effects to Unity's GUI elements such as buttons, texts, and images. The system is designed to handle various types of effects like color swaps, size transitions, and custom actions upon user interaction with the GUI elements.

# Features
 * Modular Architecture: Easily extendable system to add custom effects.
 * Predefined Effects: Includes effects for image color swap, text color swap, and size transitions.
 * Customizable: Easily integrate custom actions to be triggered during different GUI states like hover, click, or disable.
 * Optimized for Unity: Uses Unity’s native UI system along with external libraries such as DOTween and Cysharp.Threading.Tasks.
 * Automatic State Management: Automatically handles the interaction state of buttons, ensuring effects reset properly when re-enabled.

# Installation
1. Clone the repository into your Unity project's Assets folder:
git clone https://github.com/yourusername/unity-gui-effect-system.git

3. Ensure that DOTween and Cysharp.Threading.Tasks are installed and properly set up in your project.

# Usage
1. Attach the BaseGUIEffect component: Add the BaseGUIEffect component to any GameObject that you want to apply effects to.
2. Set up InteractiveGUI: In the Unity Inspector, configure the InteractiveGUI fields by assigning the target button, choosing the effect type, and customizing the parameters (e.g., colors, sizes).
3. Add Custom Effects (Optional): To add a custom effect, create a class that implements the IGUIEffect interface and define your custom behavior for each interaction method (OnPointerEnter, OnPointerExit, etc.).
4. Run the Scene: The effects will automatically initialize and respond to user interactions like hovering, clicking, and disabling the buttons.

# Example
Here’s an example of a button configured with the ImageColorSwap effect:

[Serializable]
public class InteractiveGUI
{
    public GUIEffectType effectType = GUIEffectType.ImageColorSwap;
    public Button targetBtn;
    public Image img;
    public Color32 defaultImgColor = Color.white;
    public Color32 hoverImgColor = Color.green;
    public Color32 pressImgColor = Color.red;
    public Color32 disableImgColor = Color.gray;
}

# Supported Effect Types
 * ImageColorSwap: Changes the color of an image on different interaction states (default, hover, press, disabled).
 * TextColorSwap: Changes the text color based on interaction states.
 * SizeSwap: Resizes the UI element when hovered over, pressed, or disabled.
 * Custom: Triggers custom UnityActions for each interaction state.

# Extending the System
You can easily extend the system by creating your own effect classes. To do this:
1. Implement the IGUIEffect interface.
2. Define the desired behaviors for the interaction states.
3. Add the custom effect to the GUIEffectFactory to enable selection through the Unity Editor.

# Dependencies
* DOTween: For smooth and efficient tween animations.
* Cysharp.Threading.Tasks: For handling async tasks within Unity's event system.

# Contributing
Feel free to submit pull requests for bug fixes or new features. Make sure to open an issue first to discuss any significant changes.

# License
This project is licensed under the MIT License.
