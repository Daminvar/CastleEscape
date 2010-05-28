#ifndef NPE_HH
#define NPE_HH

#include <string>

#include <SFML/Graphics.hpp>

namespace CastleEscape {

class NPE {
public:
	NPE();
	int GetXPos();
	int GetYPos();
	void SetPosition(int x, int y);
	void SetTexture(std::string textureName);

private:
	int xPos;
	int yPos;
	sf::Image texture;
};

} // namespace CastleEscape

#endif // NPE_HH
