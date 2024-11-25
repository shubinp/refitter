using Refitter.Core;
using MSBuildTask = Microsoft.Build.Utilities.Task;

namespace Refitter.MSBuild;

public class RefitterGenerateTask : MSBuildTask
{
    public override bool Execute()
    {
        var path = Path.GetDirectoryName(this.BuildEngine.ProjectFileOfTaskNode)!;

        // Search for .refitter files under path
        var files = Directory.GetFiles(
            path,
            "*.refitter",
            SearchOption.AllDirectories);

        Log.LogCommandLine($"Found {files.Length} .refitter files");

        foreach (var file in files)
        {
            Log.LogCommandLine($"Processing {file}");

            var json = File.ReadAllText(file);
            var settings = TryDeserialize(json);
            if (settings is null)
            {
                Log.LogError($"Failed to deserialize {file}");
                continue;
            }

            try
            {
                if (!settings.OpenApiPath.StartsWith("http", StringComparison.OrdinalIgnoreCase) &&
                    !File.Exists(settings.OpenApiPath))
                {
                    settings.OpenApiPath = Path.Combine(
                        Path.GetDirectoryName(path)!,
                        settings.OpenApiPath);
                }

                var generator = RefitGenerator.CreateAsync(settings).GetAwaiter().GetResult();
                var refit = generator.Generate();

                var generatedPath = Path.ChangeExtension(file, ".generated.cs");
                File.WriteAllText(generatedPath, refit);

                Log.LogCommandLine($"Generated {generatedPath}");
            }
            catch (Exception e)
            {
                Log.LogError($"Failed to generate refit code for {file}: {e}");
            }
        }

        return true;
    }

    private RefitGeneratorSettings? TryDeserialize(string json)
    {
        try
        {
            return Serializer.Deserialize<RefitGeneratorSettings>(json);
        }
        catch (Exception e)
        {
            Log.LogErrorFromException(e);
            return null;
        }
    }
}
