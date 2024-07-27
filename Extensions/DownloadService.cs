using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBarDemo.Extensions;
public static class DownloadService
{
    public static async Task DownloadFileAsync(this HttpClient client, string url, string destinationPath, IProgress<float> progress)
    {
        using var response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        using var stream = await response.Content.ReadAsStreamAsync();
        using var fileStream = File.Create(destinationPath);

        var buffer = new byte[8192];
        var bytesRead = 0L;
        var totalBytes = response.Content.Headers.ContentLength ?? -1L;

        while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            await fileStream.WriteAsync(buffer, 0, (int)bytesRead);

            if (totalBytes > 0)
            {
                var percentComplete = (float)fileStream.Length / totalBytes;
                progress.Report(percentComplete);
            }
        }
    }

}
