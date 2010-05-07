import os
import os.path

APPNAME = "CastleEscape"
VERSION = "0.2.0"
top = "."
out = "Build"

def set_options(opt):
    opt.tool_options('compiler_cxx')
    #opt.add_option("--mode", action="store")

def configure(conf):
    conf.check_tool("compiler_cxx")

def build(bld):
    bld(
            features = ["cxx", "cprogram"],
            source = bld.glob("Source/*.cc") +
                bld.glob("Source/States/*.cc") +
                bld.glob("Source/tinyxml/*.cpp"),
            target = APPNAME,
            vnum = VERSION,
            lib = ["sfml-graphics", "sfml-window", "sfml-system", "v8", "pthread"],
    )
