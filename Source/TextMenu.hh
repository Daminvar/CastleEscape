#ifndef TEXTMENU_HH
#define TEXTMENU_HH

#include <string>
#include <vector>

#include <SFML/Graphics.hpp>

namespace CastleEscape {

class TextMenu {
public:
	TextMenu(const std::vector<std::string>& options, const sf::Font& font);
	bool IsFinished();
	void Restart();
	uint GetSelectedOption();
	std::vector<std::string> GetOptions();
	std::vector<std::string> SetOptions(std::vector<std::string> options);
	void Update(const sf::Clock& clock, const sf::Input& input);
	void Draw(sf::RenderWindow& window, int x, int y, const sf::Color& color);

private:
	sf::Font font;
	std::vector<std::string> options;
	uint selectedOption;
	float defaultStretch;
	float selectedStretch;
	bool canMove;
	bool isFinished;
	bool canPressZ;
};

} // namespace CastleEscape

#endif // TEXTMENU_HH
