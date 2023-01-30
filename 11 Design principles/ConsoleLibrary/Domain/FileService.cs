using ConsoleLibrary.Domain.Contract;
using ConsoleLibrary.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleLibrary.Domain;

internal class FileService : BaseStorageService
{
    private readonly string _filename = "type_{id}.json";

    public FileService() { }

    public override BaseDocument GetDocument(string documentId)
    {
        var currentDirectory = Environment.CurrentDirectory;
        var file = _filename.Replace("{id}", documentId);
        if (!File.Exists(Path.Combine(currentDirectory, file))) throw new FileNotFoundException($"Please check that {file} exists!");

        using var stream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.None);
        var converter = new BaseDocumentConverter();
        var options = new JsonSerializerOptions();
        options.Converters.Add(converter);

        return JsonSerializer.Deserialize<BaseDocument>(stream, options);
    }

    class BaseDocumentConverter : JsonConverter<BaseDocument>
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeof(BaseDocument).IsAssignableFrom(typeToConvert);
        }

        public override BaseDocument Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var readerClone = reader;

            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            readerClone.Read();
            if (readerClone.TokenType != JsonTokenType.PropertyName) throw new JsonException();
            if (readerClone.GetString() != "type") throw new JsonException();

            readerClone.Read();
            var documentType = readerClone.GetString();
            BaseDocument document = documentType switch
            {
                "book" => JsonSerializer.Deserialize<Book>(ref reader)!,
                "localizedBook" => JsonSerializer.Deserialize<LocalizedBook>(ref reader)!,
                "patent" => JsonSerializer.Deserialize<Patent>(ref reader)!,
                _ => throw new JsonException()
            };

            return document;
        }

        public override void Write(
            Utf8JsonWriter writer, BaseDocument document, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            // not required
            writer.WriteEndObject();
        }
    }
}
