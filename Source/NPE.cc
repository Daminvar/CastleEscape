#include "NPE.hh"

#include <iostream>
#include <string>
using namespace std;

#include <SFML/Graphics.hpp>

namespace CastleEscape {

NPE::NPE() {
	//TODO
}

int NPE::GetXPos() {
	return xPos_;
}

int NPE::GetYPos() {
	return yPos_;
}

void NPE::SetPosition(int x, int y) {
	xPos_ = x;
	yPos_ = y;
}

void NPE::SetTexture(string textureName) {
	texture_.LoadFromFile("Content/Graphics/" + textureName);
	texture_.SetSmooth(false);
}

void NPE::Draw(sf::RenderWindow& window, int x, int y) {
	sf::Sprite sprite(texture_);
	sprite.SetPosition(x, y);
	window.Draw(sprite);
}

ostream& operator<<(ostream& os, const NPE& npe) {
	return os << "NPE: (" << npe.xPos_ << "," << npe.yPos_ << ")";
}

} // namespace CastleEscape
