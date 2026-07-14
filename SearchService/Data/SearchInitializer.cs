using Typesense;

namespace SearchService.Data;

public static class SearchInitializer
{
    public static async Task EnsureIndexExistsAsync(ITypesenseClient client, CancellationToken cancellationToken = default)
    {
        const string schemaName = "questions";
        const int maxAttempts = 10;
        var delay = TimeSpan.FromSeconds(2);

        for (var attempt = 1; attempt <= maxAttempts; attempt++)
        {
            try
            {
                await client.RetrieveCollection(schemaName);
                Console.WriteLine($"Collection '{schemaName}' has been created already.");
                return;
            }
            catch (TypesenseApiUnprocessableEntityException ex) when (IsNotReadyOrLagging(ex.Message) && attempt < maxAttempts)
            {
                Console.WriteLine($"Typesense not ready yet (attempt {attempt}/{maxAttempts}). Waiting {delay.TotalSeconds:0}s...");
                await Task.Delay(delay, cancellationToken);
            }
            catch (TypesenseApiException ex) when (IsNotReadyOrLagging(ex.Message) && attempt < maxAttempts)
            {
                Console.WriteLine($"Typesense not ready yet (attempt {attempt}/{maxAttempts}). Waiting {delay.TotalSeconds:0}s...");
                await Task.Delay(delay, cancellationToken);
            }
            catch (TypesenseApiNotFoundException)
            {
                Console.WriteLine($"Collection '{schemaName}' does not exist. Creating it now...");

                try
                {
                    var schema = new Schema(schemaName,
                    [
                        new("id", FieldType.String),
                        new("title", FieldType.String),
                        new("content", FieldType.String),
                        new("tags", FieldType.StringArray),
                        new("createdAt", FieldType.Int64),
                        new("hasAcceptedAnswer", FieldType.Bool),
                        new("answersCount", FieldType.Int32)
                    ])
                    {
                        DefaultSortingField = "createdAt"
                    };

                    await client.CreateCollection(schema);
                    Console.WriteLine($"Collection '{schemaName}' has been created successfully.");
                    return;
                }
                catch (TypesenseApiUnprocessableEntityException ex) when (IsNotReadyOrLagging(ex.Message) && attempt < maxAttempts)
                {
                    Console.WriteLine($"Typesense not ready yet (attempt {attempt}/{maxAttempts}). Waiting {delay.TotalSeconds:0}s...");
                    await Task.Delay(delay, cancellationToken);
                }
                catch (TypesenseApiException ex) when (IsNotReadyOrLagging(ex.Message) && attempt < maxAttempts)
                {
                    Console.WriteLine($"Typesense not ready yet (attempt {attempt}/{maxAttempts}). Waiting {delay.TotalSeconds:0}s...");
                    await Task.Delay(delay, cancellationToken);
                }
            }
        }

        throw new TimeoutException("Typesense did not become ready in time to ensure the search collection exists.");
    }

    private static bool IsNotReadyOrLagging(string? message)
    {
        return !string.IsNullOrWhiteSpace(message)
            && message.Contains("Not Ready or Lagging", StringComparison.OrdinalIgnoreCase);
    }
}
