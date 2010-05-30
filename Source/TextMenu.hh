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
	sf::Font font_;
	std::vector<std::string> options_;
	uint selectedOption_;
	float defaultStretch_;
	float selectedStretch_;
	bool canMove_;
	bool isFinished_;
	bool canPressZ_;
};

} // namespace CastleEscape

#endif // TEXTMENU_HH
