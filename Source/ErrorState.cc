#include "ErrorState.hh"

#include <string>
using namespace std;

#include <SFML/Graphics.hpp>

#include "StateManager.hh"

namespace CastleEscape {

const int FONT_SIZE = 20;

ErrorState::ErrorState(string error) {
	error_ = error;
	canPressEnter_ = false;
	background_.LoadFromFile("Content/Graphics/error-background.png");
	bgSprite_.SetImage(background_);
	errorFont_.LoadFromFile("Content/Fonts/droid-sans.ttf", FONT_SIZE);
	errorString_.SetFont(errorFont_);
	errorString_.SetSize(FONT_SIZE);
	errorString_.SetText(error_ + "\nPress \"Enter\" to quit.");
	errorString_.SetPosition(30, 30);
}

ErrorState::~ErrorState() {
	//TODO
}

void ErrorState::Pause() {
	//TODO
}

void ErrorState::Resume() {
	//TODO
}

void ErrorState::Update(const sf::Clock& clock, const sf::Input& input) {
	if (!input.IsKeyDown(sf::Key::Return))
		canPressEnter_ = true;
	if (canPressEnter_ && input.IsKeyDown(sf::Key::Return))
		StateManager::PopState();

}

void ErrorState::Draw(sf::RenderWindow& window) {
	window.Draw(bgSprite_);
	window.Draw(errorString_);
}

} // namespace CastleEscape
