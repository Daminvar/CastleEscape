#include "State.hh"

namespace CastleEscape {

State::State() {
	transparent = false;
}

State::~State() {

}

bool State::IsTransparent() {
	return transparent;
}

} // namespace CastleEscape
