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
	sf::Image tileset;
	void drawLayers();
};

} // namespace CastleEscape

#endif // DRAWABLEMAP_HH
