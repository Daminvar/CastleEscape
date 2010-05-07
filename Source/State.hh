#ifndef STATE_HH
#define STATE_HH

#include <SFML/Graphics.hpp>

namespace CastleEscape {

class State {
protected:
	bool transparent;

public:
	State();
	virtual ~State();
	bool IsTransparent();

	virtual void Pause() = 0;
	virtual void Resume() = 0;
	virtual void Update(const sf::Clock& clock, const sf::Input& input) = 0;
	virtual void Draw(sf::RenderWindow& window) = 0;
};

} // namespace CastleEscape

#endif // STATE_HH
