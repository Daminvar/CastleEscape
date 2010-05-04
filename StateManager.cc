#include "StateManager.hh"

#include <iostream>
#include <vector>
#include <SFML/Graphics.hpp>
#include "State.hh"

namespace CastleEscape {

std::vector<State*> StateManager::states;
bool StateManager::running;

void StateManager::Initialize() {
	running = true;
}

int StateManager::GetStackSize() {
	return states.size();
}

void StateManager::Stop() {
	running = false;
}

void StateManager::Continue() {
	running = true;
}

void StateManager::Update(const sf::Clock& clock, const sf::Input& input) {
	if (states.empty() || !running)
		return;

	states.back()->Update(clock, input);
}

void StateManager::Draw(sf::RenderWindow& window) {
	if (states.empty() || !running)
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
