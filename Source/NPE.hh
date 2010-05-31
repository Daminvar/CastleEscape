#ifndef NPE_HH
#define NPE_HH

#include <iostream>
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
	void Draw(sf::RenderWindow& window, int x, int y);

private:
	int xPos_;
	int yPos_;
	sf::Image texture_;

	friend std::ostream& operator<<(std::ostream& os, const NPE& npe);
};

} // namespace CastleEscape

#endif // NPE_HH
