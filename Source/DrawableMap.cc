#include "DrawableMap.hh"

#include <iostream>
#include <vector>
using namespace std;

#include <SFML/Graphics.hpp>

namespace CastleEscape {

DrawableMap::DrawableMap() {
	tileset_.LoadFromFile("Content/Graphics/tileset.png");
	tileset_.SetSmooth(false); //necessary to prevent rendering glitches
}

DrawableMap::~DrawableMap() {
	//TODO: DrawableMap destructor
}

void DrawableMap::DrawBase(sf::RenderWindow& window, int xPos, int yPos) {
	MapVector baseLayers = tmxMap_.GetBaseLayers();
	drawLayers(window, baseLayers, xPos, yPos);
	drawNPEs(window);

}

void DrawableMap::DrawTop(sf::RenderWindow& window, int xPos, int yPos) {
	MapVector topLayers = tmxMap_.GetTopLayers();
	drawLayers(window, topLayers, xPos, yPos);
}

void DrawableMap::drawLayers(sf::RenderWindow& window, MapVector layers,
		int xPos, int yPos) {
	int tileSize = tmxMap_.GetTileSize();
	int rowSize = tileset_.GetWidth() / tmxMap_.GetTileSize();
	for (int z = 0; z < layers.size(); z++) {
		for (int y = 0; y < layers[0].size(); y++) {
			for (int x = 0; x < layers[0][0].size(); x++) {
				int tileID = layers[z][y][x];
				if (tileID == -1)
					continue;
				sf::Sprite tileSprite(tileset_);
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

void DrawableMap::drawNPEs(sf::RenderWindow& window) {
	for (int i = 0; i < NPEs_.size(); i++) {
		int xPos = NPEs_[i].GetXPos() * tmxMap_.GetTileSize();
		int yPos = NPEs_[i].GetYPos() * tmxMap_.GetTileSize();
		NPEs_[i].Draw(window, xPos, yPos);
	}
}

} // namespace CastleEscape
