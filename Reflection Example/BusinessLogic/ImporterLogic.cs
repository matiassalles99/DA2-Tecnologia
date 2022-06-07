using System.Reflection;
using Domain;
using IBusinessLogic;
using ImporterInterface;

namespace BusinessLogic;

public class ImporterLogic : IImporterLogic
{
  public List<string> GetAllImporters()
  {
    return GetImporterImplementations().Select(importer => importer.GetName()).ToList();
  }

  public List<Pet> ImportPets(string importerName)
  {
    List<IImporter> importers = GetImporterImplementations();
    IImporter? desiredImplementation = null;

    foreach (IImporter importer in importers)
    {
      if (importer.GetName() == importerName)
      {
        desiredImplementation = importer;
        break;
      }
    }

    if (desiredImplementation == null)
      throw new ResourceNotFoundException("No se pudo encontrar el importador solicitado");

    List<Pet> importedPets = desiredImplementation.ImportPets();
    return importedPets;
  }

  private List<IImporter> GetImporterImplementations()
  {
    List<IImporter> availableImporters = new List<IImporter>();
    string importersPath = "./Importers";
    string[] filePaths = Directory.GetFiles(importersPath);

    foreach (string filePath in filePaths)
    {
      if (filePath.EndsWith(".dll"))
      {
        FileInfo fileInfo = new FileInfo(filePath);
        Assembly assembly = Assembly.LoadFile(fileInfo.FullName);

        foreach (Type type in assembly.GetTypes())
        {
          if (typeof(IImporter).IsAssignableFrom(type) && !type.IsInterface)
          {
            IImporter importer = (IImporter)Activator.CreateInstance(type);
            if (importer != null)
              availableImporters.Add(importer);
          }
        }
      }
    }

    return availableImporters;
  }
}
