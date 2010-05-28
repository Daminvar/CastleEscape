#include "DrawableMap.hh"

#include <iostream>
#include <vector>
using namespace std;

#include <SFML/Graphics.hpp>

namespace CastleEscape {

DrawableMap::DrawableMap() {
	tileset.LoadFromFile("Content/Graphics/tileset.png");
	tileset.SetSmooth(false); //necessary to prevent rendering glitches
}

DrawableMap::~DrawableMap() {
	//TODO: DrawableMap destructor
}

void DrawableMap::DrawBase(sf::RenderWindow& window, int xPos, int yPos) {
	MapVector baseLayers = tmxMap.GetBaseLayers();
	drawLayers(window, baseLayers, xPos, yPos);

}

void DrawableMap::DrawTop(sf::RenderWindow& window, int xPos, int yPos) {
	MapVector topLayers = tmxMap.GetTopLayers();
	drawLayers(window, topLayers, xPos, yPos);
}

void DrawableMap::drawLayers(sf::RenderWindow& window, MapVector layers,
		int xPos, int yPos) {
	int tileSize = tmxMap.GetTileSize();
	int rowSize = tileset.GetWidth() / tmxMap.GetTileSize();
	for (int z = 0; z < layers.size(); z++) {
		for (int y = 0; y < layers[0].size(); y++) {
			for (int x = 0; x < layers[0][0].size(); x++) {
				int tileID = layers[z][y][x];
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

} // namespace CastleEscape
