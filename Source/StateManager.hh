#ifndef STATEMANAGER_HH
#define STATEMANAGER_HH

#include <boost/ptr_container/ptr_vector.hpp>
#include <SFML/Graphics.hpp>

#include "State.hh"

namespace CastleEscape {

class StateManager {
public:
	static void Initialize();
	static int GetStackSize();
	static void Stop();
	static void Continue();
	static void Update(const sf::Clock& clock, const sf::Input& input);
	static void Draw(sf::RenderWindow& window);
	static void PushState(State* newState);
	static void PopState();
	static void PopAllStates();
	static bool IsEmpty();

private:
	static boost::ptr_vector<State> states;
	static bool running;
};

} // namespace CastleEscape

#endif // STATEMANAGER_HH
