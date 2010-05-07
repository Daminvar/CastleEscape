#include "DrawableMap.hh"

#include <iostream>
#include <vector>
using namespace std;

#include <SFML/Graphics.hpp>

namespace CastleEscape {

DrawableMap::DrawableMap() {
	tileset.LoadFromFile("Content/tileset.png");
	tileset.SetSmooth(false); //necessary to prevent rendering glitches
}

DrawableMap::~DrawableMap() {
	//TODO: DrawableMap destructor
}

void DrawableMap::DrawBase(sf::RenderWindow& window, int xPos, int yPos) {
	vector<vector<vector<int> > > baseLayers = tmxMap.GetBaseLayers();
	int tileSize = tmxMap.GetTileSize();
	int rowSize = tileset.GetWidth() / tmxMap.GetTileSize();
	for (int z = 0; z < baseLayers.size(); z++) {
		for (int y = 0; y < baseLayers[0].size(); y++) {
			for (int x = 0; x < baseLayers[0][0].size(); x++) {
				int tileID = baseLayers[z][y][x];
				if (tileID == -1)
					continue;
				sf::Sprite tileSprite(tileset);
				int tileX = (tileID % rowSize) * tileSize;
				int tileY = (tileID / rowSize) * tileSize;
				tileSprite.SetSubRect(sf::IntRect(tileX, tileY, tileX
						+ tileSize, tileY + tileSize));
				tileSprite.SetPosition(xPos + x * tileSize, yPos + y * tileSize);
				window.Draw(tileSprite);
			}
		}
	}
}

void DrawableMap::DrawTop(sf::RenderWindow& window, int xPos, int yPos) {
	//TODO: DrawTop
}

} // namespace CastleEscape
