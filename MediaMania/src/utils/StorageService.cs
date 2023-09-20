using MediaMania.src.obj;
using Newtonsoft.Json;
using System.IO;
using System.Net.NetworkInformation;

namespace MediaMania.src.utils
{
    public static class StorageService
    {

        public static void Save(Library library, FileInfo file)
        {
            string json = JsonConvert.SerializeObject(library, Formatting.Indented);
            File.WriteAllText(file.FullName, json);
            Console.WriteLine("Le fichier a été sauvegardé avec succès dans : " + file.FullName);
            createDataFolder();
            Copy(file.FullName, Path.Combine("..", "..", "..", "data", "library.json"));
        }

        public static void Save(Library library, string nameFile)
        {
            Save(library, new FileInfo(nameFile));
        }

        public static Library? Load(FileInfo file)
        {
            if (file.Exists)
            {
                string json = File.ReadAllText(file.FullName);
                Library? library = JsonConvert.DeserializeObject<Library>(json);
                return library;
            }
            return null;
        }

        public static Library? Load(string path)
        {
            return Load(new FileInfo(path));
        }


        public static void Copy(string sourcePath, string destinationPath)
        {
            FileInfo sourceFile = new FileInfo(sourcePath);
            FileInfo destinationFile = new FileInfo(destinationPath);

            if (sourceFile.Exists)
            {
                sourceFile.CopyTo(destinationFile.FullName, true);
                Console.WriteLine("Le fichier a été copié avec succès vers : " + destinationFile.FullName);
            }
            else
            {
                Console.WriteLine("Le fichier source n'existe pas : " + sourcePath);
            }
        }

        public static void createDataFolder()
        {
            if (!Directory.Exists(Path.Combine("..", "..", "..", "data")))
            {
                Directory.CreateDirectory(Path.Combine("..", "..", "..", "data"));
            }
        }    

    }
}
