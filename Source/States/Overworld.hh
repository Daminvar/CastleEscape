#ifndef OVERWORLD_HH
#define OVERWORLD_HH

#include <SFML/Graphics.hpp>

#include "../DrawableMap.hh"
#include "../State.hh"

namespace CastleEscape {

class Overworld: public State {
public:
	Overworld();
	virtual ~Overworld();
	void Pause();
	void Resume();
	void Update(const sf::Clock& clock, const sf::Input& input);
	void Draw(sf::RenderWindow& window);

private:
	DrawableMap map;
};

} // namespace CastleEscape

#endif // OVERWORLD_HH
