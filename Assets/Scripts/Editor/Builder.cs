using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class Builder
{
    [MenuItem("Build/Build WebGL")]
    static void Build()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/SampleScene.unity" };
        buildPlayerOptions.locationPathName = "Build/";
        buildPlayerOptions.target = BuildTarget.WebGL;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.LogFormat("Build succeeded: {0}bytes, {1}s", summary.totalSize, summary.totalTime.TotalSeconds);
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed");
            Debug.LogError(report);
        }
    }
}
