﻿using System;

namespace BenchmarkDotNet.Tasks
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class BenchmarkTaskAttribute : Attribute
    {
        public BenchmarkTask Task { get; protected set; }

        public BenchmarkTaskAttribute(
            int processCount = 3,
            BenchmarkMode mode = BenchmarkMode.Throughput,
            BenchmarkPlatform platform = BenchmarkPlatform.HostPlatform,
            BenchmarkJitVersion jitVersion = BenchmarkJitVersion.HostJit,
            BenchmarkFramework framework = BenchmarkFramework.HostFramework,
#if DNX451
            BenchmarkToolchain toolchain = BenchmarkToolchain.DNX451,
#elif CORE
            BenchmarkToolchain toolchain = BenchmarkToolchain.CORE,
#else
            BenchmarkToolchain toolchain = BenchmarkToolchain.Classic,
#endif
            BenchmarkRuntime runtime = BenchmarkRuntime.Clr,
            int warmupIterationCount = 5,
            int targetIterationCount = 10
            )
        {
            Task = new BenchmarkTask(
                processCount,
                new BenchmarkConfiguration(mode, platform, jitVersion, framework, toolchain, runtime, warmupIterationCount, targetIterationCount));
        }
    }
}