#ifndef MAINMENU_HH
#define MAINMENU_HH

#include <SFML/Graphics.hpp>
#include "State.hh"
#include "TextMenu.hh"

namespace CastleEscape {

class MainMenu: public State {
public:
	MainMenu();
	virtual ~MainMenu();
	virtual void Pause();
	virtual void Resume();
	virtual void Update(const sf::Clock& clock);
	virtual void Draw(sf::RenderWindow& window);

private:
	sf::Image background;
	sf::Sprite bgSprite;
	TextMenu* menu;
};

} // namespace CastleEscape

#endif // MAINMENU_HH
