# polkadot_api_dotnet

## Milestones

- [Milestone 1](https://github.com/usetech-llc/polkadot_api_dotnet/blob/master/doc/demo_milestone1.md)
- [Milestone 2](https://github.com/usetech-llc/polkadot_api_dotnet/blob/master/doc/demo_milestone2.md)

## Requirements

### Windows

- Visual Studio Community 2019 (Pro or Enterprise will also work)
- SDK: .NET Core 2.2

### Linux

- [Dotnet Core 2.2](https://dotnet.microsoft.com/download/linux-package-manager/ubuntu16-04/sdk-current)

## Building

### Windows

Please use Ctrl+Shift+B in Visual Studio :)

### Linux

```
git clone https://github.com/usetech-llc/polkadot_api_dotnet && cd polkadot_api_dotnet
$ dotnet build
$ dotnet test
```

### Docker

```
git clone https://github.com/usetech-llc/polkadot_api_dotnet
$ docker build -t polkanet .
$ docker run -it --rm polkanet /bin/bash
# dotnet build
# dotnet test
```


### Building of documentation

Edit Polkadot.csproj file and add "build;" in the docfx section like here:
```
<PackageReference Include="docfx.console" Version="2.45.1">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
</PackageReference>
```

Now when project is rebuilt, the docuemntation will be updated.

### Special Thanks

We thank Gautam Dhameja for sharing the source code for C-Rust bindings for SR25519 Rust library, which enabled our end-to-end testing and validation of our sr25519 implementations.