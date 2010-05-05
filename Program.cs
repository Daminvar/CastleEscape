using System;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace CastleEscape
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
			var app = new SFML.Graphics.RenderWindow(new VideoMode(800, 480, 32), "Escape from the Castle");
			app.SetFramerateLimit(60);
			app.Closed += delegate {
				app.Close();
			};
			var clock = new Clock();
			
			StateManager.Initialize();
			StateManager.PushState(new MainMenu());
			
			while (app.IsOpened())
			{
				StateManager.Update(clock, app.Input);
				if (StateManager.IsEmpty())
					app.Close();
				else
				{
					StateManager.Draw(app);
				}
			}
        }
    }
}

