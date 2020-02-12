using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PathLen {
    class Program {
        static void Main(string[] args) {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        static void RunOptions(Options opts) {
            CheckPath(opts.RootPath, opts.Path, opts.MaxPathLen, opts.IgnoreDirectories);
        }

        static void HandleParseError(IEnumerable<Error> errs) {
            Console.WriteLine("can't parse params");
        }

        static void CheckPath(string rootPath, string path, int maxPathLen, IEnumerable<string> ignoreDirectories) {
            rootPath = rootPath.TrimEnd(Path.DirectorySeparatorChar);
            var files = GetFiles(path, new HashSet<string>(ignoreDirectories, StringComparer.OrdinalIgnoreCase));
            int pathLength = path.Length;
            int rootPathLength = rootPath.Length;
            int totalCount = 0;
            int errorCount = 0;
            foreach (var file in files) {
                totalCount++;
                int len = file.FullName.Length - pathLength + rootPathLength;
                if (len <= maxPathLen)
                    continue;
                errorCount++;
                Console.WriteLine($"{len} : {file.FullName}");
            }
            Console.WriteLine($"Files: {totalCount}. Wrong files: {errorCount}");
        }
        static IEnumerable<FileInfo> GetFiles(string path, HashSet<string> ignoreDirectories) {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (ignoreDirectories.Contains(directoryInfo.Name))
                yield break;
            foreach (var fileInfo in directoryInfo.GetFiles())
                yield return fileInfo;
            foreach (var directory in directoryInfo.GetDirectories()) {
                foreach (var fileInfo in GetFiles(directory.FullName, ignoreDirectories))
                    yield return fileInfo;
            }
        }
    }
}
