#include "GameData.hh"

#include <map>
#include <string>
using namespace std;

namespace CastleEscape {

map<string, bool> GameData::flags;

bool GameData::GetFlag(string name) {
	if (flags.find(name) != flags.end()) {
		return flags[name];
	}
	return false;
}

void GameData::SetFlag(string name) {
	flags[name] = true;
}

} // namespace CastleEscape
