using CommandLine;
using System.Collections.Generic;

namespace PathLen {
    class Options {

        [Option('i', "ignore", Required = true, HelpText = "Folders to ignore")]
        public IEnumerable<string> IgnoreDirectories { get; set; }


        [Option('p', "path", Required = true, HelpText = "Path to project root")]
        public string Path { get; set; }

        [Option('m', "max", Required = false, HelpText = "Max path size, 260 by default")]
        public int MaxPathLen { get; set; } = 260;

        [Option('r', "root", Required = true, HelpText = "Root path")]
        public string RootPath { get; set; }
    }
}
