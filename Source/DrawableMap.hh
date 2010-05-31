#ifndef DRAWABLEMAP_HH
#define DRAWABLEMAP_HH

#include <SFML/Graphics.hpp>

#include "ScriptableMap.hh"

namespace CastleEscape {

class DrawableMap: public ScriptableMap {
public:
	DrawableMap();
	virtual ~DrawableMap();
	void DrawBase(sf::RenderWindow& window, int xPos, int yPos);
	void DrawTop(sf::RenderWindow& window, int xPos, int yPos);

private:
	sf::Image tileset_;
	void drawLayers(sf::RenderWindow& window, MapVector layers, int xPos,
			int yPos);
	void drawNPEs(sf::RenderWindow& window);
};

} // namespace CastleEscape

#endif // DRAWABLEMAP_HH
