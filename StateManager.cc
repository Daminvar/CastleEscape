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

void StateManager::Update(const sf::Clock& clock) {
	if (states.empty())
		return;

	states[states.size() - 1]->Update(clock);
}

void StateManager::Draw(sf::RenderWindow& window) {
	if (states.empty())
		return;

	states[states.size() - 1]->Draw(window);
}

void StateManager::PushState(State* newState) {
	if (!states.empty())
		states[states.size() - 1]->Pause();
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
