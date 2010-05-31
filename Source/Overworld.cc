#include "Overworld.hh"

#include <SFML/Graphics.hpp>

namespace CastleEscape {

Overworld::Overworld() {
	map_.LoadMap("Content/Maps/testmap.lua"); //TOOD fix
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
	map_.DrawBase(window, 0, 0);
	map_.DrawTop(window, 0, 0);
}

} // namespace CastleEscape
