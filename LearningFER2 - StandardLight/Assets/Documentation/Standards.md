# Naming Standards

## Scenes
Scenes should use the naming convention of `SCENE_{name}_{mode}.unity`.

**name**: The name of your scene such as `Level1` or `SplashScreen`.  
**mode**:
- `R`: Release mode. This scene is intended to be built into the final game.
- `D`: Developer mode. This scene is intended to be an editor only test scene for developer use only.

> Examples:
>
> `SCENE_Level1_R.unity` is a scene named "Level1" that is intended to be shipped.
>
> `SCENE_ColliderTest_D.unity` is a scene named "ColliderTest" that is intended to be excluded from builds but available in the editor.