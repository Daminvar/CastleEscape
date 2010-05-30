#include <iostream>
using namespace std;

#include <SFML/Graphics.hpp>

#include "ErrorState.hh"
#include "MainMenu.hh"
#include "StateManager.hh"
using namespace CastleEscape;

int main() {
	sf::RenderWindow app(sf::VideoMode(800, 480, 32), "Escape from the Castle");
	sf::Clock clock;
	app.SetFramerateLimit(60);
	StateManager::Initialize();
	StateManager::PushState(new MainMenu());

	while (app.IsOpened()) {
		sf::Event event;
		while (app.GetEvent(event)) {
			if (event.Type == sf::Event::Closed)
				app.Close();
		}
		try {
			StateManager::Update(clock, app.GetInput());
			if (StateManager::IsEmpty())
				app.Close();
			app.Clear();
			StateManager::Draw(app);
			app.Display();
		} catch (const exception& e) {
			cerr << e.what() << endl;
			StateManager::PopAllStates();
			StateManager::PushState(new ErrorState(e.what()));
		}
	}
	return 0;
}

