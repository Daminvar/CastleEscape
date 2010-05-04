#include "TestState.hh"

#include <SFML/Graphics.hpp>

namespace CastleEscape {

TestState::TestState() {
	background.LoadFromFile("Content/main-menu-background.png");
	bgSprite.SetImage(background);
}

TestState::~TestState() {
	// TODO Auto-generated destructor stub
}

void TestState::Pause() {
	// TODO
}

void TestState::Resume() {
	// TODO
}

void TestState::Update(const sf::Clock& clock) {

}

void TestState::Draw(sf::RenderWindow& window) {
	window.Draw(bgSprite);
}

} // namespace CastleEscape
