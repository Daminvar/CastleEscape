#ifndef TESTSTATE_HH
#define TESTSTATE_HH

#include <SFML/Graphics.hpp>
#include "State.hh"

namespace CastleEscape {

class TestState: public State {
public:
	TestState();
	virtual ~TestState();
	virtual void Pause();
	virtual void Resume();
	virtual void Update(const sf::Clock& clock);
	virtual void Draw(sf::RenderWindow& window);

private:
	sf::Image background;
	sf::Sprite bgSprite;
};

} // namespace CastleEscape

#endif // TESTSTATE_HH
