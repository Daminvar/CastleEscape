#ifndef MAINMENU_HH
#define MAINMENU_HH

#include <memory>

#include <SFML/Graphics.hpp>

#include "State.hh"
#include "TextMenu.hh"

namespace CastleEscape {

class MainMenu: public State {
public:
	MainMenu();
	virtual ~MainMenu();
	void Pause();
	void Resume();
	void Update(const sf::Clock& clock, const sf::Input& input);
	void Draw(sf::RenderWindow& window);

private:
	sf::Image background;
	sf::Sprite bgSprite;
	std::vector<std::string> options;
	std::auto_ptr<TextMenu> menu;
};

} // namespace CastleEscape

#endif // MAINMENU_HH
