using System;
using System.Collections.Generic;
using System.Linq;
using BasicGameEngine.Components;

namespace BasicGameEngine
{
    /// <summary>
    /// The core entity of the engine. It's a container for Components.
    /// Everything in your "Workspace" is a GameObject.
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// A list of all components attached to this GameObject.
        /// The "Properties" (right bar) would show these.
        /// </summary>
        private List<Component> _components = new List<Component>();
        
        /// <summary>
        /// A unique ID for this object instance.
        /// </summary>
        public Guid InstanceID { get; private set; }

        public string Name { get; set; }
        public Scene Scene { get; internal set; }

        /// <summary>
        /// A quick-access property for the Transform.
        /// Every GameObject is required to have one.
        /// </summary>
        public Transform Transform { get; private set; }

        public GameObject(string name)
        {
            Name = name;
            InstanceID = Guid.NewGuid();

            // Every GameObject MUST have a Transform.
            // We add it automatically on creation.
            Transform = AddComponent<Transform>();
        }

        /// <summary>
        /// Adds a new component of type T to this GameObject.
        /// </summary>
        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            component.GameObject = this; // Set the back-reference
            _components.Add(component);
            // In a real engine, you'd call component.Start() here
            return component;
        }

        /// <summary>
        /// Gets the first component of type T found on this GameObject.
        /// </summary>
        public T GetComponent<T>() where T : Component
        {
            return _components.OfType<T>().FirstOrDefault();
        }

        /// <summary>
        // Returns an enumerable of all components on the object.
        /// </summary>
        public IEnumerable<Component> GetAllComponents()
        {
            return _components;
        }

        /// <summary>
        /// Called by the Scene every frame.
        /// Updates all components attached to this object.
        /// </summary>
        internal void Update()
        {
            foreach (var component in _components)
            {
                component.Update();
            }
        }
    }
}
