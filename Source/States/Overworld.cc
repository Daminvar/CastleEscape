#include "Overworld.hh"

#include <SFML/Graphics.hpp>

namespace CastleEscape {

Overworld::Overworld() {
	map.LoadMap("Content/maps/bedroom1.tmx");
}

Overworld::~Overworld() {
	//TODO: Overworld destructor
}

void Overworld::Pause() {
	//TODO: Overworld pause
}

void Overworld::Resume() {
	//TODO: Overworld resume
}

void Overworld::Update(const sf::Clock& clock, const sf::Input& input) {
	//TODO: Overworld update
}

void Overworld::Draw(sf::RenderWindow& window) {
	map.DrawBase(window, 0, 0);
	map.DrawTop(window, 0, 0);
}

} // namespace CastleEscape
