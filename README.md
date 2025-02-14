# Utility Scripts Collection

This repository provides a collection of utility scripts designed to enhance your Unity development workflow.

## Installation

Clone the repository or download the scripts and folders you need. You can import:

- Each script in Utilities folder individually.
- Each other folder.

Feel free to download only the parts that suit your needs.

## Available Utilities

### **Blockable.cs**
A simple blocking system using an internal counter to manage the blocked state. Events notify when the blocking state changes.

### **ListUtility.cs**
Extension methods for `List<T>` and arrays:
- `Shuffle`: Randomly shuffles the list.
- `GetRandomIndex`: Gets a random index from the list or array.
- `GetRandomElement`: Gets a random element from the list or array.
- `PopRandomElement`: Removes and returns a random element.

### **RectUtility.cs**
Helper methods for manipulating `Rect` objects:
- `CutLeft`, `CutTop`, `CutRight`, `CutBottom`: Cuts a specified portion of the rectangle, returns cuted part.
- `Grow`, `Shrink`: Resizes the rectangle.
- `NormalizedValueToPoint`, `PointToNormalizedValue`: Converts between normalized values and actual points within the rect.
- Unity Editor-specific: `IsClicked` checks if the rect was clicked.

### **SingletonBehaviour.cs**
A generic `MonoBehaviour` singleton pattern to manage single instances of classes, ensuring that only one instance exists in the scene.

### **VectorUtility.cs**
Methods to convert between 2D and 3D vector types:
- `Vector2DTo3D`: Converts Vector2 (X, Y) to Vector3 (X, 0, Y)
- `Vector3DTo2D`: Converts Vector3 (X, Y, Z) to Vector2 (X, Z)

### **Config Assets**
A ScriptableObject-based configuration system that allows you to load and save custom settings:
- Uses a singleton pattern to ensure only one instance of each configuration is loaded.
- Loads configurations from the `Resources/Config` directory.
- In editor, if asset does not exist, it gets automatically created.

## License

This repository is open-source and can be freely used in any Unity project, but it comes without any warranties. Contributions and improvements are welcome!
