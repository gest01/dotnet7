# Performance Improvements in .NET 7

- https://devblogs.microsoft.com/dotnet/announcing-dotnet-7/

## PGO

- https://petabridge.com/blog/dotnet7-pgo-performance-improvements/
- https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6/#jit
- https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/#pgo
- https://github.com/dotnet/runtime/blob/main/docs/design/features/DynamicPgo-InstrumentedTiers.md

### Runtime configuration options for compilation

- https://learn.microsoft.com/en-us/dotnet/core/runtime-config/compilation

**Profile-guided optimization**

This setting enables dynamic or tiered profile-guided optimization (PGO) in .NET 6 and later versions.

```xml
<PropertyGroup>
    <TieredPGO>true</TieredPGO>
</PropertyGroup>
```

**Quick JIT for loops**

Enabling quick JIT for loops may improve startup performance.
However, long-running loops can get stuck in less-optimized code for long periods.
If quick JIT is disabled, this setting has no effect.
If you omit this setting, quick JIT is not used for methods that contain loops. This is equivalent to setting the value to **false**

```xml
<PropertyGroup>
    <TieredCompilationQuickJitForLoops>true</TieredCompilationQuickJitForLoops>
</PropertyGroup>
```

**Tiered compilation**

In .NET Core 3.0 and later, tiered compilation is enabled by default.

```xml
<PropertyGroup>
    <TieredCompilation>true</TieredCompilation>
</PropertyGroup>
```

**Quick JIT**

In .NET Core 3.0 and later, quick JIT is enabled by default.

```xml
<PropertyGroup>
    <TieredCompilationQuickJit>true</TieredCompilationQuickJit>
</PropertyGroup>
```

**Environment Variable Docker**

```docker
ENV DOTNET_ReadyToRun=0
ENV DOTNET_TieredPGO=1
ENV DOTNET_TC_QuickJitForLoops=1
```

**Environment Variable Powershell**

```powershell
$env:DOTNET_TieredPGO="1"
$env:DOTNET_TieredPGO="0"
```

**Environment Variable Bash**

```bash
export DOTNET_TieredPGO=1
export DOTNET_TieredPGO=0
```

**Environment Variable CMD**

```cmd
set DOTNET_TieredPGO=1
set DOTNET_TieredPGO=0
```

---

## Native AOT

- https://devblogs.microsoft.com/dotnet/performance_improvements_in_net_7/#native-aot
- https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8#native-aot
- https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/

**csproj**

```xml
<PropertyGroup>
    <PublishAot>true</PublishAot>
</PropertyGroup>
```

```sh
dotnet publish -r win-x64 -c Release
dotnet publish -r linux-arm64 -c Release
```

**Limitations of native AOT deployment :** https://learn.microsoft.com/en-us/dotnet/core/deploying/native-aot/#limitations-of-native-aot-deployment

---

## Demo JIT

```
!dumpheap -type MyApp
!dumpmt -md 00007fd43716c770 (= MT)
!dumpmd 00007FD43716C730 (= MD => MethodDesc(Method Descriptor))
!dumpil 00007FD43716C730 (<Method Descriptor>)

u 00007fd4370941c0 (CodeAddr)
```

## Demo PGO

```sh
$env:DOTNET_TieredPGO="1"
dotnet run -c Release
```

## Demo Native AOT

```sh
cd NativeAotConsole
docker build -f Dockerfile --force-rm -t test/nativeaotcli .

cd NativeAotWeb
docker build -f DockerfileFull --force-rm -t test/nativeaotweb .

docker run --rm -it test/nativeaotcli
docker run --rm -it -p 8082:80 test/nativeaotweb

docker container list
docker exec -it AA /bin/bash

ps aux
file ./NativeAotConsole
ldd ./NativeAotConsole

```
