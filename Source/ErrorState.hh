#ifndef ERRORSTATE_HH
#define ERRORSTATE_HH

#include <string>

#include <SFML/Graphics.hpp>

#include "State.hh"

namespace CastleEscape {

class ErrorState: public State {
public:
	ErrorState(std::string error);
	virtual ~ErrorState();
	void Pause();
	void Resume();
	void Update(const sf::Clock& clock, const sf::Input& input);
	void Draw(sf::RenderWindow& window);

private:
	sf::Image background_;
	sf::Sprite bgSprite_;
	sf::Font errorFont_;
	sf::String errorString_;
	std::string error_;
	bool canPressEnter_;
};

} // namespace CastleEscape

#endif // ERRORSTATE_HH
