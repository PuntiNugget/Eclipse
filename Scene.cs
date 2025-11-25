using System.Collections.Generic;

namespace BasicGameEngine
{
    /// <summary>
    /// Represents the "Scene Space" and the "Workspace".
    /// It holds a list of all GameObjects in the current level.
    /// </summary>
    public class Scene
    {
        /// <summary>
        /// The list of all GameObjects in this scene. This is what the
        /// "Workspace" (left bar) would display.
        /// </summary>
        private List<GameObject> _gameObjects = new List<GameObject>();

        /// <summary>
        /// Simulates the "Right-click -> Add Sprite" action.
        /// Creates a new GameObject, adds it to the scene, and returns it.
        /// </summary>
        /// <param name="name">The name for the new object.</param>
        public GameObject CreateGameObject(string name)
        {
            GameObject go = new GameObject(name);
            go.Scene = this;
            _gameObjects.Add(go);
            return go;
        }

        public void DestroyGameObject(GameObject go)
        {
            if (_gameObjects.Contains(go))
            {
                //TODO: Add logic for OnDestroy()
                _gameObjects.Remove(go);
            }
        }

        /// <summary>
        /// Called by the GameEngine every frame.
        /// This, in turn, updates all components on all GameObjects.
        /// </summary>
        public void Update()
        {
            // We loop backwards in case an object is destroyed during update
            for (int i = _gameObjects.Count - 1; i >= 0; i--)
            {
                _gameObjects[i].Update();
            }

            // In a real engine, the Physics step (collision detection)
            // would happen here, after all movements.
        }

        public IEnumerable<GameObject> GetAllGameObjects()
        {
            return _gameObjects;
        }
    }
}
