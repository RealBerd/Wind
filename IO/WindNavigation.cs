using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class WindNavigation
    {
        public static DirectoryContent GetDirectoryContentByAddress(string address)
        {
            if (Directory.Exists(address))
            {
                var dirs = Directory.GetDirectories(address);
                var files = Directory.GetFiles(address);

                var dirContent = new DirectoryContent();
                foreach (var d in dirs)
                {
                    dirContent.Direcctories.Add(PrepareDirectory(d, address));
                }

                foreach (var f in files)
                {
                    dirContent.Files.Add(PrepareFile(f, address));
                }

                dirContent.DebugMessage = "Directory";

                return dirContent;
            }
            return new DirectoryContent()
            {
                DebugMessage = "Nothing yet"
            };
            
        }

        private static WindFile PrepareFile(string Filename, string Directory)
        {
            var dotIndex = Filename.LastIndexOf('.');
            var dashIndex = Filename.LastIndexOf('\\');
            return new WindFile()
            {
                Name = Filename.Substring(Math.Max(dashIndex+1, 0)),
                Ext = Filename.Substring(Math.Max(dotIndex, 0)),
                bytes = new FileInfo(Filename).Length
            };
        }

        private static WindDirectory PrepareDirectory(string Dirname, string Directory)
        {
            var dashIndex = Dirname.LastIndexOf('\\');
            return new WindDirectory()
            {
                Name = Dirname.Substring(Math.Max(dashIndex+1, 0))
            };
        }

    }

    public class DirectoryContent
    {
        public string DebugMessage;

        public List<WindFile> Files = new List<WindFile>();
        public List<WindDirectory> Direcctories = new List<WindDirectory>();
    }

    public class WindFile
    {
        public string Name;
        public string Ext;

        private bool initialized = false;
        public long bytes;
    }


    public class WindDirectory
    {
        public string Name;

        private bool initialized = false;
        public long bytes; // ???
    }


    // ??
    public interface IDirectoryItem
    {

    }

    

}
