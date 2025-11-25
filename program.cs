using System;
using System.Linq;
using System.Threading;
using BasicGameEngine;
using BasicGameEngine.Components;

// This class simulates the User Interface (UI) and engine loop
// you described.
public class Program
{
    public static void Main(string[] args)
    {
        // 1. SETUP
        // Create the main engine and a scene
        GameEngine engine = new GameEngine();
        engine.CurrentScene = new Scene();

        // 2. "RIGHT-CLICK IN WORKSPACE" -> Create GameObject
        Console.WriteLine("[Simulation] Right-clicking in Workspace to create a new Sprite...");
        GameObject player = engine.CurrentScene.CreateGameObject("Player");

        // The object is created. By default, it ONLY has a Transform.
        Console.WriteLine($"Created GameObject: '{player.Name}' (ID: {player.InstanceID})");

        // 3. "ADD COMPONENTS"
        // Let's add the components you mentioned
        Console.WriteLine("[Simulation] Adding components to 'Player'...");
        var sprite = player.AddComponent<SpriteRenderer>();
        var physics = player.AddComponent<PhysicsBody>();
        var collider = player.AddComponent<BoxCollider>();

        // 4. "CLICK OBJECT IN WORKSPACE" -> Select Object
        Console.WriteLine("[Simulation] Clicking 'Player' in Workspace...");
        engine.SelectedGameObject = player;
        
        // 5. "PROPERTIES BAR" -> Show properties for selected object
        Console.WriteLine("------------------------------------------");
        Console.WriteLine($"PROPERTIES: {engine.SelectedGameObject.Name}");
        Console.WriteLine("------------------------------------------");
        
        // Use the helper method to display all components and their properties
        ShowProperties(engine.SelectedGameObject);

        // 6. "USE THE TOOLS"
        // Simulate using the "Move Tool"
        Console.WriteLine("\n[Simulation] Using 'Move Tool'...");
        Transform playerTransform = player.Transform; // Get the transform
        playerTransform.Position = new Vector2(10, 50);
        Console.WriteLine($"Set Position to: {playerTransform.Position}");

        // Simulate using the "Scale Tool"
        Console.WriteLine("[Simulation] Using 'Scale Tool'...");
        playerTransform.Scale = new Vector2(2, 2);
        Console.WriteLine($"Set Scale to: {playerTransform.Scale}");

        // Simulate using the "Rotate Tool"
        Console.WriteLine("[Simulation] Using 'Rotate Tool'...");
        playerTransform.Rotation = 45.0f;
        Console.WriteLine($"Set Rotation to: {playerTransform.Rotation} degrees");

        // 7. "PHYSICS PROPERTIES"
        // Simulate changing a property in the Physics component
        Console.WriteLine("[Simulation] Adjusting 'Gravity Scale' in Physics component...");
        physics.GravityScale = 0.5f;
        Console.WriteLine($"Set Gravity Scale to: {physics.GravityScale}");

        // 8. "RUN THE GAME"
        // Simulate the game loop running for 2 seconds
        Console.WriteLine("\n[Simulation] === RUNNING GAME LOOP (2 seconds) ===");
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < 2)
        {
            // The engine loop updates the scene, which updates all
            // components (like PhysicsBody)
            engine.RunGameLoop();
            
            // Show the player's position being affected by physics
            Console.WriteLine($"Game Time: {Time.TotalTime:F2}s | Player Position: {player.Transform.Position} | Velocity: {physics.Velocity}");
            
            // Sleep to simulate real-time
            Thread.Sleep(50); // Sleep for 50ms
        }
        Console.WriteLine("[Simulation] === GAME LOOP ENDED ===");
    }

    /// <summary>
    /// Helper method to simulate the Property Inspector.
    /// It uses reflection to find all public properties of a component.
    /// </summary>
    public static void ShowProperties(GameObject go)
    {
        if (go == null)
        {
            Console.WriteLine("No object selected.");
            return;
        }

        foreach (var component in go.GetAllComponents())
        {
            // Get the component's type name (e.g., "Transform", "SpriteRenderer")
            string componentName = component.GetType().Name;
            Console.WriteLine($"\n> {componentName}");

            // Find all public properties of this component
            var properties = component.GetType().GetProperties(
                System.Reflection.BindingFlags.Public | 
                System.Reflection.BindingFlags.Instance);
                
            if (properties.Length == 0)
            {
                Console.WriteLine("  (No public properties)");
            }

            foreach (var prop in properties)
            {
                // Print the property name and its current value
                Console.WriteLine($"  - {prop.Name}: {prop.GetValue(component)}");
            }
        }
    }
}
