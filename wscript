import os
import os.path

APPNAME = "CastleEscape"
top = "."
out = "build"

def set_options(opt):
    opt.tool_options('compiler_cxx')
    #opt.add_option("--mode", action="store")

def configure(conf):
    conf.check_tool("compiler_cxx")

def build(bld):
    bld(
            features = ["cxx", "cprogram"],
            source = bld.glob("*.cc") + bld.glob("States/*.cc"),
            target = "CastleEscape",
            vnum = "1.0",
            lib = ["sfml-graphics", "sfml-window", "sfml-system"],
    )
    def copy_content(task):
        os.symlink(os.path.join(bld.srcnode.abspath(), "Content"),
                   os.path.join(bld.srcnode.abspath(bld.env), "Content"))
    bld(rule=copy_content)