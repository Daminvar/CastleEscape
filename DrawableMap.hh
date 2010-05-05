#ifndef DRAWABLEMAP_HH
#define DRAWABLEMAP_HH

#include <SFML/Graphics.hpp>

#include "ScriptableMap.hh"

namespace CastleEscape {

class DrawableMap: public ScriptableMap {
public:
	DrawableMap();
	virtual ~DrawableMap();
	void DrawBase(sf::RenderWindow& window, int x, int y);
	void DrawTop(sf::RenderWindow& window, int x, int y);

private:
	sf::Image tileset;
	void drawLayers();
};

} // namespace CastleEscape

#endif // DRAWABLEMAP_HH
