using System.Diagnostics;

namespace BasicGameEngine
{
    /// <summary>
    /// The main singleton class that manages the entire engine,
    /// including the scene, game loop, and editor state.
    /// </summary>
    public class GameEngine
    {
        /// <summary>
        /// The currently active scene being simulated or edited.
        /// </summary>
        public Scene CurrentScene { get; set; }

        /// <summary>
        /// Simulates the "selected object" in the editor's
        /// Workspace/Hierarchy. The Properties bar would show this.
        /// </summary>
        public GameObject SelectedGameObject { get; set; }

        private Stopwatch _gameTimer;

        public GameEngine()
        {
            _gameTimer = new Stopwatch();
            Time.Update(0); // Initialize time
        }

        /// <summary>
        /// Simulates a single frame of the game loop.
        /// </summary>
        public void RunGameLoop()
        {
            if (CurrentScene == null) return;

            // 1. Start timer / Calculate DeltaTime
            _gameTimer.Stop();
            float deltaTime = (float)_gameTimer.Elapsed.TotalSeconds;
            if (deltaTime > 0.1f) deltaTime = 0.1f; // Clamp large gaps
            Time.Update(deltaTime);
            _gameTimer.Restart();

            // 2. Process Input (Skipped in this simulation)

            // 3. Update Scene (Physics, component logic)
            CurrentScene.Update();

            // 4. Render Scene (Skipped in this simulation)
        }
    }
}
