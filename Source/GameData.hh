#ifndef GAMEDATA_HH
#define GAMEDATA_HH

#include <map>
#include <string>

namespace CastleEscape {

class GameData {
public:
	static bool GetFlag(std::string flag);
	static void SetFlag(std::string flag);

private:
	static std::map<std::string, bool> flags;
};

} // namespace CastleEscape

#endif // GAMEDATA_HH
