using Azure;
using ProjectDataCtx;
using System.Text.Json;

namespace Host
{
    public static class DataSetupHelpers
    {
        private const string SeedDataSearchName = "ProjectData*.json";
        public const string SeedFileSubDirectory = "seedData";

        public static async Task<int> SeedDatabaseIfNoBooksAsync(this EfDataCtx context, string dataDirectory)
        {
            var dataNum = context.ProjectData.Count();
            if (dataNum == 0)
            {
                //the database is empty so we fill it from a json file
                var projectData = BookJsonLoader.LoadBooks(Path.Combine(dataDirectory, SeedFileSubDirectory),
                    SeedDataSearchName).ToList();
                context.Books.AddRange(books);
                await context.SaveChangesAsync();

                //We add this separately so that it has the highest Id. That will make it appear at the top of the default list
                context.Books.Add(SpecialBook.CreateSpecialBook());
                await context.SaveChangesAsync();
                numBooks = books.Count + 1;
            }

            return numBooks;
        }

    }

    public static class ProjectDataJsonLoader
    {
        public static IEnumerable<ProjectData> LoadData(string fileDir, string fileSearchString)
        {
            var filePath = GetJsonFilePath(fileDir, fileSearchString);
            var jsonDecoded = JsonSerializer.Deserialize<ICollection<BookInfoJson>>(File.ReadAllText(filePath));

            var authorDict = new Dictionary<string, Author>();
            var tagDict = new Dictionary<string, Tag>();
            foreach (var bookInfoJson in jsonDecoded)
            {
                foreach (var author in bookInfoJson.authors)
                {
                    if (!authorDict.ContainsKey(author))
                        authorDict[author] = new Author { Name = author };
                }
                foreach (var category in bookInfoJson.categories)
                {
                    if (!tagDict.ContainsKey(category))
                        tagDict[category] = new Tag { TagId = category };
                }

            }

            return jsonDecoded.Select(x => CreateBookWithRefs(x, authorDict, tagDict));
        }
        private static string GetJsonFilePath(string fileDir, string searchPattern)
        {
            var fileList = Directory.GetFiles(fileDir, searchPattern);

            if (fileList.Length == 0)
                throw new FileNotFoundException(
                    $"Could not find a file with the search name of {searchPattern} in directory {fileDir}");

            //If there are many then we take the most recent
            return fileList.ToList().OrderBy(x => x).Last();
        }
    }
}
