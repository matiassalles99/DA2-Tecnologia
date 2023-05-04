using System.Reflection;
using Domain;
using IBusinessLogic;
using IImporter;

namespace BusinessLogic;

public class ImporterManager : IImporterManager
{
    // Aca devuelve strings solamente, pero los importadores pueden tambien tener que recibir
    // algun tipo de parametros, por lo que quizas estaría bueno armar una estructura que represente el importador
    // que especifique los parametros necesarios y sus tipos
    public List<string> GetAllImporters()
    {
        return GetImporterImplementations().Select(importer => importer.GetName()).ToList();
    }

    public List<Order> ImportOrders(string importerName)
    {
        List<IImporterInterface> importers = GetImporterImplementations();
        IImporterInterface? desiredImplementation = null;

        foreach (IImporterInterface importer in importers)
        {
            if (importer.GetName() == importerName)
            {
                desiredImplementation = importer;
                break;
            }
        }

        if (desiredImplementation == null)
            throw new Exception("No se pudo encontrar el importador solicitado");

        List<Order> importerOrders = desiredImplementation.ImportOrders();
        return importerOrders;
    }

    private List<IImporterInterface> GetImporterImplementations()
    {
        List<IImporterInterface> availableImporters = new List<IImporterInterface>();
        // Va a estar adentro de WebApi, ya que mira relativo de donde se ejecuta el programa
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
                    if (typeof(IImporterInterface).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        IImporterInterface importer = (IImporterInterface)Activator.CreateInstance(type);
                        if (importer != null)
                            availableImporters.Add(importer);
                    }
                }
            }
        }

        return availableImporters;
    }
}