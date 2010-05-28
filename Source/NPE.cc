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
	return xPos;
}

int NPE::GetYPos() {
	return yPos;
}

void NPE::SetPosition(int x, int y) {
	xPos = x;
	yPos = y;
}

void NPE::SetTexture(string textureName) {
	texture.LoadFromFile("Content/Graphics/" + textureName);
	texture.SetSmooth(false);
}

void NPE::Draw(sf::RenderWindow& window, int x, int y) {
	sf::Sprite sprite(texture);
	sprite.SetPosition(x, y);
	window.Draw(sprite);
}

ostream& operator<<(ostream& os, const NPE& npe) {
	return os << "NPE: (" << npe.xPos << "," << npe.yPos << ")";
}

} // namespace CastleEscape
