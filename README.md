# Unity Wireframe Shaders

These are general purpose wireframe shaders adapted from Unity's built-in SpatialMappingWireframe shader.

![](https://raw.githubusercontent.com/Chaser324/unity-wireframe/gh-pages/Screenshots/2017-06-02_13-40-13.gif)

[Unity Forums Thread](https://forum.unity3d.com/threads/free-open-source-generic-wireframe-shaders.473968/)

## Requirements

* These shaders will only work on devices that support at least Shader Model 4.0. Most mobile devices do not meet this requirement.

## Usage

* Add the `Wireframe` directory to your Unity project's `Assets` directory.
* To use the wireframe shaders, set your material's shader to `SuperSystems/Wireframe`, `SuperSystems/Wireframe-Transparent`, or `SuperSystems/Wireframe-Transparent-Culled`.
* To use the replacement shader image effect, add the `WireframeImageEffect` component to your camera. Some other effects like GlobalFog will interfere with the replacement shaders and will need to be disabled.

## License
All code in this repository ([unity-wireframe](https://github.com/Chaser324/unity-wireframe)) is made freely available under the MIT license. This essentially means you're free to use it however you like as long as you provide attribution.
