#include "NPE.hh"

#include <string>
using namespace std;

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

} // namespace CastleEscape
