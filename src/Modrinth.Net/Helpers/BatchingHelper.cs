namespace Modrinth.Helpers;

internal static class BatchingHelper
{
    internal static async Task<TResult[]> GetFromBatchesAsync<TResult>(
        IEnumerable<string> ids,
        Func<string[], CancellationToken, Task<TResult[]>> fetchBatchAsync,
        int batchSize = 100,
        CancellationToken cancellationToken = default)
    {
        if (ids == null) throw new ArgumentNullException(nameof(ids));
        if (fetchBatchAsync == null) throw new ArgumentNullException(nameof(fetchBatchAsync));

        var idBatches = ids.Select((value, index) => new { Index = index, Value = value })
                     .GroupBy(x => x.Index / batchSize)
                     .Select(g => g.Select(x => x.Value).ToArray())
                     .ToArray();
        var tasks = idBatches.Select(batch => fetchBatchAsync(batch, cancellationToken));
        var results = await Task.WhenAll(tasks).ConfigureAwait(false);
        
        // Flatten the results from all batches into a single array
        return results.SelectMany(x => x).ToArray();
    }
}