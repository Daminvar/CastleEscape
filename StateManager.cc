#include "StateManager.hh"

#include <iostream>
#include <vector>
#include <SFML/Graphics.hpp>
#include "State.hh"

namespace CastleEscape {

std::vector<State*> StateManager::states;

void StateManager::Initialize() {
	std::cout << "Initializing!" << std::endl;
}

void StateManager::Update(const sf::Clock& clock, const sf::Input& input) {
	if (states.empty())
		return;

	states.back()->Update(clock, input);
}

void StateManager::Draw(sf::RenderWindow& window) {
	if (states.empty())
		return;

	states.back()->Draw(window);
}

void StateManager::PushState(State* newState) {
	if (!states.empty())
		states.back()->Pause();
	states.push_back(newState);
}

void StateManager::PopState() {
	states.pop_back();
}

void StateManager::PopAllStates() {
	states.clear();
}

bool StateManager::IsEmpty() {
	return states.empty();
}

} // namespace CastleEscape
