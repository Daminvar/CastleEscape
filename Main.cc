#include <SFML/Graphics.hpp>
#include "StateManager.hh"
#include "TestState.hh"
using namespace CastleEscape;

int main() {
	sf::RenderWindow app(sf::VideoMode(800, 480, 32), "Escape from the Castle");
	sf::Clock clock;
	app.SetFramerateLimit(60);
	StateManager::Initialize();
	StateManager::PushState(new TestState());

	while (app.IsOpened()) {
		sf::Event event;
		while (app.GetEvent(event)) {
			if (event.Type == sf::Event::Closed)
				app.Close();
		}
		StateManager::Update(clock);
		app.Clear();
		StateManager::Draw(app);
		app.Display();
		clock.Reset();
	}
	return 0;
}

